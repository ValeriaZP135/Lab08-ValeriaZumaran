# Etapa 1: Compilación de la app usando el SDK de .NET 9
FROM docker.io/microsoft/dotnet-sdk:9.0 AS build-env
WORKDIR /app

# Copiar archivos de proyecto y restaurar dependencias
COPY *.sln ./
COPY Lab08-ValeriaZumaran/*.csproj ./Lab08-ValeriaZumaran/
RUN dotnet restore

# Copiar el resto del código y compilar la publicación
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa 2: Runtime ligero para ejecutar la aplicación
FROM docker.io/microsoft/dotnet-aspnet:9.0
WORKDIR /app
COPY --from=build-env /app/out .

# Exponer el puerto estándar que Render requiere
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "Lab08-ValeriaZumaran.dll"]

