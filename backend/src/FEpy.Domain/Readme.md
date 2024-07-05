# Ideas sobre esta capa *DOMAIN*

- Domain es la capa de negocio, la que contiene las entidades y la l�gica de negocio.
- No tiene dependencias con otras capas, es decir, no depende de Application ni de Infrastructure.
- No se habla de claves primarias o foraneas, de relaciones entre las entidades, eso se deja para la capa de infraestructura.
- La capa Domain solo tiene la perspectiva desde el punto de vista del experto del negocio, es decir del due�o del negocio.
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
>Se refieren a las especificaciones o restricciones que dictan c�mo se debe conducir el negocio. Estas reglas son las pol�ticas y restricciones espec�ficas que gu�an las operaciones de negocio, decisiones, y actividades. Por ejemplo, una regla de negocio podr�a ser que un cliente debe tener al menos 18 a�os de edad para abrir una cuenta bancaria. Las reglas de negocio son directrices que deben seguirse para cumplir con los requisitos del negocio.

- Este es el punto de partida. 
- Las reglas del negocio son definidas por los stakeholders o expertos en el dominio del negocio. 
- Estas reglas son esenciales para entender qu� es lo que el sistema necesita hacer y c�mo debe comportarse en diferentes situaciones.

## Logica de negocio

>[!IMPORTANT]
><b>Es la implementaci�n t�cnica de las `reglas de negocio` dentro de un sistema </b>. 
Incluye el c�digo y los algoritmos que aplican las reglas de negocio en la aplicaci�n. La l�gica de negocio toma las reglas de negocio y las traduce en c�digo que puede ser ejecutado por la computadora para realizar tareas espec�ficas, como validar la edad de un cliente o calcular el inter�s de una cuenta de ahorros. La l�gica de negocio es m�s amplia que las reglas de negocio, ya que tambi�n puede incluir la l�gica necesaria para orquestar c�mo se procesan y se manejan los datos dentro de la aplicaci�n, m�s all� de las restricciones directas impuestas por las reglas de negocio.

- Es el c�digo que efectivamente aplica las reglas del negocio
-  Esta implementaci�n se realiza t�picamente en la capa de dominio de la arquitectura, asegurando que el n�cleo de la aplicaci�n sea robusto, testeable y f�cil de mantener.

## Servicio de dominio

>[!IMPORTANT]
>Los servicios de dominio son una parte de la implementaci�n de la l�gica del negocio. Estos servicios encapsulan operaciones complejas del dominio que no pertenecen naturalmente a una entidad. Facilitan la interacci�n entre diferentes entidades y objetos de valor, y ejecutan operaciones significativas dentro del dominio. Los servicios de dominio toman las reglas y la l�gica del negocio y las exponen a trav�s de interfaces bien definidas, permitiendo que otras partes del sistema interact�en con el dominio de manera cohesiva y desacoplada.



>En resumen, La secuencia de "reglas del negocio" a "l�gica del negocio" y finalmente a "servicios de dominio" refleja un proceso de abstracci�n y encapsulamiento que es fundamental en la arquitectura limpia. 



```mermaid
flowchart LR
    Reglas_de_negocio -->|Se implentan en| Logica_de_negocio -->|Se exponen a traves de| Servicio_de_dominio
```

<hr/>