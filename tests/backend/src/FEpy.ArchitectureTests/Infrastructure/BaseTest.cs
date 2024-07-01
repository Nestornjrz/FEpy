using System.Configuration;
using System.Reflection;
using FEpy.Application.Abstractions.Messaging;
using FEpy.Domain.Abstractions;
using FEpy.Infrastructure;

namespace FEpy.ArchitectureTests.Infrastructure;

public class BaseTest
{
    protected static readonly Assembly DomainAssembly = typeof(IEntity).Assembly;
    protected static readonly Assembly ApplicationAssembly = typeof(IBaseCommand).Assembly;
    protected static readonly Assembly InfrastructureAssembly = typeof(ApplicationDbContext).Assembly;
    protected static readonly Assembly PresentationAssembly = typeof(Program).Assembly;
}