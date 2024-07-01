using System.Data;
using Microsoft.Data.SqlClient;
using FEpy.Application.Abstractions.Data;
// using Npgsql;

namespace FEpy.Infrastructure.Data;

internal sealed class SqlServerConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;

    public SqlServerConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection CreateConnection()
    {
         var connection = new SqlConnection(_connectionString);
         connection.Open();

        return connection;
    }
}