CREATE TABLE [dbo].[SalesInventory] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [SalesId]        INT             NULL,
    [ProductBatchId] INT             NULL,
    [ProductId]      INT             NULL,
    [Rate]           DECIMAL (18, 2) NULL,
    [Quantity]       DECIMAL (18, 3) NULL,
    [Amount]         DECIMAL (18, 2) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SalesInventory_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]),
    CONSTRAINT [FK_SalesInventory_Sales] FOREIGN KEY ([SalesId]) REFERENCES [dbo].[Sales] ([Id])
);

