USE [QuanLySanPham]
GO

INSERT INTO [dbo].[Catalog]
           (
		   [Id]
           ,
		   [CatalogCode]
           ,[CatalogName])
     VALUES
           (
		   1,
		   'DM01',N'Điện Thoại'),
           (
		   2,
		   'DM02',N'Máy Tính'),
           (
		   3,
		   'DM03',N'Thời Trang'),
           (
		   4,
		   'DM04',N'Gia Dụng')
GO




INSERT INTO [dbo].[Product]
           (
		   [Id]
           ,
		   [CatalogId]
           ,[ProductCode]
		   ,[ProductName]
		   ,[Picture]
		   ,[UnitPrice])
     VALUES
           (
		   1,
		   1,'PRO01','SamSung J7 Prime','PRO01.PNG',10000000),
           (
		   2,
		   1,'PRO02','Iphone X','PRO02.PNG',30000000),
           (
		   3,
		   2,'PRO03','Dell Inspiron N3552','PRO03.PNG',12000000),
           (
		   4,
		   2,'PRO04','Dell Inspiron N3467','PRO04.PNG',13000000),
           (
		   5,
		   2,'PRO05','Acer AS A315-31-C8GB','PRO05.PNG',9000000)
GO