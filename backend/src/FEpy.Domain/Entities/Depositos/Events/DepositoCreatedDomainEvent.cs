using FEpy.Domain.Abstractions;

namespace FEpy.Domain.Entities.Depositos.Events;

public sealed record DepositoCreatedDomainEvent(
    DepositoId DepositoId,
    string NombreDeposito,
    string direccionDeposito,
    PersonaId supervisorId
    ) : IDomainEvent;
