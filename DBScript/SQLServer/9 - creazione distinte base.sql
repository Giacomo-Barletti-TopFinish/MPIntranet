use mpi
go

CREATE TABLE [TIPIDIBA]
(
 [IDTIPODIBA]     int IDENTITY (1, 1) NOT NULL ,
 [TIPODIBA]       nvarchar(50) NOT NULL ,
 [CANCELLATO]     bit NOT NULL ,
 [DATAMODIFICA]   datetime NOT NULL ,
 [UTENTEMODIFICA] nvarchar(50) NOT NULL ,
 CONSTRAINT [PK_tipodiba] PRIMARY KEY CLUSTERED ([IDTIPODIBA] ASC)
);
GO
create index IDX_TIPIDIBA_1 ON TIPIDIBA(TIPODIBA)
GO

CREATE TABLE [TIPIDIBA_LOG]
(
 [IDTIPODIBA]     int  NULL,
 [TIPODIBA]       nvarchar(50) NULL,
 [CANCELLATO]     bit NULL ,
 [DATAMODIFICA]   datetime NULL ,
 [UTENTEMODIFICA] nvarchar(50) NOT NULL 
);
GO
CREATE OR ALTER TRIGGER TIPIDIBA_LOG_I
ON TIPIDIBA
AFTER INSERT
AS
BEGIN 
INSERT INTO TIPIDIBA_LOG (IDTIPODIBA, TIPODIBA,CANCELLATO, DATAMODIFICA, UTENTEMODIFICA) 
SELECT I.IDTIPODIBA, I.TIPODIBA,I.CANCELLATO, I.DATAMODIFICA, I.UTENTEMODIFICA FROM INSERTED I
END


GO
CREATE OR ALTER TRIGGER TIPIDIBA_LOG_U
ON TIPIDIBA
AFTER UPDATE
AS
BEGIN 
INSERT INTO TIPIDIBA_LOG (IDTIPODIBA, TIPODIBA, CANCELLATO, DATAMODIFICA, UTENTEMODIFICA) 
SELECT I.IDTIPODIBA, I.TIPODIBA,I.CANCELLATO, I.DATAMODIFICA, I.UTENTEMODIFICA FROM TIPIDIBA I
INNER JOIN DELETED D ON D.IDTIPODIBA=I.IDTIPODIBA
END
GO


CREATE TABLE [DIBA]
(
 [IDDIBA]         int IDENTITY (1, 1) NOT NULL ,
 [IDARTICOLO]     int NOT NULL ,
 [IDTIPODIBA]     int NOT NULL ,
 [VERSIONE]       int NOT NULL ,
 [DESCRIZIONE]    nvarchar(50) NULL ,
 [STANDARD]       bit NOT NULL ,
 [CANCELLATO]     bit NOT NULL ,
 [DATAMODIFICA]   datetime NOT NULL ,
 [UTENTEMODIFICA] nvarchar(50) NOT NULL ,
 CONSTRAINT [PK_diba] PRIMARY KEY CLUSTERED ([IDDIBA] ASC),
 CONSTRAINT [FK_178] FOREIGN KEY ([IDARTICOLO])  REFERENCES [dbo].[ARTICOLI]([IDARTICOLO]),
 CONSTRAINT [FK_193] FOREIGN KEY ([IDTIPODIBA])  REFERENCES [TIPIDIBA]([IDTIPODIBA])
);
GO
CREATE TABLE [DIBA_LOG]
(
 [IDDIBA]         int NULL ,
 [IDARTICOLO]     int NULL ,
 [IDTIPODIBA]     int NULL ,
 [VERSIONE]       int NULL ,
 [DESCRIZIONE]    nvarchar(50) NULL ,
 [STANDARD]       bit NULL ,
 [CANCELLATO]     bit NULL ,
 [DATAMODIFICA]   datetime NULL ,
 [UTENTEMODIFICA] nvarchar(50) NOT NULL 
);
GO
CREATE OR ALTER TRIGGER DIBA_LOG_I
ON DIBA
AFTER INSERT
AS
BEGIN 
INSERT INTO DIBA_LOG (IDDIBA, IDARTICOLO,IDTIPODIBA,VERSIONE,DESCRIZIONE,[STANDARD],CANCELLATO, DATAMODIFICA, UTENTEMODIFICA) 
SELECT I.IDDIBA, I.IDARTICOLO,I.IDTIPODIBA,I.VERSIONE,I.DESCRIZIONE,I.[STANDARD],I.CANCELLATO, I.DATAMODIFICA, I.UTENTEMODIFICA FROM INSERTED I
END


GO
CREATE OR ALTER TRIGGER DIBA_LOG_U
ON DIBA
AFTER UPDATE
AS
BEGIN 
INSERT INTO DIBA_LOG (IDDIBA, IDARTICOLO,IDTIPODIBA,VERSIONE,DESCRIZIONE,[STANDARD],CANCELLATO, DATAMODIFICA, UTENTEMODIFICA) 
SELECT I.IDDIBA, I.IDARTICOLO,I.IDTIPODIBA,I.VERSIONE,I.DESCRIZIONE,I.[STANDARD],I.CANCELLATO, I.DATAMODIFICA, I.UTENTEMODIFICA FROM DIBA I
INNER JOIN DELETED D ON D.IDDIBA=I.IDDIBA
END
GO


CREATE NONCLUSTERED INDEX [fkIdx_179] ON [DIBA]  (  [IDARTICOLO] ASC )

GO

CREATE NONCLUSTERED INDEX [fkIdx_194] ON [DIBA]  (  [IDTIPODIBA] ASC )

