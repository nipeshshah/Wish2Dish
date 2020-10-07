CREATE TABLE [dbo].[Sales] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [CustomerId]      BIGINT          NULL,
    [SDate]           DATE            NULL,
    [Inv No]          NVARCHAR (20)   NULL,
    [DueAmount]       DECIMAL (18, 2) NULL,
    [PaidAmount]      DECIMAL (18, 2) NULL,
    [TotalBillAmount] DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Sales_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id])
);

