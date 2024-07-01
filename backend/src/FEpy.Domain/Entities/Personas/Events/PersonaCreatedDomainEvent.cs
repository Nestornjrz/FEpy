using FEpy.Domain.Abstractions;

public sealed record PersonaCreatedDomainEvent(PersonaId PersonaId, string Nombre) : IDomainEvent;