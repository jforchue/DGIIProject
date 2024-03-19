CREATE TABLE [dbo].[TiposContribuyentes] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nombre] VARCHAR (100) NOT NULL,
    UNIQUE NONCLUSTERED ([Nombre] ASC)
);

