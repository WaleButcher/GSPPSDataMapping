using GSPPSDataMapping.DET;
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
using GSPPSDataMapping.Tables;

namespace GSPPSDataMapping
{
    class Program
    {
        private static Int64 totalParts = 0;

        //static void Main(string[] args)
        static void Main(string[] args)
        {
            try
            {
                //For some reason, console is editable, it shound't be
                DisableConsoleQuickEdit.Go();

                //Step 1. Get File from HQEDI
                string sourceFolder, sourceFile, SpecsFolder;
                ExtractSourceDocuments(args, out sourceFolder, out sourceFile, out SpecsFolder);

                //DeleteDirectoryContents(SpecsFolder, false);

                //Step 2. Establish connection with IMQS Oracle Server
                TryConnectionToIQMSDatabase();

                //Step 3a:  read the spec file, and create CSVs
                //Step 3b:  insert into the provided Database
                ReadDownloadedSpecFile(sourceFolder, sourceFile, SpecsFolder);

                //Connection is successful if this is reached.
                Thread.Sleep(20000);
            }
            catch (Exception ex)
            {
                Logger.log(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private static void ExtractSourceDocuments(string[] args, out string sourceFolder, out string sourceFile, out string SpecsFolder)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("DataPull.xml");

            XmlNode node = doc.GetElementsByTagName("sourceFolder")[0];
            sourceFolder = node.InnerText;
            node = (args.Length > 0 && args[0].Trim().ToUpper() == "INCREMENT") ? doc.GetElementsByTagName("sourceFileINCREMENT")[0] : doc.GetElementsByTagName("sourceFileFULL")[0];
            sourceFile = node.InnerText;
            SpecsFolder = doc.GetElementsByTagName("SpecSubFolder")[0].InnerText.Trim().ToUpper();
        }

        private static void TryConnectionToIQMSDatabase()
        {
            using (OracleConnection dbO = OracleConnectionFactory.IQMSConnection)
            {
                Console.WriteLine("Connected to Oracle Database {0}", dbO.ServerVersion);
            }
        }

        private static void ReadDownloadedSpecFile(string sourceFolder, string sourceFile, string SpecsFolder)
        {
            //List<Task<string>> tasks = new List<Task<string>>();

            // Read the file and display it line by line.  
            //FileInfo fileInfo = new FileInfo(sourceFolder + sourceFile);
            
            //*/
            Stopwatch watch = Stopwatch.StartNew();

            Console.WriteLine("\n Parsing... ");

            #region READ IN CHUNKS
            /*
            using (FileStream fStream = new FileStream(sourceFolder + sourceFile, FileMode.Open, FileAccess.Read))
            {
                long totalBytes = fStream.Length;
                long fileLength = totalBytes;

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

                int nBytes = 1000;
                int chunkSize = 40 * 1024 * 1024;

                long lastLocationSeeked = 0;
                byte[] ByteArray = new byte[nBytes];
                byte[] AnotherByteArray = new byte[chunkSize + 1000];
                
                while (lastLocationSeeked < fileLength)
                {
                    string s = "";
                    fStream.Seek(Math.Min(chunkSize + lastLocationSeeked, fileLength), SeekOrigin.Begin);
                    //Read 1000 bytes into an array from the specified file.
                    int nBytesRead = fStream.Read(ByteArray, 0, nBytes);
                    s = Encoding.ASCII.GetString(ByteArray, 0, nBytesRead);

                    int seekOffset = 0;

                    for (int i = 0; i < ByteArray.Length; i++)
                    {
                        if ((char)ByteArray[i] == '\n')
                        {
                            seekOffset = i;
                            break;
                        }
                    }

                    fStream.Seek(lastLocationSeeked, SeekOrigin.Begin);

                    long newSeekLocation = Math.Min(chunkSize + seekOffset + lastLocationSeeked, fileLength);

                    nBytesRead = fStream.Read(AnotherByteArray, 0, chunkSize + seekOffset);
                    s = Encoding.ASCII.GetString(AnotherByteArray, 0, nBytesRead);

                    int rawLineLength = 0;
                    string[] arrString = s.Split('\n');
                    for (int i = 0; i < arrString.Length; i++)
                    {
                        rawLine = arrString[i];
                        rawLineLength += rawLine.Length;
                        //calculate progress
                        //keep track of current stream position
                        double percent = Math.Round((lastLocationSeeked + rawLineLength) * 100f / totalBytes, 2);

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
                                ShowProgress(pkgSpec, percent);

                                tasks.Add(processSpec(SpecsFolder, pkgSpec, currentDetails, currentBOM, currentRemarkCode, rmk, rawSpec));
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
                                ShowProgress(pkgSpec, percent);

                                tasks.Add(processSpec(SpecsFolder, pkgSpec, currentDetails, currentBOM, currentRemarkCode, rmk, rawSpec));
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
                            DETAILS pkgLevel = new DETAILS(rawLine, currentServicePartNumber);
                            rawSpec += (rawLine + System.Environment.NewLine);
                            currentDetails.Add(pkgLevel);
                        }
                        #endregion

                        #region Others
                        //else if (rawLine.StartsWith("DET3") && currentServicePartNumber != "") //REMARK CODE
                        //{
                        //    REMARKCODE rmkCode = new REMARKCODE(rawLine, currentServicePartNumber);
                        //    rawSpec += (rawLine + System.Environment.NewLine);
                        //    currentRemarkCode.Add(rmkCode);
                        //}
                        //else if (rawLine.StartsWith("DET4") && currentServicePartNumber != "") //REMARK
                        //{
                        //    rmk = new REMARK(rawLine, currentServicePartNumber);
                        //    rawSpec += (rawLine + System.Environment.NewLine);

                        //}
                        //else if (rawLine.StartsWith("DET5") && currentServicePartNumber != "") //BOM
                        //{
                        //    BOM bom = new BOM(rawLine, currentServicePartNumber);
                        //    rawSpec += (rawLine + System.Environment.NewLine);

                        //    currentBOM.Add(bom);
                        //}
                        #endregion
                    }
                    lastLocationSeeked = newSeekLocation;
                }
            }
            //*/
            #endregion

            #region READ LINE BY LINE
            //*
            FileInfo fStream = new FileInfo(sourceFolder + sourceFile);
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
            using (StreamReader sr = new StreamReader(sourceFolder + sourceFile))
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
                    #endregion
                }
            }
            //*/
            #endregion

            watch.Stop();
            TimeSpan t = TimeSpan.FromMilliseconds(watch.ElapsedMilliseconds);

            string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                                    t.Hours,
                                    t.Minutes,
                                    t.Seconds,
                                    t.Milliseconds);

