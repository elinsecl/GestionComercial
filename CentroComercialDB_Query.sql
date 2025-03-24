----------------- EXAMEN GRUPO 2 -----------------
-- Usamos MASTER para administrar la BD
USE MASTER;
GO
-----------------------------------------------------------------------------------
-----------------------------------------------------------------------------------
--------------------------------------------------------
-------------------- BASE DE DATOS ---------------------
--------------------------------------------------------
-- Verificamos si la base de datos existe, y en caso de existir la eliminamos
IF EXISTS (SELECT NAME FROM DBO.SYSDATABASES WHERE NAME = 'CentroComercialDB')
BEGIN
	DROP DATABASE CentroComercialDB;
END;
GO
-- Crear la base de datos
CREATE DATABASE CentroComercialDB;
GO
-- Procedemos a empezar a usar la base de datos creada
USE CentroComercialDB;
GO
----------------------------------------------------
-------------------- SERVICIOS ---------------------
----------------------------------------------------
-- Verificar que la tabla no existe en la BD y si existe eliminarla
IF EXISTS (SELECT NAME FROM DBO.SYSOBJECTS WHERE NAME = 'Servicios')
BEGIN
	DROP TABLE Servicios;
END;
GO
-- Creamos la tabla Servicios
CREATE TABLE Servicios (
	IdServicio INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	NombreServicio VARCHAR(200) NOT NULL,
	Descripcion VARCHAR (1000) NOT NULL,
	Precio DECIMAL(18,2)  NOT NULL,
    Duracion INT NOT NULL CHECK (Duracion <= 500), -- Restricción de límite
	Categoria VARCHAR (50) NOT NULL,
	Estado VARCHAR (20) NOT NULL,
	FechaCreacion DATE NOT NULL,
	Foto VARCHAR (500)
);
GO
--------------------------------------------
-------------- CRUD SERVICIOS --------------
--------------------------------------------
-- Verificar que el procedimiento almacenado no exista en la BD
IF EXISTS (SELECT NAME FROM DBO.SYSOBJECTS WHERE NAME = '[Sp_Ins_Servicio]')
BEGIN
	DROP TABLE [Sp_Ins_Servicio];
END;
GO
-------------- CREAR --------------
CREATE OR ALTER PROCEDURE [Sp_Ins_Servicio]
	@NombreServicio VARCHAR (200),
	@Descripcion VARCHAR (1000),
	@Precio DECIMAL(18,2),
	@Duracion INT,
	@Categoria VARCHAR (50),
	@Estado VARCHAR (20),
	@FechaCreacion DATE,
	@Foto VARCHAR (500)
AS
BEGIN 
		INSERT INTO Servicios (NombreServicio, Descripcion, Precio, Duracion, Categoria, Estado, FechaCreacion, Foto)
		VALUES (@NombreServicio, @Descripcion, @Precio, @Duracion, @Categoria, @Estado, @FechaCreacion, @Foto);

		PRINT 'Servicio insertado correctamente.';
END;
GO

Exec [Sp_Ins_Servicio] 'ADSF', 'FADF', '12000.00', '10', 'Salud', 'Activo','2024-07-14',''
go
-----------------------------------------------------------------------------------
-----------------------------------------------------------------------------------
-- Verificar que el procedimiento almacenado no exista en la BD
IF EXISTS (SELECT NAME FROM DBO.SYSOBJECTS WHERE NAME = '[Sp_Buscar_Nombre_Servicio]')
BEGIN
	DROP TABLE [Sp_Buscar_Nombre_Servicios];
END;
GO
-------------- LEER --------------
CREATE OR ALTER PROCEDURE [Sp_Buscar_Nombre_Servicio]
	@NombreServicio VARCHAR (200)
AS
BEGIN
		SELECT *
		FROM Servicios
		WHERE NombreServicio LIKE '%' + RTRIM(LTRIM(@NombreServicio)) + '%'
		ORDER BY NombreServicio;

		PRINT 'Búsqueda completada correctamente';
END;
GO 

