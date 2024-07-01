using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FEpy.Domain.Entities.Supervisores;

namespace FEpy.Infrastructure.Configuration.Entities;

internal sealed class SupervisorConfiguration : IEntityTypeConfiguration<Supervisor>
{
    public void Configure(EntityTypeBuilder<Supervisor> builder)
    {
        builder.ToTable("Supervisores");
        builder.HasKey(x => x.Id);

        // Configura la propiedad Id como clave foránea que referencia a Persona.
        builder.HasOne(i => i.Persona)
            .WithOne()
            .HasForeignKey<Supervisor>(x => x.Id);

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
