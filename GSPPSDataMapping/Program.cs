using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

using GSPPSDataMapping.DET;
using GSPPSDataMapping.Tables;
using GSPPSDataMapping.Utilities;

namespace GSPPSDataMapping
{
    /// <summary>
    /// The main class
    ///     Contains all methods for performing parsing functions some oracle tables.
    ///Only ARINVT operations for now.
    /// </summary>
    class Program
    {
        private static int sleeptime = 20;
        //ARINVT: class used to do operations relating to the ARINVT table
        private static IIQMSTable arinvtTable;

        /// <summary>
        /// the main class: Application startup
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                //For some reason, console is editable, it shoudn't be
                DisableConsoleQuickEdit.Go();

                //Extract the variables from specified xml file
                XmlDocument doc = new XmlDocument();
                doc.Load("ConfigFiles/DataPull.xml");

                string GSPPSSourceFolder = doc.GetElementsByTagName("GSPPSSourceFolder")[0].InnerText.Trim().ToUpper();
                string CSVFolder = doc.GetElementsByTagName("CSVFolder")[0].InnerText.Trim().ToUpper();
                string sourceFile = (args.Length > 0 && args[0].Trim().ToUpper() == "INCREMENT") ? doc.GetElementsByTagName("sourceFileINCREMENT")[0].InnerText : doc.GetElementsByTagName("sourceFileFULL")[0].InnerText;

                //Remove the csvs for a fresh install
                //DeleteDirectoryContents(SpecsFolder, false);

                //Establish connection with IQMS Oracle Database
                TryConnectionToIQMSDatabase();
                //Connection is successful if this is reached.


                Stopwatch watch = Stopwatch.StartNew();

                //Read the spec file, and create CSVs
                //1) Get temporary table ready for data
                arinvtTable = new ARINVT(CSVFolder, true);

                ParseSpecFile(GSPPSSourceFolder, sourceFile, CSVFolder);

                watch.Stop();
                TimeSpan t = TimeSpan.FromMilliseconds(watch.ElapsedMilliseconds);

                string timeSpanDisplay = string.Format(" {0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                                        t.Hours,
                                        t.Minutes,
                                        t.Seconds,
                                        t.Milliseconds);

                Console.WriteLine(timeSpanDisplay);

