using FEpy.Domain.Abstractions;
using FEpy.Domain.Entities.Depositos;
using FEpy.Domain.Entities.DepositosSociosDeNegocios.Events;
using FEpy.Domain.Entities.SociosDeNegocios;

namespace FEpy.Domain.Entities.DepositosSociosDeNegocios
{
    public sealed class DepositoSocioDeNegocio : Entity<DepositoSocioDeNegocioId>
    {
        private DepositoSocioDeNegocio() { }
        private DepositoSocioDeNegocio(
            DepositoSocioDeNegocioId id,
            DepositoId depositoId,
            PersonaId socioDeNegocioId) : base(id)
        {
            DepositoId = depositoId;
            SocioDeNegocioId = socioDeNegocioId;
        }

        public DepositoId? DepositoId { get; private set; }
        public PersonaId? SocioDeNegocioId { get; private set; }

        #region NAVEGACION
        public Deposito? Deposito { get; private set; }
        public SocioDeNegocio? SocioDeNegocio { get; private set; }
        #endregion

        public static DepositoSocioDeNegocio Create(DepositoId depositoId, PersonaId socioDeNegocioId)
        {
            var relacionMuchoAMucho = new DepositoSocioDeNegocio(
                DepositoSocioDeNegocioId.New(), depositoId, socioDeNegocioId);
            relacionMuchoAMucho.RaiseDomainEvent(new DepositoSocioDeNegocioCreatedDomainEvent(
                relacionMuchoAMucho.Id!, depositoId, socioDeNegocioId));

            return relacionMuchoAMucho;
        }
    }
}
