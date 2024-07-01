using FEpy.Domain.Abstractions;
using FEpy.Domain.Entities.DepositosInspectores;
using FEpy.Domain.Entities.Inspectores.Events;
using FEpy.Domain.Entities.Personas;

namespace FEpy.Domain.Entities.Inspectores
{
    public sealed class Inspector : Entity<PersonaId>
    {
        private Inspector() { }

        private Inspector(
            PersonaId id,
            Apellido? apellido,
            NumeroDeCedula numeroDeCedula) : base(id)
        {
            Apellido = apellido;
            NumeroDeCedula = numeroDeCedula;
        }
        public Apellido? Apellido { get; private set; }
        public NumeroDeCedula? NumeroDeCedula { get; private set; }
        public bool Activo { get; private set; } = true;

        #region NAVEGACION
        // Propiedad de navegación hacia Persona
        public Persona? Persona { get; set; }
        public List<DepositoInspector> Depositos { get; private set; } = [];
        #endregion

        public static Inspector Create(Nombre nombre, Apellido apellido, NumeroDeCedula numeroDeCedula)
        {
            var persona = Persona.Create(nombre);
            var inspector = new Inspector(persona.Id!, apellido, numeroDeCedula);
            inspector.RaiseDomainEvent(
                new InspectorCreatedDomainEvent(inspector.Id!, apellido.Value, numeroDeCedula.Value, true)
            );
            return inspector;
        }
    }
}
