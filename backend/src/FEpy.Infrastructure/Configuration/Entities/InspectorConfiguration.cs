using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FEpy.Domain.Entities.Inspectores;
using FEpy.Domain.Entities.Personas;

namespace FEpy.Infrastructure.Configuration.Entities
{
    internal sealed class InspectorConfiguration : IEntityTypeConfiguration<Inspector>
    {
        public void Configure(EntityTypeBuilder<Inspector> builder)
        {
            builder.ToTable("Inspectores");
            builder.HasKey(x => x.Id);

            // Configura la propiedad Id como clave foránea que referencia a Persona.
            builder.HasOne(i => i.Persona) 
                .WithOne()
                .HasForeignKey<Inspector>(x => x.Id);

            builder.Property(x => x.Id)
                .HasConversion(inspectorId => inspectorId!.Value, value => new PersonaId(value));

            builder.Property(x => x.Apellido)
                .HasConversion(apellido => apellido!.Value, value => new Apellido(value))
                .HasMaxLength(50);

            builder.Property(x => x.NumeroDeCedula)
                .HasConversion(numeroDeCedula => numeroDeCedula!.Value, value => new NumeroDeCedula(value))
                .HasMaxLength(50);

            // Agregar índice único para NumeroDeCedula
            builder.HasIndex(x => x.NumeroDeCedula)
                .IsUnique();
        }
    }
}
