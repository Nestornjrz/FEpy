using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using FEpy.Application.Abstractions.Clock;
using FEpy.Application.Exceptions;
using FEpy.Domain.Abstractions;
using FEpy.Domain.Entities.Inspectores;
using FEpy.Domain.Entities.Personas;
using FEpy.Infrastructure.Outbox;

namespace FEpy.Infrastructure;

public sealed class ApplicationDbContext : DbContext, IUnitOfWork
{
    private static readonly JsonSerializerSettings jsonSerializerSettings = new()
    {
        TypeNameHandling = TypeNameHandling.All
    };
    private readonly IDateTimeProvider dateTimeProvider;

    public ApplicationDbContext(
        DbContextOptions options,
        IDateTimeProvider dateTimeProvider)
        : base(options)
    {
        this.dateTimeProvider = dateTimeProvider;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(
       CancellationToken cancellationToken = default
       )
    {
        try
        {
            AddDomainEventsToOutboxMessages();
            var result = await base.SaveChangesAsync(cancellationToken);


            return result;
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new ConcurrencyException("La excepcion por concurrencia se disparo", ex);
        }
    }

    private void AddDomainEventsToOutboxMessages()
    {
        var outboxMessages = ChangeTracker
            .Entries<IEntity>()
            .Select(entry => entry.Entity)
            .SelectMany(entity =>
            {
                var domainEvents = entity.GetDomainEvents();
                entity.ClearDomainEvents();
                return domainEvents;
            }).Select(domainEvent => new OutboxMessage(
                 Guid.NewGuid(),
                 dateTimeProvider.currentTime,
                 domainEvent.GetType().Name,
                 JsonConvert.SerializeObject(domainEvent, jsonSerializerSettings)
              )).ToList();

        AddRange(outboxMessages);
    }
}
