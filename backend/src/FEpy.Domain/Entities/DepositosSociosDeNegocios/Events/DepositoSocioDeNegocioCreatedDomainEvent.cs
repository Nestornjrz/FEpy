using FEpy.Domain.Abstractions;
using FEpy.Domain.Entities.Depositos;

namespace FEpy.Domain.Entities.DepositosSociosDeNegocios.Events;

public sealed record DepositoSocioDeNegocioCreatedDomainEvent(
    DepositoSocioDeNegocioId DepositoSocioDeNegocioId,
    DepositoId DepositoId,
    PersonaId SocioDeNegocioId
) : IDomainEvent;
