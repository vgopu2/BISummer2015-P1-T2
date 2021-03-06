USE [AdventureWorksLT2008]
GO
/****** Object:  StoredProcedure [dbo].[spAuthenticateUser]    Script Date: 6/26/2015 2:34:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spAuthenticateUser]
	(
	@email varchar(50),
	@password varchar(50)
	)	
AS
BEGIN
Declare @count int
Declare @passwordInDb varchar(50)
Declare @returnCode int
Declare @customerId int

SELECT @count = COUNT([EmailAddress])
FROM [SalesLT].[Customer]
WHERE [EmailAddress] = @email 

 SET @returnCode = -1
IF @count = 1 
  BEGIN  
   SELECT  @customerId = [CustomerID], @passwordInDb = [PasswordHash]
    FROM [SalesLT].[Customer]
    WHERE  [EmailAddress] = @email 
   
   IF @passwordInDb = @password
    BEGIN
      SET @returnCode = @customerId
    END
  END

SELECT @returnCode as returnValue
END
