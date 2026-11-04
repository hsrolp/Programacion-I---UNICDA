# Crud_Login

Ejercicio de WinForms con inicio de sesión y gestión de personas. Requiere Windows, el SDK de .NET 10 y SQL Server.

Antes de abrir el programa, define las variables de entorno `CRUD_LOGIN_USUARIO` y `CRUD_LOGIN_CLAVE` con tus propias credenciales y reinicia Visual Studio si ya estaba abierto. La aplicación verifica esas credenciales al iniciar. Usa una cuenta local de demostración, separada de la autenticación de SQL Server.

El CRUD usa la base de datos `CRUD_PERSONAS` de SQL Server en `localhost` con autenticación integrada de Windows. Si la base aún no existe, instala la herramienta `dotnet-ef` de la serie 10 y ejecuta `dotnet ef database update` desde esta carpeta para aplicar la migración incluida.
