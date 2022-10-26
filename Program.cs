// See https://aka.ms/new-console-template for more information

using System.Data.SqlClient;

namespace HellowWorld
{

    class Program
    {
        static void Main(string[] args)
        {
            // define connection string
            string connectionString = "Server=tcp:mkazsql.database.windows.net,1433;Initial Catalog=mkazSQL;Persist Security Info=False;User ID=ubuntu;Password=M3purple####;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            // Provide the query string 
            string queryString =
                "SELECT ProductID, ListPrice, Name from SalesLT.Product ORDER BY ListPrice DESC;";

            // initialize query record number counter.
            int rows = 0;

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command object.
                SqlCommand command = new SqlCommand(queryString, connection);

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                while (true)
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        Random r = new Random();
                        int rInt = r.Next(0, 295);

                        for (int i = 0; i < rInt; i++)
                        {
                            reader.Read();
                            Console.WriteLine("\t{0}\t{1}\t{2}",
                                reader[0], reader[1], reader[2]);
                            rows++;
                        }
                        reader.Close();
                        connection.Close();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    Console.WriteLine(rows + " records fetched");
                    rows = 0;
                    Thread.Sleep(60000);
                }

            }

        }

    }
}