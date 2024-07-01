using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FEpy.Domain.Entities.Depositos;

namespace FEpy.Infrastructure.Configuration.Entities;

internal sealed class DepositoConfiguration : IEntityTypeConfiguration<Deposito>
{
    public void Configure(EntityTypeBuilder<Deposito> builder)
    {
        builder.ToTable("Depositos");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(depositoId => depositoId!.Value, value => new DepositoId(value));

        builder.Property(x => x.NombreDeposito)
            .HasConversion(nombreDeposito => nombreDeposito!.Value, value => new NombreDeposito(value))
            .HasMaxLength(70);

        builder.Property(x => x.DireccionDeposito)
            .HasConversion(direccionDeposito => direccionDeposito!.Value, value => new DireccionDeposito(value))
            .HasMaxLength(100);

        builder.Property(x => x.SupervisorId)
            .HasConversion(personaId => personaId!.Value, value => new PersonaId(value));

        builder.HasOne(d => d.Supervisor) // Utiliza la propiedad de navegación Supervisor en Deposito
            .WithMany(s => s.Depositos) // Utiliza la propiedad de navegación Depositos en Supervisor
            .HasForeignKey(d => d.SupervisorId) // Especifica la clave foránea en Deposito
            .IsRequired(false); // Indica que la clave foránea SupervisorId puede ser nula

        builder.HasIndex(x => x.NombreDeposito).IsUnique();
    }
}
