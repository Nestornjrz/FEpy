namespace FEpy.Domain.Entities.DepositosSociosDeNegocios;

public sealed record DepositoSocioDeNegocioId(Guid Value)
{
    public static DepositoSocioDeNegocioId New() => new(Guid.NewGuid());
}