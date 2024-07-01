# APPLICATION, Comandos y paquetes

## Referenciar Domain en Application
``` powershell
dotnet add .\backend\src\FEpy.Application\FEpy.Application.csproj reference .\backend\src\FEpy.Domain\FEpy.Domain.csproj
```

# Instalar paquetes

Se tiene que estar en la raiz del proyecto FEpy.Application

``` powershell
dotnet add package MediatR
```

``` powershell
dotnet add package Serilog
```

``` powershell
dotnet add package Microsoft.Extensions.Logging.Abstractions
```

``` powershell
dotnet add package FluentValidation.DependencyInjectionExtensions
```


> Por el momento la autenticacion no voy a implementar porque la idea de que el
Frontend sea la que autentique