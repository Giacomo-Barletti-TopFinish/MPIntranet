
 CREATE TABLE REPARTI (  
    IDREPARTO NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
    CODICE VARCHAR2(10) NOT NULL ,     
    DESCRIZIONEBREVE VARCHAR2(15) NULL ,     
    DESCRIZIONE VARCHAR2(30) NULL ,     
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_REPARTO PRIMARY KEY (IDREPARTO)
   );

CREATE UNIQUE INDEX IDX_REPARTO_A ON REPARTI(CODICE);


 CREATE TABLE REPARTI_LOG (  
    IDREPARTO NUMBER NULL,  
    CODICE VARCHAR2(10)  NULL ,     
    DESCRIZIONEBREVE VARCHAR2(15) NULL ,     
    DESCRIZIONE VARCHAR2(30) NULL ,     
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50)  NULL
   );

  create or replace TRIGGER REPARTI_LOG
AFTER INSERT OR UPDATE ON REPARTI
FOR EACH ROW
BEGIN
INSERT INTO REPARTI_LOG(IDREPARTO,CODICE,DESCRIZIONEBREVE,DESCRIZIONE,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDREPARTO,:NEW.CODICE,:NEW.DESCRIZIONEBREVE,:NEW.DESCRIZIONE,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;



  CREATE TABLE FASI (  
    IDFASE NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,   
  CODICE VARCHAR2(10) NOT NULL,
  DESCRIZIONE VARCHAR2(40) NOT NULL,
  IDREPARTO NUMBER NOT NULL,
  RICARICO FLOAT NULL,
  COSTO FLOAT NULL,
  INCLUDIPREVENTIVO VARCHAR2(1) NOT NULL,
  IDESTERNA NUMBER NULL,
  TABELLAESTERNA VARCHAR2(25) NULL,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_FASE PRIMARY KEY (IDFASE),
   FOREIGN KEY (IDREPARTO) REFERENCES REPARTI (IDREPARTO) ENABLE
   );

CREATE UNIQUE INDEX IDX_FASE_1 ON FASI (CODICE);

 CREATE TABLE FASI_LOG (  
    IDFASE NUMBER NULL,   
  CODICE VARCHAR2(10)  NULL,
  DESCRIZIONE VARCHAR2(40)  NULL,
  IDREPARTO NUMBER NULL,
  RICARICO FLOAT NULL,
  COSTO FLOAT NULL,
  INCLUDIPREVENTIVO VARCHAR2(1)  NULL,
  IDESTERNA NUMBER NULL,
  TABELLAESTERNA VARCHAR2(25) NULL,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50)  NULL
   );
   
   
   create or replace TRIGGER FASI_LOG
AFTER INSERT OR UPDATE ON FASI 
FOR EACH ROW
BEGIN
INSERT INTO FASI_LOG(IDFASE,CODICE,DESCRIZIONE,IDREPARTO,RICARICO,COSTO,INCLUDIPREVENTIVO,IDESTERNA,TABELLAESTERNA,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDFASE,:NEW.CODICE,:NEW.DESCRIZIONE,:NEW.IDREPARTO,:NEW.RICARICO,:NEW.COSTO,:NEW.INCLUDIPREVENTIVO,:NEW.IDESTERNA,:NEW.TABELLAESTERNA,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;


 CREATE TABLE TIPIPRODOTTO (  
    IDTIPOPRODOTTO NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
    CODICE VARCHAR2(10) NOT NULL ,     
    DESCRIZIONE VARCHAR2(30) NULL ,     
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_TIPOPRODOTTO PRIMARY KEY (IDTIPOPRODOTTO)
   );

CREATE UNIQUE INDEX IDX_TIPIPRODOTTO_A ON TIPIPRODOTTO(CODICE);


 CREATE TABLE TIPIPRODOTTO_LOG (  
    IDTIPOPRODOTTO NUMBER NULL,  
    CODICE VARCHAR2(10)  NULL ,     
    DESCRIZIONE VARCHAR2(30) NULL ,     
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50)  NULL
   );
   
   
   create or replace TRIGGER TIPIPRODOTTO_LOG
