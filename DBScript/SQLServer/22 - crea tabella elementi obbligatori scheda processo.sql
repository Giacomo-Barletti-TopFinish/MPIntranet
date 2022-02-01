USE MPI
GO
CREATE TABLE [SPELEMENTIOBBLIGATORI]
(
 [IDSPELEMENTOOBBLIGATORIO]		int IDENTITY (1, 1) NOT NULL ,
 [IDSPMASTEROBBLIGATORIO]     int NOT NULL ,
 [IDSPCONTROLLO]     int  NULL ,
 [SEQUENZA]       int NOT NULL ,
 [OBBLIGATORIO]    BIT NULL ,
 [TIPOELEMENTO]  NVARCHAR(12) NOT NULL,
 [TESTO]		NVARCHAR(25) NULL,
 [CANCELLATO]     bit NOT NULL ,
 [DATAMODIFICA]   datetime NOT NULL ,
 [UTENTEMODIFICA] nvarchar(50) NOT NULL ,
 CONSTRAINT [PK_SPELEMENTIOBBLIGATORI] PRIMARY KEY CLUSTERED ([IDSPELEMENTOOBBLIGATORIO] ASC),
 CONSTRAINT [FK_SPELEMENTIOBBLIGATORI_2] FOREIGN KEY ([IDSPCONTROLLO])  REFERENCES [SPCONTROLLI]([IDSPCONTROLLO])
);

GO

CREATE TABLE [SPELEMENTIOBBLIGATORI_LOG]
(
 [IDSPELEMENTOOBBLIGATORIO]		int NULL ,
 [IDSPMASTEROBBLIGATORIO]     int  NULL ,
 [IDSPCONTROLLO]     int  NULL ,
 [SEQUENZA]       int  NULL ,
 [OBBLIGATORIO]    BIT NULL ,
 [TIPOELEMENTO]  NVARCHAR(12)  NULL,
 [TESTO]		NVARCHAR(25) NULL,
 [CANCELLATO]     bit  NULL ,
 [DATAMODIFICA]   datetime  NULL ,
 [UTENTEMODIFICA] nvarchar(50)  NULL 
);
GO


CREATE OR ALTER TRIGGER SPELEMENTIOBBLIGATORI_LOG_I
ON SPELEMENTIOBBLIGATORI
AFTER INSERT
AS
BEGIN 
INSERT INTO SPELEMENTIOBBLIGATORI_LOG ([IDSPELEMENTOOBBLIGATORIO], [IDSPMASTEROBBLIGATORIO],[IDSPCONTROLLO],[SEQUENZA],[OBBLIGATORIO],[TIPOELEMENTO],[TESTO],CANCELLATO, DATAMODIFICA, UTENTEMODIFICA) 
SELECT I.[IDSPELEMENTOOBBLIGATORIO], I.[IDSPMASTEROBBLIGATORIO],I.[IDSPCONTROLLO],I.[SEQUENZA],I.[OBBLIGATORIO],I.[TIPOELEMENTO],I.[TESTO],I.CANCELLATO, I.DATAMODIFICA, I.UTENTEMODIFICA FROM INSERTED I
END


GO
CREATE OR ALTER TRIGGER SPELEMENTIOBBLIGATORI_LOG_U
ON SPELEMENTIOBBLIGATORI
AFTER UPDATE
AS
BEGIN 
INSERT INTO SPELEMENTIOBBLIGATORI_LOG ([IDSPELEMENTOOBBLIGATORIO], [IDSPMASTEROBBLIGATORIO],[IDSPCONTROLLO],[SEQUENZA],[OBBLIGATORIO],[TIPOELEMENTO],[TESTO],CANCELLATO, DATAMODIFICA, UTENTEMODIFICA) 
SELECT I.[IDSPELEMENTOOBBLIGATORIO], I.[IDSPMASTEROBBLIGATORIO],I.[IDSPCONTROLLO],I.[SEQUENZA],I.[OBBLIGATORIO],I.[TIPOELEMENTO],I.[TESTO],I.CANCELLATO, I.DATAMODIFICA, I.UTENTEMODIFICA FROM INSERTED I
INNER JOIN DELETED D ON D.[IDSPELEMENTOOBBLIGATORIO]=I.[IDSPELEMENTOOBBLIGATORIO]
END

go

alter table SPMASTERS ADD IDSCHEDAOBBLIGATORIA INTEGER NULL
UPDATE SPMASTERS SET IDSCHEDAOBBLIGATORIA = 1
ALTER TABLE SPMASTERS ALTER COLUMN IDSCHEDAOBBLIGATORIA INTEGER NOT NULL
GO
alter table SPMASTERS_LOG ADD IDSCHEDAOBBLIGATORIA INTEGER NULL
UPDATE SPMASTERS_LOG SET IDSCHEDAOBBLIGATORIA = 1

