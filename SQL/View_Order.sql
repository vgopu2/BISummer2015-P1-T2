USE [AdventureWorksLT2008]
GO

/****** Object:  View [SalesLT].[vProductListing]    Script Date: 6/26/2015 2:10:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [SalesLT].[vOrder] 
AS 

SELECT 
P.[ProductID]
      ,P.[Name]
      ,P.[ProductNumber]
      ,P.[Color]
      ,P.[StandardCost]
      ,P.[ListPrice]
      ,P.[Size]
      ,P.[Weight]
      ,P.[ProductCategoryID]
      ,P.[ProductModelID]
      ,P.[SellStartDate]
      ,P.[SellEndDate]
      ,P.[DiscontinuedDate]
      ,P.[ThumbnailPhotoFileName]
	  ,PM.Name AS ModelName
	  ,PC.Name AS CategoryName
	  ,PC.ParentProductCategoryID
	  ,SOD.[SalesOrderID]
      ,[SalesOrderDetailID]
      ,[OrderQty]
      ,[UnitPrice]
      ,[UnitPriceDiscount]
      ,[LineTotal]
	  ,[DueDate]
      ,[ShipDate]
      ,dbo.[ufnGetSalesOrderStatusText]([STATUS]) as [Status]
	  ,SOH.CustomerID

FROM 
SalesLT.SalesOrderDetail SOD
LEFT JOIN SalesLT.Product P ON SOD.ProductID =P.ProductID
Left JOIN SalesLT.ProductCategory PC ON P.ProductCategoryID = PC.ProductCategoryID
Left JOIN SalesLT.ProductModel PM ON P.ProductModelID = PM.ProductModelID
LEFT JOIN SalesLT.SalesOrderHeader SOH on SOH.SalesOrderID = SOD.SalesOrderID



GO


