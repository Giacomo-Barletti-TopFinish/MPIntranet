
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


CREATE TABLE MANUTENTORI
(
  IDMANUTENTORE NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
  IDDITTA NUMBER not null,
  NOMECOGNOME VARCHAR2(45) NOT NULL,
  ACCOUNT VARCHAR2(45) NULL,
  NOTA VARCHAR2(100) NULL,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_MANUTENTORE PRIMARY KEY (IDMANUTENTORE),
   FOREIGN KEY (IDDITTA) REFERENCES DITTE (IDDITTA) ENABLE
);

   CREATE TABLE MANUTENTORI_LOG
(   
  IDMANUTENTORE NUMBER NULL ,
IDDITTA NUMBER,
NOMECOGNOME VARCHAR2(45) NULL,
  ACCOUNT VARCHAR2(45)  NULL,
  NOTA VARCHAR2(100)  NULL,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50) NULL
);

create or replace TRIGGER MANUTENTORI_LOG
AFTER INSERT OR UPDATE ON MANUTENTORI
FOR EACH ROW
BEGIN
INSERT INTO MANUTENTORI_LOG(IDMANUTENTORE,IDDITTA,NOMECOGNOME,ACCOUNT,NOTA,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDMANUTENTORE,:NEW.IDDITTA,:NEW.NOMECOGNOME,:NEW.ACCOUNT,:NEW.NOTA,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;

CREATE TABLE RIFERIMENTI
(
  IDRIFERIMENTO NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
  ETICHETTA VARCHAR2(45) NOT NULL,
  TIPOLOGIA VARCHAR2(45) NOT NULL,
  RIFERIMENTO VARCHAR2(45) NOT NULL,
  IDESTERNA NUMBER NOT NULL,
  TABELLAESTERNA VARCHAR2(25) NOT NULL,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_RIFERIMENTI PRIMARY KEY (IDRIFERIMENTO)
   
);

   CREATE TABLE RIFERIMENTI_LOG
(   
  IDRIFERIMENTO NUMBER NULL ,
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
INSERT INTO RIFERIMENTI_LOG(IDRIFERIMENTO,ETICHETTA,RIFERIMENTO,IDESTERNA,TABELLAESTERNA,TIPOLOGIA,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDRIFERIMENTO,:NEW.ETICHETTA,:NEW.RIFERIMENTO,:NEW.IDESTERNA,:NEW.TABELLAESTERNA,:NEW.TIPOLOGIA,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;


  CREATE TABLE DOCUMENTI (  
    IDDOCUMENTO NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
    IDTIPODOCUMENTO NUMBER NOT NULL,
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
    IDTIPODOCUMENTO NUMBER  NULL,
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
INSERT INTO DOCUMENTI_LOG(IDDOCUMENTO,IDTIPODOCUMENTO,FILENAME,IDESTERNA,DATI,TABELLAESTERNA,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDDOCUMENTO,:NEW.IDTIPODOCUMENTO,:NEW.FILENAME,:NEW.IDESTERNA,:NEW.DATI,:NEW.TABELLAESTERNA,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;

 CREATE TABLE MACCHINE (  
    IDMACCHINA NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
    IDDITTA NUMBER NOT NULL,
    IDPADRE NUMBER NULL,
    DESCRIZIONE VARCHAR(45) NOT NULL , 
    SERIALE VARCHAR(20) NOT NULL,
    NOTE VARCHAR2(100) NULL,
    LUOGO VARCHAR(45) NULL,
    DATACOSTRUZIONE VARCHAR2(10) NULL, 
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_MACCHINA PRIMARY KEY (IDMACCHINA),
    FOREIGN KEY (IDDITTA) REFERENCES DITTE (IDDITTA) ENABLE
   );


 CREATE TABLE MACCHINE_LOG (  
    IDMACCHINA NUMBER NULL,  
    IDDITTA NUMBER NULL,
    DESCRIZIONE VARCHAR2(45) NULL,
    IDPADRE NUMBER NULL,
    SERIALE VARCHAR2(20) NULL , 
    NOTE VARCHAR2(100) NULL,
    LUOGO VARCHAR(45) NULL ,
    DATACOSTRUZIONE VARCHAR2(10) NULL ,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50)  NULL
   );
   
   
   create or replace TRIGGER MACCHINE_LOG
AFTER INSERT OR UPDATE ON MACCHINE
FOR EACH ROW
BEGIN
INSERT INTO MACCHINE_LOG(IDMACCHINA,IDDITTA,IDPADRE,DESCRIZIONE,SERIALE,NOTE,LUOGO,DATACOSTRUZIONE,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDMACCHINA,:NEW.IDDITTA,:NEW.IDPADRE,:NEW.DESCRIZIONE,:NEW.SERIALE,:NEW.NOTE,:NEW.LUOGO,:NEW.DATACOSTRUZIONE,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;



 CREATE TABLE INTERVENTI (  
    IDINTERVENTO NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
    DESCRIZIONE VARCHAR(100) NOT NULL ,     
    DURATA NUMBER NULL ,     
    IDMACCHINA NUMBER NULL,
    IDMANUTENTORE NUMBER NULL,
    IDSERIE NUMBER NULL , 
    FREQUENZA VARCHAR(20) NULL,
    NOTE VARCHAR2(200) NULL,
    LUOGO VARCHAR(50) NULL,
    DATAINTERVENTO DATE NULL, 
    STATO VARCHAR2(25) NULL,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_INTERVENTO PRIMARY KEY (IDINTERVENTO),
    FOREIGN KEY (IDMACCHINA) REFERENCES MACCHINE (IDMACCHINA) ENABLE,
    FOREIGN KEY (IDMANUTENTORE) REFERENCES MANUTENTORI (IDMANUTENTORE) ENABLE
   );

CREATE INDEX IDX_INTERVENTI_1 ON INTERVENTI(DATAINTERVENTO);
CREATE INDEX IDX_INTERVENTI_2 ON INTERVENTI(IDMANUTENTORE);
CREATE INDEX IDX_INTERVENTI_3 ON INTERVENTI(STATO);

 CREATE TABLE INTERVENTI_LOG (  
    IDINTERVENTO NUMBER NULL,  
    DESCRIZIONE VARCHAR(100) NULL ,  
    DURATA NUMBER NULL,
    IDMACCHINA NUMBER NULL,
    IDMANUTENTORE NUMBER NULL,
    IDSERIE NUMBER NULL , 
    FREQUENZA VARCHAR(20) NULL,
    NOTE VARCHAR2(200) NULL,
    LUOGO VARCHAR(50) NULL,
    DATAINTERVENTO DATE NULL, 
    STATO VARCHAR2(25) NULL,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50)  NULL
   );

  create or replace TRIGGER INTERVENTI_LOG
AFTER INSERT OR UPDATE ON INTERVENTI
FOR EACH ROW
BEGIN
INSERT INTO INTERVENTI_LOG(IDINTERVENTO,DESCRIZIONE,DURATA,IDMACCHINA,IDMANUTENTORE,IDSERIE,FREQUENZA,NOTE,LUOGO,DATAINTERVENTO,STATO,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDINTERVENTO,:NEW.DESCRIZIONE,:NEW.DURATA,:NEW.IDMACCHINA,:NEW.IDMANUTENTORE,:NEW.IDSERIE,:NEW.FREQUENZA,:NEW.NOTE,:NEW.LUOGO,:NEW.DATAINTERVENTO,:NEW.STATO,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;