GO

CREATE OR ALTER TRIGGER SPMASTERS_LOG_I
ON SPMASTERS
AFTER INSERT
AS
BEGIN 
INSERT INTO SPMASTERS_LOG ([IDSPMASTER], [AREAPRODUZIONE],[TASK],[CODICE],DESCRIZIONE,CANCELLATO, DATAMODIFICA, UTENTEMODIFICA,IDSCHEDAOBBLIGATORIA) 
SELECT I.[IDSPMASTER], I.[AREAPRODUZIONE],I.[TASK],I.[CODICE],I.DESCRIZIONE,I.CANCELLATO, I.DATAMODIFICA, I.UTENTEMODIFICA,IDSCHEDAOBBLIGATORIA FROM INSERTED I
END


GO
CREATE OR ALTER TRIGGER SPMASTERS_LOG_U
ON SPMASTERS
AFTER UPDATE
AS
BEGIN 
INSERT INTO SPMASTERS_LOG ([IDSPMASTER], [AREAPRODUZIONE],[TASK],[CODICE],DESCRIZIONE,CANCELLATO, DATAMODIFICA, UTENTEMODIFICA,IDSCHEDAOBBLIGATORIA) 
SELECT I.[IDSPMASTER], I.[AREAPRODUZIONE],I.[TASK],I.[CODICE],I.DESCRIZIONE,I.CANCELLATO, I.DATAMODIFICA, I.UTENTEMODIFICA,I.IDSCHEDAOBBLIGATORIA FROM INSERTED I
INNER JOIN DELETED D ON D.[IDSPMASTER]=I.[IDSPMASTER]
END
GO

alter table [SPCONTROLLI] ADD VISIBILE bit NULL
UPDATE [SPCONTROLLI] SET VISIBILE = 1
ALTER TABLE [SPCONTROLLI] ALTER COLUMN VISIBILE bit NOT NULL
go
alter table [SPCONTROLLI_LOG] ADD VISIBILE bit NULL
UPDATE [SPCONTROLLI_LOG] SET VISIBILE = 1

go
CREATE OR ALTER TRIGGER SPCONTROLLI_LOG_I
ON SPCONTROLLI
AFTER INSERT
AS
BEGIN 
INSERT INTO SPCONTROLLI_LOG ([IDSPCONTROLLO], [CODICE],[DESCRIZIONE],[TIPO],[MINIMO],[MASSIMO],[DEFAULT],CANCELLATO, DATAMODIFICA, UTENTEMODIFICA,VISIBILE) 
SELECT I.[IDSPCONTROLLO], I.[CODICE],I.[DESCRIZIONE],I.[TIPO],I.[MINIMO],I.[MASSIMO],I.[DEFAULT],I.CANCELLATO, I.DATAMODIFICA, I.UTENTEMODIFICA,I.VISIBILE FROM INSERTED I
END

GO
CREATE OR ALTER TRIGGER SPCONTROLLI_LOG_U
ON SPCONTROLLI
AFTER UPDATE
AS
BEGIN 
INSERT INTO SPCONTROLLI_LOG ([IDSPCONTROLLO], [CODICE],[DESCRIZIONE],[TIPO],[MINIMO],[MASSIMO],[DEFAULT],CANCELLATO, DATAMODIFICA, UTENTEMODIFICA,VISIBILE) 
SELECT I.[IDSPCONTROLLO], I.[CODICE],I.[DESCRIZIONE],I.[TIPO],I.[MINIMO],I.[MASSIMO],I.[DEFAULT],I.CANCELLATO, I.DATAMODIFICA, I.UTENTEMODIFICA,I.VISIBILE FROM INSERTED I
INNER JOIN DELETED D ON D.[IDSPCONTROLLO]=I.[IDSPCONTROLLO]
END



