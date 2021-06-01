  USE [MPI]
  GO
  CREATE TABLE TOKEN 
   (	
    TOKEN NVARCHAR(50), 
     UTENTE NVARCHAR(50), 
    DATACREAZIONE DATETIME, 
    DURATA INT, 
    IPADDRESS NVARCHAR(15),
    CONSTRAINT PK_MPI_TOKEN PRIMARY KEY (TOKEN)
   ) 

GO
  CREATE TABLE MENU 
   (	
    IDMENU INT NOT NULL , 
    IDMENUPADRE INT, 
    ETICHETTA NVARCHAR(20) NOT NULL , 
    DESCRIZIONE NVARCHAR(80) NOT NULL , 
    ONCLICK NVARCHAR(150), 
    HREF NVARCHAR(150), 
    FONT NVARCHAR(50), 
    SEQUENZA INT NOT NULL , 
    AZIONE NVARCHAR(1) NULL,
     CONSTRAINT PK_IDMENU PRIMARY KEY (IDMENU)
   )
GO

 CREATE TABLE ABILITAZIONI
   (	
    UTENTE NVARCHAR(50), 
    IDMENU INT NOT NULL ,
      FOREIGN KEY (IDMENU) REFERENCES MENU (IDMENU) 
   );

   CREATE UNIQUE INDEX IDX_ABILITAZIONE_1 ON ABILITAZIONI(UTENTE,IDMENU);

   
   GO
CREATE TABLE LOGMESSAGGI(
  IDLOG INT IDENTITY (1,1),
  MESSAGGIO NVARCHAR(200)NOT NULL,
  STACK NVARCHAR(200),
  MODULO NVARCHAR(200),
  TIPOMESAGGIO NVARCHAR(15) NOT NULL,
  DATA DATETIME NOT NULL
);