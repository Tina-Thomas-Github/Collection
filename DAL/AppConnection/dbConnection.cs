using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.AppConnection
{
    public class dbConnection
    {
        protected static dbConnection _obj;
        private dbConnection()
        {

        }
        public static dbConnection GetObject()
        {
            if (_obj == null)
            {
                _obj = new dbConnection();

            }
            return _obj;
        }
        public SqlConnection conn;

        public SqlConnection makeConnection()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Collections"].ConnectionString);
            conn.Open();
            return conn;
        }
        public SqlConnection closeConnection()
        {
            conn.Close();
            return conn;
        }

        public string GetConfigKey(string Key)
        {
            string value = string.Empty;
            try
            {
                value = ConfigurationManager.AppSettings[Key].ToString();
            }
            catch (Exception)
            {
                value = string.Empty;
            }
            return value;
        }
    }
}