-- Verificar que el procedimiento almacenado no exista en la BD
IF EXISTS (SELECT NAME FROM DBO.SYSOBJECTS WHERE NAME = '[Sp_Buscar_Id_Servicio]')
BEGIN
	DROP TABLE [Sp_Buscar_IdServicio];
END;
GO
-------------- LEER --------------
CREATE OR ALTER PROCEDURE [Sp_Buscar_Id_Servicio]
	@IdServicio INT
AS
BEGIN
		SELECT *
		FROM Servicios
		WHERE IdServicio LIKE '%' + RTRIM(LTRIM(@IdServicio)) + '%'
		ORDER BY IdServicio;

		PRINT 'Búsqueda completada correctamente';
END;
GO 
-----------------------------------------------------------------------------------
-----------------------------------------------------------------------------------
-- Verificar que el procedimiento almacenado no exista en la BD
IF EXISTS (SELECT NAME FROM DBO.SYSOBJECTS WHERE NAME = '[Sp_Upd_Servicio]')
BEGIN
	DROP TABLE [Sp_Upd_Servicio];
END;
GO
-------------- ACTUALIZAR --------------
CREATE OR ALTER PROCEDURE [Sp_Upd_Servicio]
	@IdServicio INT,
	@NombreServicio VARCHAR (200),
	@Descripcion VARCHAR (1000),
	@Precio DECIMAL (18,2),
	@Duracion INT,
	@Categoria VARCHAR (50),
	@Estado VARCHAR (20),
	@FechaCreacion DATE,
	@Foto VARCHAR (500)
AS
BEGIN
		UPDATE Servicios
		SET
			NombreServicio = @NombreServicio,
			Descripcion = @Descripcion,
			Precio = @Precio,
			Duracion = @Duracion,
			Categoria = @Categoria, 
			Estado = @Estado,
			FechaCreacion = @FechaCreacion,
			Foto = @Foto
		WHERE IdServicio = @IdServicio;

		PRINT 'Servicio actualizado correctamente.';
END;
GO
-----------------------------------------------------------------------------------
-- Verificar que el procedimiento almacenado no exista en la BD
IF EXISTS (SELECT NAME FROM DBO.SYSOBJECTS WHERE NAME = '[Sp_Del_Servicio]')
BEGIN
	DROP TABLE [Sp_Del_Servicio];
END;
GO
-------------- ELIMINAR --------------
CREATE OR ALTER PROCEDURE [Sp_Del_Servicio]
	@IdServicio INT
AS
BEGIN
		DELETE FROM Servicios WHERE IdServicio = @IdServicio;

		PRINT 'Servicio eliminado correctamente';
END;
GO

CREATE OR ALTER VIEW [Vp_Cns_Servicios]    
AS
    SELECT 
        s.IdServicio,
        s.NombreServicio,
        s.Descripcion,
        s.Precio,
        s.Duracion,
        s.Categoria,
        s.Estado,
        s.FechaCreacion,
        s.Foto
    FROM Servicios s
GO
select * from [Vp_Cns_Servicios] order by NombreServicio;



----------------------------------------------------
-------------------- CLIENTES ---------------------
----------------------------------------------------
-- Verificar que la tabla no existe en la BD y si existe eliminarla
IF EXISTS (SELECT NAME FROM DBO.SYSOBJECTS WHERE NAME = 'Clientes')
BEGIN
	DROP TABLE Clientes;
END;
GO
-- Creamos la tabla Clientes
CREATE TABLE Clientes (
	IdCliente INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	NombreCompleto VARCHAR(200) NOT NULL,
	FechaNacimiento DATE NOT NULL,
	CorreoElectronico VARCHAR (255) NOT NULL,
	Telefono VARCHAR (15) NOT NULL,
	Direccion VARCHAR (500),
	FechaRegistro DATE NOT NULL,
	EstadoCuenta VARCHAR (20) NOT NULL,
	Foto VARCHAR (500)
);
GO
-- Verificar que el procedimiento almacenado no exista en la BD
IF EXISTS (SELECT NAME FROM DBO.SYSOBJECTS WHERE NAME = '[Sp_Ins_Cliente]')
BEGIN
    DROP PROCEDURE [Sp_Ins_Cliente];
