using FEpy.Domain.Abstractions;
using FEpy.Domain.Entities.TiposDeMovimientos.Events;

namespace FEpy.Domain.Entities.TiposDeMovimientos
{
    public sealed class TipoDeMovimiento : Entity<TipoDeMovimientoId>
    {
        private TipoDeMovimiento() {  }
        private TipoDeMovimiento(
            TipoDeMovimientoId id,
            NombreTipoMovimiento nombreTipoMovimiento): base(id)
        {
            NombreTipoMovimiento = nombreTipoMovimiento;
        }

        public NombreTipoMovimiento? NombreTipoMovimiento { get; private set; }

        public static TipoDeMovimiento Create(int tipoMovimientoId, NombreTipoMovimiento nombre)
        {
            var tipoDeMovimiento = new TipoDeMovimiento(new TipoDeMovimientoId(tipoMovimientoId), nombre);
            tipoDeMovimiento.RaiseDomainEvent(new TipoDeMovimientoCreatedDomainEvent(tipoDeMovimiento.Id!, nombre.Value));
            return tipoDeMovimiento;
        }
    }
}
