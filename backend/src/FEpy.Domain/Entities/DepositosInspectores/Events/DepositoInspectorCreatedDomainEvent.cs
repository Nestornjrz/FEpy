using FEpy.Domain.Abstractions;
using FEpy.Domain.Entities.Depositos;

namespace FEpy.Domain.Entities.DepositosInspectores.Events;
public sealed record DepositoInspectorCreatedDomainEvent(
    DepositoInspectorId DepositoInspectorId,
    DepositoId DepositoId,
    PersonaId InspectorId
) : IDomainEvent;
