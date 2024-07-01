using FEpy.Application.Abstractions.Messaging;

namespace FEpy.Application.Cqrs.Personas.GetPersona;

public sealed record GetPersonaQuery(Guid PersonaId) : IQuery<PersonaResponse>;
