# Comandos

# Listar contenedores

```powershell
docker ps -a
```

Ver que direccion ip tiene el contenedor

```powershell
docker inspect -f "{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}" <container_id>
```

Para inspeccionar un contenedor podemos usar el siguiente comando, nos dara un JSON
conteniendo toda la informacion del contenedor

``` bash	
docker inspect <container_id>
```

Comando para eliminar todos los contenedores

``` bash
docker container prune
```

# El contexto de construccion

Es un dolor de cabeza no entender el contexto de contruccion,
especialmente del comando <code>COPY</code>.

En general, el <u>contexto de construcci�n</u> cuando usas <code>docker-compose</code>
se define por la ubicaci�n del archivo **docker-compose.yml**, a menos que especifiques expl�citamente 
un contexto diferente usando la clave **context** en tu archivo **docker-compose.yml**.

El <u>contexto de construcci�n</u> es el directorio base
que Docker utiliza para ejecutar las construcciones de las
im�genes. Incluye todos los archivos y subdirectorios dentro
de �l. Cuando especificas rutas en tus comandos <code>COPY</code> o <code>ADD</code>
dentro de un Dockerfile, esas rutas se interpretan relativas a este contexto de construcci�n.

Si necesitas que el <u>contexto de construcci�n</u> sea un 
directorio diferente, puedes cambiar la ruta en la clave **context**. 
Por ejemplo, si tu **docker-compose.yml** est� en el directorio ra�z de tu 
proyecto pero quieres usar el directorio **backend/** como contexto de construcci�n, podr�as hacerlo as�:

``` yaml
version: '3.8'
services:
  mi-servicio:
    build:
      context: ./backend # Ahora el contexto de construcci�n es el directorio "backend" relativo al lugar donde se encuentra docker-compose.yml
      dockerfile: src/fepy.Api/Dockerfile # El Dockerfile est� dentro del contexto especificado
```


IMPORTANTE
> Recuerda que el contexto de construcci�n afecta a qu� archivos est�n disponibles para comandos como COPY y ADD en tu Dockerfile, as� como el tiempo que toma construir tu imagen, ya que Docker enviar� todo el contexto al daemon de Docker.