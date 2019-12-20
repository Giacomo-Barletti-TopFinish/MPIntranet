
CREATE TABLE BRAND
(
  IDBRAND NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,   
  BRAND VARCHAR2(20) NOT NULL,
  CODICEGESTIONALE VARCHAR2(10) NULL,
  PREFISSOCOLORE VARCHAR2(2) NOT NULL,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_BRAND PRIMARY KEY (IDBRAND)
);

CREATE UNIQUE INDEX IDX_BRAND_1 ON BRAND(BRAND);

CREATE TABLE BRAND_LOG
(
  IDBRAND NUMBER NULL ,   
  BRAND VARCHAR2(20) NULL,
  CODICEGESTIONALE VARCHAR2(10) NULL,
  PREFISSOCOLORE VARCHAR2(2) NULL,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE NULL,
  UTENTEMODIFICA VARCHAR2(50) NULL
);

create or replace TRIGGER BRAND_LOG
AFTER INSERT OR UPDATE ON BRAND 
FOR EACH ROW
BEGIN
INSERT INTO BRAND_LOG(IDBRAND,BRAND,CODICEGESTIONALE,PREFISSOCOLORE,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDBRAND,:NEW.BRAND,:NEW.CODICEGESTIONALE,:NEW.PREFISSOCOLORE,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;


  CREATE TABLE COLORI (  
    IDCOLORE NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,   
  CODICE VARCHAR2(3) NOT NULL,
  DESCRIZIONE VARCHAR2(40) NOT NULL,
  IDBRAND NUMBER NULL,
  CODICEFIGURATIVO VARCHAR2(10) NOT NULL,
  CODICECLIENTE VARCHAR2(8) NOT NULL,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_COLORI PRIMARY KEY (IDCOLORE),
   FOREIGN KEY (IDBRAND) REFERENCES BRAND (IDBRAND) ENABLE
   );

CREATE UNIQUE INDEX IDX_COLORI_1 ON COLORI (CODICE);

 CREATE TABLE COLORI_LOG (  
    IDCOLORE NUMBER NULL,   
  CODICE VARCHAR2(3) NULL,
  DESCRIZIONE VARCHAR2(40)  NULL,
  IDBRAND NUMBER NULL,
  CODICEFIGURATIVO VARCHAR2(10) NULL,
  CODICECLIENTE VARCHAR2(8) NULL,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50)  NULL
   );
   
   
   create or replace TRIGGER COLORI_LOG
AFTER INSERT OR UPDATE ON COLORI 
FOR EACH ROW
BEGIN
INSERT INTO COLORI_LOG(IDCOLORE,CODICE,DESCRIZIONE,IDBRAND,CODICEFIGURATIVO,CODICECLIENTE,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDCOLORE,:NEW.CODICE,:NEW.DESCRIZIONE,:NEW.IDBRAND,:NEW.CODICEFIGURATIVO,:NEW.CODICECLIENTE,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;


  CREATE TABLE ARTICOLI (  
    IDARTICOLO NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
    CODICESAM VARCHAR2(17) NULL,
    PROGRESSIVOSAM NUMBER NULL,
    IDMAGAZZ	VARCHAR2(10 BYTE) null,
  MODELLO	VARCHAR2(30 BYTE) null,
  DESCRIZIONE VARCHAR2(80) NULL,
  CODICECLIENTE VARCHAR2(15) NULL,
  CODICEPROVVISORIO VARCHAR2(15) NULL,
  IDCOLORE NUMBER NULL,
  IDBRAND NUMBER NULL,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_ARTICOLO PRIMARY KEY (IDARTICOLO),
   FOREIGN KEY (IDBRAND) REFERENCES BRAND (IDBRAND) ENABLE,
   FOREIGN KEY (IDCOLORE) REFERENCES COLORI (IDCOLORE) ENABLE
   );

CREATE UNIQUE INDEX IDX_ARTICOLI_1 ON ARTICOLI (CODICECLIENTE);
CREATE UNIQUE INDEX IDX_ARTICOLI_2 ON ARTICOLI (CODICESAM,PROGRESSIVOSAM);
CREATE UNIQUE INDEX IDX_ARTICOLI_3 ON ARTICOLI (IDMAGAZZ);
CREATE UNIQUE INDEX IDX_ARTICOLI_4 ON ARTICOLI (MODELLO);


 CREATE TABLE ARTICOLI_LOG (  
    IDARTICOLO NUMBER ,  
    CODICESAM VARCHAR2(17) NULL,
    PROGRESSIVOSAM NUMBER NULL,
    IDMAGAZZ	VARCHAR2(10 BYTE) null,
  MODELLO	VARCHAR2(30 BYTE) null,
  DESCRIZIONE VARCHAR2(80) NULL,
  CODICECLIENTE VARCHAR2(15) NULL,
  CODICEPROVVISORIO VARCHAR2(15) NULL,
  IDCOLORE NUMBER NULL,
  IDBRAND NUMBER NULL,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50)  NULL
   );
   
   
   create or replace TRIGGER ARTICOLI_LOG
