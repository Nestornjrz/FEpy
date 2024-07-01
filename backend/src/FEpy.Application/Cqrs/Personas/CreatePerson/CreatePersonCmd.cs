using FEpy.Application.Abstractions.Messaging;

namespace FEpy.Application.Cqrs.Personas.CreatePerson
{
    public sealed record CreatePersonCmd(string Nombre) : ICommand<Guid>;
}
