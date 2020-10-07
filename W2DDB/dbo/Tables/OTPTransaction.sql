CREATE TABLE [dbo].[OTPTransaction] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [MobileNo]        NVARCHAR (10) NULL,
    [OTP]             NVARCHAR (4)  NULL,
    [SendStatus]      NVARCHAR (10) NULL,
    [UsedStatus]      BIT           NULL,
    [TransactionTime] DATETIME      NULL,
    [ValidTill]       DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

