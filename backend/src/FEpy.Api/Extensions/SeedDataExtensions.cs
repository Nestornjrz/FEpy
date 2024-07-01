//using Bogus;
using Bogus;
using Dapper;
using FEpy.Application.Abstractions.Data;

namespace FEpy.Api.Extensions;

public static class SeedDataExtensions
{
    public static void SeedData(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();
        using var connection = sqlConnectionFactory.CreateConnection();

        // Establecer una semilla aleatoria para Faker
        Randomizer.Seed = new Random();

        var faker = new Faker();

        List<object> personas = new();

        for (var i = 0; i < 100; i++)
        {
            personas.Add(new
            {
                Id = Guid.NewGuid(),
                Nombre = faker.Person.FirstName
            });
        }

        const string sql = @"INSERT INTO [dbo].[Personas]
           ([Id] ,[Nombre])
            VALUES
           (@Id, @Nombre)";

        connection.Execute(sql, personas);
    }
}