AFTER INSERT OR UPDATE ON TIPIPRODOTTO 
FOR EACH ROW
BEGIN
INSERT INTO TIPIPRODOTTO_LOG(IDTIPOPRODOTTO,CODICE,DESCRIZIONE,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDTIPOPRODOTTO,:NEW.CODICE,:NEW.DESCRIZIONE,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;


  CREATE TABLE MATERIEPRIME (  
    IDMATERIAPRIMA NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,   
  CODICE VARCHAR2(10) NOT NULL,
  DESCRIZIONE VARCHAR2(40) NOT NULL,
  IDMATERIALE NUMBER NOT NULL,
  RICARICO FLOAT NULL,
  COSTO FLOAT NULL,
  INCLUDIPREVENTIVO VARCHAR2(1) NOT NULL,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_MATERIAPRIMA PRIMARY KEY (IDMATERIAPRIMA),
   FOREIGN KEY (IDMATERIALE) REFERENCES MATERIALI (IDMATERIALE) ENABLE
   );

CREATE UNIQUE INDEX IDX_MATERIAPRIMA_1 ON MATERIEPRIME (CODICE);

 CREATE TABLE MATERIEPRIME_LOG (  
    IDMATERIAPRIMA NUMBER NULL,   
  CODICE VARCHAR2(10)  NULL,
  DESCRIZIONE VARCHAR2(40)  NULL,
  IDMATERIALE NUMBER NULL,
  RICARICO FLOAT NULL,
  COSTO FLOAT NULL,
  INCLUDIPREVENTIVO VARCHAR2(1)  NULL,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50)  NULL
   );
   
   
   create or replace TRIGGER MATERIEPRIME_LOG
AFTER INSERT OR UPDATE ON MATERIEPRIME 
FOR EACH ROW
BEGIN
INSERT INTO MATERIEPRIME_LOG(IDMATERIAPRIMA,CODICE,DESCRIZIONE,IDMATERIALE,RICARICO,COSTO,INCLUDIPREVENTIVO,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDMATERIAPRIMA,:NEW.CODICE,:NEW.DESCRIZIONE,:NEW.IDMATERIALE,:NEW.RICARICO,:NEW.COSTO,:NEW.INCLUDIPREVENTIVO,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;



 CREATE TABLE GRUPPI (  
    IDGRUPPO NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
    CODICE VARCHAR2(10) NOT NULL ,     
    DESCRIZIONE VARCHAR2(30) NULL , 
    IDBRAND NUMBER NOT NULL,
     COLOREGRUPPO VARCHAR2(10) NULL,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_GRUPPO PRIMARY KEY (IDGRUPPO),
    FOREIGN KEY (IDBRAND) REFERENCES BRAND (IDBRAND) ENABLE
   );

CREATE UNIQUE INDEX IDX_GRUPPI_A ON GRUPPI(CODICE,IDBRAND);


 CREATE TABLE GRUPPI_LOG (  
    IDGRUPPO NUMBER NULL,  
    CODICE VARCHAR2(10)  NULL ,     
    DESCRIZIONE VARCHAR2(30) NULL , 
     IDBRAND NUMBER NULL,
     COLOREGRUPPO VARCHAR2(10) NULL,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50)  NULL
   );
   
   
   create or replace TRIGGER GRUPPI_LOG
AFTER INSERT OR UPDATE ON GRUPPI 
FOR EACH ROW
BEGIN
INSERT INTO GRUPPI_LOG(IDGRUPPO,CODICE,DESCRIZIONE,IDBRAND,COLOREGRUPPO,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDGRUPPO,:NEW.CODICE,:NEW.DESCRIZIONE,:NEW.IDBRAND,:NEW.COLOREGRUPPO,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;


 CREATE TABLE GRUPPIFASI (  
    IDGRUPPOFASE NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
    IDFASE NUMBER NOT NULL , 
    IDGRUPPO NUMBER NOT NULL,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_GRUPPIFASE PRIMARY KEY (IDGRUPPOFASE),
    FOREIGN KEY (IDGRUPPO) REFERENCES GRUPPI (IDGRUPPO) ENABLE,
    FOREIGN KEY (IDFASE) REFERENCES FASI (IDFASE) ENABLE
   );



 CREATE TABLE GRUPPIFASI_LOG (  
    IDGRUPPOFASE NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
    IDFASE NUMBER NOT NULL , 
    IDGRUPPO NUMBER NOT NULL,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50)  NULL
   );
   
   
   create or replace TRIGGER GRUPPIFASI_LOG
