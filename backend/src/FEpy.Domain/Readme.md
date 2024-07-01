# Ideas sobre esta capa *DOMAIN*

- Domain es la capa de negocio, la que contiene las entidades y las reglas de negocio.
- No tiene dependencias con otras capas, es decir, no depende de Application ni de Infrastructure.
- No se habla de claves primarias o foraneas, de relaciones entre las entidades, eso se deja para la capa de infraestructura.
- La capa Domain solo tiene la perspectiva desde el punto de vista del experto del negocio, es decir del dueño del negocio.
- No tiene la implementacion tecnica de como se va a guardar en la base de datos, eso se deja para la capa de infraestructura.
- Aqui estan todas las abstracciones necesarias para que el negocio funcione
segun las reglas de negocio del negocio, aqui esa por ejemplo la manera uniforme
en que se van a responder a las consultas mediante la API ([Result](Abstractions/Result.cs)).

>[!NOTE]
> Aqui estan por ejemplo, 
las entidades (entities, por ejemplo [Persona](Entities/Personas/Persona.cs)), 
los servicios de dominio, los eventos de dominio,
los objetos de valor (value objects), 
las especificaciones (specifications) (las especificaciones de paginado de Personas, por ejemplo 
[Persona Pagination Counting Specifications](Entities/Personas/Especifications/PersonaPaginationCountingSpecifications.cs))
, las interfaces de los respositorios (por ejemplo [IPersonaRepository](Entities/Personas/IPersonaRepository.cs))



[Readme.Comandos Ypaquetes](Readme.ComandosYpaquetes.md)