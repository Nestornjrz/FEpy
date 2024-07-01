

using System.Data;

namespace FEpy.Application.Abstractions.Data;

public interface ISqlConnectionFactory
{

    IDbConnection CreateConnection();

}