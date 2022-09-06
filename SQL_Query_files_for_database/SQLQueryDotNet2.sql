USE [QuanLySanPham]
GO

UPDATE [dbo].[Catalog]
   SET 
      [CatalogName] = N'Điện Thoại'
 WHERE id=1
GO

UPDATE [dbo].[Catalog]
   SET 
      [CatalogName] = N'Máy Tính'
 WHERE id=2
GO

UPDATE [dbo].[Catalog]
   SET 
      [CatalogName] = N'Thời Trang'
 WHERE id=3
GO

UPDATE [dbo].[Catalog]
   SET 
      [CatalogName] = N'Gia Dụng'
 WHERE id=4
GO

USE [QuanLySanPham]
GO

-- 

DELETE FROM [dbo].[Catalog]
      WHERE id=0
GO

--

DELETE FROM [dbo].[Product]
      WHERE id=0
GO

--
SET IDENTITY_INSERT [dbo].[Catalog] OFF
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[Catalog] ON
SET IDENTITY_INSERT [dbo].[Product] ON