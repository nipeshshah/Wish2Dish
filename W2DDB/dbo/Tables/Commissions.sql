CREATE TABLE [dbo].[Commissions] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [Description]    NVARCHAR (MAX)  NULL,
    [FromCustomer]   BIGINT          NULL,
    [ToCustomer]     BIGINT          NULL,
    [ProductBatchId] INT             NULL,
    [Level]          INT             NULL,
    [Amount]         DECIMAL (18, 2) NULL,
    [SalesBillId]    INT             NULL,
    [Status]         NVARCHAR (50)   NULL,
    [Date]           DATETIME        NULL,
    CONSTRAINT [PK__Commissi__3214EC07FE560DC7] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Commissions_Customer] FOREIGN KEY ([FromCustomer]) REFERENCES [dbo].[Customer] ([Id]),
    CONSTRAINT [FK_Commissions_Customer1] FOREIGN KEY ([ToCustomer]) REFERENCES [dbo].[Customer] ([Id]),
    CONSTRAINT [FK_Commissions_ProductBatch] FOREIGN KEY ([ProductBatchId]) REFERENCES [dbo].[ProductBatch] ([Id]),
    CONSTRAINT [FK_Commissions_Sales] FOREIGN KEY ([SalesBillId]) REFERENCES [dbo].[Sales] ([Id])
);

