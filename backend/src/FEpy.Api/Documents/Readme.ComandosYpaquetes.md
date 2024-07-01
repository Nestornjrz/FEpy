# API, Comandos y paquetes

## Referencias

La capa de presentacion hace referencias a las siguientes capas

``` powershell
dotnet add .\FEpy.Api.csproj reference ..\..\..\backend\src\FEpy.Infrastructure\FEpy.Infrastructure.csproj
```

``` powershell
dotnet add .\FEpy.Api.csproj reference ..\..\..\backend\src\FEpy.Application\FEpy.Application.csproj
```

## Instalar paquetes

``` powershell
dotnet add package Microsoft.EntityFrameworkCore.Design
```

``` powershell
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

Paquete para cargar datos de prueba

``` powershell
dotnet add package Bogus
```
Paquete para manegar los logs
``` powershell
dotnet add package Serilog.AspNetCore
```

``` powershell
dotnet add package Serilog.Sinks.Seq
```





## Ejecutar la API 

Para que la migracion efectivamente impacte en la base de datos, debemos aplicarla
esto sucedera si ejecutamos la API pues en program.cs se encuentra la linea de codigo donde se llama al 
metodo de extension <code> await app.ApplyMigration();</code> que va a aplicar las migraciones pendientes.

``` powershell
 dotnet run --project .\FEpy.Api.csproj
 ```

 