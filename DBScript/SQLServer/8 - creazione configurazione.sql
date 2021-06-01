

CREATE TABLE CONFIGURAZIONI
(
		IDCONFIGURAZIONE INT IDENTITY(1,1),
		CODICE NVARCHAR(20) NOT NULL,
		DESCRIZIONE NVARCHAR(100) NOT NULL,
		VALORE NVARCHAR(100) NOT NULL,
		TIPODATO NVARCHAR(20) NOT NULL,
			CANCELLATO	BIT NOT NULL,
	DATAMODIFICA	DATETIME NOT NULL,
	UTENTEMODIFICA	NVARCHAR(50) NOT NULL,
	 CONSTRAINT PK_IDCONFIGURAZIONE PRIMARY KEY (IDCONFIGURAZIONE)
)

GO

CREATE UNIQUE INDEX IDX_CONFIGRAZIONI_1 ON CONFIGURAZIONI(CODICE);


insert into CONFIGURAZIONI (CODICE,DESCRIZIONE,VALORE,TIPODATO,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA) VALUES('PathPDN','PATH PER FUNZIONI ARCHIVIO DOCUMENTI','\\Dc04\ut_bck\PDM','STRING',0,SYSDATETIME(),'IMPIANTO')