GO
CREATE TABLE [FASIDIBA]
(
 [IDFASEDIBA]        int IDENTITY (1, 1) NOT NULL ,
 [IDDIBA]            int NOT NULL ,
 [IDPADRE]           int NULL ,
 [TIPOFASE]			 nvarchar(20) NOT NULL ,
 [DESCRIZIONE]       nvarchar(50) NOT NULL ,
 [ANAGRAFICA]        nvarchar(20) NOT NULL ,
 [AREAPRODUZIONE]    nvarchar(20) NOT NULL ,
 [TASK]              nvarchar(10) NOT NULL ,
 [SCHEDAPROCESSO]    nvarchar(20) NULL ,
 [COLLEGAMENTOCICLO] nvarchar(20) NOT NULL ,
 [COLLEGAMENTODIBA]  nvarchar(20) NOT NULL ,
 [QUANTITA]          float NOT NULL ,
 [PEZZIPERIODO]      float NULL ,
 [PERIODO]           float NULL ,
 [UMQUANTITA]        nvarchar(10) NULL ,
 [SETUP]             float NULL ,
 [ATTESA]            float NULL ,
 [MOVIMENTAZIONE]    float NULL ,
  [CANCELLATO]     bit NULL ,
 [DATAMODIFICA]   datetime NULL ,
 [UTENTEMODIFICA] nvarchar(50) NOT NULL 

 CONSTRAINT [PK_fasidiba] PRIMARY KEY CLUSTERED ([IDFASEDIBA] ASC),
 CONSTRAINT [FK_183] FOREIGN KEY ([IDDIBA])  REFERENCES [DIBA]([IDDIBA]),
 CONSTRAINT [FK_202] FOREIGN KEY ([IDPADRE])  REFERENCES [FASIDIBA]([IDFASEDIBA])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_184] ON [FASIDIBA]  (  [IDDIBA] ASC )
GO

CREATE NONCLUSTERED INDEX [fkIdx_203] ON [FASIDIBA]  (  [IDPADRE] ASC )
GO

CREATE TABLE [FASIDIBA_LOG]
(
 [IDFASEDIBA]        int NULL ,
 [IDDIBA]            int NULL ,
 [IDPADRE]           int NULL ,
 [TIPOFASE]			 nvarchar(20) NULL ,
 [DESCRIZIONE]       nvarchar(50) NULL ,
 [ANAGRAFICA]        nvarchar(20) NULL ,
 [AREAPRODUZIONE]    nvarchar(20) NULL ,
 [TASK]              nvarchar(10) NULL ,
 [SCHEDAPROCESSO]    nvarchar(20) NULL ,
 [COLLEGAMENTOCICLO] nvarchar(20) NULL ,
 [COLLEGAMENTODIBA]  nvarchar(20) NULL ,
 [QUANTITA]          float NULL ,
 [PEZZIPERIODO]      float NULL ,
 [PERIODO]           float NULL ,
 [UMQUANTITA]        nvarchar(10) NULL ,
 [SETUP]             float NULL ,
 [ATTESA]            float NULL ,
 [MOVIMENTAZIONE]    float NULL ,
  [CANCELLATO]     bit NULL ,
 [DATAMODIFICA]   datetime NULL ,
 [UTENTEMODIFICA] nvarchar(50) NOT NULL 

);
GO
CREATE OR ALTER TRIGGER FASIDIBA_LOG_I
ON FASIDIBA
AFTER INSERT
AS
BEGIN 
INSERT INTO FASIDIBA_LOG (IDFASEDIBA,IDDIBA, IDPADRE,DESCRIZIONE,AREAPRODUZIONE,TASK,SCHEDAPROCESSO,COLLEGAMENTOCICLO,COLLEGAMENTODIBA,QUANTITA,
PEZZIPERIODO,PERIODO,UMQUANTITA,SETUP,ATTESA,MOVIMENTAZIONE,CANCELLATO, DATAMODIFICA, UTENTEMODIFICA) 
SELECT I.IDFASEDIBA,I.IDDIBA, I.IDPADRE,I.DESCRIZIONE,I.AREAPRODUZIONE,I.TASK,I.SCHEDAPROCESSO,I.COLLEGAMENTOCICLO,I.COLLEGAMENTODIBA,I.QUANTITA,
I.PEZZIPERIODO,I.PERIODO,I.UMQUANTITA,I.SETUP,I.ATTESA,I.MOVIMENTAZIONE,I.CANCELLATO, I.DATAMODIFICA, I.UTENTEMODIFICA FROM INSERTED I
END


GO
CREATE OR ALTER TRIGGER FASIDIBA_LOG_U
ON FASIDIBA
AFTER UPDATE
AS
BEGIN 
INSERT INTO FASIDIBA_LOG (IDFASEDIBA,IDDIBA, IDPADRE,DESCRIZIONE,AREAPRODUZIONE,TASK,SCHEDAPROCESSO,COLLEGAMENTOCICLO,COLLEGAMENTODIBA,QUANTITA,
PEZZIPERIODO,PERIODO,UMQUANTITA,SETUP,ATTESA,MOVIMENTAZIONE,CANCELLATO, DATAMODIFICA, UTENTEMODIFICA) 
SELECT I.IDFASEDIBA,I.IDDIBA, I.IDPADRE,I.DESCRIZIONE,I.AREAPRODUZIONE,I.TASK,I.SCHEDAPROCESSO,I.COLLEGAMENTOCICLO,I.COLLEGAMENTODIBA,I.QUANTITA,
I.PEZZIPERIODO,I.PERIODO,I.UMQUANTITA,I.SETUP,I.ATTESA,I.MOVIMENTAZIONE,I.CANCELLATO, I.DATAMODIFICA, I.UTENTEMODIFICA FROM FASIDIBA I
INNER JOIN DELETED D ON D.IDFASEDIBA=I.IDFASEDIBA
END
