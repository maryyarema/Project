using System;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;


internal class PrintSearchFilms : IQuery
{
    public Task Print(SqlConnection connection)
    {
        using (IDbConnection db = new SqlConnection(connection.ConnectionString))
        {
                Console.WriteLine("Введіть назву фільм яку бажаєте знайти: ");
                var search = Console.ReadLine()?.Trim();
                if (search.Length == 0)
                {
                    Console.WriteLine("Нічого не введено...");
                    return Task.CompletedTask;
                }

                var result = db.Query<Film>($"EXEC SearchFilms '%{search}%'");
                if (result.Count() == 0)
                {
                    Console.WriteLine("Нічого не знайдено...");
                    return Task.CompletedTask;
                }
                foreach (var item in result)
                    Console.WriteLine($"{item.title}");
        }

        return Task.CompletedTask;
    }
}