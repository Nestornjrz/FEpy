#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Invoca al runtime de .NET
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

#Genera dentro del directorio del container una carpeta que se llama app
WORKDIR /app
#Es el puerto con el que este contenedor se va a comunicar con los agentes externos
EXPOSE 81

#Invoca al SDK de .NET
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#Se crea un directorio donde se va a poner los compilados 
WORKDIR /src
#Se copian al src los resultados de la compilacion de Domain, Application, Infrastructure (Aunque en realidad no hace falta)
COPY ["backend/src/FEpy.Domain/FEpy.Domain.csproj", "src/FEpy.Domain/"]
COPY ["backend/src/FEpy.Application/FEpy.Application.csproj", "src/FEpy.Application/"]
COPY ["backend/src/FEpy.Infrastructure/FEpy.Infrastructure.csproj", "src/FEpy.Infrastructure/"]
#Se copian los binarios a la carpeta src (los resultados de la compilacion), ya contienen todos los compilados de los proyectos dependientes
COPY ["backend/src/FEpy.Api/FEpy.Api.csproj", "src/FEpy.Api/"]
#Se descargan todas las librerias y paquetes Nuget
RUN dotnet restore "src/FEpy.Api/FEpy.Api.csproj"
# Esta copiando todos los archivos que estan en la carpeta local (donde se encuentra el archivo docker-compose.yml) a la carpeta src del container
# en este caso esta copiando todos los archivos de la carpeta backend a la carpeta src del container
# hay que recordar que la carpeta backend esta dentro del contexto de contruccion del docker (que es donde esta el archivo docker-compose.yml).
# COPY [origen] [destino], el origen es la carpeta local (en windows) y el destino es la carpeta dentro del container (en linux, WSL)
COPY backend/ .

#Esta cambiando el directorio de trabajo local al contexto del contenedor (la carpeta src del container)
WORKDIR "/src/src/FEpy.Api"
#Se ejecuta la compilacion dentro del container
RUN dotnet build "FEpy.Api.csproj" -c Debug -o /app/build

# Comienza una nueva etapa de construccion llamada Publish que se basa en el SDK de .NET que ya fue construido en la etapa build
FROM build AS publish
#Se ejecuta el comando "dotnet publish" que publica la aplicacion en la carpeta publish
RUN dotnet publish "FEpy.Api.csproj" -c Debug -o /app/publish /p:UseAppHost=false

FROM base AS final
#Se establece el directorio de trabajo en la carpeta app del contenedor
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FEpy.Api.dll"]