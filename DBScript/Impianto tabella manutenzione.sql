


CREATE TABLE DITTE
(
  IDDITTA NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,   
  RAGIONESOCIALE VARCHAR2(45) NOT NULL,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_DITTA PRIMARY KEY (IDDITTA)
);
   CREATE TABLE DITTE_LOG
(
  IDDITTA NUMBER NULL ,   
  RAGIONESOCIALE VARCHAR2(45) NULL,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE NULL,
  UTENTEMODIFICA VARCHAR2(50) NULL
);

create or replace TRIGGER DITTE_LOG
AFTER INSERT OR UPDATE ON DITTE
FOR EACH ROW
BEGIN
INSERT INTO DITTE_LOG(IDDITTA,RAGIONESOCIALE,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDDITTA,:NEW.RAGIONESOCIALE,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;

CREATE TABLE MANUTENTORE
(
  IDMANUTENTORE NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
  NOME_COGNOME VARCHAR2(45) NOT NULL,
  ACCOUNT_ VARCHAR2(45) NULL,
  NOTA VARCHAR2(100) NULL,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_MANUTENTORE PRIMARY KEY (IDMANUTENTORE),
   FOREIGN KEY (IDDITTA) REFERENCES DITTA (IDDITTA) ENABLE
);

   CREATE TABLE MANUTENTORE_LOG
(   
  IDMANUTENTORE NUMBER NULL ,
  NOME_COGNOME VARCHAR2(45)  NULL,
  ACCOUNT_ VARCHAR2(45)  NULL,
  NOTA VARCHAR2(100)  NULL,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50) NULL
);

create or replace TRIGGER MANUTENTORE_LOG
AFTER INSERT OR UPDATE ON MANUTENTORE
FOR EACH ROW
BEGIN
INSERT INTO MANUTENTORE_LOG(IDMANUTENTORE,NOME_COGNOME,ACCOUNT_,NOTA,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDMANUTENTORE,:NEW.NOME_COGNOME,:NEW.ACCOUNT_,:NEW.NOTA,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;

CREATE TABLE RIFERIMENTI
(
  IDRIFERIMENTI NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
  ETICHETTA VARCHAR2(45) NOT NULL,
  TIPOLOGIA VARCHAR2(45) NOT NULL,
  RIFERIMENTO VARCHAR2(45) NOT NULL,
  IDESTERNA NUMBER NOT NULL,
  TABELLAESTERNA VARCHAR2(25) NOT NULL,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_RIFERIMENTI PRIMARY KEY (IDRIFERIMENTI)
   
);

   CREATE TABLE RIFERIMENTI_LOG
(   
  IDRIFERIMENTI NUMBER NULL ,
  ETICHETTA VARCHAR2(45)  NULL,
  TIPOLOGIA VARCHAR2(45)  NULL,
  RIFERIMENTO VARCHAR2(45)  NULL,
  IDESTERNA NUMBER NULL,
  TABELLAESTERNA VARCHAR2(25)  NULL,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50) NULL
);

create or replace TRIGGER RIFERIMENTI_LOG
AFTER INSERT OR UPDATE ON RIFERIMENTI
FOR EACH ROW
BEGIN
INSERT INTO RIFERIMENTI_LOG(IDRIFERIMENTI,ETICHETTA,RIFERIMENTO,IDESTERNA,TABELLAESTERNA,TIPOLOGIA,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDRIFERIMENTI,:NEW.ETICHETTA,:NEW.RIFERIMENTO,:NEW.IDESTERNA,:NEW.TABELLAESTERNA,:NEW.TIPOLOGIA,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;

CREATE TABLE TIPIDOCUMENTO (  
    IDTIPODOCUMENTO NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
    DESCRIZIONE VARCHAR2(25) NULL,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_TIPODOCUMENTO PRIMARY KEY (IDTIPODOCUMENTO)
   );


 CREATE TABLE TIPIDOCUMENTO_LOG (  
     IDTIPODOCUMENTO NUMBER NULL ,  
    DESCRIZIONE VARCHAR2(25) NULL,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50)  NULL
   );
   
   
   create or replace TRIGGER TIPIDOCUMENTO_LOG
AFTER INSERT OR UPDATE ON TIPIDOCUMENTO 
FOR EACH ROW
BEGIN
INSERT INTO TIPIDOCUMENTO_LOG(IDTIPODOCUMENTO,DESCRIZIONE,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDTIPODOCUMENTO,:NEW.DESCRIZIONE,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;


  CREATE TABLE DOCUMENTI (  
    IDDOCUMENTO NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
    FILENAME VARCHAR2(50) NOT NULL,
    DATI BLOB NOT NULL , 
    IDESTERNA NUMBER NOT NULL,
    TABELLAESTERNA VARCHAR2(25)NOT NULL,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_DOCUEMENTO PRIMARY KEY (IDDOCUMENTO),
    FOREIGN KEY (IDTIPODOCUMENTO) REFERENCES TIPIDOCUMENTO (IDTIPODOCUMENTO) ENABLE
   );


 CREATE TABLE DOCUMENTI_LOG (  
    IDDOCUMENTO NUMBER NULL,  
    FILENAME VARCHAR2(50) NULL,
    DATI BLOB NULL , 
    TABELLAESTERNA VARCHAR2(25) NULL,
    IDESTERNA NUMBER NULL,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50)  NULL
   );
   
   
   create or replace TRIGGER DOCUMENTI_LOG
AFTER INSERT OR UPDATE ON DOCUMENTI 
FOR EACH ROW
BEGIN
INSERT INTO DOCUMENTI_LOG(IDDOCUMENTO,FILENAME,IDESTERNA,DATI,TABELLAESTERNA,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDDOCUMENTO,:NEW.FILENAME,:NEW.IDESTERNA,:NEW.DATI,:NEW.TABELLAESTERNA,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;

 CREATE TABLE MACCHINA (  
    IDMACCHINA NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
    IDPADRE NUMBER NULL,
    DESCRIZIONE VARCHAR(45) NOT NULL , 
    SERIALE VARCHAR(20) NOT NULL,
    NOTE VARCHAR2(100) NOT NULL,
    LUOGO VARCHAR(45) NOT NULL,
    DATACOSTRUZIONE VARCHAR2(45) NOT NULL, 
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_MACCHINA PRIMARY KEY (IDMACCHINA),
    FOREIGN KEY (IDDITTA) REFERENCES DITTA (IDDITTA) ENABLE,
   );


 CREATE TABLE MACCHINA_LOG (  
    IDMACCHINA NUMBER NULL,  
    DESCRIZIONE VARCHAR2(45) NULL,
    IDPADRE NUMBER NULL,
    SERIALE VARCHAR2(20) NULL , 
    NOTE VARCHAR2(100) NULL,
    LUOGO VARCHAR(45) NULL ,
    DATACOSTRUZIONE VARCHAR2(45) NULL ,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50)  NULL
   );
   
   
   create or replace TRIGGER MACCHINA_LOG
AFTER INSERT OR UPDATE ON MACCHINA
FOR EACH ROW
BEGIN
INSERT INTO MACCHINA_LOG(IDMACCHINA,IDPADRE,DESCRIZIONE,SERIALE,NOTE,LUOGO,DATACOSTRUZIONE,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDMACCHINA,:NEW.IDPADRE,:NEW.DESCRIZIONE,:NEW.SERIALE,:NEW.NOTE,:NEW.LUOGO,:NEW.DATACOSTRUZIONE,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;




