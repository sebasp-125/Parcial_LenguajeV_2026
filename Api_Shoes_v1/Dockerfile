# ETAPA 1: Compilación
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

# Copiar archivos de proyecto y restaurar dependencias
COPY *.sln .
COPY *.csproj ./
RUN dotnet restore

# Copiar todo el código fuente y publicar en modo Release
# Corregido: se usa "out" sin la 's' para coincidir con la etapa de runtime
COPY . .
RUN dotnet publish "Api_Shoes_v1.csproj" -c Release -o out

# ETAPA 2: Runtime (Imagen ligera para ejecución)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Configuración de puerto requerida por Render
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

# Punto de entrada con el nombre exacto de tu DLL
ENTRYPOINT ["dotnet", "Api_Shoes_v1.dll"]