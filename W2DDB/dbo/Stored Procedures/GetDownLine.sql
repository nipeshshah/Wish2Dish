CREATE PROCEDURE [dbo].[GetDownLine] 
    @customerId INT
AS
    DECLARE @cnt INT = 0;
    DECLARE @CNAME NVARCHAR(100)
    --DECLARE @customerId INT = 2

    DECLARE @myteamlevel TABLE ([Id] INT, [Name] varchar(100), level int)
    INSERT INTO @myteamlevel([Id], [Name], level)
        Values (@customerId, 'YOU', @cnt)
       
    WHILE @cnt <= 10
    BEGIN
        --Select @customerId = ReferredBy from Customer where [Id] = @customerId
        if(@customerId is null)
            break;
        INSERT INTO @myteamlevel([Id], [Name], level)
        Select [Id], [Name], @cnt from Customer where ReferredBy in (select [Id] from @myteamlevel where level = @cnt -1)
        
       SET @cnt = @cnt + 1;
    END;
    select t.[Id] as MemberId, t.[Name] as MemberName, t.level as Level, c.[Name] as ReferralName from @myteamlevel t left join Customer c on t.[Id] = c.[Id]
    
RETURN 0


