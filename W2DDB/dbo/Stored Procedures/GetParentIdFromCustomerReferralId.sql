CREATE PROCEDURE GetParentIdFromCustomerReferralId 
	@customerId INT = 10011
as
Begin

	DECLARE @cnt INT = 0;
	DECLARE @CNAME NVARCHAR(50)
	DECLARE @myteamlevel TABLE ([Id] INT, [Name] varchar(20), level int, parent int)
	INSERT INTO @myteamlevel([Id], [Name], level, parent)
		Values (@customerId, 'YOU', @cnt, 0)
       
	WHILE @cnt <= 10
	BEGIN
		--Select @customerId = ReferredBy from Customer where [Id] = @customerId
		if(@customerId is null)
			break;
		INSERT INTO @myteamlevel([Id], [Name], level, parent)
		Select [Id], [Name], @cnt, ReferredBy from Customer where ReferredBy in (select [Id] from @myteamlevel where level = @cnt -1)
        
		SET @cnt = @cnt + 1;
	END;
	select * from @myteamlevel
	SET @cnt = 0
	DECLARE @totolLevel int = 0
	WHILE @cnt <= 10
	BEGIN
		--SELECT * from @myteamlevel where level = @cnt
		select @totolLevel = Count([Id]) from @myteamlevel where level = @cnt
		print(@totolLevel)
		IF(@totolLevel < POWER(2,@cnt))
		BEGIN
			SELECT parent as [Id],* from @myteamlevel t 
			where level = @cnt and (select count(*) from @myteamlevel where level = @cnt and parent = t.parent) < 2
			BREAK;
		END
	SET @cnt = @cnt + 1;
	END;
end
