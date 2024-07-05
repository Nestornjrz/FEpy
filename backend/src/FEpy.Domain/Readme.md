# Ideas sobre esta capa *DOMAIN*

- Domain es la capa de negocio, la que contiene las entidades y la lógica de negocio.
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

<hr/>

# Conceptos fundamentales de esta capa

## Reglas de negocio

>[!IMPORTANT]
>Se refieren a las especificaciones o restricciones que dictan cómo se debe conducir el negocio. Estas reglas son las políticas y restricciones específicas que guían las operaciones de negocio, decisiones, y actividades. Por ejemplo, una regla de negocio podría ser que un cliente debe tener al menos 18 años de edad para abrir una cuenta bancaria. Las reglas de negocio son directrices que deben seguirse para cumplir con los requisitos del negocio.

- Este es el punto de partida. 
- Las reglas del negocio son definidas por los stakeholders o expertos en el dominio del negocio. 
- Estas reglas son esenciales para entender qué es lo que el sistema necesita hacer y cómo debe comportarse en diferentes situaciones.

## Logica de negocio

>[!IMPORTANT]
><b>Es la implementación técnica de las `reglas de negocio` dentro de un sistema </b>. 
Incluye el código y los algoritmos que aplican las reglas de negocio en la aplicación. La lógica de negocio toma las reglas de negocio y las traduce en código que puede ser ejecutado por la computadora para realizar tareas específicas, como validar la edad de un cliente o calcular el interés de una cuenta de ahorros. La lógica de negocio es más amplia que las reglas de negocio, ya que también puede incluir la lógica necesaria para orquestar cómo se procesan y se manejan los datos dentro de la aplicación, más allá de las restricciones directas impuestas por las reglas de negocio.

- Es el código que efectivamente aplica las reglas del negocio
-  Esta implementación se realiza típicamente en la capa de dominio de la arquitectura, asegurando que el núcleo de la aplicación sea robusto, testeable y fácil de mantener.

## Servicio de dominio

>[!IMPORTANT]
>Los servicios de dominio son una parte de la implementación de la lógica del negocio. Estos servicios encapsulan operaciones complejas del dominio que no pertenecen naturalmente a una entidad. Facilitan la interacción entre diferentes entidades y objetos de valor, y ejecutan operaciones significativas dentro del dominio. Los servicios de dominio toman las reglas y la lógica del negocio y las exponen a través de interfaces bien definidas, permitiendo que otras partes del sistema interactúen con el dominio de manera cohesiva y desacoplada.



>En resumen, La secuencia de "reglas del negocio" a "lógica del negocio" y finalmente a "servicios de dominio" refleja un proceso de abstracción y encapsulamiento que es fundamental en la arquitectura limpia. 



```mermaid
flowchart LR
    Reglas_de_negocio -->|Se implentan en| Logica_de_negocio -->|Se exponen a traves de| Servicio_de_dominio
```

<hr/>