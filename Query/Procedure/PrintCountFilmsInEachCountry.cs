using System;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;


internal class PrintCountFilmsInEachCountry : IQuery
{
    public Task Print(SqlConnection connection)
    {
        using (IDbConnection db = new SqlConnection(connection.ConnectionString))
        {
   
                var result = db.Query<CountCountry>("EXEC CountFilmsInEachCountry");
                foreach (var item in result)
                    Console.WriteLine($"{item.NameCountry} {item.FilmCount}");
        }

        return Task.CompletedTask;
    }
}