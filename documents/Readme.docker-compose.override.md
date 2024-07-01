# docker-compose.override.yml

Este archivo sobre escribe el archivo `docker-compose.yml` 
y se usa para configurar el entorno de desarrollo.

``` yaml
version: '3.4'

services:
  fepycadb:
    container_name: fepycadb
    image: mcr.microsoft.com/mssql/server:2022-latest
    environment:
      # Estos datos los necesita la base de datos SQL SERVER para arrancar
      # y se puede cambiar el password
      SA_PASSWORD: "Your_password123"
      ACCEPT_EULA: "Y"
    restart: always
    volumes:
      - ./.containers/database:/var/opt/mssql/data
    ports:
      - "1433:1433"
  fepycaapi:
    container_name: fepycaapi
    #Aqui se sobrescriven las variables de entorno y el conecction string
    environment:
      - ASPNETCORE_ENVIRONMENT=DockerDebug
      - ASPNETCORE_URLS=http://+:5000
      # Esta parte es especial porque tiene una nomeclatura especial, este "ConnectionStrings__SqlServerConnection"
      # esta diciendo que va a sobreecribir la propiedad "SqlServerConnection" dentro del 
      # archivo appsettings.json (que esta en la raiz del proyecto fepyCA.API)
      # como esto se esta ejecutando en el entorno Docker se tiene que usar el nombre de la imagen
      # del contenedor de la base de datos, en este caso "fepycadb"
      # Los doble guiones bajos "__" son para indicar que es una propiedad anidada
      - ConnectionStrings__SqlServerConnection=Server=fepycadb,1433;Database=fepy;User Id=sa;Password=Your_password123;Encrypt=False;
    depends_on:
      - fepycadb
    ports:
      - "81:5000"

  serilogseq:
    container_name: serilogseq
    environment:
      - ACCEPT_EULA=Y
    ports:
      - "5341:5341"
      - "8081:80"

```