using Dapper;
using FEpy.Application.Abstractions.Data;
using FEpy.Application.Abstractions.Messaging;
using FEpy.Domain.Abstractions;

namespace FEpy.Application.Cqrs.Personas.GetPersona
{
    internal sealed class GetPersonaQueryHandler : IQueryHandler<GetPersonaQuery, PersonaResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetPersonaQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<PersonaResponse>> Handle(
            GetPersonaQuery request,
            CancellationToken cancellationToken)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();

            var sql = @"
                       SELECT [Id], [Nombre]
                       FROM Personas
                       WHERE [Id] = @Id";

            var persona = await connection.QueryFirstOrDefaultAsync<PersonaResponse>(
                sql,
                new
                {
                   Id = request.PersonaId
                }
            );

            return persona!;
        }
    }
}
