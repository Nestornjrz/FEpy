using FEpy.Infrastructure.Outbox;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FEpy.Infrastructure.Configurations;

internal sealed class OutboxMessageConfiguration
: IEntityTypeConfiguration<OutboxMessage>
{
    public void Configure(EntityTypeBuilder<OutboxMessage> builder)
    {
        builder.ToTable("OutboxMessages");
        builder.HasKey(outboxMessage => outboxMessage.Id);

        builder.Property(OutboxMessage => OutboxMessage.Content)
        .HasColumnType("nvarchar(max)");

    }
}