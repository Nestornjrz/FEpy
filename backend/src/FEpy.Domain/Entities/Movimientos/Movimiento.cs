using FEpy.Domain.Abstractions;
using FEpy.Domain.Entities.Depositos;
using FEpy.Domain.Entities.Mercaderias;
using FEpy.Domain.Entities.TiposDeMovimientos;
using FEpy.Domain.Entities.Movimientos.Events;
using FEpy.Domain.Entities.SociosDeNegocios;

namespace FEpy.Domain.Entities.Movimientos
{
    public sealed class Movimiento : Entity<MovimientoId>
    {
        private Movimiento() { }
        private Movimiento(
            MovimientoId id,
            DateTime fechaDeCarga,
            DepositoId depositoId,
            PersonaId socioDeNegocioId,
            MercaderiaId mercaderiaId,
            TipoDeMovimientoId tipoDeMovimientoId,
            DateTime fechaDeMovimiento,
            Observacion observacion,
            Valor valor,
            UnidadDeMedida unidadDeMedida
        ) : base(id)
        {
            FechaDeCarga = fechaDeCarga;
            DepositoId = depositoId;
            SocioDeNegocioId = socioDeNegocioId;
            MercaderiaId = mercaderiaId;
            TipoDeMovimientoId = tipoDeMovimientoId;
            FechaDeMovimiento = fechaDeMovimiento;
            Observacion = observacion;
            Valor = valor;
            UnidadDeMedida = unidadDeMedida;
        }

        public DateTime FechaDeCarga { get; }
        public DepositoId? DepositoId { get; }
        public PersonaId? SocioDeNegocioId { get; }
        public MercaderiaId? MercaderiaId { get; }
        public TipoDeMovimientoId? TipoDeMovimientoId { get; }
        public DateTime FechaDeMovimiento { get; }
        public Observacion? Observacion { get; }
        public Valor? Valor { get; }
        public UnidadDeMedida? UnidadDeMedida { get; }

        #region NAVEGACION
        public Deposito? Deposito { get; }
        public SocioDeNegocio? SocioDeNegocio { get; }
        public Mercaderia? Mercaderia { get; private set; }
        public TipoDeMovimiento? TipoDeMovimiento { get; }
        #endregion

        public static Movimiento Create(
            int id,
            DateTime fechaDeCarga,
            DepositoId depositoId,
            PersonaId socioDeNegocioId,
            MercaderiaId mercaderiaId,
            TipoDeMovimientoId tipoDeMovimientoId,
            DateTime fechaDeMovimiento,
            Observacion observacion,
            Valor valor,
            UnidadDeMedida unidadDeMedida
        )
        {
            var movimiento = new Movimiento(
                new MovimientoId(id),
                fechaDeCarga,
                depositoId,
                socioDeNegocioId,
                mercaderiaId,
                tipoDeMovimientoId,
                fechaDeMovimiento,
                observacion,
                valor,
                unidadDeMedida
            );
            movimiento.RaiseDomainEvent(new MovimientoCreatedDomainEvent(
                movimiento.Id!,
                fechaDeCarga,
                depositoId,
                socioDeNegocioId,
                mercaderiaId,
                tipoDeMovimientoId,
                fechaDeMovimiento,
                observacion.Value,
                valor.Value,
                unidadDeMedida.Value));
            return movimiento;
        }
    }
}
