namespace FEpy.Domain.Entities.Depositos;

public record DepositoId(Guid Value)
{
    public static DepositoId New() => new(Guid.NewGuid());
}