            Console.WriteLine(answer);
        }

        private static void ShowProgress(SPECIFICATION pkgSpec, double percent)
        {
            Console.Write("\r " + (percent + "% : " + pkgSpec.ServicePartNo).PadRight(30));
            //Console.WriteLine((percent + "% : " + pkgSpec.ServicePartNo).PadRight(30));
        }

        private static string processSpec(string SpecsFolder, SPECIFICATION pkgSpec, 
                        double percent, List<DETAILS> currentDetails, List<BOM> currentBOM, 
                        List<REMARKCODE> currentRemarkCode, REMARK rmk, string rawSpec)
        {
            if (totalParts < 10) //do only 10 specs for testing
            {
                //if (pkgSpec.isB969F())
                {
                    //Create CSV
                    Directory.CreateDirectory(SpecsFolder);

                    ARINVT.process(SpecsFolder, pkgSpec, currentDetails,
                                            currentBOM, currentRemarkCode, rmk, rawSpec);
                    totalParts++;
                }
            }

            ShowProgress(pkgSpec, percent);

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
        
        

        private void ReadCSV(string csvPath, string tableName)
        {
            var lines = System.IO.File.ReadAllLines(csvPath);
            if (lines.Count() == 0) return;
            var columns = lines[0].Split(',');
            var table = new DataTable();
            foreach (var c in columns)
            {
                table.Columns.Add(c);
            }

            for (int i = 1; i < lines.Count() - 1; i++)
            {
                table.Rows.Add(lines[i].Split(','));
            }

            using (OracleConnection dbO = OracleConnectionFactory.IQMSConnection)
            {
                /*
                using (var sqlBulk = new OracleBulkCopy(dbO))
                {
                    sqlBulk.DestinationTableName = tableName;
                    sqlBulk.WriteToServer(table);
                }
                */
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
