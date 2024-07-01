using FEpy.Domain.Abstractions;
using FEpy.Domain.Entities.Depositos;
using FEpy.Domain.Entities.Mercaderias;
using FEpy.Domain.Entities.TiposDeMovimientos;

namespace FEpy.Domain.Entities.Movimientos.Events;

public sealed record MovimientoCreatedDomainEvent
(
    MovimientoId MovimientoId,
    DateTime FechaDeCarga,
    DepositoId DepositoId,
    PersonaId SocioDeNegocioId,
    MercaderiaId MercaderiaId,
    TipoDeMovimientoId TipoDeMovimientoId,
    DateTime FechaDeMovimiento,
    string Observacion,
    decimal Valor,
    string UnidadDeMedida
) : IDomainEvent;