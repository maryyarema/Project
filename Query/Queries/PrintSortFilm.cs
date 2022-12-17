using System;
using System.Data;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;


internal class PrintSortFilm : IQuery
{
    public Task Print(SqlConnection connection)
    {
        using (IDbConnection db = new SqlConnection(connection.ConnectionString))
        {
            Console.WriteLine("1 - Cортування по рейтингу");
            Console.WriteLine("2 - Cортування по назві");
            Console.WriteLine("3 - Cортування по роках");

            switch (Console.ReadLine()?.ToLower().Trim())
            {
                case ("1"):
                    Console.WriteLine();
                    var result = db.Query<Film>(
                        @"
                            SELECT 
                                films.title,
                                films.rating
                            FROM films
                            ORDER BY rating DESC
                        "
                    );

                    foreach (var item in result)
                        Console.Write(
                            $"Назва фільму - {item.title}\n" +
                            $"Рейтинг: {item.rating}\n\n"
                        );
                    break;
                case ("2"):
                    Console.WriteLine();
                    var result1 = db.Query<Film>(
                        @"
                            SELECT 
                                films.title
                            FROM films
                            ORDER BY title ASC
                        "
                    );

                    foreach (var item in result1)
                        Console.Write(
                            $"Назва фільму - {item.title}\n\n"
                        );
                    break;
                case ("3"):
                    Console.WriteLine();
                    var result2 = db.Query<Film>(
                        @"
                            SELECT 
                                films.title,
                                films.year
                            FROM films
                            ORDER BY year DESC
                        "
                    );

                    foreach (var item in result2)
                        Console.Write(
                            $"Назва фільму - {item.title}\n\n" +
                            $"Рік: {item.year}\n\n"

                        );
                    break;
                case ("exit"):
                    break;
                default:
                    Console.Write("\nВведено некоректне значення...");
                    break;
            }
        }

        return Task.CompletedTask;
    }
}