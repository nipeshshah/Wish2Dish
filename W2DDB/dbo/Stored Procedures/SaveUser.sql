CREATE PROCEDURE [dbo].[SaveUser]
   @FirstName nvarchar(100),
   @LastName nvarchar(100),
   @MobileNo nvarchar(10),
   @Pincode nvarchar(6),
   @ReferralCode  nvarchar(15)
AS
BEGIN
    if(NOT(SUBSTRING(@ReferralCode,0,3) = 'WB'))
    begin
        Select @ReferralCode = ReferralCode from Customer where ContactNumber = @ReferralCode
    end
    
    Insert into Customer ([Name],[ContactNumber], [ReferralCode], [ReferredBy],[RegistrationDate],[Status])
                Values (Concat(@FirstName , ' ' , @LastName), @MobileNo, '', @ReferralCode, GETUTCDATE(),'Active')

    Update Customer set [ReferralCode] = Concat('WB' , FORMAT(Id, '00000000')) where Id = @@IDENTITY

END
