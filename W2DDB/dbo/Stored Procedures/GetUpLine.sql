CREATE PROCEDURE [dbo].[GetUpLine]
    @customerId int
AS
    DECLARE @cnt INT = 0;
    DECLARE @CNAME NVARCHAR(50)

	DECLARE @myteamlevel TABLE (id INT, [Name] varchar(20), level int)

    WHILE @cnt < 10
    BEGIN
       Select @customerId = ReferredBy from Customer where Id = @customerId
        if(@customerId is null)
            break;
       Select @CNAME = [Name] from Customer where Id = @customerId
       Print CONCAT('L',(@cnt+1), '-', @customerId,'-',@CNAME)
	   Insert into @myteamlevel (id, [Name], level) values (@customerId, @CNAME, @cnt+1)
       SET @cnt = @cnt + 1;
    END;

	select t.id as MemberId, t.[Name] as MemberName, t.level as Level, c.[Name] as ReferralName from @myteamlevel t left join Customer c on t.id = c.Id