AFTER INSERT OR UPDATE ON GRUPPIFASI 
FOR EACH ROW
BEGIN
INSERT INTO GRUPPIFASI_LOG(IDGRUPPOFASE,IDFASE,IDGRUPPO,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDGRUPPOFASE,:NEW.IDFASE,:NEW.IDGRUPPO,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;

 CREATE TABLE PRODOTTIFINITI (  
    IDPRODOTTOFINITO NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
    IDBRAND NUMBER NULL , 
     IDCOLORE NUMBER NULL , 
     IDTIPOPRODOTTO NUMBER NOT NULL,
    CODICE VARCHAR(10) NOT NULL,
     MODELLO	VARCHAR2(30 BYTE) NOT null,
  DESCRIZIONE VARCHAR2(80) NULL,
  CODICEDEFINITIVO VARCHAR2(15) NULL,
  CODICEPROVVISORIO VARCHAR2(15) NULL,
  PREVENTIVO VARCHAR(1) NOT NULL,
  PRESERIE VARCHAR(1) NOT NULL,
  PRODUZIONE VARCHAR(1) NOT NULL,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_PRODOTTOFINITO PRIMARY KEY (IDPRODOTTOFINITO),
    FOREIGN KEY (IDBRAND) REFERENCES BRAND (IDBRAND) ENABLE,
    FOREIGN KEY (IDCOLORE) REFERENCES COLORI (IDCOLORE) ENABLE,
    FOREIGN KEY (IDTIPOPRODOTTO) REFERENCES TIPIPRODOTTO (IDTIPOPRODOTTO) ENABLE
   );

CREATE UNIQUE INDEX IDX_PRODOTTOFINITO_1 ON PRODOTTIFINITI(CODICE,IDCOLORE);
CREATE UNIQUE INDEX IDX_PRODOTTOFINITO_2 ON PRODOTTIFINITI(MODELLO,IDCOLORE);

 CREATE TABLE PRODOTTIFINITI_LOG (  
    IDPRODOTTOFINITO NUMBER NULL,  
    IDBRAND NUMBER NULL , 
     IDCOLORE NUMBER NULL , 
     IDTIPOPRODOTTO NUMBER NULL,
    CODICE VARCHAR(10)  NULL,
     MODELLO	VARCHAR2(30 BYTE)  null,
  DESCRIZIONE VARCHAR2(80) NULL,
  CODICEDEFINITIVO VARCHAR2(15) NULL,
  CODICEPROVVISORIO VARCHAR2(15) NULL,
  PREVENTIVO VARCHAR(1) NULL,
  PRESERIE VARCHAR(1) NULL,
  PRODUZIONE VARCHAR(1) NULL,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50)  NULL
   );
   
   
   create or replace TRIGGER PRODOTTIFINITI_LOG
AFTER INSERT OR UPDATE ON PRODOTTIFINITI 
FOR EACH ROW
BEGIN
INSERT INTO PRODOTTIFINITI_LOG(IDPRODOTTOFINITO,IDBRAND,IDCOLORE,IDTIPOPRODOTTO, MODELLO,CODICE, DESCRIZIONE,  CODICEDEFINITIVO  ,CODICEPROVVISORIO ,PREVENTIVO  ,PRESERIE  ,PRODUZIONE, CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDPRODOTTOFINITO,:NEW.IDBRAND,:NEW.IDCOLORE,:NEW.IDTIPOPRODOTTO, :NEW.MODELLO,:NEW.CODICE, :NEW.DESCRIZIONE,  :NEW.CODICEDEFINITIVO  ,:NEW.CODICEPROVVISORIO ,:NEW.PREVENTIVO  ,:NEW.PRESERIE  ,:NEW.PRODUZIONE,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;



 CREATE TABLE PREVENTIVI (  
    IDPREVENTIVO NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
    VERSIONE NUMBER NOT NULL ,     
    DESCRIZIONE VARCHAR2(30) NULL , 
    NOTA VARCHAR2(100) NULL,
    IDPRODOTTOFINITO NUMBER NOT NULL,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PD_PREVENTIVO PRIMARY KEY (IDPREVENTIVO),
    FOREIGN KEY (IDPRODOTTOFINITO) REFERENCES PRODOTTIFINITI (IDPRODOTTOFINITO) ENABLE
   );
CREATE INDEX IDX_PREVENTIVI_1 ON PREVENTIVI (IDPRODOTTOFINITO);

 CREATE TABLE PREVENTIVI_LOG (  
    IDPREVENTIVO NUMBER NULL ,  
    VERSIONE NUMBER  NULL ,     
    DESCRIZIONE VARCHAR2(30) NULL , 
    NOTA VARCHAR2(100) NULL,
    IDPRODOTTOFINITO NUMBER  NULL,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50)  NULL
   );
   
   
   create or replace TRIGGER PREVENTIVI_LOG
