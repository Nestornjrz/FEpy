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

En general, el <u>contexto de construcción</u> cuando usas <code>docker-compose</code>
se define por la ubicación del archivo **docker-compose.yml**, a menos que especifiques explícitamente 
un contexto diferente usando la clave **context** en tu archivo **docker-compose.yml**.

El <u>contexto de construcción</u> es el directorio base
que Docker utiliza para ejecutar las construcciones de las
imágenes. Incluye todos los archivos y subdirectorios dentro
de él. Cuando especificas rutas en tus comandos <code>COPY</code> o <code>ADD</code>
dentro de un Dockerfile, esas rutas se interpretan relativas a este contexto de construcción.

Si necesitas que el <u>contexto de construcción</u> sea un 
directorio diferente, puedes cambiar la ruta en la clave **context**. 
Por ejemplo, si tu **docker-compose.yml** está en el directorio raíz de tu 
proyecto pero quieres usar el directorio **backend/** como contexto de construcción, podrías hacerlo así:

``` yaml
version: '3.8'
services:
  mi-servicio:
    build:
      context: ./backend # Ahora el contexto de construcción es el directorio "backend" relativo al lugar donde se encuentra docker-compose.yml
      dockerfile: src/fepy.Api/Dockerfile # El Dockerfile está dentro del contexto especificado
```


IMPORTANTE
> Recuerda que el contexto de construcción afecta a qué archivos están disponibles para comandos como COPY y ADD en tu Dockerfile, así como el tiempo que toma construir tu imagen, ya que Docker enviará todo el contexto al daemon de Docker.