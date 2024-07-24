# Sistema de Envío de Correos

## Configuración

### Base de Datos

1. Crear la base de datos y tabla en MySQL Server:

```sql
CREATE DATABASE EmailSystemDB;
USE EmailSystemDB;

CREATE TABLE Destinatarios (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    CorreoElectronico VARCHAR(100) NOT NULL UNIQUE
);

DELIMITER //

CREATE PROCEDURE InsertarDestinatario (
    IN p_Nombre VARCHAR(100),
    IN p_CorreoElectronico VARCHAR(100)
)
BEGIN
    DECLARE correoExiste INT;
    SELECT COUNT(*) INTO correoExiste FROM Destinatarios WHERE CorreoElectronico = p_CorreoElectronico;
    IF correoExiste = 0 THEN
        INSERT INTO Destinatarios (Nombre, CorreoElectronico) VALUES (p_Nombre, p_CorreoElectronico);
    ELSE
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El correo ya está registrado';
    END IF;
END //

CREATE PROCEDURE ObtenerDestinatarios()
BEGIN
    SELECT * FROM Destinatarios;
END //

DELIMITER ;

2.Crear el Proyecto ASP.NET Core.
	Abre tu terminal o Visual Studio y crea un nuevo proyecto ASP.NET Core:
	dotnet new webapp -n MailTest, cd MailTest.
	Añadir los paquetes necesarios para Entity Framework Core y MySQL:
	dotnet add package Microsoft.EntityFrameworkCore dotnet add package Pomelo.EntityFrameworkCore.MySql
3.Configurar la Conexión a la Base de Datos.
	Configurar appsettings.json, añadir la cadena de conexión del archivo appsettings.json.
	Crear el Modelo y el Contexto de la Base de Datos, Crea una carpeta llamada Models y añade un archivo 		Destinatario.cs.
	Crea un archivo ApplicationDbContext.cs en la misma carpeta.
	Configurar el Contexto en Startup.cs, añade la configuración del contexto de la base de datos en 	Startup.cs.
4.Crear los Controladores y Vistas.
	Crear el Controlador para los Destinatarios, Crea una carpeta Controllers y añade un archivo 	DestinatariosController.cs:
5.Crear el Controlador y la Vista para Enviar Correos
	Configurar el Servidor SMTP, Añade la configuración del servidor SMTP en appsettings.json:



