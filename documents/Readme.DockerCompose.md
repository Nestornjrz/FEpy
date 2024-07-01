# Docker Compose


Crea los contenedores las imagenes y los levantarlos

```powershell
docker compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d
```

El comando se utiliza para iniciar y ejecutar toda tu aplicación Docker definida en los archivos docker-compose.yml y docker-compose.override.yml. Aquí tienes un desglose del comando:
- <code>docker compose</code>: Este es el comando principal utilizado para gestionar aplicaciones Docker usando un archivo YAML para definir servicios, redes y volúmenes.
- <code>-f .\docker-compose.yml</code>: La bandera -f especifica un archivo a utilizar. En este caso, apunta a docker-compose.yml, que es el archivo Docker Compose predeterminado que contiene la configuración base de tu aplicación.
- <code>-f .\docker-compose.override.yml</code>: Esta es otra bandera -f que especifica un archivo adicional. docker-compose.override.yml se utiliza típicamente para sobrescribir o añadir a la configuración en el archivo base docker-compose.yml para entornos específicos o propósitos de desarrollo. Docker Compose lee automáticamente ambos archivos cuando están presentes, con los ajustes en el archivo de sobrescritura teniendo prioridad.
- <code>up</code>: Este comando levanta los servicios definidos en los archivos Docker Compose. Inicia y ejecuta toda tu aplicación.
- <code>-d</code>: Esta bandera significa "modo desacoplado" (detached mode). Ejecuta tus contenedores en segundo plano, permitiéndote continuar usando la sesión de terminal.

Para que sea verboso es decir muestre todas las salidas es con el siguiente comando

```powershell
docker-compose --verbose -f docker-compose.yml -f docker-compose.override.yml up -d
```



Comando para recompilar una imagen con docker-compose, el <nombre_servicio> es el nombre del servicio que se quiere recompilar
que esta dentro del archivo docker-compose.yml

```powershell
docker-compose up --build <nombre_servicio>
```


