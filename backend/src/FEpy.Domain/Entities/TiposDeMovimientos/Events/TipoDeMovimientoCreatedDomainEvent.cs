using FEpy.Domain.Abstractions;

namespace FEpy.Domain.Entities.TiposDeMovimientos.Events
{
    public sealed record TipoDeMovimientoCreatedDomainEvent(TipoDeMovimientoId TipoDeMovimientoId, string NombreTipoDeMovimiento) : IDomainEvent;
}