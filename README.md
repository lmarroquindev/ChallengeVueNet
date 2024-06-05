# Proyecto API .NET 6 y Cliente Vue.js

Este proyecto contiene un API backend desarrollado en .NET 6 con Entity Framework y una aplicación cliente Vue.js 3.2.13 con Node.js.

## Requisitos Previos

- .NET 6 SDK
- Node.js y npm
- SQL Server o cualquier base de datos compatible con Entity Framework
- Visual Studio o Visual Studio Code

## Instrucciones de Despliegue

### Configuración del Backend

1. **Ejecutar el Script de Base de Datos**:
   Navega a la carpeta donde se encuentra el script de la base de datos y ejecútalo para crear la base de datos vacia local.
   ChallengeVueNet\Queries\01-CreateDb.sql

2. **Configurar el String de Conexión**:
   En el proyecto API, busca el archivo `appsettings.json` y actualiza el string de conexión para apuntar a tu base de datos local.

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "tu-string-de-conexion-aquí"
   }

3. **Ejecuta las migraciones del entity framework**:
Ejecutar Migraciones de Entity Framework: Abre una terminal y navega a la carpeta del proyecto API. Ejecuta el siguiente comando para aplicar las migraciones a la base de datos:

dotnet ef database update

O desde el package manager console de visual studio, selecciona el proyecto BackendChallenge.Data en "Default Project" y ejecuta el comando: 

update-database

4. **Configurar CORS**:
En el archivo Program.cs del proyecto API, asegúrate de configurar CORS para permitir solicitudes desde la URL de tu aplicación cliente.

builder.Services.AddCors(options =>
{
    options.AddPolicy("ClientVueApp", builder =>
    {
        builder.WithOrigins("http://localhost:8080")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

5. **Ejecutar el proyecto API**:
Selecciona el proyecto api como proyecto de inicio, y levanta el proyecto con el iisExpress o con Docker desde el Visual Studio.

### Configuración del Cliente Vue.js
1. **Instalar Dependencias**:
Navega a la carpeta de la aplicación cliente y ejecuta el siguiente comando para instalar las dependencias:

npm install

2. **Configurar la URL del API**:
En la aplicación Vue.js, busca la variable de entorno o la configuración donde se define la URL del API y actualízala con el dominio de tu API:

VUE_APP_API_BASE_URL="http://localhost:5000" 

Asegúrate de que las URLs y puertos coincidan con la configuración de tu entorno local.

3. **Ejecutar la Aplicación Cliente**:
Ejecuta el siguiente comando para iniciar la aplicación cliente:

npm run serve