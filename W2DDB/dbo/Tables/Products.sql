CREATE TABLE [dbo].[Products] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (50)   NULL,
    [Image]          NVARCHAR (MAX)  NULL,
    [CategoryId]     INT             NULL,
    [Gujarati]       NVARCHAR (50)   NULL,
    [Hindi]          NVARCHAR (50)   NULL,
    [Weight]         DECIMAL (10, 3) NULL,
    [StandardWeight] DECIMAL (10, 3) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Products_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id])
);

