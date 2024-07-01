using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FEpy.Domain.Entities.Personas;

namespace FEpy.Infrastructure.Configuration.Entities;

internal sealed class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.ToTable("Personas");
        builder.HasKey(persona => persona.Id);

        builder.Property(persona => persona.Id)
            .HasConversion(id => id!.Value, value => new PersonaId(value));

        builder.Property(persona => persona.Nombre)
            .HasConversion(nombre => nombre!.Value, value => new Nombre(value))
            .HasMaxLength(50);

    }
}
