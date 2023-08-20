CREATE TABLE [dbo].[PalletWithContents] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [IdPallet] INT NULL,
    [IdBox]    INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

