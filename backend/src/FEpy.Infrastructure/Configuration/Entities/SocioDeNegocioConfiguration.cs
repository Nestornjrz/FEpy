using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FEpy.Domain.Entities.SociosDeNegocios;

namespace FEpy.Infrastructure.Configuration.Entities
{
    internal sealed class SocioDeNegocioConfiguration : IEntityTypeConfiguration<SocioDeNegocio>
    {
        public void Configure(EntityTypeBuilder<SocioDeNegocio> builder)
        {
            builder.ToTable("SociosDeNegocios");
            builder.HasKey(x => x.Id);

            // Configura la propiedad Id como clave foránea que referencia a Persona.
            builder.HasOne(i => i.Persona)
                .WithOne()
                .HasForeignKey<SocioDeNegocio>(x => x.Id);

            builder.Property(x => x.Id)
                .HasConversion(inspectorId => inspectorId!.Value, value => new PersonaId(value));

            builder.Property(x => x.Ruc)
                .HasConversion(ruc => ruc!.Value, value => new Ruc(value))
                .HasMaxLength(10);

            // Agregar índice único para Ruc
            builder.HasIndex(x => x.Ruc).IsUnique();
        }
    }
}
