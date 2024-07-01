using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FEpy.Domain.Entities.Mercaderias;

namespace FEpy.Infrastructure.Configuration.Entities;

internal sealed class MercaderiaConfiguration : IEntityTypeConfiguration<Mercaderia>
{
    public void Configure(EntityTypeBuilder<Mercaderia> builder)
    {
        builder.ToTable("Mercaderias");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(m => m!.Value, v => new MercaderiaId(v));

        builder.Property(x => x.NombreMercaderia)
            .HasConversion(m => m!.Value, v => new NombreMercaderia(v))
            .HasMaxLength(50);

        builder.HasIndex(x => x.NombreMercaderia).IsUnique();
    }
}
