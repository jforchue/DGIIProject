/*
Plantilla de script posterior a la implementación							
--------------------------------------------------------------------------------------
 Este archivo contiene instrucciones de SQL que se anexarán al script de compilación.		
 Use la sintaxis de SQLCMD para incluir un archivo en el script posterior a la implementación.			
 Ejemplo:      :r .\miArchivo.sql								
 Use la sintaxis de SQLCMD para hacer referencia a una variable en el script posterior a la implementación.		
 Ejemplo:      :setvar TableName miTabla							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO TiposContribuyentes (Nombre) VALUES ('Persona Física');
INSERT INTO TiposContribuyentes (Nombre) VALUES ('Persona Jurídica');

GO

-- Insertar 10 personas en la tabla Contribuyentes con nombres de ejemplo
INSERT INTO Contribuyentes (Nombre, Tipo, Activo)
VALUES 
('Juan Pérez', 1, 1),     -- Persona jurídica
('María García', 2, 0),   -- Persona física
('Pedro López', 1, 1),    -- Persona jurídica
('Ana Martínez', 2, 0),   -- Persona física
('Luis Rodríguez', 1, 1), -- Persona jurídica
('Laura Hernández', 2, 0),-- Persona física
('Carlos Sánchez', 1, 1), -- Persona jurídica
('Sofía Díaz', 2, 0),     -- Persona física
('Roberto Gómez', 1, 1),  -- Persona jurídica
('Elena Vázquez', 2, 0);  -- Persona física

GO

-- Insertar comprobantes fiscales de ejemplo para cada persona en la tabla Contribuyentes
INSERT INTO ComprobantesFiscales (IdContribuyente, NCF, Monto, Itibis18)
VALUES 
(1, 'B010123456', 50000, 9000),
(1, 'B010789012', 75000, 13500),
(2, 'B010345678', 60000, 10800),
(3, 'B010901234', 35000, 6300),
(4, 'B010567890', 80000, 14400),
(5, 'B010234567', 40000, 7200),
(5, 'B010890123', 55000, 9900),
(6, 'B010456789', 70000, 12600),
(7, 'B010012345', 45000, 8100),
(8, 'B010678901', 85000, 15300),
(8, 'B010234567', 60000, 10800),
(8, 'B010890123', 70000, 12600),
(9, 'B010345678', 50000, 9000),
(10, 'B010901234', 90000, 16200);
