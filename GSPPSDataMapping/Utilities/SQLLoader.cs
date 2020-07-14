using GSPPSDataMapping.Tables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GSPPSDataMapping.Utilities
{
    class SQLLoader
    {
        public static void RunControlFile(string controlFile, string tableName,  long totalItems)
        {
            if (!File.Exists(controlFile))
            {
                Console.WriteLine();
                throw new FileNotFoundException("File '" + controlFile + "' does not exist.");
            }

            var appSettings = ConfigurationManager.AppSettings;

            string Command = "/C SQLLDR userid=" + appSettings["IQMSUserID"] + "/"
                + appSettings["IQMSPassword"] + "@" + appSettings["IQMSDataSource"]
                + " control=" + controlFile
                + " bindsize=90000000 readsize=90000000  rows=2000 ";

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = Command,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            Console.WriteLine("\n Importing " + totalItems + " items into " + tableName + " via SQL Loader");
            proc.Start();

            while (!proc.StandardOutput.EndOfStream)
            {
                Console.Write("\r " + (Regex.Replace(proc.StandardOutput.ReadLine(), @"\t|\n|\r", "")).PadRight(80));
                //Console.WriteLine(proc.StandardOutput.ReadLine());
                //Console.Write('.');
            }
            Console.WriteLine();
        }
    }
}