END;
GO

-------------- CREAR --------------
CREATE  PROCEDURE [Sp_Ins_Cliente]
    @NombreCompleto VARCHAR(200),
    @FechaNacimiento DATE,
    @CorreoElectronico VARCHAR(255),
    @Telefono VARCHAR(15),
    @Direccion VARCHAR(500),
    @FechaRegistro DATE,
    @EstadoCuenta VARCHAR(20),
    @Foto VARCHAR(500)
AS
BEGIN
    INSERT INTO Clientes (NombreCompleto, FechaNacimiento, CorreoElectronico, Telefono, Direccion, FechaRegistro, EstadoCuenta, Foto)
    VALUES (@NombreCompleto, @FechaNacimiento, @CorreoElectronico, @Telefono, @Direccion, @FechaRegistro, @EstadoCuenta, @Foto);
    PRINT 'Cliente insertado correctamente.';
END;
GO

-------------- LEER POR NOMBRE --------------
IF EXISTS (SELECT NAME FROM DBO.SYSOBJECTS WHERE NAME = '[Sp_Buscar_Nombre_Clientes]')
BEGIN
	DROP TABLE [Sp_Buscar_Nombre_Clientes];
END;
GO
CREATE OR ALTER PROCEDURE [Sp_Buscar_Nombre_Clientes]
	@NombreCompleto VARCHAR (200)
AS
BEGIN
		SELECT *
		FROM Clientes
		WHERE NombreCompleto LIKE '%' + RTRIM(LTRIM(@NombreCompleto)) + '%'
		ORDER BY NombreCompleto;

		PRINT 'Búsqueda completada correctamente';
END;
GO 

-------------- LEER POR ID --------------
IF EXISTS (SELECT NAME FROM DBO.SYSOBJECTS WHERE NAME = '[Sp_Buscar_Id_Cliente]')
BEGIN
	DROP TABLE [Sp_Buscar_Id_Cliente];
END;
GO
CREATE  PROCEDURE [Sp_Buscar_Id_Cliente]
    @IdCliente INT
AS
BEGIN
    SELECT * FROM Clientes WHERE IdCliente = @IdCliente;
    PRINT 'Búsqueda completada correctamente';
END;
GO

-------------- ACTUALIZAR --------------
IF EXISTS (SELECT NAME FROM DBO.SYSOBJECTS WHERE NAME = '[Sp_Upd_Cliente]')
BEGIN
	DROP TABLE [Sp_Upd_Cliente];
END;
GO
CREATE  PROCEDURE [Sp_Upd_Cliente]
    @IdCliente INT,
    @NombreCompleto VARCHAR(200),
    @FechaNacimiento DATE,
    @CorreoElectronico VARCHAR(255),
    @Telefono VARCHAR(15),
    @Direccion VARCHAR(500),
    @FechaRegistro DATE,
    @EstadoCuenta VARCHAR(20),
    @Foto VARCHAR(500)
AS
BEGIN
    UPDATE Clientes
    SET NombreCompleto = @NombreCompleto,
        FechaNacimiento = @FechaNacimiento,
        CorreoElectronico = @CorreoElectronico,
        Telefono = @Telefono,
        Direccion = @Direccion,
        FechaRegistro = @FechaRegistro,
        EstadoCuenta = @EstadoCuenta,
        Foto = @Foto
    WHERE IdCliente = @IdCliente;
    PRINT 'Cliente actualizado correctamente.';
END;
GO

-------------- ELIMINAR --------------
IF EXISTS (SELECT NAME FROM DBO.SYSOBJECTS WHERE NAME = '[Sp_Del_Cliente]')
BEGIN
	DROP TABLE [Sp_Del_Cliente];
END;
GO
CREATE  PROCEDURE [Sp_Del_Cliente]
    @IdCliente INT
