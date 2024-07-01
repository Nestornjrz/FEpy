using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEpy.Application.Abstractions.Messaging;
using FEpy.Domain.Entities.Personas;
using FEpy.Domain.Shared;

namespace FEpy.Application.Cqrs.Personas.GetPersonasByPagination
{
    public sealed record GetPersonasByPaginationQuery : SpecificationEntry, IQuery<PaginationResult<Persona, PersonaId>>
    {
        public string? Nombre { get; init; }
    }
}
