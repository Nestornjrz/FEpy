using FEpy.Domain.Abstractions;

namespace FEpy.Domain.Entities.Mercaderias.Events;

public sealed record MercaderiaCreatedDomainEvent(MercaderiaId MercaderiaId, string NombreMercaderia) : IDomainEvent;