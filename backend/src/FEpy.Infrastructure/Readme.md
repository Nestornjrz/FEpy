# Ideas sobre esta capa *INFRASTRUCTURE*

- Aqui se implementan las interfaces definidas en el proyecto FEpy.Domain, es decir, aqui si
 se habla de claves primarias, foraneas, relaciones entre entidades, etc.
 - Aqui se agregan componentes que agregan funcionalidades tecnicas a las entidades que definimos en la capa FEpy.Domain
 - Aqui se configuran las entidades para que se mapeen a tablas en la base de datos.
 - Aqui esta el *<u>DbContext</u>* que se encarga de la conexion con la base de datos y de mapear las entidades a tablas en la base de datos.

 >[!NOTE]
 > En resumen tiene todo lo necesario para comunicarse con sistemas externos,
 como son las bases de datos, enviar correos, etc 

[Readme.ComandosYpaquetes](Readme.ComandosYpaquetes.md)