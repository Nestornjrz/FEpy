# Explicacion de las configuraciones en el docker-compose.yml

``` yaml
version: '3.4'

services:
  warrantcadb:
    # Esta linea le indica al docker compose de donde tiene que quitar
    # la imagen de la base de datos  
    # [SQL SERVER](https://mcr.microsoft.com/en-us/product/mssql/server/tags)
    image: mcr.microsoft.com/mssql/server:2022-latest

  warrantcaapi:
    # Es una variable de entorno del bash
    # se puede ver usando el comando `echo $DOCKER_REGISTRY`
<<<<<<< HEAD
    image: ${DOCKER_REGISTRY-}fepycaapi
    build:
      context: .
      dockerfile: backend/src/FEpy.Api/Dockerfile
=======
    image: ${DOCKER_REGISTRY-}warrantcaapi
    build:
      context: .
      dockerfile: backend/src/Warrant.Api/Dockerfile
>>>>>>> 8f905cb80c4e5ede575537734738c63479285d5d
  
  serilogseqfepy:
    image: datalust/seq:latest
```