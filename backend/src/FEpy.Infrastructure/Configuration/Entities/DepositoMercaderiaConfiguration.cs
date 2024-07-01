using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FEpy.Domain.Entities.Depositos;
using FEpy.Domain.Entities.DepositosMercaderias;
using FEpy.Domain.Entities.Mercaderias;

namespace FEpy.Infrastructure.Configuration.Entities;

internal sealed class DepositoMercaderiaConfiguration : IEntityTypeConfiguration<DepositoMercaderia>
{
    public void Configure(EntityTypeBuilder<DepositoMercaderia> builder)
    {
        builder.ToTable("DepositosMercaderias");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(depositoMercaderiaId => depositoMercaderiaId!.Value, value => new DepositoMercaderiaId(value));

        builder.Property(x => x.DepositoId)
            .HasConversion(depositoId => depositoId!.Value, value => new DepositoId(value));

        builder.Property(x => x.MercaderiaId)
            .HasConversion(mercaderiaId => mercaderiaId!.Value, value => new MercaderiaId(value));

        builder.HasOne(x => x.Deposito)
            .WithMany(x => x.Mercaderias)
            .HasForeignKey(x => x.DepositoId)
            .IsRequired();

        builder.HasOne(x => x.Mercaderia)
            .WithMany(x => x.Depositos)
            .HasForeignKey(x => x.MercaderiaId)
            .IsRequired();

        builder.HasIndex(x => new { x.DepositoId, x.MercaderiaId }).IsUnique();
    }
}
