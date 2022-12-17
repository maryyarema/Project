using System;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;

internal class PR_QUERIES
{
    public static async Task Print(IQuery query, SqlConnection connection) => await query.Print(connection);
}