CREATE PROCEDURE [dbo].[GetReferralDetails]
   @ReferralCode nvarchar(100)
AS
BEGIN
    if(SUBSTRING(@ReferralCode,0,3) = 'W2D1S')
    begin
        Select [Name] from Customer where ReferralCode = @ReferralCode
    end
    else
    begin
        Select [Name] from Customer where ContactNumber = @ReferralCode
    end
END
