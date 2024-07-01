using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEpy.Application.Abstractions.Messaging;
using FEpy.Domain.Abstractions;
using FEpy.Domain.Entities.Personas;
using FEpy.Domain.Entities.Personas.Especifications;
using FEpy.Domain.Shared;

namespace FEpy.Application.Cqrs.Personas.GetPersonasByPagination
{
    internal class GetPersonasByPaginationQueryHandler : IQueryHandler<GetPersonasByPaginationQuery, PaginationResult<Persona, PersonaId>>
    {
        private readonly IPersonaRepository _personaRepository;

        public GetPersonasByPaginationQueryHandler(IPersonaRepository personaRepository)
        {
            this._personaRepository = personaRepository;
        }
        public async Task<Result<PaginationResult<Persona, PersonaId>>> Handle(
            GetPersonasByPaginationQuery request,
            CancellationToken cancellationToken)
        {
            var spec = new PersonaPaginationSpecifications(
            request.Sort!,
            request.PageIndex,
            request.PageSize,
            request.Nombre!
        );

            var records = await _personaRepository.GetAllWithSpec(spec);
            var specCount = new PersonaPaginationCountingSpecifications(request.Nombre!);
            var totalRecords = await _personaRepository.CountAsync(specCount);
            var rounded = Math.Ceiling(Convert.ToDecimal(totalRecords) / Convert.ToDecimal(request.PageSize));
            var totalPages = Convert.ToInt32(rounded);
            var recordsByPage = records.Count();
            return new PaginationResult<Persona, PersonaId>
            {
                Count = totalRecords,
                Data = records.ToList(),
                PageCount = totalPages,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                ResultByPage = recordsByPage
            };
        }
    }
}
