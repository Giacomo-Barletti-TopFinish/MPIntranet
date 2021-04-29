use [MPI]
GO
-- MANU ACCOUNT - GESTIONE SICUREZZA
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values (1,null,'ACCOUNT','GESTIONE ACCOUNT E ABILITAZIONI',null,null,'fa fa-user fa-lg',NULL,1);
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values (2,1,'ABILITA MENU','ABILITA ACCOUNT AL MENU',null,'/ACCOUNT/ABILITAMENU','',NULL,2);
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values (3,2,'CREA ACCOUNT','crea un nuovo account',null,'/ACCOUNT/CREANUOVOACCOUNT','','A',3);
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values (4,2,'RIMUOVI ACCOUNT','rimuove un account',null,'/ACCOUNT/RIMUOVIACCOUNT','','A',4);

GO

Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values (10,null,'ARTICOLO','GESTIONE ARTICOLO',null,null,'fa fa-list fa-lg',NULL,1);
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values (11,10,'SCHEDA','SCHEDA ARTICOLO',null,'/ARTICOLO/RICERCAARTICOLO/?TipoRicerca=1','',NULL,2);
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values (12,10,'CREA ARTICOLO','CREA UN NUOVO ARTICOLO',null,'/ARTICOLO/CREAARTICOLO','',NULL,3);
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values (13,10,'SALVA ARTICOLO','COMANDO SALVA ARTICOLO',null,'/ARTICOLO/SALVAARTICOLO','A',NULL,4);

Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values (14,10,'RIMUOVI ARTICOLO','cancella un ARTICOLO',null,'/ARTICOLO/RIMUOVIARTICOLO','','A',5);
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values (15,10,'MODIFICA ARTICOLO','modifica un ARTICOLO',null,'/ARTICOLO/MODIFICAARTICOLO','','A',6);
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values (16,10,'Accesso documenti tecnici ARTICOLO','accesso alla sezione documenti tecnici',null,'/ARTICOLO/DOCUMENTITECNICI','','A',7);

Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values (17,10,'CREA DOCUMENTO','Aggiunge un documento',null,'/DOCUMENTI/AGGIUNGIDOCUMENTO','','A',8);
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values (18,10,'CANCELLA DOCUMENTO','Rimuove un documento',null,'/DOCUMENTI/RIMUOVIDOCUMENTO','','A',9);
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values (19,10,'ESTRAI DOCUMENTO','Estrai un documento',null,'/DOCUMENTI/ESTRAIDOCUMENTO','','A',10);

GO

Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values (30,null,'IMPOSTAZIONI','GESTIONE IMPOSTAZIONI',null,null,'fa fa-cog fa-lg',NULL,1);
Insert into MENU (IDMENU,IDMENUPADRE,ETICHETTA,DESCRIZIONE,ONCLICK,HREF,FONT,AZIONE,SEQUENZA) values (31,30,'TIPI DOCUMENTO','GESTIONE TIPI DOCUMENTO',null,'/IMPOSTAZIONI/TIPIDOCUMENTO','',NULL,2);