AFTER INSERT OR UPDATE ON ARTICOLI 
FOR EACH ROW
BEGIN
INSERT INTO ARTICOLI_LOG(IDARTICOLO,CODICESAM,PROGRESSIVOSAM,IDMAGAZZ,MODELLO,DESCRIZIONE,CODICECLIENTE,CODICEPROVVISORIO,IDCOLORE,IDBRAND,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDARTICOLO,:NEW.CODICESAM,:NEW.PROGRESSIVOSAM,:NEW.IDMAGAZZ,:NEW.MODELLO,:NEW.DESCRIZIONE,:NEW.CODICECLIENTE,:NEW.CODICEPROVVISORIO,:NEW.IDCOLORE,:NEW.IDBRAND,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;



  CREATE TABLE CAPITOLATI (  
    IDCAPITOLATO NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
    CODICE VARCHAR2(17) NOT NULL,
    DESCRIZIONE VARCHAR2(45) NULL,
  IDARTICOLO NUMBER NOT NULL,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_CAPITOLATO PRIMARY KEY (IDCAPITOLATO),
   FOREIGN KEY (IDARTICOLO) REFERENCES ARTICOLI (IDARTICOLO) ENABLE
   );

CREATE UNIQUE INDEX IDX_CAPITOLATI_1 ON CAPITOLATI (CODICE);

 CREATE TABLE CAPITOLATI_LOG (  
    IDCAPITOLATO NUMBER NULL ,  
    CODICE VARCHAR2(17) NULL,
    DESCRIZIONE VARCHAR2(45) NULL,
  IDARTICOLO NUMBER NULL,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50)  NULL
   );
   
   
   create or replace TRIGGER CAPITOLATI_LOG
AFTER INSERT OR UPDATE ON CAPITOLATI 
FOR EACH ROW
BEGIN
INSERT INTO CAPITOLATI_LOG(IDCAPITOLATO,CODICE,DESCRIZIONE,IDARTICOLO,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDCAPITOLATO,:NEW.CODICE,:NEW.DESCRIZIONE,:NEW.IDARTICOLO,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;



  CREATE TABLE MATERIALI (  
    IDMATERIALE NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
    CODICE VARCHAR2(8) NOT NULL,
    DESCRIZIONE VARCHAR2(25) NULL,
    PREZIOSO VARCHAR2(1) NOT NULL,
  PESOSPECIFICO FLOAT,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_MATERIALE PRIMARY KEY (IDMATERIALE)
   );

CREATE UNIQUE INDEX IDX_MATERIALE_1 ON MATERIALI (CODICE);

 CREATE TABLE MATERIALI_LOG (  
     IDMATERIALE NUMBER NULL ,  
    CODICE VARCHAR2(8) NULL,
    DESCRIZIONE VARCHAR2(25) NULL,
    PREZIOSO VARCHAR2(1) NOT NULL,
  PESOSPECIFICO FLOAT,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50)  NULL
   );
   
   
   create or replace TRIGGER MATERIALI_LOG
