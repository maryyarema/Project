using System;
using System.Data;
using System.Threading.Tasks;
using Azure.Core.GeoJson;
using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;


internal class PrintAllFilm : IQuery
{
    public  Task Print(SqlConnection connection)
    {
        using (IDbConnection db = new SqlConnection(connection.ConnectionString))
        {
            var sql = @"
                SELECT 
                    films.id, 
                    films.title, 
                    films.year,
                    films.language_id, 
                    languages.name,
                    films.country_id, 
                    countries.name,
                    films.producer_id, 
                    producers.full_name,
                    films.company_id, 
                    companies.name,
                    genres.id AS genre_id,
                    genres.name,
                    coments.id,
                    coments.coment
                FROM films
                INNER JOIN languages ON films.language_id = languages.id
                INNER JOIN countries ON films.country_id = countries.id
                INNER JOIN producers ON films.producer_id = producers.id
                INNER JOIN companies ON films.company_id = companies.id
                INNER JOIN films_to_genres ON films.id = films_to_genres.film_id
                INNER JOIN genres ON films_to_genres.genre_id = genres.id
                LEFT JOIN coments ON coments.film_id = films.id
            ";


            var result = db.Query<Film, Language, Country, Producer, Company, Genre, Comment, Film >(
                sql, 
                (film, language, country, producer, company, genre, comment) => {
                    film.language = language;
                    film.country = country;
                    film.producer = producer;
                    film.company = company;
                    film.genres = new List<Genre>();
                    film.genres.Add(genre);
                    film.comments = new List<Comment>();
                    film.comments.Add(comment);
                    return film;
                },
                splitOn: "language_id, country_id, producer_id, company_id, genre_id, id"
            );

            var films = result.GroupBy((film) => film.id).Select((gFilm) =>
            {
                var groupedFilm = gFilm.First();
                groupedFilm.genres = gFilm.Select((film) => film.genres.Single()).ToList();
                groupedFilm.comments = gFilm.Select((film) => film.comments.Single()).ToList();
                // remove duplicates
                groupedFilm.comments = groupedFilm.comments.GroupBy(c => c).Select(c => c.First()).ToList();

                return groupedFilm;
            });

            foreach (var film in films)
            {
                var genres = string.Join(", ", film.genres.Select((genre) => genre.name));
                var comments = string.Join(", ", film.comments.Select((comment) => comment != null ? comment.coment : "[Коментарів не має...]"));

                Console.Write(
                    $"Назва фільму - {film.title}\n" +
                    $"Мова - {film.language.name}\n" +
                    $"Країна - {film.country.name}\n" +
                    $"Продюсер - {film.producer.full_name}\n" +
                    $"Компанія - {film.company.name}\n" +
                    $"Рік - {film.year}\n" +
                    $"Жанри: {genres}\n" +
                    $"Коментарі: {comments}\n\n"
                );
            }
        }

        return Task.CompletedTask;
    }
}