USE [MPI_TEST]
GO

/****** Object:  View [dbo].[Task]    Script Date: 25/05/2021 15:49:14 ******/
DROP VIEW [dbo].[Task]
GO

/****** Object:  View [dbo].[Task]    Script Date: 25/05/2021 15:49:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

  CREATE VIEW [dbo].[Task] as   SELECT * FROM [TEST].[dbo].[MetalPlus_WS$Standard Task$437dbf0e-84ff-417a-965d-ed2bb9650972]
GO

USE [MPI]
GO

/****** Object:  View [dbo].[AreeProduzione]    Script Date: 25/05/2021 15:54:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create view [dbo].[AreeProduzione] as 
select * from [TEST].[dbo].[MetalPlus_WS$Work Center$437dbf0e-84ff-417a-965d-ed2bb9650972]
GO

USE [MPI]
GO

/****** Object:  View [dbo].[Items]    Script Date: 25/05/2021 15:54:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[Items] as
select * from [TEST].[dbo].[MetalPlus_WS$Item$437dbf0e-84ff-417a-965d-ed2bb9650972]
GO

create view [dbo].[CicliBCTestata] as
SELECT * FROM [TEST].[dbo].[MetalPlus_WS$Routing Header$437dbf0e-84ff-417a-965d-ed2bb9650972]
go

create view [dbo].[CicliBCDettaglio] as
SELECT * FROM [TEST].[dbo].[MetalPlus_WS$Routing Line$437dbf0e-84ff-417a-965d-ed2bb9650972]
go


create view [dbo].[DistinteBCTestata] as
SELECT * FROM [TEST].[dbo].[MetalPlus_WS$Production BOM Header$437dbf0e-84ff-417a-965d-ed2bb9650972]
go

create view [dbo].[DistinteBCDettaglio] as
SELECT * FROM  [TEST].[dbo].[MetalPlus_WS$Production BOM Line$437dbf0e-84ff-417a-965d-ed2bb9650972]go
