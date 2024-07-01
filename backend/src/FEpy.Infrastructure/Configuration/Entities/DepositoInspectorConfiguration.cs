using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FEpy.Domain.Entities.Depositos;
using FEpy.Domain.Entities.DepositosInspectores;

namespace FEpy.Infrastructure.Configuration.Entities;

internal sealed class DepositoInspectorConfiguration : IEntityTypeConfiguration<DepositoInspector>
{
    public void Configure(EntityTypeBuilder<DepositoInspector> builder)
    {
        builder.ToTable("DepositosInspectores");
        builder.HasKey(x => x.Id);

        builder.HasOne(di => di.Deposito)
            .WithMany(d => d.Inspectores)
            .HasForeignKey(di => di.DepositoId)
            .IsRequired();

        builder.HasOne(di => di.Inspector)
            .WithMany(i => i.Depositos)
            .HasForeignKey(di => di.InspectorId)
            .IsRequired();

        builder.Property(x => x.Id)
            .HasConversion(depositoInspectorId => depositoInspectorId!.Value, value => new DepositoInspectorId(value));

        builder.Property(x => x.DepositoId)
            .HasConversion(depositoId => depositoId!.Value, value => new DepositoId(value));

        builder.Property(x => x.InspectorId)
            .HasConversion(inspectorId => inspectorId!.Value, value => new PersonaId(value));

        builder.HasIndex(x => new { x.DepositoId, x.InspectorId }).IsUnique();
    }
}