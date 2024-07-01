using Microsoft.EntityFrameworkCore;
using FEpy.Domain.Entities.Personas;

namespace FEpy.Infrastructure.Repositories.Entities
{
    internal sealed class PersonaRepository : Repository<Persona, PersonaId>, IPersonaRepository
    {
        public PersonaRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsUserExistAsync(Nombre nombre, CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<Persona>().AnyAsync(x => x.Nombre == nombre);
        }
    }
}
