// See https://aka.ms/new-console-template for more information

using System;
using System.Data;
using System.Data.SqlClient;

namespace HelloWorld
{

    class Program
    {
        static void Main(string[] args)
        {

        string connectionString = "Server=tcp:mkazsql.database.windows.net,1433;Initial Catalog=mkazSQL;Persist Security Info=False;User ID=ubuntu;Password=M3purple####;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // Provide the query string with a parameter placeholder.
        string queryString =
            "SELECT ProductID, ListPrice, Name from SalesLT.Product ORDER BY ListPrice DESC;";

        // Specify the parameter value.
        int rows = 0;

        // Create and open the connection in a using block. This
        // ensures that all resources will be closed and disposed
        // when the code exits.
        using (SqlConnection connection =
            new SqlConnection(connectionString))
        {
            // Create the Command and Parameter objects.
            SqlCommand command = new SqlCommand(queryString, connection);
            
            // Open the connection in a try/catch block.
            // Create and execute the DataReader, writing the result
            // set to the console window.
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("\t{0}\t{1}\t{2}",
                        reader[0], reader[1], reader[2]);
                        rows++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(rows+" records fetched");
            Console.ReadLine();
            
        }



            /*
            int i=0;
            while(true)
            {
            Console.WriteLine("Hello World! {0}",i);
            i++;
            Thread.Sleep(2000);
            }
            */
        }
        
    }
}