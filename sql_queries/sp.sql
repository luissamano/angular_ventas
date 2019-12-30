-- Create a new stored procedure called 'spVentas' in schema 'SchemaName'
-- Drop the stored procedure if it already exists
USE db_ventas;

IF EXISTS (
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'SchemaName'
    AND SPECIFIC_NAME = N'spVentas'
)
DROP PROCEDURE spVentas
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE spVentas
-- add more stored procedure parameters here
AS
-- body of the stored procedure
SELECT
    [VentaId]
      , [Descripcion]
      , [Fecha_hora]
      , [Total]
      , [Estatus]
FROM [db_ventas].[dbo].[Venta]
GO
-- example to execute the stored procedure we just created
EXECUTE spVentas
GO


--- 2

-- Create a new stored procedure called 'spGetArticulos' in schema 'SchemaName'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'SchemaName'
    AND SPECIFIC_NAME = N'spGetArticulos'
)
DROP PROCEDURE spGetArticulos
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE spGetArticulos
-- add more stored procedure parameters here
AS
-- body of the stored procedure
SELECT
    [ArticuloId]
      , [Nombre]
      , [Descripcion]
      , [Stock]
      , [Precio]
      , [Estatus]
FROM [db_ventas].[dbo].[Articulo]
GO
-- example to execute the stored procedure we just created
EXECUTE spGetArticulos
GO



-- 3

-- Create a new stored procedure called 'spGetArticulos' in schema 'SchemaName'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'SchemaName'
    AND SPECIFIC_NAME = N'spGetArticuloId'
)
DROP PROCEDURE spGetArticulos
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE spGetArticuloId
    -- add more stored procedure parameters here
    @param /*parameter name*/ int /*datatype_for_param1*/ = 0
AS
-- body of the stored procedure
SELECT
    [ArticuloId]
      , [Nombre]
      , [Descripcion]
      , [Stock]
      , [Precio]
      , [Estatus]
FROM [db_ventas].[dbo].[Articulo]
WHERE [ArticuloId] = @param
GO
-- example to execute the stored procedure we just created
EXECUTE spGetArticuloId 1
GO


-- 4

-- Create a new stored procedure called 'spDetalleVenta' in schema 'SchemaName'
-- Drop the stored procedure if it already exists
IF EXISTS (
  SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'SchemaName'
    AND SPECIFIC_NAME = N'spDetalleVenta'
  )
  DROP PROCEDURE SchemaName.spDetalleVenta
  GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE spDetalleVenta
    @VentaId /*parameter name*/ int /*datatype_for_param1*/ = 0
/*default_value_for_param1*/
-- add more stored procedure parameters here
AS
-- body of the stored procedure
SELECT
    dtl.[VentaId]
	, [ArticuloId]
	, [Cantidad]
	, [Precio]
	, [Fecha_hora]
	, [Total]
	, [Estatus]
FROM [db_ventas].[dbo].[Detalle] as dtl
    INNER JOIN [db_ventas].[dbo].[Venta] as vts on dtl.VentaId = @VentaId
  GO
-- example to execute the stored procedure we just created
EXECUTE spDetalleVenta 1
  GO