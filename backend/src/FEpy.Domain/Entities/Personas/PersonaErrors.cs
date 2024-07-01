using FEpy.Domain.Abstractions;

namespace FEpy.Domain.Entities.Personas;

public static class PersonaErrors
{
    public static Error NotFound = new(
        "Persona.NotFound",
        "No existe una persona con este id"
    );
    public static Error AlreadyExists = new(
       "Persona.AlreadyExists",
       "La persona ya existe en la base de datos"
   );
}
