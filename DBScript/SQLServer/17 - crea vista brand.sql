USE MPI_TEST
go
drop view brands
go
CREATE VIEW BRANDS as
select CASE WHEN ISNUMERIC(acronym) = 1 THEN CAST(acronym AS INT) ELSE -1 END IDBRAND,
Code CODICE, [Description] DESCRIZIONE from [PROD].[dbo].[METALPLUS$EOS028 CFG Charac_ Value$0fb12c8a-6c9e-407f-bb0e-9fee792ee665] WITH (NOLOCK)
where [Characteristic Code] = 'TBRAND'

USE MPI
GO
drop view brands
GO
CREATE VIEW BRANDS as
select CASE WHEN ISNUMERIC(acronym) = 1 THEN CAST(acronym AS INT) ELSE -1 END IDBRAND,
Code CODICE, [Description] DESCRIZIONE from [PROD].[dbo].[METALPLUS$EOS028 CFG Charac_ Value$0fb12c8a-6c9e-407f-bb0e-9fee792ee665] WITH (NOLOCK)
where [Characteristic Code] = 'TBRAND'


-- DA USARE SOLO PER EVENTUALI TEST
USE TEST
select acronym ID_BRAND_, 

CASE WHEN ISNUMERIC(acronym) = 1 THEN CAST(acronym AS INT) ELSE -1 END IDBRAND,

Code CODICE, [Description] DESCRIZIONE from [dbo].[MetalPlus_WS$EOS028 CFG Charac_ Value$0fb12c8a-6c9e-407f-bb0e-9fee792ee665]
where [Characteristic Code] = 'TBRAND'

USE MPI_TEST
GO
create view CARATTERISTICHE_ANAGRAFICA AS
select itca.[Item No_] ANAGRAFICA,itca.[Characteristic Code] CARATTERISTICA,ca.[Description]DESCARATTERISTICA,itca.Sequence SEQUENZA, itca.[Characteristic Value] VALORE,va.[Description] DESVALORE
 from [PROD].[dbo].[METALPLUS$EOS028 CFG Item Var_ Charac_$0fb12c8a-6c9e-407f-bb0e-9fee792ee665] itca with(nolock)
inner join [PROD].[dbo].[METALPLUS$EOS028 CFG Characteristic$0fb12c8a-6c9e-407f-bb0e-9fee792ee665] ca with(nolock) on ca.code = itca.[Characteristic Code]
inner join [PROD].[dbo].[METALPLUS$EOS028 CFG Charac_ Value$0fb12c8a-6c9e-407f-bb0e-9fee792ee665] va with(nolock) on va.[Characteristic Code]=itca.[Characteristic Code] and va.Code = itca.[Characteristic Value]

USE MPI
GO
create view CARATTERISTICHE_ANAGRAFICA AS
select itca.[Item No_] ANAGRAFICA,itca.[Characteristic Code] CARATTERISTICA,ca.[Description]DESCARATTERISTICA,itca.Sequence SEQUENZA, itca.[Characteristic Value] VALORE,va.[Description] DESVALORE
 from [PROD].[dbo].[METALPLUS$EOS028 CFG Item Var_ Charac_$0fb12c8a-6c9e-407f-bb0e-9fee792ee665] itca with(nolock)
inner join [PROD].[dbo].[METALPLUS$EOS028 CFG Characteristic$0fb12c8a-6c9e-407f-bb0e-9fee792ee665] ca with(nolock) on ca.code = itca.[Characteristic Code]
inner join [PROD].[dbo].[METALPLUS$EOS028 CFG Charac_ Value$0fb12c8a-6c9e-407f-bb0e-9fee792ee665] va with(nolock) on va.[Characteristic Code]=itca.[Characteristic Code] and va.Code = itca.[Characteristic Value]