                Console.WriteLine(" Sleep for " + sleeptime + " seconds.");
                Thread.Sleep(sleeptime * 1000);
            }
            catch (Exception ex)
            {
                Logger.log(ex.Message + "\n" + ex.StackTrace);
                Console.WriteLine(" ERROR: " + ex.Message);
                Thread.Sleep(14000);
            }
        }

        /// <summary>
        /// Trys to quickly establish a connection with IQMS database.
        /// </summary>
        private static void TryConnectionToIQMSDatabase()
        {
            using (OracleConnection dbO = OracleConnectionFactory.IQMSConnection)
            {
                Console.WriteLine(" Connected to Oracle Database " + dbO.ServerVersion);
            }
        }

        /// <summary>ReadDownloadedSpecFile method does the following:
        /// <list type="bullet">
        /// <item><description>Retrieve specs from the spec file (already downloaded)</description></item>
        /// <item><description>For each spec, try to process the spec via the ARINVT rules</description></item>
        /// <item><description>Insert parsed spec line into staging table using SQLLoader</description></item>
        /// <item><description>try insert staging (tempARINVT_for_GSPPS) values into ARINVT</description></item>
        /// </list>
        /// </summary>
        private static void ParseSpecFile(string GSPPSSourceFolder, 
                                          string sourceFile, string SpecsFolder)
        {            
            Console.WriteLine("\n Parsing... ");

            #region READ LINE BY LINE
            //*
            FileInfo fStream = new FileInfo(GSPPSSourceFolder + sourceFile);
            long fileLength = fStream.Length;

            string rawLine = String.Empty;
            string currentServicePartNumber = "";
            string packedServicePart = "";

            SPECIFICATION pkgSpec = null;
            List<DETAILS> currentDetails = new List<DETAILS>();
            List<REMARKCODE> currentRemarkCode = new List<REMARKCODE>();
            List<BOM> currentBOM = new List<BOM>();
            REMARK rmk = null;
            string rawSpec = "";
            int index = 0; //keep track of current spec
                           //int lineCounter = 0; //keep track of current line in file

            int rawLineLength = 0;
            using (StreamReader sr = new StreamReader(GSPPSSourceFolder + sourceFile))
            {
                while (sr.EndOfStream == false)
                {
                    rawLine = sr.ReadLine();
                    rawLineLength += rawLine.Length;
                    //calculate progress
                    //keep track of current stream position
                    double percent = Math.Round((rawLineLength) * 100f / fileLength, 2);

                    #region DATA
                    if (rawLine.StartsWith("HDR")) //HEADER: Reset the current Service Part Number
                    {
                        pkgSpec = null;
                        rmk = null;
                        currentDetails.Clear(); currentRemarkCode.Clear(); currentBOM.Clear();
                        currentServicePartNumber = "";
                        packedServicePart = "";
                        rawSpec = "";
                    }
                    else if (rawLine.StartsWith("TRL")) //TRAILER: Reset the current Service Part Number
                    {
                        if (pkgSpec != null)
                        {
                            index = index + 1;

                            processSpec(SpecsFolder, pkgSpec, percent, currentDetails, 
                                        currentBOM, currentRemarkCode, rmk, rawSpec);

                            arinvtTable.InsertIntoDataFile(true);

                            ShowProgress(pkgSpec, percent);
                        }
                        pkgSpec = null;
                        rmk = null;
                        currentDetails.Clear(); currentRemarkCode.Clear(); currentBOM.Clear();
                        currentServicePartNumber = "";
                        packedServicePart = "";
                        rawSpec = "";
                    }
                    else if (rawLine.StartsWith("DET1")) ///HEADER SPECIFICATION
                    {
                        if (pkgSpec != null)
                        {
                            index = index + 1;

                            processSpec(SpecsFolder, pkgSpec, percent, currentDetails, 
                                        currentBOM, currentRemarkCode, rmk, rawSpec);

                            arinvtTable.InsertIntoDataFile(false);

                            ShowProgress(pkgSpec, percent);
                        }
                        currentDetails.Clear(); currentRemarkCode.Clear(); currentBOM.Clear();
                        currentServicePartNumber = "";
                        packedServicePart = "";
                        rawSpec = "";

                        pkgSpec = new SPECIFICATION(rawLine);
                        rawSpec += (rawLine + System.Environment.NewLine);

                        currentServicePartNumber = pkgSpec.ServicePartNo;
                        packedServicePart = pkgSpec.PackedServicePart;
                    }
                    else if (rawLine.StartsWith("DET2") && currentServicePartNumber != "") //DETAIL/LEVEL
                    {
                        DETAILS pkgLevel = new DETAILS(rawLine, currentServicePartNumber, pkgSpec);
                        rawSpec += (rawLine + System.Environment.NewLine);
                        currentDetails.Add(pkgLevel);
                    }
                    #endregion

                    #region Others
                    /*
                    else if (rawLine.StartsWith("DET3") && currentServicePartNumber != "") //REMARK CODE
                    {
                        REMARKCODE rmkCode = new REMARKCODE(rawLine, currentServicePartNumber);
                        rawSpec += (rawLine + System.Environment.NewLine);
                        currentRemarkCode.Add(rmkCode);
                    }
                    else if (rawLine.StartsWith("DET4") && currentServicePartNumber != "") //REMARK
                    {
                        rmk = new REMARK(rawLine, currentServicePartNumber);
                        rawSpec += (rawLine + System.Environment.NewLine);

                    }
                    else if (rawLine.StartsWith("DET5") && currentServicePartNumber != "") //BOM
                    {
                        BOM bom = new BOM(rawLine, currentServicePartNumber);
                        rawSpec += (rawLine + System.Environment.NewLine);

                        currentBOM.Add(bom);
                    }
                    //*/
                    #endregion
                }
            }
            //*/
            #endregion

            //in case there are data items not inserted into the sql loader data file
            arinvtTable.InsertIntoDataFile(true);

            //SQLLoader.RunControlFile(arinvtTable);
            SQLLoader.RunControlFile(arinvtTable.GetControlFilePath(), 
                arinvtTable.GetSqlLoaderTableName(), arinvtTable.TotalItems());

            arinvtTable.StageIntoRealTable();
        }

        private static void ShowProgress(SPECIFICATION pkgSpec, double percent)
        {
            //if ((percent % 1) == 0)
            {
                Console.Write("\r " + (Math.Floor(percent) + "% : " + pkgSpec.ServicePartNo + " ").PadRight(40));
            }
        }

        /// <summary>
        /// processSpec method: For each spec, try to process the spec via the ARINVT rules
        /// </summary>
        private static string processSpec(string SpecsFolder, SPECIFICATION pkgSpec, 
                        double percent, List<DETAILS> currentDetails, List<BOM> currentBOM, 
                        List<REMARKCODE> currentRemarkCode, REMARK rmk, string rawSpec)
        {
            //if (pkgSpec.isB969F())
            {
                //Create CSV
                Directory.CreateDirectory(SpecsFolder);

                arinvtTable.process(SpecsFolder, pkgSpec, currentDetails, currentBOM, currentRemarkCode, rmk, rawSpec);
            }

            return pkgSpec.ServicePartNo;
        }

        private static void DeleteDirectoryContents(string path, bool removeDirectory)
        {
            if (Directory.Exists(path))
            {
                //Delete all files from the Directory
                foreach (string file in Directory.GetFiles(path))
                {
                    File.Delete(file);
                }
                //Delete all child Directories
                foreach (string directory in Directory.GetDirectories(path))
                {
                    DeleteDirectoryContents(directory, true);
                }

                if (removeDirectory)
                {
                    //Delete a Directory
                    Directory.Delete(path);
                }
            }
        }
        

        /*
        private static DataTable GetSchemaTable(string tableName)
        {
            DataSet ds = new DataSet();
            
            using (OracleConnection dbO = OracleConnectionFactory.IQMSConnection)
            {
                using (OracleCommand select = new OracleCommand(
                    "SELECT table_name, column_name, data_type, data_length " +
                        " FROM USER_TAB_COLUMNS " +
                        " WHERE table_name = '" + tableName + "' ORDER by column_id ", dbO))
                {
                    select.CommandType = CommandType.Text;
                    select.CommandTimeout = 0;
                    using (OracleDataAdapter adapter = new OracleDataAdapter(select))
                    {
                        adapter.Fill(ds, tableName);

                        return ds.Tables[tableName];
                    }
                }
            }
        }
        */
    }
}
