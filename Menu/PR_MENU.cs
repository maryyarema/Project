using System;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;

internal class PR_MENU
{
    public static async Task Print(SqlConnection connection, IMenu item) => await item.Menu(connection);
}