using FEpy.Domain.Abstractions;

namespace FEpy.Domain.Entities.Personas.Especifications
{
    public class PersonaPaginationCountingSpecifications : BaseSpecification<Persona, PersonaId>
    {
        public PersonaPaginationCountingSpecifications(string search)
            : base(x => string.IsNullOrEmpty(search) || x.Nombre == new Nombre(search))
        {

        }
    }
}
