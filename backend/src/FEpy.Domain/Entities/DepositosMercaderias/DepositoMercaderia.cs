using FEpy.Domain.Abstractions;
using FEpy.Domain.Entities.Depositos;
using FEpy.Domain.Entities.DepositosMercaderias.Events;
using FEpy.Domain.Entities.Mercaderias;

namespace FEpy.Domain.Entities.DepositosMercaderias;

public class DepositoMercaderia: Entity<DepositoMercaderiaId>
{
    private DepositoMercaderia() { }
    private DepositoMercaderia(
        DepositoMercaderiaId id,
        DepositoId depositoId,
        MercaderiaId mercaderiaId): base(id)
    {
        DepositoId = depositoId;
        MercaderiaId = mercaderiaId;
    }

    public DepositoId? DepositoId { get; }
    public MercaderiaId? MercaderiaId { get; }

    #region NAVEGACION
    public Deposito? Deposito { get; private set; }
    public Mercaderia? Mercaderia { get; private set; }
    #endregion

    public static DepositoMercaderia Create(DepositoId depositoId, MercaderiaId mercaderiaId)
    {
        var depositoMercaderia = new DepositoMercaderia(DepositoMercaderiaId.New(), depositoId, mercaderiaId);
        depositoMercaderia.RaiseDomainEvent(new DepositoMercaderiaCreatedDomainEvent(depositoMercaderia.Id!, depositoId, mercaderiaId));

        return depositoMercaderia;
    }
}
