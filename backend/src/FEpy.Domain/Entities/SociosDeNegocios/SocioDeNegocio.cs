using FEpy.Domain.Abstractions;
using FEpy.Domain.Entities.DepositosSociosDeNegocios;
using FEpy.Domain.Entities.Personas;
using FEpy.Domain.Entities.SociosDeNegocios.Events;

namespace FEpy.Domain.Entities.SociosDeNegocios;

public sealed class SocioDeNegocio : Entity<PersonaId>
{
    private SocioDeNegocio() { }

    private SocioDeNegocio(
        PersonaId id,
        Ruc ruc
    ) : base(id)
    {
        Ruc = ruc;
    }
    public Ruc? Ruc { get; private set; }
    #region NAVEGACION
    // Propiedad de navegación hacia Persona
    public Persona? Persona { get; private set; }

    public List<DepositoSocioDeNegocio> Depositos { get; private set; } = [];
    #endregion
    public static SocioDeNegocio Create(Nombre nombre, Ruc ruc)
    {
        var persona = Persona.Create(nombre);
        var socio = new SocioDeNegocio(persona.Id!, ruc);
        socio.RaiseDomainEvent(new SocioDeNegocioCreatedDomainEvent(socio.Id!, ruc.Value));
        return socio;
    }
}
