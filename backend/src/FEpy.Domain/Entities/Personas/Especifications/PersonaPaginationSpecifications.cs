using FEpy.Domain.Abstractions;

namespace FEpy.Domain.Entities.Personas.Especifications;

public class PersonaPaginationSpecifications : BaseSpecification<Persona, PersonaId>
{
    public PersonaPaginationSpecifications(
        string sort,
        int pageIndex,
        int pageSize,
        string search
        ) : base(x => string.IsNullOrEmpty(search) || x.Nombre == new Nombre(search))
    {
        ApplyPaging(pageSize * (pageIndex - 1), pageSize);
        if (!string.IsNullOrEmpty(sort))
        {
            switch (sort)
            {
                case "nombreAsc": AddOrderBy(x => x.Nombre!); break;
                case "nombreDesc": AddOrderByDescending(x => x.Nombre!); break;
                default: AddOrderBy(x => x.Nombre!); break;
            }
        }
        else
        {
            AddOrderBy(x => x.Nombre!);
        }
    }
}
