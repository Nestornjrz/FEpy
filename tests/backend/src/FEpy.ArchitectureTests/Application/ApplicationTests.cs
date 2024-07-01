using FEpy.Application.Abstractions.Messaging;
using FEpy.ArchitectureTests.Infrastructure;
using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace FEpy.ArchitectureTests.Application;

public class ApplicationTests : BaseTest
{

    [Fact]
    public void CommandHandler_Should_NotBePublic()
    {
        var resultados = Types.InAssembly(ApplicationAssembly)
        .That()
        .ImplementInterface(typeof(ICommandHandler<>))
        .Or()
        .ImplementInterface(typeof(ICommandHandler<,>))
        .Should()
        .NotBePublic()
        .GetResult();

        resultados.IsSuccessful.Should().BeTrue();
    }
    

    [Fact]
    public void QueryHandler_Should_NotBePublic()
    {
        var resultados = Types.InAssembly(ApplicationAssembly)
        .That()
        .ImplementInterface(typeof(IQueryHandler<,>))
        .Should()
        .NotBePublic()
        .GetResult();

        resultados.IsSuccessful.Should().BeTrue();
    }


}