AS
BEGIN
    DELETE FROM Clientes WHERE IdCliente = @IdCliente;
    PRINT 'Cliente eliminado correctamente';
END;
GO

-------------- VISTA PARA CONSULTA --------------
CREATE OR ALTER VIEW [Vp_Cns_Clientes] AS
    SELECT 
        c.IdCliente,
        c.NombreCompleto,
        c.FechaNacimiento,
        c.CorreoElectronico,
        c.Telefono,
        c.Direccion,
        c.FechaRegistro,
        c.EstadoCuenta,
        c.Foto
    FROM Clientes c;
GO

-- Consultar la vista ordenada por NombreCompleto
SELECT * FROM [Vp_Cns_Clientes] ORDER BY NombreCompleto;

EXEC [Sp_Ins_Cliente] 
    'Juan Pérez', 
    '1990-05-15', 
    'juan.perez@email.com', 
    '88889999', 
    'Calle 123, Ciudad, País', 
    '2025-03-01', 
    'Activo', 
    'https://ejemplo.com/foto.jpg';
	EXEC [Sp_Ins_Cliente] 
    'Manolo', 
    '1990-05-15', 
    'juan.perez@email.com', 
    '88889999', 
    'Calle 123, Ciudad, País', 
    '2025-03-01', 
    'Activo', 
    'https://ejemplo.com/foto.jpg';


----------------------------------------------------
-------------------- ENCUESTAS ---------------------
----------------------------------------------------
-- Verificar que la tabla no existe en la BD y si existe eliminarla
IF EXISTS (SELECT NAME FROM DBO.SYSOBJECTS WHERE NAME = 'Encuestas')
BEGIN
	DROP TABLE Encuestas;
END;
GO
-- Creamos la tabla Encuestas
CREATE TABLE Encuestas (
	IdEncuesta INT IDENTITY (1, 1) PRIMARY KEY NOT NULL,
	IdCliente INT NULL,
	IdServicio INT NOT NULL,
	Comentarios VARCHAR (1000) NULL,
	FechaEncuesta DATE NOT NULL CHECK (FechaEncuesta <= GETDATE()),  -- No permite fechas futuras
	CalificacionEncuesta INT NOT NULL CHECK (CalificacionEncuesta BETWEEN 1 AND 5),  -- Solo valores entre 1 y 5
	TipoEncuesta VARCHAR(20) NOT NULL CHECK (TipoEncuesta IN ('Satisfacción', 'Recomendación', 'Opinión')),  -- Solo permite estos valores
    	EstadoEncuesta VARCHAR(20) NOT NULL CHECK (EstadoEncuesta IN ('Completada', 'Pendiente')),  -- Solo permite estos valores
	CONSTRAINT FK_Encuestas_Clientes FOREIGN KEY (IdCliente) REFERENCES Clientes (IdCliente),
	CONSTRAINT FK_Encuestas_Servicios FOREIGN KEY (IdServicio) REFERENCES Servicios (IdServicio)
);
GO
--------------------------------------------
-------------- CRUD ENCUESTAS --------------
--------------------------------------------

-- Verificar que el procedimiento almacenado no exista en la BD
IF EXISTS (SELECT NAME FROM DBO.SYSOBJECTS WHERE NAME = '[Sp_Ins_Encuesta]')
BEGIN
	DROP PROCEDURE [Sp_Ins_Encuesta];
END;
GO
-------------- CREAR --------------
CREATE OR ALTER PROCEDURE [Sp_Ins_Encuesta]
	@IdCliente INT,
	@IdServicio INT,
	@Comentarios VARCHAR (1000),
	@FechaEncuesta DATE,
	@CalificacionEncuesta INT,
	@TipoEncuesta VARCHAR (20),
	@EstadoEncuesta VARCHAR (20)
