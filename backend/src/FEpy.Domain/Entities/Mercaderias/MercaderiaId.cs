namespace FEpy.Domain.Entities.Mercaderias;

public sealed record MercaderiaId(Guid Value)
{
    public static MercaderiaId New() => new(Guid.NewGuid());
}