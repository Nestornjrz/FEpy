using FEpy.Application.Abstractions.Messaging;
using FEpy.Domain.Abstractions;
using FEpy.Domain.Entities.Personas;

namespace FEpy.Application.Cqrs.Personas.CreatePerson
{
    internal class CreatePersonCmdHandler : ICommandHandler<CreatePersonCmd, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPersonaRepository _personaRepository;

        public CreatePersonCmdHandler(IUnitOfWork unitOfWork, IPersonaRepository personaRepository)
        {
            _unitOfWork = unitOfWork;
            _personaRepository = personaRepository;
        }

        public async Task<Result<Guid>> Handle(CreatePersonCmd request, CancellationToken cancellationToken)
        {
            // Validar si existe una persona con el mismo nombre
            var personaExists = await _personaRepository.IsUserExistAsync(new Nombre(request.Nombre));
            if (personaExists)
            {
                return Result.Failure<Guid>(PersonaErrors.AlreadyExists);
            }
            // Crear objeto persona
            var persona = Persona.Create(new Nombre(request.Nombre));
            // Insertar persona en el DbContext
            _personaRepository.Add(persona);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return persona.Id!.Value;
        }
    }
}
