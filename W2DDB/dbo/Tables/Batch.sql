CREATE TABLE [dbo].[Batch] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [BatchNumber] NVARCHAR (50) NULL,
    [BatchDate]   DATE          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

