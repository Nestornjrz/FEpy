using FEpy.Domain.Abstractions;

namespace FEpy.Domain.Entities.Supervisores.Events;

public sealed record SupervisorCreatedDomainEvent(
    PersonaId InspectorId,
    string Apellido,
    string NumeroDeCedula
) : IDomainEvent;
