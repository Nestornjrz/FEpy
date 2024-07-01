# INFRASTRUCTURE, Comandos y paquetes

## Referenciar Application en Infrastructure
``` powershell
dotnet add .\backend\src\FEpy.Infrastructure\FEpy.Infrastructure.csproj reference .\backend\src\FEpy.Application\FEpy.Application.csproj
```

## Instalar paquetes necesarios

Hay que estar en la raiz del proyecto Infrastructure para instalar los paquetes necesarios.
no porque sea necesario, sino porque es más fácil. Asi no hace falta usar rutas largas o relativas 
para decirle a dotnet donde esta el proyecto.

``` powershell
dotnet add package Microsoft.Extensions.Configuration.Abstractions
```

Paquetes para manejar la base de datos

``` powershell
dotnet add package Microsoft.EntityFrameworkCore
```

``` powershell
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

``` powershell
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

## demas paquetes

``` powershell
dotnet add package Newtonsoft.Json
```

Paquete para agregar versionado a la API (no funciona para minimal APIs, para eso
se necesita otra paquete)

``` powershell
dotnet add package Asp.Versioning.Mvc
```

``` powershell
dotnet add package Asp.Versioning.Mvc.ApiExplorer
```

## Quartz

``` powershell
dotnet add package Quartz.Extensions.Hosting
```


