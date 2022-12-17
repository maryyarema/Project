using System;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;

internal class MENU : IMenu
{
    public async Task Menu(SqlConnection connection)
    {
        try
        {
            await CreateProcedures.Create(connection);
            Console.ReadKey(); Console.Clear();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);

            Console.Write("\nНатисніть для продовження...");
            Console.ReadKey(); Console.Clear();
        }
        while (true)
        {
            Console.WriteLine("1 - Відображення всіх фільмів та подюсерів");
            Console.WriteLine("2 - Відображення всієї інформація про фільм");
            Console.WriteLine("3 - Відображення кількості фільмів з кожної країни");
            Console.WriteLine("4 - Відображення топ 3 фльми по рейтингу");
            Console.WriteLine("5 - Відображення всіх коментарі до фільму ");
            Console.WriteLine("6 - Пошук фільмів");
            Console.WriteLine("7 - Сортування фільмів");
            Console.Write("Exit - Відключення від БД \n > ");

            switch (Console.ReadLine()?.ToLower().Trim())
            {
                case ("1"):
                    Console.WriteLine();
                    await PR_QUERIES.Print(new PrintFilmByProduser(), connection);
                    break;
              case ("2"):
                    Console.WriteLine();
                    await PR_QUERIES.Print(new PrintAllFilm(), connection);
                    break;
                  case ("3"):
                    Console.WriteLine();
                    await PR_QUERIES.Print(new PrintCountFilmsInEachCountry(), connection);
                    break;
                case ("4"):
                     Console.WriteLine();
                     await PR_QUERIES.Print(new PrintTopThreeFilmByCountRating(), connection);
                     break;
                 case ("5"):
                     Console.WriteLine();
                     await PR_QUERIES.Print(new PrintAllFilmComments(), connection);
                     break; 
                 case ("6"):
                     Console.WriteLine();
                     await PR_QUERIES.Print(new PrintSearchFilms(), connection);
                     break;
                 case ("7"):
                     Console.WriteLine();
                     await PR_QUERIES.Print(new PrintSortFilm(), connection);
                     break;
                case ("exit"):
                    Console.WriteLine();
                    Console.ReadKey();
                    Console.Clear();
                    return;
                default:
                    Console.Write("\nВведено некоректне значення...");
                    break;
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}