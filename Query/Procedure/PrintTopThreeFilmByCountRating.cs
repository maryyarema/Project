using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;


internal class PrintTopThreeFilmByCountRating : IQuery
{
    public Task Print(SqlConnection connection)
    {
        using (IDbConnection db = new SqlConnection(connection.ConnectionString))
        {

            var result = db.Query<Film>("EXEC TopThreeFilmByCountRating");
            foreach (var item in result)
                Console.WriteLine(
               $"Назва фільму - {item.title}\n" +
               $"Рейтинг - {item.rating}\n");
        }

        return Task.CompletedTask;
    }
}