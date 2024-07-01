namespace FEpy.Domain.Entities.DepositosInspectores;

public record DepositoInspectorId(Guid Value)
{
    public static DepositoInspectorId New() => new(Guid.NewGuid());
}
