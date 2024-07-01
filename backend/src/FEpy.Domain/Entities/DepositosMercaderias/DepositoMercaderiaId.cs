namespace FEpy.Domain.Entities.DepositosMercaderias;

public sealed record DepositoMercaderiaId(Guid Value)
{
    public static DepositoMercaderiaId New() => new(Guid.NewGuid());
}
