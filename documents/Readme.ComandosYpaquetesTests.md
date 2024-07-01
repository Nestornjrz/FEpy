# Creacion de los test

## Domain

Crear la libreria

``` powershell
dotnet new classlib -o .\tests\backend\src\FEpy.Domain.UnitTests
```

Agregarlo a la solucion

``` powershell
 dotnet sln add .\tests\backend\src\FEpy.Domain.UnitTests\FEpy.Domain.UnitTests.csproj
```

Referenciar a Domain

``` powershell
dotnet add .\tests\backend\src\FEpy.Domain.UnitTests\FEpy.Domain.UnitTests.csproj reference .\backend\src\FEpy.Domain\FEpy.Domain.csproj
```

### Paquetes

Hay que estar en la raiz del proyecto Domain es decir en 
.\tests\backend\src\FEpy.Domain.UnitTests

``` powershell
dotnet add package xunit
```

``` powershell
dotnet add package xunit.runner.visualstudio
```

``` powershell
dotnet add package FluentAssertions
```

``` powershell
dotnet add package Microsoft.NET.Test.Sdk
```

```powershell
 dotnet add package coverlet.collector
 ```

## Application

``` powershell
dotnet new classlib -o .\tests\backend\src\FEpy.Application.UnitTests
```

## Architecture Tests

``` powershell
dotnet new classlib -o .\tests\backend\src\FEpy.ArchitectureTests
```

Agregarlo a la solucion

``` powershell
dotnet sln add .\tests\backend\src\FEpy.ArchitectureTests\FEpy.ArchitectureTests.csproj
```

Hay que referenciar tambien al proyecto Web.Api


### Paquetes

Los mismos paquetes que en el tests para Domain, pero 
hay un maquete mas

``` powershell
dotnet add package NetArchTest.Rules
```


## Integration Tests

``` powershell
dotnet new classlib -o .\tests\backend\src\FEpy.Application.IntegrationTests
```

## Funtional tests

``` powershell
dotnet new classlib -o .\tests\backend\src\FEpy.Api.FunctionalTests
```

# EJECUCION DE LOS TESTS

``` powershell
dotnet test .\WarrantCaApp.sln
```
