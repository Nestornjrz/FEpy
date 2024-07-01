using FEpy.Domain.Abstractions;

namespace FEpy.Domain.Entities.Personas;
public sealed class Persona: Entity<PersonaId>
{
    private Persona() { }

    private Persona(PersonaId id, Nombre nombre) : base(id)
    {
        Nombre = nombre;
    }

    public Nombre? Nombre { get; private set; }

    public static Persona Create(Nombre nombre)
    {
        var persona = new Persona(PersonaId.New(), nombre);
        persona.RaiseDomainEvent(new PersonaCreatedDomainEvent(persona.Id!, nombre.Value));
        return persona;
    }
}