AS
BEGIN
		-- Verificar si la encuesta es anónima (solo permitido en tipo 'Satisfacción')
    	IF @IdCliente IS NULL AND @TipoEncuesta <> 'Satisfacción'
    	BEGIN
        	PRINT 'Solo las encuestas de tipo "Satisfacción" pueden ser anónimas.';
        RETURN;
    END

    	-- Verificar si el cliente está activo (si la encuesta no es anónima)
    	IF @IdCliente IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Clientes WHERE IdCliente = @IdCliente AND EstadoCuenta = 'Activo')
    	BEGIN
        	PRINT 'Solo los clientes activos pueden responder encuestas.';
        RETURN;
    END
	 	-- Insertar la encuesta
		INSERT INTO Encuestas (IdCliente, IdServicio, Comentarios, FechaEncuesta, CalificacionEncuesta, TipoEncuesta, EstadoEncuesta)
		VALUES (@IdCliente, @IdServicio, @Comentarios, @FechaEncuesta, @CalificacionEncuesta, @TipoEncuesta, @EstadoEncuesta);

		PRINT 'Encuesta insertada correctamente.';
END;
GO
-----------------------------------------------------------------------------------
-----------------------------------------------------------------------------------
-- Verificar que el procedimiento almacenado no exista en la BD
IF EXISTS (SELECT NAME FROM DBO.SYSOBJECTS WHERE NAME = '[Sp_Buscar_TiposEncuestas]')
BEGIN
	DROP PROCEDURE [Sp_Buscar_TiposEncuestas];
END;
GO
-------------- LEER --------------
CREATE OR ALTER PROCEDURE [Sp_Buscar_TiposEncuestas]
    @TipoEncuesta VARCHAR(20)
AS
BEGIN
    	SELECT * FROM Encuestas
    	WHERE TipoEncuesta LIKE '%' + RTRIM(LTRIM(@TipoEncuesta)) + '%'
    	ORDER BY TipoEncuesta;

    	PRINT 'Búsqueda completada correctamente.';
END;
GO
-- Verificar que el procedimiento almacenado no exista en la BD
IF EXISTS (SELECT NAME FROM DBO.SYSOBJECTS WHERE NAME = '[Sp_Buscar_IdEncuesta]')
BEGIN
	DROP PROCEDURE [Sp_Buscar_IdEncuesta];
END;
GO
-------------- LEER --------------
CREATE OR ALTER PROCEDURE [Sp_Buscar_IdEncuesta]
    @IdEncuesta INT
AS
BEGIN
    	SELECT * FROM Encuestas WHERE IdEncuesta = @IdEncuesta;

    	PRINT 'Búsqueda completada correctamente.';
END;
GO
-----------------------------------------------------------------------------------
-----------------------------------------------------------------------------------
-- Verificar que el procedimiento almacenado no exista en la BD
IF EXISTS (SELECT NAME FROM DBO.SYSOBJECTS WHERE NAME = '[Sp_Upd_Encuesta]')
BEGIN
	DROP PROCEDURE [Sp_Upd_Encuesta];
END;
GO
-------------- ACTUALIZAR --------------
CREATE OR ALTER PROCEDURE [Sp_Upd_Encuesta]
    	@IdEncuesta INT,
    	@IdCliente INT NULL,  
    	@IdServicio INT,
    	@Comentarios VARCHAR(1000),
    	@FechaEncuesta DATE,
    	@CalificacionEncuesta INT,
    	@TipoEncuesta VARCHAR(20),
    	@EstadoEncuesta VARCHAR(20)
AS
BEGIN
 		-- Verificar si la encuesta es anónima
		IF @IdCliente IS NULL AND @TipoEncuesta <> 'Satisfacción'
		BEGIN
			PRINT 'Solo las encuestas de tipo "Satisfacción" pueden ser anónimas.';
        RETURN;
    END

		-- Verificar si el cliente está activo, si no es anónima
		IF @IdCliente IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Clientes WHERE IdCliente = @IdCliente AND EstadoCuenta = 'Activo')
		BEGIN
			PRINT 'Solo los clientes activos pueden responder encuestas.';
        RETURN;
    END
	
	-- Actualizar la encuesta si no está completada
    	UPDATE Encuestas
    	SET 	
			IdCliente = @IdCliente,
        	IdServicio = @IdServicio,
        	Comentarios = @Comentarios,
        	FechaEncuesta = @FechaEncuesta,
        	CalificacionEncuesta = @CalificacionEncuesta,
        	TipoEncuesta = @TipoEncuesta,
        	EstadoEncuesta = @EstadoEncuesta
    	WHERE IdEncuesta = @IdEncuesta;

    	PRINT 'Encuesta actualizada correctamente.';
