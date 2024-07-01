using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FEpy.Domain.Entities.Depositos;
using FEpy.Domain.Entities.DepositosSociosDeNegocios;

namespace FEpy.Infrastructure.Configuration.Entities;

internal sealed class DepositoSocioDeNegocioConfiguration : IEntityTypeConfiguration<DepositoSocioDeNegocio>
{
    public void Configure(EntityTypeBuilder<DepositoSocioDeNegocio> builder)
    {
        builder.ToTable("DepositosSociosDeNegocios");
        builder.HasKey(x => x.Id);

        builder.HasOne(dsn => dsn.Deposito)
            .WithMany(d => d.SociosDeNegocios)
            .HasForeignKey(dsn => dsn.DepositoId)
            .IsRequired();

        builder.HasOne(dsn => dsn.SocioDeNegocio)
            .WithMany(s => s.Depositos)
            .HasForeignKey(dsn => dsn.SocioDeNegocioId)
            .IsRequired();

        builder.Property(x => x.Id)
            .HasConversion(depositoSocioDeNegocioId => depositoSocioDeNegocioId!.Value, value => new DepositoSocioDeNegocioId(value));

        builder.Property(x => x.DepositoId)
            .HasConversion(depositoId => depositoId!.Value, value => new DepositoId(value));

        builder.Property(x => x.SocioDeNegocioId)
            .HasConversion(socioDeNegocioId => socioDeNegocioId!.Value, value => new PersonaId(value));

        builder.HasIndex(x => new { x.DepositoId, x.SocioDeNegocioId }).IsUnique();
    }
}
