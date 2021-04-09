CREATE TABLE BRANDS
(
	IDBRAND INT IDENTITY(1,1),
	DESCRIZIONE NVARCHAR(15) NOT NULL,
	CANCELLATO	BIT NOT NULL,
	DATAMODIFICA	DATETIME NOT NULL,
	UTENTEMODIFICA	NVARCHAR(50) NOT NULL,
	 CONSTRAINT PK_ID_BRAND PRIMARY KEY (IDBRAND)
)
GO
CREATE UNIQUE INDEX IDX_BRANDS_1 ON BRANDS(DESCRIZIONE)
GO
CREATE TABLE BRANDS_LOG
(
	IDBRAND INT NULL,
	DESCRIZIONE NVARCHAR(15) NULL,
	CANCELLATO	BIT NULL,
	DATAMODIFICA	DATETIME NULL,
	UTENTEMODIFICA	NVARCHAR(50) NULL
)
GO
CREATE OR ALTER TRIGGER BRAND_LOG_I
ON BRANDS
AFTER INSERT
AS
BEGIN 
INSERT INTO BRANDS_LOG (IDBRAND, DESCRIZIONE, CANCELLATO, DATAMODIFICA, UTENTEMODIFICA) 
SELECT I.IDBRAND, I.DESCRIZIONE, I.CANCELLATO, I.DATAMODIFICA, I.UTENTEMODIFICA FROM INSERTED I
END
GO


GO
CREATE OR ALTER TRIGGER BRAND_LOG_U
ON BRANDS
AFTER UPDATE
AS
BEGIN 
INSERT INTO BRANDS_LOG (IDBRAND, DESCRIZIONE, CANCELLATO, DATAMODIFICA, UTENTEMODIFICA) 
SELECT I.IDBRAND, I.DESCRIZIONE, I.CANCELLATO, I.DATAMODIFICA, I.UTENTEMODIFICA FROM BRANDS I INNER JOIN DELETED D ON D.IDBRAND=I.IDBRAND
END
GO

 CREATE TABLE ARTICOLI
   (	
	IDARTICOLO INT IDENTITY(1,1),
	 IDBRAND INT NOT NULL ,
	DESCRIZIONE NVARCHAR(50) NOT NULL,
	ANAGRAFICA NVARCHAR(20) NULL,
	COLORE NVARCHAR(15) NULL,
	CODICECLIENTE NVARCHAR(20)NULL,
	CANCELLATO	BIT NOT NULL,
	DATAMODIFICA	DATETIME NOT NULL,
	UTENTEMODIFICA	NVARCHAR(50) NOT NULL,
      FOREIGN KEY (IDBRAND) REFERENCES BRANDS (IDBRAND) ,
	 CONSTRAINT PK_ID_ARTICOLO PRIMARY KEY (IDARTICOLO)
   );

   CREATE UNIQUE INDEX IDX_ARTICOLI_1 ON ARTICOLI (ANAGRAFICA)

 CREATE TABLE ARTICOLI_LOG
   (	
	IDARTICOLO INT NULL,
	IDBRAND INT  NULL,
	DESCRIZIONE NVARCHAR(50)  NULL,
	ANAGRAFICA NVARCHAR(20) NULL,
	COLORE NVARCHAR(15) NULL,
	CODICECLIENTE NVARCHAR(20)NULL,
	CANCELLATO	BIT  NULL,
	DATAMODIFICA	DATETIME  NULL,
	UTENTEMODIFICA	NVARCHAR(50)  NULL
   );

   GO
CREATE OR ALTER TRIGGER ARTICOLI_LOG_I
ON ARTICOLI
AFTER INSERT
AS
BEGIN 
INSERT INTO ARTICOLI_LOG (IDARTICOLO, IDBRAND,DESCRIZIONE,ANAGRAFICA,COLORE, CANCELLATO,CODICECLIENTE, DATAMODIFICA, UTENTEMODIFICA) 
SELECT I.IDARTICOLO, I.IDBRAND,I.DESCRIZIONE,I.ANAGRAFICA,I.COLORE, I.CANCELLATO,I.CODICECLIENTE, I.DATAMODIFICA, I.UTENTEMODIFICA FROM INSERTED I
END

GO
CREATE OR ALTER TRIGGER ARTICOLI_LOG_U
ON ARTICOLI
AFTER UPDATE
AS
BEGIN 
INSERT INTO ARTICOLI_LOG (IDARTICOLO, IDBRAND,DESCRIZIONE,ANAGRAFICA,COLORE, CANCELLATO,CODICECLIENTE, DATAMODIFICA, UTENTEMODIFICA) 
SELECT I.IDARTICOLO, I.IDBRAND,I.DESCRIZIONE,I.ANAGRAFICA,I.COLORE, I.CANCELLATO,I.CODICECLIENTE, I.DATAMODIFICA, I.UTENTEMODIFICA FROM ARTICOLI I 
INNER JOIN DELETED D ON D.IDARTICOLO = I.IDARTICOLO
END
GO
