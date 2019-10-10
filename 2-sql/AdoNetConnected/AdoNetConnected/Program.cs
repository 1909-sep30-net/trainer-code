using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AdoNetConnected
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // we need the connection string to connect to the database..
            // but it should not be uploaded to public github
            // we get that connection string from Azure Portal.

            /*
namespace AdoNetConnected
{
    public static class SecretConfiguration
    {
        public const string ConnectionString = "{connection_string_here};
    }
}
             */

            // with ADO.NET, you run SELECT commands with command.ExecuteReader()
            // but all other commands have no data that comes back to iterate over -
            // you use command.ExecuteNonQuery() which just returns int (number of rows changed)

            var connectionString = SecretConfiguration.ConnectionString;

            // to use ADO.NET with a SQL Server DB, we need NuGet package System.Data.SqlClient.

            // for connected architecture, we have a four-step process
            try
            {
                using var connection = new SqlConnection(connectionString);
                // 1. open the connection
                connection.Open();
                using DbCommand command = new SqlCommand("SELECT * FROM Pokemon;", connection);
                // 2. execute your query
                using DbDataReader reader = await command.ExecuteReaderAsync();
                // this DataReader object receives the data and starts providing it immediately
                // it's sort of a "cursor" over the data being recieved in the network buffer
                // 3. process the results
                if (reader.HasRows)
                {
                    // get one more row
                    while (await reader.ReadAsync())
                    {
                        // print each row as it comes in
                        Console.WriteLine($"Pokemon {reader["Name"]} (height {reader["Height"]}, " +
                            $"weight {reader["Weight"]})");
                    }
                }
                else
                {
                    Console.WriteLine("No data found");
                }
                // 4. close the connection
                connection.Close();
                // (because we're using "using declaration", the object is disposed at the end of the method anyway.)
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error connecting to database: {ex.Message}");
            }
        }
    }
}
