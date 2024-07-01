using FEpy.Domain.Abstractions;
using FEpy.Domain.Entities.Depositos;
using FEpy.Domain.Entities.Personas;
using FEpy.Domain.Entities.Supervisores.Events;

namespace FEpy.Domain.Entities.Supervisores
{
    public sealed class Supervisor : Entity<PersonaId>
    {
        private Supervisor() { }

        private Supervisor(
            PersonaId id,
            Apellido? apellido,
            NumeroDeCedula numeroDeCedula) : base(id)
        {
            Apellido = apellido;
            NumeroDeCedula = numeroDeCedula;
        }
        public Apellido? Apellido { get; private set; }
        public NumeroDeCedula? NumeroDeCedula { get; private set; }

        #region navegacion
        // Propiedad de navegación hacia Persona (1:1)
        public Persona? Persona { get; set; }
        // Propiedad de navegación hacia Depositos (1:N)
        public List<Deposito> Depositos { get; private set; } = [];
        #endregion

        public static Supervisor Create(Nombre nombre, Apellido apellido, NumeroDeCedula numeroDeCedula)
        {
            var persona = Persona.Create(nombre);
            var supervisor = new Supervisor(persona.Id!, apellido, numeroDeCedula);
            supervisor.RaiseDomainEvent(
                new SupervisorCreatedDomainEvent(supervisor.Id!, apellido.Value, numeroDeCedula.Value)
            );
            return supervisor;
        }
    }
}
