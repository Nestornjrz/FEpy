using FEpy.Domain.Abstractions;
using FEpy.Domain.Entities.Depositos;
using FEpy.Domain.Entities.DepositosInspectores.Events;
using FEpy.Domain.Entities.Inspectores;

namespace FEpy.Domain.Entities.DepositosInspectores;

public sealed class DepositoInspector : Entity<DepositoInspectorId>
{
    private DepositoInspector() { }

    public DepositoInspector(
        DepositoInspectorId id,
        DepositoId depositoId, 
        PersonaId inspectorId): base(id)
    {
        DepositoId = depositoId;
        InspectorId = inspectorId;
    }

    public DepositoId? DepositoId { get; private set; }
    public PersonaId? InspectorId { get; private set; }

    // Propiedades de navegación
    public Deposito? Deposito { get; private set; }
    public Inspector? Inspector { get; private set; }


    public static DepositoInspector Create(DepositoId depositoId, PersonaId inspectorId)
    {
        var relacionMuchoAMucho = new DepositoInspector(
            DepositoInspectorId.New(), depositoId, inspectorId);
        relacionMuchoAMucho.RaiseDomainEvent(new DepositoInspectorCreatedDomainEvent(
            relacionMuchoAMucho.Id!, depositoId, inspectorId));

        return relacionMuchoAMucho;
    }
}
