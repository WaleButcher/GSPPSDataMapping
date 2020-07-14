using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GSPPSDataMapping
{
    class Logger
    {
        public static void log(String message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@"D:\ErrorLogs\" 
                                + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name 
                                + ".log", true))
                {
                    sw.WriteLine("\r\n[" + DateTime.Now + "] " + message);
                    sw.Close();
                }
            }
            catch { }
        }
        public static void logMessageOnly(String message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@"D:\ErrorLogs\"
                                + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name
                                + ".log", true))
                {
                    sw.WriteLine("\r"+ message);
                    sw.Close();
                }
            }
            catch { }
        }
    }
}
