# BACKEND

- Esta carpeta contiene el código fuente del backend de la aplicación.

- Esta aplicación está dividida en capas, siguiendo los delineamientos de la arquitectura limpia.
  - [Domain](src/FEpy.Domain/Readme.md)
  - [Application](src/FEpy.Application/Readme.md)
  - [Infrastructure](src/FEpy.Infrastructure/Readme.md)
  - [Presentation](src/FEpy.Api/Readme.md)
- Aunque la única capa que se ejecuta es la de presentación, se crean las demás capas para seguir las buenas prácticas de desarrollo.
- Cada capa tiene su propio archivo de inyección de dependencias.
(exepto DOMAIN, porque no carga ningun servicio en el contenedor de servicios)
  - [Application](src/FEpy.Application/DependencyInjection.cs)
  - [Infrastructure](src/FEpy.Infrastructure/DependencyInjection.cs)
  - [Presentation](src/FEpy.Api/DependencyInjection.cs)