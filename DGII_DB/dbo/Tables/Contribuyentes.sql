CREATE TABLE [dbo].[Contribuyentes] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nombre] VARCHAR(300) NULL,
    [Tipo]   INT        NOT NULL,
    [Activo] BIT        NULL,
    FOREIGN KEY ([Tipo]) REFERENCES [dbo].[TiposContribuyentes] ([Id])
);


