# Etapa 1: Construcci�n
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /source

# Copiar archivos y restaurar dependencias
COPY . .
RUN dotnet restore

# Compilar y publicar la aplicaci�n
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Ejecuci�n
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "AgendaWeb.dll"]
