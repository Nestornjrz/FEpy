using MediatR;
using FEpy.Application.Abstractions.Email;
using FEpy.Domain.Entities.Personas;

namespace FEpy.Application.Cqrs.Personas.CreatePerson;

internal sealed class PersonaCreatedDomainEventHandler : INotificationHandler<PersonaCreatedDomainEvent>
{
    private readonly IPersonaRepository _userRepository;
    private readonly IEmailService _emailService;

    public PersonaCreatedDomainEventHandler(IPersonaRepository userRepository, IEmailService emailService)
    {
        _userRepository = userRepository;
        _emailService = emailService;
    }

    public async Task Handle(PersonaCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var persona = await _userRepository.GetByIdAsync(notification.PersonaId, cancellationToken);
        if(persona is null)
        {
            throw new InvalidOperationException("Persona not found");
        }

        _emailService.Send(
            "nestor@gicaldev.com.py",
            "Welcome", 
            $"Welcome to our platform {persona.Nombre}");
    }
}
