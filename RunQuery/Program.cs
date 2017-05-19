using System;
using System.Data.SqlClient;
using System.Data;

namespace RunQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseConnection connection = new DatabaseConnection();

            try
            {
                connection.Connect();

                SqlCommand command = new SqlCommand();

                command.CommandType = CommandType.Text;
                command.CommandText = "Query Here";


                command.ExecuteNonQuery();

            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                connection.Disconnect();
            }

        }
    }
}
