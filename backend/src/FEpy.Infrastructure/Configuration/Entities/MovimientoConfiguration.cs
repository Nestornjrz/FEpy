using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FEpy.Domain.Entities.Movimientos;
using FEpy.Domain.Entities.Depositos;
using FEpy.Domain.Entities.Mercaderias;
using FEpy.Domain.Entities.TiposDeMovimientos;

namespace FEpy.Infrastructure.Configuration.Entities;

internal class MovimientoConfiguration : IEntityTypeConfiguration<Movimiento>
{
    public void Configure(EntityTypeBuilder<Movimiento> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(
                movimientoId => movimientoId!.Value,
                value => new MovimientoId(value));

        builder.HasOne(x => x.Deposito)
          .WithMany()
          .HasForeignKey(x => x.DepositoId)
          .IsRequired();
        builder.HasOne(x => x.SocioDeNegocio)
            .WithMany()
            .HasForeignKey(x => x.SocioDeNegocioId)
            .IsRequired();
        builder.HasOne(x => x.Mercaderia)
            .WithMany()
            .HasForeignKey(x => x.MercaderiaId)
            .IsRequired();
        builder.HasOne(x => x.TipoDeMovimiento)
            .WithMany()
            .HasForeignKey(x => x.TipoDeMovimientoId)
            .IsRequired();

        builder.Property(x => x.DepositoId)
            .HasConversion(depositoId => depositoId!.Value, value => new DepositoId(value));

        builder.Property(x => x.SocioDeNegocioId)
            .HasConversion(socioDeNegocioId => socioDeNegocioId!.Value, value => new PersonaId(value));
        builder.Property(x => x.MercaderiaId)
            .HasConversion(mercaderiaId => mercaderiaId!.Value, value => new MercaderiaId(value));
        builder.Property(x => x.TipoDeMovimientoId)
            .HasConversion(tipoDeMovimientoId => tipoDeMovimientoId!.Value, value => new TipoDeMovimientoId(value));
        builder.Property(x => x.Observacion)
            .HasConversion(observacion => observacion!.Value, value => new Observacion(value));
        builder.Property(x => x.Valor)
            .HasConversion(valor => valor!.Value, value => new Valor(value));
        builder.Property(x => x.UnidadDeMedida)
            .HasConversion(unidadDeMedida => unidadDeMedida!.Value, value => new UnidadDeMedida(value));
    }
}
