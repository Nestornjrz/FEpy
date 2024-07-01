# BACKEND

- Esta carpeta contiene el c�digo fuente del backend de la aplicaci�n.

- Esta aplicaci�n est� dividida en capas, siguiendo los delineamientos de la arquitectura limpia.
  - [Domain](src/FEpy.Domain/Readme.md)
  - [Application](src/FEpy.Application/Readme.md)
  - [Infrastructure](src/FEpy.Infrastructure/Readme.md)
  - [Presentation](src/FEpy.Api/Readme.md)
- Aunque la �nica capa que se ejecuta es la de presentaci�n, se crean las dem�s capas para seguir las buenas pr�cticas de desarrollo.
- Cada capa tiene su propio archivo de inyecci�n de dependencias.
(exepto DOMAIN, porque no carga ningun servicio en el contenedor de servicios)
  - [Application](src/FEpy.Application/DependencyInjection.cs)
  - [Infrastructure](src/FEpy.Infrastructure/DependencyInjection.cs)
  - [Presentation](src/FEpy.Api/DependencyInjection.cs)