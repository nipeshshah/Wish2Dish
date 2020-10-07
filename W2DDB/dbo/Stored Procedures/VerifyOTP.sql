CREATE PROCEDURE [dbo].[VerifyOTP]
   @MobileNumber nvarchar(10),
   @OTP nvarchar(10)
AS
BEGIN
    if(Exists(Select * from OTPTransaction Where MobileNo = @MobileNumber and OTP = @OTP and UsedStatus = 0 and ValidTill > GETUTCDATE()))
    begin
        update OTPTransaction set UsedStatus = 1 Where MobileNo = @MobileNumber and OTP = @OTP and UsedStatus = 0 and ValidTill > GETUTCDATE()
        select 'Valid' as 'Status'
    end
    else    
    begin
        select 'InValid' as 'Status'
    end
END