AFTER INSERT OR UPDATE ON MATERIALI 
FOR EACH ROW
BEGIN
INSERT INTO MATERIALI_LOG(IDMATERIALE,CODICE,DESCRIZIONE,PREZIOSO,PESOSPECIFICO,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDMATERIALE,:NEW.CODICE,:NEW.DESCRIZIONE,:NEW.PREZIOSO,:NEW.PESOSPECIFICO,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;




  CREATE TABLE ELEMENTICAPITOLATO (  
    IDELEMENTOCAPITOLATO NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
    SPESSOREMINIMO NUMBER(8,3) NOT NULL,
    SPESSOREMASSIMO NUMBER(8,3) NOT NULL,
    SPESSORENOMINALE NUMBER(8,3) NOT NULL,
    SEQUENZA NUMBER NOT NULL,
     IDMATERIALE NUMBER,
     IDCAPITOLATO NUMBER,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_ELEMENTOCAPITOLATO PRIMARY KEY (IDELEMENTOCAPITOLATO),
    FOREIGN KEY (IDMATERIALE) REFERENCES MATERIALI (IDMATERIALE) ENABLE,
    FOREIGN KEY (IDCAPITOLATO) REFERENCES CAPITOLATI (IDCAPITOLATO) ENABLE
   );


 CREATE TABLE ELEMENTICAPITOLATO_LOG (  
     IDELEMENTOCAPITOLATO NUMBER NULL ,  
    SPESSOREMINIMO NUMBER(8,3) NULL,
    SPESSOREMASSIMO NUMBER(8,3) NULL,
    SPESSORENOMINALE NUMBER(8,3) NULL,
    SEQUENZA NUMBER NULL,
     IDMATERIALE NUMBER,
  IDCAPITOLATO NUMBER,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50)  NULL
   );
   
   
   create or replace TRIGGER ELEMENTICAPITOLATO_LOG
AFTER INSERT OR UPDATE ON ELEMENTICAPITOLATO 
FOR EACH ROW
BEGIN
INSERT INTO ELEMENTICAPITOLATO_LOG(IDELEMENTOCAPITOLATO,SPESSOREMINIMO,SPESSOREMASSIMO,SPESSORENOMINALE,SEQUENZA,IDMATERIALE,IDCAPITOLATO,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDELEMENTOCAPITOLATO,:NEW.SPESSOREMINIMO,:NEW.SPESSOREMASSIMO,:NEW.SPESSORENOMINALE,:NEW.SEQUENZA,:NEW.IDMATERIALE,:NEW.IDCAPITOLATO,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
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
    IDTIPODOCUMENTO NUMBER NOT NULL,
    DATI BLOB NOT NULL , 
    IDARTICOLO NUMBER NOT NULL,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_DOCUEMENTO PRIMARY KEY (IDDOCUMENTO),
    FOREIGN KEY (IDTIPODOCUMENTO) REFERENCES TIPIDOCUMENTO (IDTIPODOCUMENTO) ENABLE,
    FOREIGN KEY (IDARTICOLO) REFERENCES ARTICOLI (IDARTICOLO) ENABLE
   );


 CREATE TABLE DOCUMENTI_LOG (  
    IDDOCUMENTO NUMBER NULL,  
    FILENAME VARCHAR2(50) NULL,
    IDTIPODOCUMENTO NUMBER NULL,
    DATI BLOB NULL , 
    IDARTICOLO NUMBER NULL,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50)  NULL
   );
   
   
   create or replace TRIGGER DOCUMENTI_LOG
AFTER INSERT OR UPDATE ON DOCUMENTI 
FOR EACH ROW
BEGIN
INSERT INTO DOCUMENTI_LOG(IDDOCUMENTO,FILENAME,IDTIPODOCUMENTO,DATI,IDARTICOLO,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDDOCUMENTO,:NEW.FILENAME,:NEW.IDTIPODOCUMENTO,:NEW.DATI,:NEW.IDARTICOLO,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;


  CREATE TABLE IMPIANTI (  
    IDIMPIANTO NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
    DESCRIZIONE VARCHAR2(50) NOT NULL,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_IMPIANTO PRIMARY KEY (IDIMPIANTO)
   );


 CREATE TABLE IMPIANTI_LOG (  
    IDIMPIANTO NUMBER NULL,  
    DESCRIZIONE VARCHAR2(50) NULL,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50)  NULL
   );
   
   
   create or replace TRIGGER IMPIANTI_LOG
