using System;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;


internal class PrintFilmAllComent : IQuery
{
    public Task Print(SqlConnection connection)
    {
        using (IDbConnection db = new SqlConnection(connection.ConnectionString))
        {
            var sql = @"
                SELECT 
                    films.title, 
                    films.producer_id, 
                    producers.full_name
                FROM films
                INNER JOIN c ON films.producer_id = producers.id
            ";

            var result = db.Query<Film, Producer, Film>(
                sql,
                (film, producer) => {
                    film.producer = producer;
                    return film;
                },
                splitOn: "producer_id"
            );

            foreach (var item in result)
                Console.WriteLine($"{item.producer.full_name} n/{item.title,-255}");
        }

        return Task.CompletedTask;
    }
}