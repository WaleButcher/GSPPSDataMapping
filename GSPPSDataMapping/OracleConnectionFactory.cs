using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace GSPPSDataMapping
{
    class OracleConnectionFactory
    {
        #region CONNECTION
        public static OracleConnection IQMSConnection
        {
            get
            {
                //string example = "user id=<userid>;password=<passwprd>; datasource=<hostname>/<schemaname>;";
                string iqmsConnection = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["IQMSConnection"]].ConnectionString;
                OracleConnection db = new OracleConnection(iqmsConnection);

                db.Open();

                return db;
            }
        }
        #endregion
    }
}
