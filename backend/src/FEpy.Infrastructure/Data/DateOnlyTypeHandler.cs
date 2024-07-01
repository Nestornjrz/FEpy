using System.Data;
using Dapper;

namespace FEpy.Infrastructure.Data;

/// <summary>
/// Esto es para la problematica que tiene Postgres con el tipo DateOnly
/// </summary>
internal sealed class DateOnlyTypeHandler : SqlMapper.TypeHandler<DateOnly>
{
    public override DateOnly Parse(object value) => DateOnly.FromDateTime((DateTime)value);
    

    public override void SetValue(IDbDataParameter parameter, DateOnly value)
    {
        parameter.DbType = DbType.Date;
        parameter.Value = value;
    }
}