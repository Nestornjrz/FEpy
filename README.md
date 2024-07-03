# Ideas sobre la aplicacion

- Utiliza [Clean Architecture](https://learn.microsoft.com/es-es/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#clean-architecture)
- Esta separada en capas, 4 capas
  - [Domain](backend/src/FEpy.Domain/Readme.md)
  - [Application](backend/src/FEpy.Application/Readme.md)
  - [Infrastructure](backend/src/FEpy.Infrastructure/Readme.md)
  - [WebApi](backend/src/FEpy.Api/Readme.md)
- En esta aplicacion se utiliza principalemente tecnologias de Microsoft
	- [.NET](https://dotnet.microsoft.com/es-es/) 8
	- [.AspNet Core](https://learn.microsoft.com/es-es/aspnet/core/?view=aspnetcore-8.0&WT.mc_id=dotnet-35129-website) 8
	- Paquetes nuget
	  - Entity Framework Core
	  - SQL Server
	  - Swagger
	  - AutoMapper
	  - FluentValidation
	  - MediatR
	  - Serilog
	  - xUnit
	  - Moq
	  - FluentAssertions
	  - Bogus

# COMO ARRANCAR
Si tienes una instancia de SQL Server en tu maquina local.
Ejecuta el siguiente comando en la Raiz del FEpy.Api
``` powershell
dotnet run --project .\FEpy.Api.csproj
```

>[!NOTE]
> Puedes ir a la appsettings.json de la capa de presentacion es decir en `backend\src\Warrant.Api\appsettings.json`
para ver el nombre de la cadena de conexion y cambiarlo si es necesario.

Si tienes Docker y tienes activado el WSL2
Ejecuta el siguiente comando en la Raiz de la solucion
``` powershell
docker compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d
```

# Tabla de Contenido

Esta tabla es un indice de los documentos que se encuentran en la carpeta `documents`
con esto pretendo que sea mas facil encontrar la informacion que se necesita y 
los comandos o configuraciones que se han usado para crear la aplicacion.

| README       | DESCRIPCION |
|--------------|--------------|
|[Readme.ComandosYpaquetes](documents/Readme.ComandosYpaquetes.md) | Casi todos los Comandos y paquetes usados para crear la aplicacion |
|[Docker](documents/Readme.Docker.md)| Comandos relacionados a Docker |
|[DockerCompose](documents/Readme.DockerCompose.md)| Comandos relacionados al DockerCompose |
|[Github](documents/Readme.Git.md)| Comandos relacionados a Git |
|[DockerCompose](documents/Readme.DockerCompose.md)| Explicacion del docker-compose.yml |
|[WSL2](documents/Readme.Wsl.md)| Comandos relacionados a WSL2 |

>[!IMPORTANT]
>En la capa de dominio, las entidades que coloque son de ejemplo,
no estan todavia relacionadas a la Facturación electrónica.
Los coloque para que se vea como funciona la arquitectura limpia en lo que respecta
a las entidades (Que se transforman en tablas al migrar).
Asi se puede ver donde estan las entidades (CAPA DE DOMINIO) y las configuraciones 
de las entidades (CAPA DE INFRAESTRUCTURA)