AFTER INSERT OR UPDATE ON IMPIANTI 
FOR EACH ROW
BEGIN
INSERT INTO IMPIANTI_LOG(IDIMPIANTO,DESCRIZIONE,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDIMPIANTO,:NEW.DESCRIZIONE,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;



  CREATE TABLE VASCHE (  
    IDVASCA NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
    DESCRIZIONEBREVE VARCHAR2(30) NOT NULL,
    DESCRIZIONE VARCHAR2(80) NOT NULL,
    ABILITASTRATO VARCHAR2(1) NOT NULL,
    IDIMPIANTO NUMBER NOT NULL,
    IDMATERIALE NUMBER NOT NULL,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_VASCA PRIMARY KEY (IDVASCA),
    FOREIGN KEY (IDIMPIANTO) REFERENCES IMPIANTI (IDIMPIANTO) ENABLE,
     FOREIGN KEY (IDMATERIALE) REFERENCES MATERIALI (IDMATERIALE) ENABLE
   );


 CREATE TABLE VASCHE_LOG (  
   IDVASCA NUMBER NULL ,  
    DESCRIZIONEBREVE VARCHAR2(30)  NULL,
    DESCRIZIONE VARCHAR2(80)  NULL,
    ABILITASTRATO VARCHAR2(1)  NULL,
    IDIMPIANTO NUMBER  NULL,
    IDMATERIALE NUMBER  NULL,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50)  NULL
   );
   
   
   create or replace TRIGGER VASCHE_LOG
AFTER INSERT OR UPDATE ON VASCHE 
FOR EACH ROW
BEGIN
INSERT INTO VASCHE_LOG(IDVASCA,DESCRIZIONEBREVE,DESCRIZIONE,ABILITASTRATO,IDIMPIANTO,IDMATERIALE,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDVASCA,:NEW.DESCRIZIONEBREVE,:NEW.DESCRIZIONE,:NEW.ABILITASTRATO,:NEW.IDIMPIANTO,:NEW.IDMATERIALE,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;




  CREATE TABLE PROCESSI (  
    IDPROCESSO NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
    IDIMPIANTO NUMBER NOT NULL,
    IDARTICOLO NUMBER NOT NULL,  
    DESCRIZIONE VARCHAR2(30) NOT NULL,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_PROCESSO PRIMARY KEY (IDPROCESSO),
    FOREIGN KEY (IDIMPIANTO) REFERENCES IMPIANTI (IDIMPIANTO) ENABLE,
     FOREIGN KEY (IDARTICOLO) REFERENCES ARTICOLI (IDARTICOLO) ENABLE
   );


 CREATE TABLE PROCESSI_LOG (  
    IDPROCESSO NUMBER NULL,  
    IDIMPIANTO NUMBER  NULL,
    IDARTICOLO NUMBER NULL,
     DESCRIZIONE VARCHAR2(30) NULL,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50)  NULL
   );
   
   
   create or replace TRIGGER PROCESSI_LOG
