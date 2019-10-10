using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;
using AdoNetConnected;

namespace AdoNetDisconnected
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // need package System.Data.SqlClient

            var connectionString = SecretConfiguration.ConnectionString;

            var commandString = "SELECT p.Id, p.Name, p.Height, p.Weight, t.Name AS Type " +
                "FROM Pokemon AS p " +
                "INNER JOIN PokemonType AS pt ON p.Id = pt.PokemonId " +
                "INNER JOIN Type AS t ON pt.TypeId = t.Id";

            Console.WriteLine("Enter a condition: ");

            var input = Console.ReadLine();
            if (input.Length > 0)
            {
                commandString += $" WHERE {input};";
            }

            // major security issue SQL injection - user input should never be trusted
            // and put directly into some SQL command

            try
            {
                var dataSet = new DataSet();

                // 1. open the connection
                using var connection = new SqlConnection(connectionString);
                await connection.OpenAsync();

                using var command = new SqlCommand(commandString, connection);
                using var dataAdapter = new SqlDataAdapter(command);

                // 2. execute query
                dataAdapter.Fill(dataSet);

                // 3. close the connection
                await connection.CloseAsync();

                // 4. process the results

                // a DataSet can have several DataTables, which each have several DataColumns and DataRows
                var table = dataSet.Tables[0];
                foreach (DataRow row in table.Rows)
                {
                    Console.WriteLine($"Pokemon {row["Name"]} (height {row["Height"]}, " +
                        $"weight {row["Weight"]}, type {row["Type"]})");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error connecting to database: {ex.Message}");
            }
            // 1. open the connection

        }
    }
}
