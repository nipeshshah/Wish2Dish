CREATE TABLE [dbo].[Points] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [CustomerId]      INT             NULL,
    [Description]     NVARCHAR (100)  NULL,
    [Points]          DECIMAL (18, 2) NULL,
    [Status]          NVARCHAR (50)   NULL,
    [TransactionTime] DATETIME        NULL,
    [ProductBatchId]  INT             NULL,
    CONSTRAINT [PK_Points] PRIMARY KEY CLUSTERED ([Id] ASC)
);

