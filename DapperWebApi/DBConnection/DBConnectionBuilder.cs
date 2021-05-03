using System;
using System.Data;
using System.Data.SqlClient;

namespace DBConnection
{
    public class DBConnectionBuilder
    {
        public static SqlConnection GetConnection(string connStr)
        {
            return new SqlConnection(connStr);
        }
    }
}