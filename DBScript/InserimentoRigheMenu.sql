-- MANU ACCOUNT - GESTIONE SICUREZZA
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('1',null,'ACCOUNT','GESTIONE ACCOUNT E ABILITAZIONI',null,null,'fa fa-user fa-lg',NULL,'1');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('2','1','ABILITA MENU','ABILITA ACCOUNT AL MENU',null,'/ACCOUNT/ABILITAMENU','',NULL,'2');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('3','2','CREA ACCOUNT','crea un nuovo account',null,'/ACCOUNT/CREANUOVOACCOUNT','','A','3');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('4','2','RIMUOVI ACCOUNT','rimuove un account',null,'/ACCOUNT/RIMUOVIACCOUNT','','A','4');

-- MENU ANAGRAFICA
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('10',null,'ANAGRAFICA','GESTIONE TABELLE ANAGRAFICA',null,null,'fa fa-table fa-lg',NULL,'10');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('11',10,'BRAND','GESTIONE TABELLA BRAND',null,'/ANAGRAFICA/BRAND','',NULL,'15');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('12',10,'COLORE','GESTIONE TABELLA COLORE',null,'/ANAGRAFICA/COLORE','',NULL,'20');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('13',10,'TIPI DOCUMENTO','GESTIONE TABELLA TIPI DOCUMENTO',null,'/ANAGRAFICA/TIPIDOCUMENTO','',NULL,'25');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('14','13','CREA TIPO DOCUMENTO','crea un nuovo tipo documento',null,'/ANAGRAFICA/CREATIPODOCUMENTO','','A','26');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('15','13','RIM TIPO DOCUMENTO','cancella un tipo documento',null,'/ANAGRAFICA/RIMUOVITIPODOCUMENTO','','A','27');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('16','11','CREA BRAND','crea un nuovo brand',null,'/ANAGRAFICA/CREABRAND','','A','16');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('17','11','RIMUOVI BRAND','cancella un brand',null,'/ANAGRAFICA/RIMUOVIBRAND','','A','17');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('18','11','MODIFICA BRAND','modifica un brand',null,'/ANAGRAFICA/MODIFICABRAND','','A','18');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('19','12','CREA COLORE','crea un nuovo COLORE',null,'/ANAGRAFICA/CREABRAND','','A','19');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('20','12','RIMUOVI COLORE','cancella un COLORE',null,'/ANAGRAFICA/RIMUOVIBRAND','','A','20');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('21','12','MODIFICA COLORE','modifica un COLORE',null,'/ANAGRAFICA/MODIFICABRAND','','A','21');

Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('25',10,'MATERIALI','GESTIONE TABELLA MATERIALI',null,'/ANAGRAFICA/MATERIALI','',NULL,'25');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('26','25','CREA MATERIALE','crea un nuovo MATERIALE',null,'/ANAGRAFICA/CREAMATERIALE','','A','26');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('27','25','RIMUOVI MATERIALE','cancella un MATERIALE',null,'/ANAGRAFICA/RIMUOVIMATERIALE','','A','27');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('28','25','MODIFICA MATERIALE','modifica un MATERIALE',null,'/ANAGRAFICA/MODIFICAMATERIALE','','A','28');

-- MENU GALVANICA
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('30',null,'GALVANICA','GESTIONE TABELLE GALVANICA',null,null,'fa fa-flask fa-lg',NULL,'30');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('35',30,'IMPIANTI','GESTIONE TABELLA IMPIANTI',null,'/GALVANICA/IMPIANTI','',NULL,'35');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('36','35','CREA IMPIANTO','crea un nuovo IMPIANTO',null,'/GALVANICA/CREAIMPIANTO','','A','36');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('37','35','RIMUOVI IMPIANTO','cancella un IMPIANTO',null,'/GALVANICA/RIMUOVIIMPIANTO','','A','37');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('38','35','MODIFICA IMPIANTO','modifica un IMPIANTO',null,'/GALVANICA/MODIFICAIMPIANTO','','A','38');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('40',30,'VASCHE','GESTIONE TABELLA TIPI VASCHE',null,'/GALVANICA/VASCHE','',NULL,'40');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('41','40','CREA VASCA','crea un nuovo VASCA',null,'/GALVANICA/CREAVASCA','','A','41');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('42','40','RIMUOVI VASCA','cancella un VASCA',null,'/GALVANICA/RIMUOVIVASCA','','A','42');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('43','40','MODIFICA VASCA','modifica un VASCA',null,'/GALVANICA/MODIFICAVASCA','','A','43');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('45',30,'PROCESSI STANDARD','PROCESSI STANDARD',null,'/GALVANICA/PROCESSISTANDARD','',NULL,'45');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('50',30,'TELAI','GESTIONE TABELLA TELAI',null,'/GALVANICA/TELAI','',NULL,'50');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('51','50','CREA TELAIO','crea un nuovo TELAIO',null,'/GALVANICA/CREATELAIO','','A','51');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('52','50','RIMUOVI TELAIO','cancella un TELAIO',null,'/GALVANICA/RIMUOVITELAIO','','A','52');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('53','50','MODIFICA TELAIO','modifica un TELAIO',null,'/GALVANICA/MODIFICATELAIO','','A','53');

