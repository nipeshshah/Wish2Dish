CREATE PROCEDURE [dbo].[GetErCommReport]
AS
    select ToCustomer, Level, Sum(Amount) from Commissions Group By ToCustomer, Level order by ToCustomer, Level
    
    select ToCustomer, Sum(Amount) from Commissions Group By ToCustomer order by ToCustomer
    
    select Date, ToCustomer, Level, Sum(Amount) from Commissions Group By ToCustomer, Level, Date order by ToCustomer, Level, Date
    
    select Date, ToCustomer, Sum(Amount) from Commissions Group By ToCustomer, Date order by ToCustomer, Date
    
RETURN 0

