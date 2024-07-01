# Migraciones

Para poder ejecutar las migraciones necesitamos instalar las herramientas de EF Core.
Vemos si tenemos instaladas las herramientas de EF Core

``` powershell
  dotnet ef --version
```

Si no las tenemos instaladas, las instalamos

``` powershell
  dotnet tool install --global dotnet-ef
```

### Primera migracion

``` powershell
 dotnet ef --verbose migrations add InitialCreate -p ..\FEpy.Infrastructure\ -s .\
 ```

* __dotnet ef:__ Este es el comando principal que se utiliza para interactuar con Entity Framework Core desde la línea de comandos.
*  __--verbose:__ Esta es una opción que indica que se debe proporcionar una salida detallada en la línea de comandos. Esto puede ser útil para la depuración.
* __migrations add:__ Este es el comando que se utiliza para agregar una nueva migración a tu proyecto. En este caso, estás agregando una migración llamada "InitialCreate".
* __InitialCreate:__ Este es el nombre de la migración que estás creando. Es una buena práctica darle a tus migraciones nombres descriptivos que indiquen qué cambios se están realizando en la base de datos.
* __-p ..\FEpy.Infrastructure\:__ La opción -p o --project se utiliza para especificar *<u>el proyecto que contiene el DbContext</u>*. En este caso, estás especificando que el proyecto se encuentra en el directorio ..\FEpy.Infrastructure\.
* __-s .\: La opción -s o --startup-project__ se utiliza para especificar el proyecto de inicio. Este es el proyecto que se ejecuta si tu proyecto DbContext está en un proyecto de biblioteca de clases y no puede ejecutarse por sí mismo. En este caso, estás especificando que el proyecto de inicio se encuentra en el directorio actual (.\).

>[!NOTE]
>En resumen, este comando está creando una nueva migración llamada "InitialCreate" en el 
proyecto ubicado en ..\FEpy.Infrastructure\, y está utilizando el proyecto en el 
directorio actual como el proyecto de inicio. Además, está proporcionando una salida 
detallada en la línea de comandos gracias a la opción <code>--verbose</code>.