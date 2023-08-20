CREATE TABLE [dbo].[Box]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Length] FLOAT NOT NULL, 
    [Width] NCHAR(10) NOT NULL, 
    [Height] NCHAR(10) NOT NULL, 
    [Volume] NCHAR(10) NOT NULL, 
    [ProductionDate] DATETIME NULL, 
    [ExpirationDate] NCHAR(10) NULL
)
