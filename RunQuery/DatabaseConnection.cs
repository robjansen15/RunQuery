using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace RunQuery
{
    public class DatabaseConnection
    {
        public DatabaseConnection()
        {
            _Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
        }


        public void Connect()
        {
            try
            {
                _Connection.Open();
            }
            catch (Exception e)
            {

            }
        }


        public void Disconnect()
        {
            try
            {
                _Connection.Close();
            }
            catch (Exception e)
            {

            }
        }


        public SqlConnection GetActiveConnection()
        {
            return _Connection;
        }


        private SqlConnection _Connection { get; set; }
    }
}