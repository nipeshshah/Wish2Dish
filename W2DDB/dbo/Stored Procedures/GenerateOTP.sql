CREATE PROCEDURE [dbo].[GenerateOTP]
   @MobileNumber nvarchar(10),
   @OTP nvarchar(10)
AS
BEGIN
    Insert into OTPTransaction (MobileNo, OTP, SendStatus, TransactionTime, UsedStatus, ValidTill)
    VALUES (@MobileNumber, @OTP, 'SENT', GETUTCDATE(), 0, DATEADD(MINUTE,10, GETUTCDATE()))

    SELECT @@IDENTITY

END
