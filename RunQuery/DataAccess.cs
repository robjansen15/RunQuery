using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunQuery
{
    public class DataAccess
    {
        public DataAccess(DatabaseConnection databaseConnection)
        {
            _DatabaseConnection = databaseConnection;
        }

        /// <summary>
        /// Get any data table in a generic way 
        /// </summary>

        public DataTable GetData(StoredProcedureObj storedProcedureObj)
        {
            SqlCommand command = new SqlCommand();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            _DatabaseConnection.Connect();
            try
            {
                command = new SqlCommand(storedProcedureObj._StoredProcedure, _DatabaseConnection.GetActiveConnection());

                //adds the parameters
                storedProcedureObj._Parameters.ForEach(x => command.Parameters.Add(x));
                command.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataTable);
            }
            catch (Exception e)
            {
                var x = e.ToString();
            }
            finally
            {
                _DatabaseConnection.Disconnect();
            }

            return dataTable;
        }


        private DatabaseConnection _DatabaseConnection { get; set; }
    }
}
