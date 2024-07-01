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

* __dotnet ef:__ Este es el comando principal que se utiliza para interactuar con Entity Framework Core desde la l�nea de comandos.
*  __--verbose:__ Esta es una opci�n que indica que se debe proporcionar una salida detallada en la l�nea de comandos. Esto puede ser �til para la depuraci�n.
* __migrations add:__ Este es el comando que se utiliza para agregar una nueva migraci�n a tu proyecto. En este caso, est�s agregando una migraci�n llamada "InitialCreate".
* __InitialCreate:__ Este es el nombre de la migraci�n que est�s creando. Es una buena pr�ctica darle a tus migraciones nombres descriptivos que indiquen qu� cambios se est�n realizando en la base de datos.
* __-p ..\FEpy.Infrastructure\:__ La opci�n -p o --project se utiliza para especificar *<u>el proyecto que contiene el DbContext</u>*. En este caso, est�s especificando que el proyecto se encuentra en el directorio ..\FEpy.Infrastructure\.
* __-s .\: La opci�n -s o --startup-project__ se utiliza para especificar el proyecto de inicio. Este es el proyecto que se ejecuta si tu proyecto DbContext est� en un proyecto de biblioteca de clases y no puede ejecutarse por s� mismo. En este caso, est�s especificando que el proyecto de inicio se encuentra en el directorio actual (.\).

>[!NOTE]
>En resumen, este comando est� creando una nueva migraci�n llamada "InitialCreate" en el 
proyecto ubicado en ..\FEpy.Infrastructure\, y est� utilizando el proyecto en el 
directorio actual como el proyecto de inicio. Adem�s, est� proporcionando una salida 
detallada en la l�nea de comandos gracias a la opci�n <code>--verbose</code>.