-- MENU ARTICOLO
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('60',null,'ARTICOLO','GESTIONE TABELLE ARTICOLO',null,null,'fa fa-list fa-lg',NULL,'60');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('61',60,'SCHEDA','SCHEDA ARTICOLO',null,'/ARTICOLO/RICERCAARTICOLO/?TipoRicerca=1','',NULL,'61');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('62','60','CREA ARTICOLO','Accesso alla pagina crea ARTICOLO',null,'/ARTICOLO/CREAARTICOLO','','','62');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('63','61','RIMUOVI ARTICOLO','cancella un ARTICOLO',null,'/ARTICOLO/RIMUOVIARTICOLO','','A','63');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('64','61','MODIFICA ARTICOLO','modifica un ARTICOLO',null,'/ARTICOLO/MODIFICAARTICOLO','','A','64');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('65','62','SALVA ARTICOLO','Operazione salva nuovo articolo',null,'/ARTICOLO/SALVAARTICOLO','','A','65');

Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('66','61','MOSTRA PROCESSI','Mostra i processi galvanici',null,'/ARTICOLO/CARICAPROCESSIPARTIAL','','A','66');

Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('80',60,'CREA PROCESSO','PROCESSO GALVANICO',null,'/ARTICOLO/RICERCAARTICOLO/?TipoRicerca=2','',NULL,'80');

-- MENU DOCUMENTI
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('90',90,'CREA DOCUMENTO','Aggiunge un documento',null,'/DOCUMENTI/AGGIUNGIDOCUMENTO','','A','90');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('91',90,'CANCELLA DOCUMENTO','Rimuove un documento',null,'/DOCUMENTI/RIMUOVIDOCUMENTO','','A','91');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('92',90,'ESTRAI DOCUMENTO','Estrai un documento',null,'/DOCUMENTI/ESTRAIDOCUMENTO','','A','92');

-- MENU MANUTENZIONE
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('100',null,'MANUTENZIONE','ATTIVITA ASSOCIATE ALLA MANUTENZIONE',null,null,'fa fa-wrench fa-lg',NULL,'100');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('110',100,'DITTE','GESTIONE TABELLA DITTE',null,'/MANUTENZIONE/DITTE','',NULL,'110');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('111','110','CREA DITTA','crea UNA NUOVA DITTA',null,'/MANUTENZIONE/CREADITTA','','A','111');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('112','110','RIMUOVI DITTA','cancella unA DITTA',null,'/MANUTENZIONE/RIMUOVIDITTA','','A','112');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('113','110','MODIFICA DITTA','modifica UNA DITTA',null,'/MANUTENZIONE/MODIFICADITTA','','A','113');

Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('120',100,'MANUTENTORI','GESTIONE TABELLA MANUTENTORI',null,'/MANUTENZIONE/MANUTENTORI','',NULL,'120');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('121','120','CREA MANUTENTORE','crea UN NUOVO MANUTENTORE',null,'/MANUTENZIONE/CREAMANUTENTORE','','A','121');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('122','120','RIMUOVI MANUTENTORE','cancella MANUTENTORE',null,'/MANUTENZIONE/RIMUOVIMANUTENTORE','','A','122');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('123','120','MODIFICA MANUTENTORE','modifica MANUTENTORE',null,'/MANUTENZIONE/MODIFICAMANUTENTORE','','A','123');

Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('130',100,'MACCHINE','GESTIONE TABELLA MACCHINE',null,'/MANUTENZIONE/MACCHINE','',NULL,'130');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('131','130','CREA MACCHINA','crea UNA UOVA MACCHINA',null,'/MANUTENZIONE/CREAMACCHINA','','A','131');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('132','130','RIMUOVI MACCHINA','cancella MACCHINA',null,'/MANUTENZIONE/RIMUOVIMACCHINA','','A','132');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('133','130','MODIFICA MACCHINA','modifica MACCHINA',null,'/MANUTENZIONE/MODIFICAMACCHINA','','A','133');

Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('140',100,'INTERVENTI','GESTIONE TABELLA INTERVENTI',null,'/MANUTENZIONE/INTERVENTI','',NULL,'140');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('141','140','CREA INTERVENTO','crea UN NUOVO INTERVENTO',null,'/MANUTENZIONE/CREAINTERVENTO','','A','141');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('142','140','RIMUOVI INTERVENTO','cancella INTERVENTO',null,'/MANUTENZIONE/RIMUOVIINTERVENTO','','A','142');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('143','140','MODIFICA INTERVENTO','modifica INTERVENTO',null,'/MANUTENZIONE/MODIFICAINTERVENTO','','A','143');

-- MENU REPORT
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('200',null,'REPORT','REPORT',null,null,'fa fo-book-open fa-lg',NULL,'100');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('210',200,'CARICO LAVORO','REPORT CARICO LAVORO',null,'/REPORT/CARICOLAVORO','',NULL,'210');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('220',200,'REPORT QUANTITA''','REPORT QUANTITA''',null,'/REPORT/REPORTQUANTITA','',NULL,'220');
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values ('230',200,'REPORT ORD. ATT.','REPORT ORDINI ATTIVI''',null,'/REPORT/REPORTORDINIATTIVI','',NULL,'230');