END;
GO
-----------------------------------------------------------------------------------
-----------------------------------------------------------------------------------
-- Verificar que el procedimiento almacenado no exista en la BD
IF EXISTS (SELECT NAME FROM DBO.SYSOBJECTS WHERE NAME = '[Sp_Del_Encuesta]')
BEGIN
	DROP PROCEDURE [Sp_Del_Encuesta];
END;
GO
-------------- ELIMINAR --------------
CREATE OR ALTER PROCEDURE [Sp_Del_Encuesta]
    	@IdEncuesta INT
AS
BEGIN
    	DELETE FROM Encuestas WHERE IdEncuesta = @IdEncuesta;

    	PRINT 'Encuesta eliminada correctamente.';
END;
GO

-------------- VALIDACIONES --------------
-- Verificar que el procedimiento almacenado no exista en la BD
IF EXISTS (SELECT NAME FROM DBO.SYSOBJECTS WHERE NAME = '[Sp_Cerrar_EncuestasPendientes]')
BEGIN
	DROP PROCEDURE [Sp_Cerrar_EncuestasPendientes];
END;
GO
-------------- VERIFICAR --------------
CREATE OR ALTER PROCEDURE [Sp_Cerrar_EncuestasPendientes]
AS
BEGIN
    	UPDATE Encuestas
    	SET EstadoEncuesta = 'Completada'
    	WHERE EstadoEncuesta = 'Pendiente' 
    	AND DATEDIFF(DAY, FechaEncuesta, GETDATE()) > 30;

    	-- Retornar la cantidad de encuestas cerradas
    	SELECT @@ROWCOUNT AS Cerradas;
END;
GO
-------------- REPORTE--------------
CREATE OR ALTER VIEW [Vp_Cns_Encuestas]
AS
SELECT 
    e.IdEncuesta,
    e.IdCliente,
    e.IdServicio,
    e.Comentarios,
    e.FechaEncuesta,
    e.CalificacionEncuesta,
    e.TipoEncuesta,
    e.EstadoEncuesta
FROM Encuestas e;
GO

SELECT * FROM [Vp_Cns_Encuestas] ORDER BY IdCliente;

IF EXISTS (SELECT NAME FROM DBO.SYSOBJECTS WHERE NAME = 'VerificarClientesInactivos')
BEGIN
	DROP TABLE VerificarClientesInactivos;
END;
GO

CREATE PROCEDURE VerificarClientesInactivos
AS
BEGIN
    -- Declarar la fecha límite, que es 2 meses antes de la fecha actual
    DECLARE @FechaLimite DATETIME
    SET @FechaLimite = DATEADD(MONTH, -2, GETDATE())

    -- Actualizar los clientes que no tienen encuestas en los últimos 2 meses a 'Inactivo'
    UPDATE c
    SET c.EstadoCuenta = 'Inactivo'
    FROM Clientes c
    LEFT JOIN Encuestas e ON c.IdCliente = e.IdCliente
    WHERE (e.FechaEncuesta IS NULL OR e.FechaEncuesta < @FechaLimite)
      AND c.EstadoCuenta = 'Activo'

    -- Actualizar los clientes que tienen encuestas recientes a 'Activo'
    UPDATE c
    SET c.EstadoCuenta = 'Activo'
    FROM Clientes c
    INNER JOIN Encuestas e ON c.IdCliente = e.IdCliente
    WHERE e.FechaEncuesta >= @FechaLimite
      AND c.EstadoCuenta != 'Activo'

END;
go
