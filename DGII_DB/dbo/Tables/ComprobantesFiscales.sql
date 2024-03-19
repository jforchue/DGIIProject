CREATE TABLE [dbo].[ComprobantesFiscales]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdContribuyente] INT NOT NULL FOREIGN KEY REFERENCES Contribuyentes(Id), 
    [NCF] VARCHAR(13) NOT NULL, 
    [Monto] DECIMAL NOT NULL, 
    [Itibis18] DECIMAL NOT NULL
)
