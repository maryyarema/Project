using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

internal class MAIN
{
    static async Task Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        await INSERT.Insert();
        await NewConnection.Connection();


        Console.ReadKey();
    }
}