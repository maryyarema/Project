using System;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;

internal class NewConnection
{
    public static async Task Connection()
    {
        try
        {
            string connectionString = "Server=.\\SQLEXPRESS;Data Source=DESKTOP-H50SRGF;Initial Catalog=movie_catalog;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";


            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                Console.WriteLine("Пiдключення до бази movie_catalog завершено успішно");
                Console.ReadKey(); Console.Clear();

                await PR_MENU.Print(connection, new MENU());
               
            }


            Console.WriteLine("Відключення від бази movie_catalog завершено успішно");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("\nНе вдалося підключитися до бази даних movie_catalog");
        }
    }
}