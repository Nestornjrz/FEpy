using FEpy.Domain.Abstractions;
using FEpy.Domain.Entities.Depositos;
using FEpy.Domain.Entities.Mercaderias;

namespace FEpy.Domain.Entities.DepositosMercaderias.Events;

internal sealed record DepositoMercaderiaCreatedDomainEvent(
    DepositoMercaderiaId DepositoMercaderiaId, 
    DepositoId DepositoId,
    MercaderiaId MercaderiaId
) : IDomainEvent;