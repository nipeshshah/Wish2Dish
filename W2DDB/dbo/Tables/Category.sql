CREATE TABLE [dbo].[Category] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [CategoryName] NVARCHAR (50) NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([Id] ASC)
);

