using System;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;

internal interface IMenu
{
    Task Menu(SqlConnection connection);
}