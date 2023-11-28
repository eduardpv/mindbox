IF OBJECT_ID('tempdb..#Category') IS NOT NULL DROP TABLE [#Category];
GO

CREATE TABLE [#Category]
(
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(15) NOT NULL UNIQUE
);
GO

IF OBJECT_ID('tempdb..#Product') IS NOT NULL DROP TABLE [#Product];
GO 

CREATE TABLE [#Product]
(
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(15) NOT NULL UNIQUE,
	
);
GO

IF OBJECT_ID('tempdb..#Category_Product') IS NOT NULL DROP TABLE #Category_Product;
GO 

CREATE TABLE [#Category_Product]
(
	[CategoryId] INT FOREIGN KEY REFERENCES [#Category]([Id]),
	[ProductId] INT FOREIGN KEY REFERENCES [#Category]([Id])
)
GO

IF NOT EXISTS (SELECT 1 FROM [#Category])
BEGIN
	INSERT INTO [#Category] VALUES (1, 'Category1');
	INSERT INTO [#Category] VALUES (2, 'Category2');
	INSERT INTO [#Category] VALUES (3, 'Category3');
END
GO

IF NOT EXISTS (SELECT 1 FROM [#Product])
BEGIN
	INSERT INTO [#Product] VALUES (1, 'Product1');
	INSERT INTO [#Product] VALUES (2, 'Product2');
	INSERT INTO [#Product] VALUES (3, 'Product3');
	INSERT INTO [#Product] VALUES (4, 'Product4');
	INSERT INTO [#Product] VALUES (5, 'Product5');
END
GO

IF NOT EXISTS (SELECT 1 FROM [#Category_Product])
BEGIN
	INSERT INTO [#Category_Product] VALUES (1, 1);
	INSERT INTO [#Category_Product] VALUES (1, 2);
	INSERT INTO [#Category_Product] VALUES (2, 1);
	INSERT INTO [#Category_Product] VALUES (2, 3);
	INSERT INTO [#Category_Product] VALUES (3, 3);
	INSERT INTO [#Category_Product] VALUES (NULL, 4);
	INSERT INTO [#Category_Product] VALUES (NULL, 5);
END
GO

SELECT [P].[Name] AS [ProductName], [C].[Name] AS [CategoryName] FROM [#Product] AS [P]
LEFT JOIN [#Category_Product] AS [CP] ON ([P].[Id] = [CP].[ProductId])
LEFT JOIN [#Category] AS [C] ON ([CP].[CategoryId] = [C].[Id])