INSERT INTO SPELEMENTIOBBLIGATORI ( [IDSPMASTEROBBLIGATORIO],[IDSPCONTROLLO],[SEQUENZA],[OBBLIGATORIO],[TIPOELEMENTO],[TESTO],CANCELLATO, DATAMODIFICA, UTENTEMODIFICA) VALUES
(1,NULL,1,1,'SESSIONE','CAMPI OBBLIGATORI',0,getdate(),'IMPIANTO')
GO
INSERT INTO SPELEMENTIOBBLIGATORI ( [IDSPMASTEROBBLIGATORIO],[IDSPCONTROLLO],[SEQUENZA],[OBBLIGATORIO],[TIPOELEMENTO],[TESTO],CANCELLATO, DATAMODIFICA, UTENTEMODIFICA) VALUES
(1,20,2,1,'CONTROLLO','PES001 - PESO ARTICOLO',0,getdate(),'IMPIANTO')
GO
INSERT INTO SPELEMENTIOBBLIGATORI ( [IDSPMASTEROBBLIGATORIO],[IDSPCONTROLLO],[SEQUENZA],[OBBLIGATORIO],[TIPOELEMENTO],[TESTO],CANCELLATO, DATAMODIFICA, UTENTEMODIFICA) VALUES
(1,101,3,1,'CONTROLLO','LEG014 - SUPERFICIE',0,getdate(),'IMPIANTO')
GO
INSERT INTO SPELEMENTIOBBLIGATORI ( [IDSPMASTEROBBLIGATORIO],[IDSPCONTROLLO],[SEQUENZA],[OBBLIGATORIO],[TIPOELEMENTO],[TESTO],CANCELLATO, DATAMODIFICA, UTENTEMODIFICA) VALUES
(1,147,4,1,'CONTROLLO','DEC001 - DURATA CICLO',0,getdate(),'IMPIANTO')
GO
INSERT INTO SPELEMENTIOBBLIGATORI ( [IDSPMASTEROBBLIGATORIO],[IDSPCONTROLLO],[SEQUENZA],[OBBLIGATORIO],[TIPOELEMENTO],[TESTO],CANCELLATO, DATAMODIFICA, UTENTEMODIFICA) VALUES
(1,145,5,1,'CONTROLLO','DEC003 - PEZZI A CICLO',0,getdate(),'IMPIANTO')
GO

UPDATE SPCONTROLLI SET VISIBILE = 0 WHERE IDSPCONTROLLO IN (20,101,147,145,15)

go


alter table SPVALORISCHEDE ADD ELEMENTOOBBLIGATORIO bit NULL
UPDATE SPVALORISCHEDE SET ELEMENTOOBBLIGATORIO = 0
ALTER TABLE SPVALORISCHEDE ALTER COLUMN ELEMENTOOBBLIGATORIO bit NOT NULL
go
alter table SPVALORISCHEDE_LOG ADD ELEMENTOOBBLIGATORIO bit NULL
UPDATE SPVALORISCHEDE_LOG SET ELEMENTOOBBLIGATORIO = 0


CREATE OR ALTER TRIGGER SPVALORISCHEDE_LOG_1
ON SPVALORISCHEDE
AFTER INSERT
AS
BEGIN 
INSERT INTO SPVALORISCHEDE_LOG([IDSPVALORESCHEDA],[IDSPSCHEDA], [IDSPELEMENTO],[CODICE],[DESCRIZIONE],[TIPO],[VALOREN],[VALORET],[VALORED],[IMMAGINESRC],CANCELLATO, DATAMODIFICA, UTENTEMODIFICA,ELEMENTOOBBLIGATORIO) 
SELECT I.[IDSPVALORESCHEDA],I.[IDSPSCHEDA], I.[IDSPELEMENTO],I.[CODICE],I.[DESCRIZIONE],I.[TIPO],I.[VALOREN],I.[VALORET],I.[VALORED],I.[IMMAGINESRC],I.CANCELLATO, I.DATAMODIFICA, I.UTENTEMODIFICA,I.ELEMENTOOBBLIGATORIO FROM INSERTED I
END


GO
CREATE OR ALTER TRIGGER SPVALORISCHEDE_LOG_U
ON SPVALORISCHEDE
AFTER UPDATE
AS
BEGIN 
INSERT INTO SPVALORISCHEDE_LOG([IDSPVALORESCHEDA],[IDSPSCHEDA], [IDSPELEMENTO],[CODICE],[DESCRIZIONE],[TIPO],[VALOREN],[VALORET],[VALORED],[IMMAGINESRC],CANCELLATO, DATAMODIFICA, UTENTEMODIFICA,ELEMENTOOBBLIGATORIO) 
SELECT I.[IDSPVALORESCHEDA],I.[IDSPSCHEDA], I.[IDSPELEMENTO],I.[CODICE],I.[DESCRIZIONE],I.[TIPO],I.[VALOREN],I.[VALORET],I.[VALORED],I.[IMMAGINESRC],I.CANCELLATO, I.DATAMODIFICA, I.UTENTEMODIFICA,I.ELEMENTOOBBLIGATORIO FROM INSERTED I
INNER JOIN DELETED D ON D.[IDSPVALORESCHEDA]=I.[IDSPVALORESCHEDA]

END