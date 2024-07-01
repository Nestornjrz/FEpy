using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FEpy.Domain.Entities.TiposDeMovimientos;

namespace FEpy.Infrastructure.Configuration.Entities;

internal sealed class TipoDeMovimientoConfiguration : IEntityTypeConfiguration<TipoDeMovimiento>
{
    public void Configure(EntityTypeBuilder<TipoDeMovimiento> builder)
    {
        builder.ToTable("TiposDeMovimientos");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(tipoDeMovimientoId => tipoDeMovimientoId!.Value, value => new TipoDeMovimientoId(value));

        builder.Property(x => x.NombreTipoMovimiento)
            .HasConversion(nombreTipoMovimiento => nombreTipoMovimiento!.Value, value => new NombreTipoMovimiento(value))
            .HasMaxLength(50);

        builder.HasIndex(x => x.NombreTipoMovimiento).IsUnique();

        builder.HasData(
            TipoDeMovimiento.Create(1,new NombreTipoMovimiento("Entrada")),
            TipoDeMovimiento.Create(2,new NombreTipoMovimiento("Salida")),
            TipoDeMovimiento.Create(3,new NombreTipoMovimiento("SinMovimiento")),
            TipoDeMovimiento.Create(4,new NombreTipoMovimiento("Ajuste"))
        );
    }
}
