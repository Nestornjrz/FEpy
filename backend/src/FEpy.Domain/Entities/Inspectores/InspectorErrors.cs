using FEpy.Domain.Abstractions;

namespace FEpy.Domain.Entities.Inspectores
{
    public static class InspectorErrors
    {
        public static Error NotFound = new(
            "Inspector.NotFound",
            "No existe un inspector con este id"
        );
        public static Error AlreadyExists = new(
           "Inspector.AlreadyExists",
           "El inspector ya existe en la base de datos"
       );
    }
}
