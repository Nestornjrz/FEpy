using FEpy.Domain.Abstractions;

namespace FEpy.Domain.Entities.SociosDeNegocios.Events;

public sealed record SocioDeNegocioCreatedDomainEvent(PersonaId PersonaId, string Ruc) : IDomainEvent;
