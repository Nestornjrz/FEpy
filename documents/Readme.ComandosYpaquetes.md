# WarrantCaApp Comandos

## Info importante
Ver la version del .NET
``` powershell
dotnet --version
```

Ver todos los SDKs y runtimes instalados
``` powershell
dotnet --info
```

## Glogal.json

``` powershell
dotnet new globaljson --sdk-version 8.0.300 --force
```

El comando se utiliza para crear un nuevo archivo global.json en el directorio actual. 
Este archivo especifica la versión del SDK de .NET que se debe usar cuando se ejecutan 
comandos dotnet en el directorio del proyecto y sus subdirectorios.

- --sdk-version 8.0.300: Este parámetro especifica la versión exacta del SDK de .NET que se desea utilizar. En este caso, se está especificando la versión 8.0.300.
- --force: Este parámetro se utiliza para sobrescribir el archivo global.json 
existente en el directorio actual, si lo hay, sin pedir confirmación.

## Crear las capas de Clean Arquitecture

### Domain
Hay que estar en la raiz del proyecto donde esta el archivo .sln
``` powershell
dotnet new classlib -o .\backend\src\FEpy.Domain
```

Vincular con la solucion
``` powershell
dotnet sln add .\backend\src\FEpy.Domain\FEpy.Domain.csproj
```
Ver si todo esta bien
``` powershell
dotnet build
```

### Application
Hay que estar en la raiz del proyecto donde esta el archivo .sln
``` powershell
dotnet new classlib -o .\backend\src\FEpy.Application
```	

Vincular con la solucion
``` powershell
dotnet sln add .\backend\src\FEpy.Application\FEpy.Application.csproj
```

### Presentation
Hay que estar en la raiz del proyecto donde esta el archivo .sln
``` powershell
dotnet new webapi -o .\backend\src\FEpy.Api --name FEpy.Api
```

``` powershell
dotnet sln add .\backend\src\FEpy.Api\FEpy.Api.csproj
```

>Las capas Infracstructure y WebApi se crean y se vinculan a la SOLUCION de la misma forma que 
Domain y Application 

## Crear los proyectos de pruebas
``` powershell
dotnet new classlib -o .\test\CleanArchitecture\FEpy.Domain.UnitTests
```

``` powershell
dotnet new classlib -o .\test\CleanArchitecture\FEpy.Application.UnitTests
```

``` powershell
dotnet new classlib -o .\test\CleanArchitecture\FEpy.ArchitectureTests
```


## Asociar los proyectos de pruebas a la solución

``` powershell
 dotnet sln add .\test\CleanArchitecture\FEpy.Domain.UnitTests\FEpy.Domain.UnitTests.csproj
 ```

 ## Referencias 
 ``` powershell
 dotnet add .\test\CleanArchitecture\FEpy.Domain.UnitTests\FEpy.Domain.UnitTests.csproj reference .\src\FEpy.Domain\FEpy.Domain.csproj
 ```

 ## Compilar y publicar en modo Debug

 ``` powershell
dotnet build ./backend/src/FEpy.Api/FEpy.Api.csproj -c Debug
dotnet publish ./backend/src/FEpy.Api/FEpy.Api.csproj -c Debug -o out
```