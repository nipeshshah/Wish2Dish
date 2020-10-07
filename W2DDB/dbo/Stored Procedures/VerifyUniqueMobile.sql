CREATE PROCEDURE [dbo].[VerifyUniqueMobile]
    @MobileNumber nvarchar(10)
AS
    Select ContactNumber from Customer where ContactNumber = @MobileNumber
RETURN 0
