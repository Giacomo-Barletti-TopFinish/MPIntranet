
 CREATE TABLE FBVPROCESSI (  
    IDFBVPROCESSO NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
    IDARTICOLO NUMBER NOT NULL,  
    IDCOLORE NUMBER NOT NULL,  
    DESCRIZIONE VARCHAR2(30) NULL ,     
    STANDARD	VARCHAR2(1)	NOT NULL,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_FBVPROCESSO PRIMARY KEY (IDFBVPROCESSO),
     FOREIGN KEY (IDARTICOLO) REFERENCES ARTICOLI (IDARTICOLO) ENABLE,
     FOREIGN KEY (IDCOLORE) REFERENCES COLORI (IDCOLORE) ENABLE
   );

CREATE UNIQUE INDEX IDX_FBVPROCESSO ON FBVPROCESSI(IDCOLORE);


 CREATE TABLE FBVPROCESSI_LOG (  
    IDFBVPROCESSO NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
    IDARTICOLO NUMBER  NULL,  
    IDCOLORE NUMBER  NULL,  
    DESCRIZIONE VARCHAR2(30) NULL ,     
    STANDARD	VARCHAR2(1)	NOT NULL,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL
   );

  create or replace TRIGGER FBVPROCESSI_LOG
AFTER INSERT OR UPDATE ON FBVPROCESSI
FOR EACH ROW
BEGIN
INSERT INTO FBVPROCESSI_LOG(IDFBVPROCESSO,IDARTICOLO,IDCOLORE,DESCRIZIONE,STANDARD,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDFBVPROCESSO,:NEW.IDARTICOLO,:NEW.IDCOLORE,:NEW.DESCRIZIONE,:NEW.STANDARD,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;



  CREATE TABLE FBVFASI (  
    IDFBVFASE NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,   
  CODICE VARCHAR2(10) NOT NULL,
  DESCRIZIONE VARCHAR2(40) NOT NULL,
  RICARICO FLOAT NULL,
  COSTOORARIO FLOAT NULL,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_FBVFASE PRIMARY KEY (IDFBVFASE)
   );

CREATE UNIQUE INDEX IDX_FBVFASE_1 ON FBVFASI (CODICE);

 CREATE TABLE FBVFASI_LOG (  
    IDFBVFASE NUMBER NULL,   
  CODICE VARCHAR2(10) NULL,
  DESCRIZIONE VARCHAR2(40) NULL,
  RICARICO FLOAT NULL,
  COSTOORARIO FLOAT NULL,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL
   );
   
   
   create or replace TRIGGER FBVFASI_LOG
AFTER INSERT OR UPDATE ON FBVFASI 
FOR EACH ROW
BEGIN
INSERT INTO FBVFASI_LOG(IDFBVFASE,CODICE,DESCRIZIONE,RICARICO,COSTOORARIO,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDFBVFASE,:NEW.CODICE,:NEW.DESCRIZIONE,:NEW.RICARICO,:NEW.COSTOORARIO,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;



  CREATE TABLE FBVGRUPPIPROPRIETA (  
    IDFBVGRUPPO NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,   
  CODICE VARCHAR2(10) NOT NULL,
  DESCRIZIONE VARCHAR2(40) NOT NULL,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_FBVGRUPPO PRIMARY KEY (IDFBVGRUPPO)
   );

CREATE UNIQUE INDEX IDX_IDFBVGRUPPO ON FBVGRUPPIPROPRIETA (CODICE);

 CREATE TABLE FBVGRUPPIPROPRIETA_LOG (  
    IDFBVGRUPPO NUMBER NULL,   
  CODICE VARCHAR2(10)  NULL,
  DESCRIZIONE VARCHAR2(40)  NULL,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50)  NULL
   );
   
   create or replace TRIGGER FBVGRUPPIPROPRIETA_LOG
AFTER INSERT OR UPDATE ON FBVGRUPPIPROPRIETA 
FOR EACH ROW
BEGIN
INSERT INTO FBVGRUPPIPROPRIETA_LOG(IDFBVGRUPPO,CODICE,DESCRIZIONE,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDFBVGRUPPO,:NEW.CODICE,:NEW.DESCRIZIONE,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;


  CREATE TABLE FBVPROPRIETA (  
    IDFBVPROPRIETA NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
    IDFBVGRUPPO NUMBER  NULL,
  CODICE VARCHAR2(10) NOT NULL,
  DESCRIZIONE VARCHAR2(40) NOT NULL,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_FBVPROPRIETA PRIMARY KEY (IDFBVPROPRIETA),
       FOREIGN KEY (IDFBVGRUPPO) REFERENCES FBVGRUPPIPROPRIETA (IDFBVGRUPPO) ENABLE

   );

CREATE UNIQUE INDEX IDX_FBVPROPRIETA ON FBVPROPRIETA (CODICE);

 CREATE TABLE FBVPROPRIETA_LOG (  
    IDFBVPROPRIETA NUMBER NULL,   
    IDFBVGRUPPO NUMBER NULL,
  CODICE VARCHAR2(10)  NULL,
  DESCRIZIONE VARCHAR2(40)  NULL,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50)  NULL
   );
   
   
   create or replace TRIGGER FBVPROPRIETA_LOG
AFTER INSERT OR UPDATE ON FBVPROPRIETA 
FOR EACH ROW
BEGIN
INSERT INTO FBVPROPRIETA_LOG(IDFBVPROPRIETA,IDFBVGRUPPO,CODICE,DESCRIZIONE,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDFBVPROPRIETA,:NEW.IDFBVGRUPPO,:NEW.CODICE,:NEW.DESCRIZIONE,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;



 CREATE TABLE FBVATTRIBUTI (  
    IDFBVATTRIBUTI NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
    IDFBVPROPRIETA NUMBER NOT NULL,   
    CODICE VARCHAR2(10) NOT NULL ,     
    DESCRIZIONE VARCHAR2(30) NULL , 
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_FBVATTRIBUTI PRIMARY KEY (IDFBVATTRIBUTI),
    FOREIGN KEY (IDFBVPROPRIETA) REFERENCES FBVPROPRIETA (IDFBVPROPRIETA) ENABLE
   );

CREATE UNIQUE INDEX IDX_FBVATTRIBUTI ON FBVATTRIBUTI(CODICE);


 CREATE TABLE FBVATTRIBUTI_LOG (  
    IDFBVATTRIBUTI NUMBER NULL,  
    IDFBVPROPRIETA NUMBER  NULL,   
    CODICE VARCHAR2(10)  NULL ,     
    DESCRIZIONE VARCHAR2(30) NULL , 
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50)  NULL
   );
   
   
   create or replace TRIGGER FBVATTRIBUTI_LOG
AFTER INSERT OR UPDATE ON FBVATTRIBUTI 
FOR EACH ROW
BEGIN
INSERT INTO FBVATTRIBUTI_LOG(IDFBVATTRIBUTI,IDFBVPROPRIETA,CODICE,DESCRIZIONE,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDFBVATTRIBUTI,:NEW.IDFBVPROPRIETA,:NEW.CODICE,:NEW.DESCRIZIONE,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;

 CREATE TABLE FBVFASIPROPRIETA(  
    IDFBVFASIPROPRIETA NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
    IDFBVPROPRIETA NUMBER NOT NULL , 
    IDFBVFASE NUMBER NOT NULL,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_FBVFASIPROPRIETA PRIMARY KEY (IDFBVFASIPROPRIETA),
    FOREIGN KEY (IDFBVPROPRIETA) REFERENCES FBVPROPRIETA (IDFBVPROPRIETA) ENABLE,
    FOREIGN KEY (IDFBVFASE) REFERENCES FBVFASI (IDFBVFASE) ENABLE
   );

CREATE INDEX IDX_IDFBVFASE ON FBVFASIPROPRIETA(IDFBVFASE);


 CREATE TABLE FBVFASIPROPRIETA_LOG (  
    IDFBVFASIPROPRIETA NUMBER ,  
    IDFBVPROPRIETA NUMBER NULL , 
    IDFBVFASE NUMBER NULL,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50)  NULL
   );
   
   
   create or replace TRIGGER FBVFASIPROPRIETA_LOG
AFTER INSERT OR UPDATE ON FBVFASIPROPRIETA 
FOR EACH ROW
BEGIN
INSERT INTO FBVFASIPROPRIETA_LOG(IDFBVFASIPROPRIETA,IDFBVPROPRIETA,IDFBVFASE,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDFBVFASIPROPRIETA,:NEW.IDFBVPROPRIETA,:NEW.IDFBVFASE,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;



 CREATE TABLE FBVPROCESSIFASI (  
    IDFBVPROCESSIFASI NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
    IDFBVFASE NUMBER NOT NULL,
    IDFBVPROCESSO NUMBER NOT NULL,
    IDFBVATTRIBUTI NUMBER NULL,
  PEZZIORARI FLOAT NULL,
  DURATA	VARCHAR2(8) NULL,
  SEQUENZA NUMBER NOT NULL,
  QUANTITA NUMBER NULL,
  VELOCITA NUMBER NULL, 
  VIBRATORE VARCHAR2(15) NULL,
  BARATTOLO VARCHAR2(1) NULL,
    RICARICO FLOAT NULL,
  COSTOORARIO FLOAT NULL,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_FBVPROCESSIFASI PRIMARY KEY (IDFBVPROCESSIFASI),
        FOREIGN KEY (IDFBVFASE) REFERENCES FBVFASI (IDFBVFASE) ENABLE,
        FOREIGN KEY (IDFBVPROCESSO) REFERENCES FBVPROCESSI (IDFBVPROCESSO) ENABLE
   );

CREATE UNIQUE INDEX IDX_FBVPROCESSIFASI ON FBVPROCESSIFASI(IDFBVPROCESSO);


 CREATE TABLE FBVPROCESSIFASI_LOG (  
    IDFBVPROCESSIFASI NUMBER NULL,  
    IDFBVFASE NUMBER  NULL,
    IDFBVPROCESSO NUMBER  NULL,
    IDFBVATTRIBUTI NUMBER NULL,
  PEZZIORARI FLOAT NULL,
  DURATA	VARCHAR2(8) NULL,
  SEQUENZA NUMBER  NULL,
  QUANTITA NUMBER NULL,
  VELOCITA NUMBER NULL, 
  VIBRATORE VARCHAR2(15) NULL,
  BARATTOLO VARCHAR2(1) NULL,
    RICARICO FLOAT NULL,
  COSTOORARIO FLOAT NULL,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50)  NULL
   );
   
   
   create or replace TRIGGER FBVPROCESSIFASI_LOG
AFTER INSERT OR UPDATE ON FBVPROCESSIFASI 
FOR EACH ROW
BEGIN
INSERT INTO FBVPROCESSIFASI_LOG(IDFBVPROCESSIFASI,IDFBVFASE,IDFBVPROCESSO,IDFBVATTRIBUTI,PEZZIORARI,DURATA,SEQUENZA,QUANTITA,VELOCITA,VIBRATORE,BARATTOLO,RICARICO,COSTOORARIO,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDFBVPROCESSIFASI,:NEW.IDFBVFASE,:NEW.IDFBVPROCESSO,:NEW.IDFBVATTRIBUTI,:NEW.PEZZIORARI,:NEW.DURATA,:NEW.SEQUENZA,:NEW.QUANTITA,:NEW.VELOCITA,:NEW.VIBRATORE,:NEW.BARATTOLO,:NEW.RICARICO,:NEW.COSTOORARIO,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;