CREATE TABLE [dbo].[Pallet] (
    [Id]     INT        IDENTITY (1, 1) NOT NULL,
    [Length] FLOAT (53) NOT NULL,
    [Width]  FLOAT (53) NOT NULL,
    [Height] FLOAT (53) NOT NULL,
    [Weight] FLOAT (53) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

