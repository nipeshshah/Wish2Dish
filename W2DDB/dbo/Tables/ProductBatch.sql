CREATE TABLE [dbo].[ProductBatch] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [BatchId]   INT             NULL,
    [ProductId] INT             NULL,
    [PP]        DECIMAL (18, 2) NULL,
    [Exp]       DECIMAL (18, 2) NULL,
    [MRP]       DECIMAL (18, 2) NULL,
    [Prof]      DECIMAL (18, 2) NULL,
    [Stock]     DECIMAL (18, 3) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProductBatch_Batch] FOREIGN KEY ([BatchId]) REFERENCES [dbo].[Batch] ([Id]),
    CONSTRAINT [FK_ProductBatch_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id])
);