AFTER INSERT OR UPDATE ON PROCESSI 
FOR EACH ROW
BEGIN
INSERT INTO PROCESSI_LOG(IDPROCESSO,IDIMPIANTO,IDARTICOLO,DESCRIZIONE,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDPROCESSO,:NEW.IDIMPIANTO,:NEW.IDARTICOLO,:NEW.DESCRIZIONE,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;



 CREATE TABLE FASIPROCESSO (  
    IDFASEPROCESSO NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,  
    IDPROCESSO NUMBER NOT NULL,
    IDVASCA NUMBER NOT NULL,
    DURATA VARCHAR2(8) NOT NULL,
    SEQUENZA NUMBER NOT NULL,
  CANCELLATO VARCHAR2(1) NOT NULL,
  DATAMODIFICA DATE NOT NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL,
   CONSTRAINT PK_FASEPROCESSO PRIMARY KEY (IDFASEPROCESSO),
    FOREIGN KEY (IDPROCESSO) REFERENCES PROCESSI (IDPROCESSO) ENABLE,
    FOREIGN KEY (IDVASCA) REFERENCES VASCHE (IDVASCA) ENABLE
   );


 CREATE TABLE FASIPROCESSO_LOG (  
     IDFASEPROCESSO NUMBER ,  
    IDPROCESSO NUMBER  NULL,
    IDVASCA NUMBER  NULL,
    DURATA VARCHAR2(8)  NULL,
    SEQUENZA NUMBER  NULL,
  CANCELLATO VARCHAR2(1)  NULL,
  DATAMODIFICA DATE  NULL,
  UTENTEMODIFICA VARCHAR2(50) NOT NULL
   );
   
   
   create or replace TRIGGER FASIPROCESSO_LOG
AFTER INSERT OR UPDATE ON FASIPROCESSO 
FOR EACH ROW
BEGIN
INSERT INTO FASIPROCESSO_LOG(IDFASEPROCESSO,IDPROCESSO,IDVASCA,DURATA,SEQUENZA,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA)
VALUES
(:NEW.IDFASEPROCESSO,:NEW.IDPROCESSO,:NEW.IDVASCA,:NEW.DURATA,:NEW.SEQUENZA,:NEW.CANCELLATO,:NEW.DATAMODIFICA,:NEW.UTENTEMODIFICA);
END;


CREATE TABLE LOGMESSAGGI(
  IDLOG NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY,
  MESSAGGIO VARCHAR2(200)NOT NULL,
  STACK VARCHAR2(200),
  MODULO VARCHAR2(200),
  TIPOMESAGGIO VARCHAR2(15) NOT NULL,
  DATA DATE NOT NULL
);


  CREATE TABLE TOKEN 
   (	
    TOKEN VARCHAR2(50 BYTE), 
     UTENTE VARCHAR2(50 BYTE), 
    DATACREAZIONE DATE, 
    DURATA NUMBER(6,0), 
    IPADDRESS VARCHAR2(15 BYTE),
    CONSTRAINT PK_TOKEN PRIMARY KEY (TOKEN)
   ) ;

CREATE TABLE CONFIGURAZIONI
(
  CODICE VARCHAR2(20) NOT NULL,
  DESCRIZIONE VARCHAR2(100) NOT NULL,
  VALORE VARCHAR2(100) NOT NULL,
  TIPODATO VARCHAR2(50),
    CONSTRAINT PK_CONFIGURAZIONE PRIMARY KEY (CODICE)
);



  CREATE TABLE MENU 
   (	
    IDMENU NUMBER(4,0) NOT NULL ENABLE, 
    IDMENUPADRE NUMBER(4,0), 
    ETICHETTA VARCHAR2(20 BYTE) NOT NULL ENABLE, 
    DESCRIZIONE VARCHAR2(80 BYTE) NOT NULL ENABLE, 
    ONCLICK VARCHAR2(150 BYTE), 
    HREF VARCHAR2(150 BYTE), 
    FONT VARCHAR2(50 BYTE), 
    SEQUENZA NUMBER(4,0) NOT NULL ENABLE, 
    AZIONE VARCHAR2(1) NULL,
     CONSTRAINT PK_IDMENU PRIMARY KEY (IDMENU)
   );

 CREATE TABLE ABILITAZIONI
   (	
    UTENTE VARCHAR2(50 BYTE), 
    IDMENU NUMBER(4,0) NOT NULL ENABLE,
      FOREIGN KEY (IDMENU) REFERENCES MENU (IDMENU) ENABLE
   );

   CREATE UNIQUE INDEX IDX_ABILITAZIONE_1 ON ABILITAZIONI(UTENTE,IDMENU);
