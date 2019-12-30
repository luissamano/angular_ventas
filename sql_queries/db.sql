-- Create a new database called 'db_ventas'
-- Connect to the 'master' database to run 
USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
    SELECT name
        FROM sys.databases
        WHERE name = N'db_ventas'
)

CREATE DATABASE db_ventas
GO


use db_ventas
GO


-- Create a new table called 'Articulo' in schema 'SchemaName'
-- Drop the table if it already exists
IF OBJECT_ID('SchemaName.Articulo', 'U') IS NOT NULL
DROP TABLE Articulo
GO
-- Create the table in the specified schema
CREATE TABLE Articulo
(
    ArticuloId INT IDENTITY(1,1) PRIMARY KEY, -- primary key column
    Nombre [NVARCHAR](60) NOT NULL,
    Descripcion [NVARCHAR](256) NULL,
    Stock INT NOT NULL,
    Precio DECIMAL(11,2) NOT NULL,
    Estatus BIT DEFAULT(1) 
);
GO


-- Create a new table called 'Venta' in schema 'SchemaName'
-- Drop the table if it already exists
IF OBJECT_ID('SchemaName.Venta', 'U') IS NOT NULL
DROP TABLE Venta
GO
-- Create the table in the specified schema
CREATE TABLE Venta
(
    VentaId INT IDENTITY(1,1) PRIMARY KEY, -- primary key column
    Descripcion [NVARCHAR](256) NULL,
    Fecha_hora DATETIME NOT NULL,
	Total DECIMAL(11,2) NOT NULL,
	Estatus INT DEFAULT(0)
);
GO


-- Create a new table called 'Detalle' in schema 'SchemaName'
-- Drop the table if it already exists
IF OBJECT_ID('SchemaName.Detalle', 'U') IS NOT NULL
DROP TABLE Detalle
GO
-- Create the table in the specified schema
CREATE TABLE Detalle
(
    DetalleId INT NOT NULL PRIMARY KEY, -- primary key column
	VentaId INT not null,
	ArticuloId INT not null,
	Cantidad int not null,
	Precio decimal(11,2) not null,
	FOREIGN KEY (VentaId) REFERENCES Venta (VentaId) ON DELETE CASCADE,
	FOREIGN KEY (ArticuloId) REFERENCES Articulo (ArticuloId)
);
GO