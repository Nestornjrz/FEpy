using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using FEpy.Api.Utils;
using FEpy.Application.Cqrs.Personas.CreatePerson;
using FEpy.Application.Cqrs.Personas.GetPersona;
using FEpy.Application.Cqrs.Personas.GetPersonasByPagination;
using FEpy.Domain.Abstractions;
using FEpy.Domain.Entities.Personas;
using FEpy.Domain.Shared;

namespace FEpy.Api.Controllers.Personas
{
    [ApiController]
    //[ApiVersion(ApiVersions.V1, Deprecated = true)] para deprecar la version
    [ApiVersion(ApiVersions.V1)]
    [Route("api/v{version:apiVersion}/personas")]
    public class PersonasController : ControllerBase
    {
        private readonly ISender _sender;

        public PersonasController(ISender sender)
        {
            this._sender = sender;
        }

        [HttpGet("getPersona")]
        [MapToApiVersion(ApiVersions.V1)]
        [ProducesResponseType(typeof(Result<PersonaResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetPersonas([FromQuery] GetPersonaQuery persona)
        {
            var resultado = await _sender.Send(persona);
            return resultado.IsSuccess ? Ok(resultado.Value) : NotFound();
        }

        [HttpGet("getPagination")]
        [MapToApiVersion(ApiVersions.V1)]
        [ProducesResponseType(typeof(PaginationResult<Persona, PersonaId>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationResult<Persona, PersonaId>>> GetPaginationPersona(
        [FromQuery] GetPersonasByPaginationQuery request
    )
        {
            var result = await _sender.Send(request);
            return Ok(result);
        }

        [HttpPost("create")]
        [MapToApiVersion(ApiVersions.V1)]
        [ProducesResponseType(typeof(Result<Guid>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreatePersona([FromBody] CreatePersonRequest request)
        {
            var cmd = new CreatePersonCmd(request.Nombre);
            var resultado = await _sender.Send(cmd);
            return resultado.IsSuccess ? Ok(resultado.Value) : BadRequest(resultado.Error);
        }
    }
}
