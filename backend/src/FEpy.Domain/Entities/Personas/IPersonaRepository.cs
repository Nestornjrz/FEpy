using FEpy.Domain.Abstractions;

namespace FEpy.Domain.Entities.Personas;

public interface IPersonaRepository
{
    Task <Persona?> GetByIdAsync(PersonaId id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Persona>> GetAllWithSpec(ISpecification<Persona, PersonaId> spec);

    Task<int> CountAsync(ISpecification<Persona, PersonaId> spec);
    Task<bool> IsUserExistAsync(Nombre nombre, CancellationToken cancellationToken = default);
    void Add(Persona persona);
}
