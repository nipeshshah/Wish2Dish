CREATE TABLE [dbo].[Customer] (
    [Id]               BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (50)  NULL,
    [ReferredBy]       NVARCHAR(30)         NULL,
    [Status]           NVARCHAR (50)  CONSTRAINT [DF_Customer_Status] DEFAULT (N'Active') NULL,
    [UserId]           NVARCHAR (128) NULL,
    [RegistrationDate] DATETIME       NULL,
    [ContactNumber]    NVARCHAR (20)  NULL,
    [ReferralCode] NVARCHAR(30) NULL, 
    CONSTRAINT [PK__Customer__3214EC0723AD83F7] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Customer_ToCustomer] FOREIGN KEY ([ReferredBy]) REFERENCES [dbo].[Customer] ([Id])
);

