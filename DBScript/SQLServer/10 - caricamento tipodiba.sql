USE [MPI]
GO

INSERT INTO [dbo].[TIPIDIBA] ([TIPODIBA],[CANCELLATO],[DATAMODIFICA],[UTENTEMODIFICA])VALUES('PREVENTIVO',0, GETDATE(),'IMPIANTO') 
GO
INSERT INTO [dbo].[TIPIDIBA] ([TIPODIBA],[CANCELLATO],[DATAMODIFICA],[UTENTEMODIFICA])VALUES('PRESERIE',0, GETDATE(),'IMPIANTO') 
GO
INSERT INTO [dbo].[TIPIDIBA] ([TIPODIBA],[CANCELLATO],[DATAMODIFICA],[UTENTEMODIFICA])VALUES('PRODUZIONE',0, GETDATE(),'IMPIANTO') 
GO

