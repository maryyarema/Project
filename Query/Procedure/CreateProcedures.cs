using System;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;


// Створення процедур
internal class CreateProcedures
{
    public static async Task Create(SqlConnection connection)
    {
        string query = ""; // для кодy запиту
        var command = new SqlCommand(query, connection);// Відобразити кількість фільмів з кожної країни


        try
        {
            query =
            @"
                CREATE PROCEDURE CountFilmsInEachCountry
                AS
                BEGIN
                    SELECT  countries.name AS NameCountry, COUNT(films.id) AS FilmCount
                    FROM films
                    INNER JOIN countries ON films.country_id = countries.id 
                    GROUP BY countries.name
                END
            ";
            command.CommandText = query;

            await command.ExecuteNonQueryAsync();
            Console.WriteLine("Процедуру CountFilmsInEachCountry створено успішно");
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message);
        }

        try
        {
            query =
            @"
                CREATE PROCEDURE TopThreeFilmByCountRating
                AS
                SELECT  TOP 3 title, rating
                FROM films 
                ORDER BY rating DESC
            ";
            command.CommandText = query;

            await command.ExecuteNonQueryAsync();
            Console.WriteLine("Процедуру [TopThreeCountryByCountBuyers] створено успішно");
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message);
        }

        try
        {
            query =
            @"
                CREATE PROCEDURE SearchFilms @search nvarchar(50)
                AS
                SELECT title, @search as search FROM films
                WHERE title LIKE @search
            ";
            command.CommandText = query;

            await command.ExecuteNonQueryAsync();
            Console.WriteLine("Процедуру [SearchFilms] створено успішно");
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}