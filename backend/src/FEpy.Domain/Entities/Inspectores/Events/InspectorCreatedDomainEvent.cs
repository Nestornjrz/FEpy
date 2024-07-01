using FEpy.Domain.Abstractions;

namespace FEpy.Domain.Entities.Inspectores.Events;

public sealed record InspectorCreatedDomainEvent(
    PersonaId InspectorId,
    string Apellido,
    string NumeroDeCedula,
    bool Activo
) : IDomainEvent;