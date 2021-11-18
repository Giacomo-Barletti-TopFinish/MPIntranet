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

  CREATE VIEW [dbo].[Task] as   SELECT * FROM [TEST].[dbo].[MetalPlus_WS$Standard Task$437dbf0e-84ff-417a-965d-ed2bb9650972] WITH (NOLOCK)
GO

USE [MPI]
GO

/****** Object:  View [dbo].[AreeProduzione]    Script Date: 25/05/2021 15:54:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create view [dbo].[AreeProduzione] as 
select * from [TEST].[dbo].[MetalPlus_WS$Work Center$437dbf0e-84ff-417a-965d-ed2bb9650972] WITH (NOLOCK)
GO


/****** Object:  View [dbo].[Items]    Script Date: 25/05/2021 15:54:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[Items] as
select * from [TEST].[dbo].[MetalPlus_WS$Item$437dbf0e-84ff-417a-965d-ed2bb9650972]WITH (NOLOCK)
GO

create view [dbo].[CicliBCTestata] as
SELECT * FROM [TEST].[dbo].[MetalPlus_WS$Routing Header$437dbf0e-84ff-417a-965d-ed2bb9650972]WITH (NOLOCK)
go
create view [dbo].[CicliBCDettaglio] as
select A.*,B.[MTP Card Code] 
from [TEST].[dbo].[MetalPlus_WS$Routing Line$437dbf0e-84ff-417a-965d-ed2bb9650972] A WITH (NOLOCK)
INNER JOIN TEST.[dbo].[MetalPlus_WS$Routing Line$acfbaca5-f819-4981-a342-d769a95abeb3] B WITH (NOLOCK)ON A.[Routing No_]=B.[Routing No_] AND A.[Version Code]=B.[Version Code] AND A.[Operation No_]=B.[Operation No_]
GO

create view [dbo].[CicliBCCommenti] as
SELECT * FROM [TEST].[dbo].[MetalPlus_WS$Routing Comment Line$437dbf0e-84ff-417a-965d-ed2bb9650972]WITH (NOLOCK)
go

create view [dbo].[DistinteBCTestata] as
SELECT * FROM [TEST].[dbo].[MetalPlus_WS$Production BOM Header$437dbf0e-84ff-417a-965d-ed2bb9650972]WITH (NOLOCK)
go

create view [dbo].[DistinteBCDettaglio] as
SELECT * FROM  [TEST].[dbo].[MetalPlus_WS$Production BOM Line$437dbf0e-84ff-417a-965d-ed2bb9650972]WITH (NOLOCK)
go

CREATE VIEW [DBO].[ArticoliOrdiniProduzione] as
select * from [TEST].[dbo].[MetalPlus_WS$Prod_ Order Line$437dbf0e-84ff-417a-965d-ed2bb9650972]WITH (NOLOCK)

go
CREATE VIEW [DBO].[ComponentiOrdiniProduzione] as
select * from [TEST].[dbo].[MetalPlus_WS$Prod_ Order Component$437dbf0e-84ff-417a-965d-ed2bb9650972]WITH (NOLOCK)

go
CREATE VIEW [DBO].[FasiOrdiniProduzione] as
select * from [TEST].[dbo].[MetalPlus_WS$Prod_ Order Routing Line$437dbf0e-84ff-417a-965d-ed2bb9650972]WITH (NOLOCK)
go
CREATE VIEW [DBO].[VersamentiFasiOrdiniProduzione] as
select * from [TEST].[dbo].[MetalPlus_WS$Capacity Ledger Entry$437dbf0e-84ff-417a-965d-ed2bb9650972]WITH (NOLOCK)

GO
USE [MPI]
GO

create OR ALTER view [dbo].[Items] as
select * from [PROD].[dbo].[METALPLUS$Item$437dbf0e-84ff-417a-965d-ed2bb9650972]WITH (NOLOCK)
GO

create or alter view [dbo].[CicliBCTestata] as
SELECT * FROM [PROD].[dbo].[METALPLUS$Routing Header$437dbf0e-84ff-417a-965d-ed2bb9650972]WITH (NOLOCK)
go

create view [dbo].[CicliBCDettaglio] as
select A.*,B.[MTP Card Code] 
FROM [PROD].[dbo].[MetalPlus$Routing Line$437dbf0e-84ff-417a-965d-ed2bb9650972] A WITH (NOLOCK)
INNER JOIN [PROD].[dbo].[METALPLUS$Routing Line$acfbaca5-f819-4981-a342-d769a95abeb3] B WITH (NOLOCK)ON A.[Routing No_]=B.[Routing No_] AND A.[Version Code]=B.[Version Code] AND A.[Operation No_]=B.[Operation No_]
go

create or alter view [dbo].[CicliBCCommenti] as
SELECT * FROM [PROD].[dbo].[MetalPlus$Routing Comment Line$437dbf0e-84ff-417a-965d-ed2bb9650972]WITH (NOLOCK)
go

create or alter view [dbo].[DistinteBCTestata] as
SELECT * FROM [PROD].[dbo].[MetalPlus$Production BOM Header$437dbf0e-84ff-417a-965d-ed2bb9650972]WITH (NOLOCK)
go

create or alter view [dbo].[DistinteBCDettaglio] as
SELECT * FROM  [PROD].[dbo].[MetalPlus$Production BOM Line$437dbf0e-84ff-417a-965d-ed2bb9650972]WITH (NOLOCK)
go

CREATE VIEW [DBO].[ArticoliOrdiniProduzione] as
select * from [PROD].[dbo].[MetalPlus$Prod_ Order Line$437dbf0e-84ff-417a-965d-ed2bb9650972]WITH (NOLOCK)

go
CREATE VIEW [DBO].[ComponentiOrdiniProduzione] as
select * from [PROD].[dbo].[MetalPlus$Prod_ Order Component$437dbf0e-84ff-417a-965d-ed2bb9650972]WITH (NOLOCK)

go
CREATE VIEW [DBO].[FasiOrdiniProduzione] as
select * from [PROD].[dbo].[MetalPlus$Prod_ Order Routing Line$437dbf0e-84ff-417a-965d-ed2bb9650972]WITH (NOLOCK)
go
CREATE VIEW [DBO].[VersamentiFasiOrdiniProduzione] as
select * from [PROD].[dbo].[MetalPlus$Capacity Ledger Entry$437dbf0e-84ff-417a-965d-ed2bb9650972]WITH (NOLOCK)
