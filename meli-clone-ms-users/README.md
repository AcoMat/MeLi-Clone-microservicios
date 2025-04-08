# MeLi Clone Users Microservice

Este proyecto es un microservicio de usuarios para una aplicación clon de Mercado Libre. Proporciona funcionalidades de registro, inicio de sesión, gestión de usuarios y tokens JWT.

## Tecnologías Utilizadas

- **.NET 8.0**
- **Entity Framework Core 9.0.3**
- **SQL Server**
- **Swashbuckle (Swagger) 6.6.2**

## Configuración del Proyecto

### Prerrequisitos

- **.NET SDK 8.0**
- **SQL Server**

### Variables de Entorno

Asegúrate de configurar las siguientes variables de entorno:

- `MeLi_Clone_users_ms_SECRET_KEY`: Clave secreta para la generación de tokens JWT.
- `MeLi_Clone_cart_ms_SECRET_KEY`: Clave secreta para la validación de tokens del microservicio de carrito.

### Configuración de la Base de Datos

Configura la cadena de conexión a la base de datos en el archivo `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=your_database;User Id=your_user;Password=your_password;"
  }
}
```

### Ejecución del Proyecto

1. Restaura las dependencias del proyecto:
   ```
    dotnet restore
   ```
2. Aplica las migraciones de la base de datos:
    ```
    dotnet ef database update
   ```
3. Ejecuta el proyecto:
   ```
    dotnet run
   ```

## Uso de la API

### EndPoints

- POST /register: Registra un nuevo usuario.
- POST /login: Inicia sesión un usuario existente.
- GET /users/me: Obtiene los datos del usuario autenticado.
- GET /users/{id}: Obtiene los datos de un usuario por ID.
- PUT /users/me/like: Añade o elimina un producto de los favoritos del usuario autenticado.
- PUT /users/me/purchases: Añade una compra al historial del usuario autenticado (no implementado).

### Diagrama inicial

![diagrama](https://github.com/user-attachments/assets/57a748df-b641-4b7a-a437-d5744d0304da)


