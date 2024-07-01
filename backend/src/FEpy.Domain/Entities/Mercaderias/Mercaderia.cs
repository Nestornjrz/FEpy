using FEpy.Domain.Abstractions;
using FEpy.Domain.Entities.DepositosMercaderias;
using FEpy.Domain.Entities.Mercaderias.Events;

namespace FEpy.Domain.Entities.Mercaderias;

public sealed class Mercaderia : Entity<MercaderiaId>
{
    private Mercaderia() { }
    private Mercaderia(
        MercaderiaId id,
        NombreMercaderia nombreMercaderia
        ) : base(id)
    {
        NombreMercaderia = nombreMercaderia;
    }

    public NombreMercaderia? NombreMercaderia { get; private set; }

    #region NAVEGACION
    public List<DepositoMercaderia> Depositos { get; private set; } = new();
    #endregion

    public static Mercaderia Create(NombreMercaderia nombre)
    {
        var mercaderia = new Mercaderia(MercaderiaId.New(), nombre);
        mercaderia.RaiseDomainEvent(new MercaderiaCreatedDomainEvent(mercaderia.Id!, nombre.Value));

        return mercaderia;
    }
}
