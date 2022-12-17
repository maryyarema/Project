using System;
using System.Data;
using System.Threading.Tasks;
using Azure.Core.GeoJson;
using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;


internal class PrintAllFilmComments : IQuery
{
    public  Task Print(SqlConnection connection)
    {
        using (IDbConnection db = new SqlConnection(connection.ConnectionString))
        {
            var sql = @"
                SELECT 
                    films.id, 
                    films.title,
                    coments.id as comment_id,
                    coments.coment,
                    users.full_name
                FROM films
                LEFT JOIN coments ON coments.film_id = films.id
                LEFT JOIN users ON coments.user_id = users.id
            ";

            var result = db.Query<Film, Comment, User, Film >(
                sql, 
                (film, comment, user) => {
                    comment.user = user;
                    film.comments = new List<Comment>();
                    film.comments.Add(comment);
                    return film;
                },
                splitOn: "comment_id, full_name"
            );

            var films = result.GroupBy((film) => film.id).Select((gFilm) =>
            {
                var groupedFilm = gFilm.First();
                groupedFilm.comments = gFilm.Select((film) => film.comments.Single()).ToList();

                return groupedFilm;
            });

            foreach (var film in films)
            {
                var comments = string.Join(",\n", film.comments.Select((comment) => comment.user != null ? $"Користувач який залишив коментар - {comment.user.full_name}, \nКоментар - {comment.coment}" : "[Коментарів не має...]"));

                Console.Write(
                    $"Назва фільму - {film.title}\n" +
                    $"{comments}\n\n"
                );
            }
        }

        return Task.CompletedTask;
    }
}