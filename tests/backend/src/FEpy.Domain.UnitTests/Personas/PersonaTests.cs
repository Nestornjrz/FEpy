using FluentAssertions;
using FEpy.Domain.Entities.Personas;
using FEpy.Domain.UnitTests.Infrastructure;
using Xunit;

namespace FEpy.Domain.UnitTests.Personas
{
    public class PersonaTests: BaseTest
    {
        [Fact]
        public void Create_Should_SetPropertyValues()
        {
            // Arrange -> Mock de persona

            // Act
            var persona = Persona.Create(PersonaMock.Nombre);
            // Assert
            persona.Nombre.Should().Be(PersonaMock.Nombre);
        }

        [Fact]
        public void Create_Should_RaiseDomainEvent()
        {
            // Arrange

            // Act
            var persona = Persona.Create(PersonaMock.Nombre);

            //var domainEvent = persona.GetDomainEvents().OfType<PersonaCreatedDomainEvent>().Single();

            var domainEvent = AssertDomainEventWasPublished<PersonaCreatedDomainEvent>(persona);
            // Assert
            domainEvent.PersonaId.Should().Be(persona.Id);
        }
    }

}