AFTER INSERT OR UPDATE ON PREVENTIVI 
FOR EACH ROW
BEGIN
INSERT INTO PREVENTIVI_LOG(IDPREVENTIVO,VERSIONE,DESCRIZIONE,NOTA,IDPRODOTTOFINITO,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDPREVENTIVO,:NEW.VERSIONE,:NEW.DESCRIZIONE,:NEW.NOTA,:NEW.IDPRODOTTOFINITO,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;


  CREATE TABLE ELEMENTIPREVENTIVO (  
    IDELEMENTOPREVENTIVO NUMBER NOT NULL,   
    IDPREVENTIVO NUMBER NOT NULL,
    IDPADRE NUMBER NULL,
  CODICE VARCHAR2(10) NOT NULL,
  DESCRIZIONE VARCHAR2(40) NOT NULL,
  IDREPARTO NUMBER NOT NULL,
  RICARICO FLOAT NULL,
  COSTO FLOAT NULL,
  INCLUDIPREVENTIVO VARCHAR2(1) NOT NULL,
  IDESTERNA NUMBER NULL,
  TABELLAESTERNA VARCHAR2(25) NULL,
  PEZZIORARI FLOAT NULL,
  PESO FLOAT NULL,
  SUPERFICIE FLOAT NULL,
  ARTICOLO VARCHAR2(30) NULL,
  QUANTITA FLOAT NOT NULL,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_ELEMENTOPREVENTIVO PRIMARY KEY (IDELEMENTOPREVENTIVO),
   FOREIGN KEY (IDPREVENTIVO) REFERENCES PREVENTIVI (IDPREVENTIVO) ENABLE,
   FOREIGN KEY (IDREPARTO) REFERENCES REPARTI (IDREPARTO) ENABLE
   );

CREATE UNIQUE INDEX IDX_ELEMENTIP_1 ON ELEMENTIPREVENTIVO (IDPREVENTIVO);

 CREATE TABLE ELEMENTIPREVENTIVO_LOG (  
     IDELEMENTOPREVENTIVO NUMBER NULL,   
    IDPREVENTIVO NUMBER  NULL,
    IDPADRE NUMBER NULL,
  CODICE VARCHAR2(10)  NULL,
  DESCRIZIONE VARCHAR2(40)  NULL,
  IDREPARTO NUMBER  NULL,
  RICARICO FLOAT NULL,
  COSTO FLOAT NULL,
  INCLUDIPREVENTIVO VARCHAR2(1)  NULL,
  IDESTERNA NUMBER NULL,
  TABELLAESTERNA VARCHAR2(25) NULL,
  PEZZIORARI FLOAT NULL,
  PESO FLOAT NULL,
  SUPERFICIE FLOAT NULL,
  ARTICOLO VARCHAR2(30) NULL,
  QUANTITA FLOAT  NULL,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50)  NULL
   );
   
   
   create or replace TRIGGER ELEMENTIPREVENTIVO_LOG
AFTER INSERT OR UPDATE ON ELEMENTIPREVENTIVO 
FOR EACH ROW
BEGIN
INSERT INTO ELEMENTIPREVENTIVO_LOG(IDELEMENTOPREVENTIVO,IDPREVENTIVO,IDPADRE,CODICE,DESCRIZIONE,IDREPARTO,RICARICO,COSTO,INCLUDIPREVENTIVO,IDESTERNA,TABELLAESTERNA,PEZZIORARI,PESO,SUPERFICIE,ARTICOLO,QUANTITA,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDELEMENTOPREVENTIVO,:NEW.IDPREVENTIVO,:NEW.IDPADRE,:NEW.CODICE,:NEW.DESCRIZIONE,:NEW.IDREPARTO,:NEW.RICARICO,:NEW.COSTO,:NEW.INCLUDIPREVENTIVO,:NEW.IDESTERNA,:NEW.TABELLAESTERNA,:NEW.PEZZIORARI,:NEW.PESO,:NEW.SUPERFICIE,:NEW.ARTICOLO,:NEW.QUANTITA,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;


CREATE INDEX IDX_DOCUMENTI_1 ON DOCUMENTI (IDESTERNA,TABELLAESTERNA);

 CREATE SEQUENCE  "MPI_SEQUENCE"  MINVALUE 1 MAXVALUE 999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE  NOPARTITION ;