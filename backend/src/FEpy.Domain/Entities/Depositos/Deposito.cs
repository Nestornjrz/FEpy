using FEpy.Domain.Abstractions;
using FEpy.Domain.Entities.Depositos.Events;
using FEpy.Domain.Entities.DepositosInspectores;
using FEpy.Domain.Entities.DepositosMercaderias;
using FEpy.Domain.Entities.DepositosSociosDeNegocios;
using FEpy.Domain.Entities.Supervisores;

namespace FEpy.Domain.Entities.Depositos;

public sealed class Deposito : Entity<DepositoId>
{
    private Deposito() { }

    private Deposito(
        DepositoId id,
        NombreDeposito nombreDeposito,
        DireccionDeposito direccionDeposito,
        PersonaId supervisorId) : base(id)
    {
        NombreDeposito = nombreDeposito;
        DireccionDeposito = direccionDeposito;
        SupervisorId = supervisorId;
    }

    public NombreDeposito? NombreDeposito { get; private set; }
    public DireccionDeposito? DireccionDeposito { get; private set; }
    public PersonaId? SupervisorId { get; private set; }

    #region NAVEGACION
    // Propiedad de navegación hacia Supervisor
    public Supervisor? Supervisor { get; private set; }
    public List<DepositoInspector> Inspectores { get; private set; } = [];
    public List<DepositoSocioDeNegocio> SociosDeNegocios { get; private set; } = [];
    public List<DepositoMercaderia> Mercaderias { get; private set; } = [];
    #endregion

    public static Deposito Create(
        NombreDeposito nombreDeposito,
        DireccionDeposito direccionDeposito,
        PersonaId personaId)
    {
        var deposito = new Deposito(
            DepositoId.New(), nombreDeposito, direccionDeposito, personaId);

        deposito.RaiseDomainEvent(new DepositoCreatedDomainEvent(
            deposito.Id!, nombreDeposito.Value, direccionDeposito.Value, personaId));

        return deposito;
    }
}
