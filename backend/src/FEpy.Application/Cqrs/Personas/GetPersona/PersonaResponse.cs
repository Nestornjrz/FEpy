namespace FEpy.Application.Cqrs.Personas.GetPersona
{
    public class PersonaResponse
    {
        public Guid Id { get; init; }
        public string? Nombre { get; init; }
    }
}