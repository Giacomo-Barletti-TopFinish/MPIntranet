using MPIntranet.Common;
using MPIntranet.DataAccess.Articolo;
using MPIntranet.Entities;
using MPIntranet.Models;
using MPIntranet.Models.Anagrafica;
using MPIntranet.Models.Articolo;
using MPIntranet.Models.Galvanica;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class Articolo : BusinessBase
    {
        private ArticoloDS _ds = new ArticoloDS();
        private RVLDS _dsRVL = new RVLDS();
        private Anagrafica _anagrafica = new Anagrafica();
        private Galvanica _galvanica = new Galvanica();
        private string _rvlImageSite;

        public Articolo()
        {
            this._rvlImageSite = string.Empty;
        }
        public Articolo(string RvlImageSite)
        {
            this._rvlImageSite = RvlImageSite;
        }
        public string CreaArticolo(decimal idBrand, string codiceSAM, decimal progressivo, string modello, string descrizione, string codiceCliente, string provvisorio, string codiceColore, string account)
        {
            BrandModel brand = _anagrafica.EstraiBrandModel(idBrand);
            if (brand == null) return "Brand non valido";
            //            if (codiceColore.Length != 3) return "Codice colore non valido";

            ColoreModel colore = _anagrafica.EstraiColoreModelPerCodiceFigurativo(codiceColore);
            if (colore == null) return "Codice colore non valido";

            if (colore.IdBrand > 0 && colore.IdBrand != idBrand)
                return "Codice colore non valido per il brand";

            if (TrovaArticoli(modello, string.Empty, string.Empty, -1, string.Empty, string.Empty, string.Empty).Count > 0)
                return "Esiste già un articolo con questo modello";

            if (!string.IsNullOrEmpty(codiceSAM) && TrovaArticoli(string.Empty, codiceSAM, string.Empty, -1, string.Empty, string.Empty, string.Empty).Count > 0)
                return "Esiste già un articolo con questo codice SAM";

            if (!string.IsNullOrEmpty(provvisorio) && TrovaArticoli(string.Empty, string.Empty, string.Empty, -1, string.Empty, string.Empty, provvisorio).Count > 0)
                return "Esiste già un articolo con questo codice provvisorio";

            string idMagazz = string.Empty;
            using (RVLBusiness bRVL = new RVLBusiness())
            {
                bRVL.FillMagazz(_dsRVL, modello);
                RVLDS.MAGAZZRow magazz = _dsRVL.MAGAZZ.Where(x => x.MODELLO == modello).FirstOrDefault();
                if (magazz == null)
                    return "Modello non presente in RVL";
                else
                    idMagazz = magazz.IDMAGAZZ;
            }

            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                ArticoloDS.ARTICOLIRow articolo = _ds.ARTICOLI.NewARTICOLIRow();
                articolo.CODICESAM = codiceSAM;
                if (progressivo > -1)
                    articolo.PROGRESSIVOSAM = progressivo;
                articolo.DESCRIZIONE = descrizione;
                articolo.CODICECLIENTE = codiceCliente;
                articolo.CODICEPROVVISORIO = provvisorio;
                articolo.IDCOLORE = colore.IdColore;
                articolo.IDBRAND = idBrand;
                articolo.CANCELLATO = SiNo.No;
                articolo.DATAMODIFICA = DateTime.Now;
                articolo.UTENTEMODIFICA = account;
                articolo.MODELLO = modello;
                articolo.IDMAGAZZ = idMagazz;

                _ds.ARTICOLI.AddARTICOLIRow(articolo);
                bArticolo.UpdateTable(_ds.ARTICOLI.TableName, _ds);
            }
            return "Articolo creato correttamente";
        }
        public List<ArticoloModel> TrovaArticoli(string modello, string codiceSam, string coloreInterno, decimal idBrand, string codiceCliente, string coloreCliente, string codiceProvvisorio)
        {
            List<ArticoloModel> articoli = new List<ArticoloModel>();
            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                List<decimal> idAdrticolo = new List<decimal>();
                if (idBrand <= 0 && string.IsNullOrEmpty(codiceSam) && string.IsNullOrEmpty(modello) && string.IsNullOrEmpty(codiceCliente) && string.IsNullOrEmpty(codiceProvvisorio))
                {
                    bArticolo.FillArticoli(_ds, true);
                    idAdrticolo = _ds.ARTICOLI.Select(x => x.IDARTICOLO).ToList();
                }
                else
                {
                    idAdrticolo = bArticolo.TrovaArticoli(true, idBrand, codiceSam, modello, codiceCliente, codiceProvvisorio);
                }

                if (!string.IsNullOrEmpty(coloreInterno) || !string.IsNullOrEmpty(coloreCliente))
                {
                    List<decimal> idArticoliColore = bArticolo.TrovaArticoliPerColore(true, coloreInterno, coloreCliente);
                    idAdrticolo = idAdrticolo.Intersect(idArticoliColore).ToList();
                    if (idAdrticolo.Count == 0) return new List<ArticoloModel>(); ;
                }
                return CreaListArticoloModel(idAdrticolo);
            }
        }

        public static decimal EstraId()
        {
            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
                return bArticolo.EstraiId();
        }
        public List<ProdottoFinitoModel> TrovaProdottiFiniti(decimal idBrand, decimal idColore, decimal idTipoProdotto, string codice, string modello, string descrizione, string codiceProvvisorio, string codiceDefinitivo, bool preventivo, bool preserie, bool produzione)
        {

            codice = correggiString(codice, 10);
            modello = correggiString(modello, 30);
            descrizione = correggiString(descrizione, 80);
            codiceProvvisorio = correggiString(codiceProvvisorio, 15);
            codiceDefinitivo = correggiString(codiceDefinitivo, 15);

            string preventivoStr = preventivo ? SiNo.Si : SiNo.No;
            string preserieStr = preserie ? SiNo.Si : SiNo.No;
            string produzioneStr = produzione ? SiNo.Si : SiNo.No;


            List<ProdottoFinitoModel> lista = new List<ProdottoFinitoModel>();
            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                bArticolo.FillProdottiFiniti(_ds, true);

                List<ArticoloDS.PRODOTTIFINITIRow> elementi = _ds.PRODOTTIFINITI.ToList();
                if (elementi.Count > 0 && idBrand != ElementiVuoti.BrandVuoto)
                    elementi = elementi.Where(X => !X.IsIDBRANDNull() && X.IDBRAND == idBrand).ToList();

                if (elementi.Count > 0 && idColore != ElementiVuoti.ColoreVuoto)
                    elementi = elementi.Where(X => !X.IsIDCOLORENull() && X.IDCOLORE == idColore).ToList();

                if (elementi.Count > 0 && idTipoProdotto != ElementiVuoti.TipoProdottoVuoto)
                    elementi = elementi.Where(X => X.IDTIPOPRODOTTO == idTipoProdotto).ToList();

                if (elementi.Count > 0 && !string.IsNullOrEmpty(codice))
                    elementi = elementi.Where(X => X.CODICE.Contains(codice)).ToList();

                if (elementi.Count > 0 && !string.IsNullOrEmpty(modello))
                    elementi = elementi.Where(X => X.MODELLO.Contains(modello)).ToList();

                if (elementi.Count > 0 && !string.IsNullOrEmpty(descrizione))
                    elementi = elementi.Where(X => !X.IsDESCRIZIONENull() && X.DESCRIZIONE.Contains(descrizione)).ToList();

                if (elementi.Count > 0 && !string.IsNullOrEmpty(codiceProvvisorio))
                    elementi = elementi.Where(X => !X.IsCODICEPROVVISORIONull() && X.CODICEPROVVISORIO.Contains(codiceProvvisorio)).ToList();

                if (elementi.Count > 0 && !string.IsNullOrEmpty(codiceDefinitivo))
                    elementi = elementi.Where(X => !X.IsCODICEDEFINITIVONull() && X.CODICEDEFINITIVO.Contains(codiceDefinitivo)).ToList();

                if (elementi.Count > 0)
                    elementi = elementi.Where(X => X.PREVENTIVO == preventivoStr && X.PRESERIE == preserieStr && X.PRODUZIONE == produzioneStr).ToList();

                foreach (ArticoloDS.PRODOTTIFINITIRow prodottoFinito in elementi)
                    lista.Add(CreaProdottoFinitoModel(prodottoFinito));

            }
            return lista;
        }

        public List<GruppoModel> CreaListaGruppoModel()
        {
            List<GruppoModel> lista = new List<GruppoModel>();

            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                _ds.GRUPPI.Clear();
                bArticolo.FillGruppi(_ds, true);
                foreach (ArticoloDS.GRUPPIRow gruppo in _ds.GRUPPI)
                    lista.Add(creaGruppoModel(gruppo));
            }
            return lista;
        }

        public List<GruppoRepartoModel> CreaListaGruppoRepartoModel(decimal idBrand)
        {
            List<GruppoRepartoModel> lista = new List<GruppoRepartoModel>();

            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                _ds.GRUPPIREPARTI.Clear();
                bArticolo.FillGruppiReparti(_ds, true);
                List<decimal> idGruppi = CreaListaGruppoModel().Where(x => x.Brand.IdBrand == idBrand).Select(x => x.IdGruppo).ToList();
                foreach (ArticoloDS.GRUPPIREPARTIRow gruppoReparto in _ds.GRUPPIREPARTI.Where(x => idGruppi.Contains(x.IDGRUPPO)))
                    lista.Add(creaGruppoRepartoModel(gruppoReparto));
            }
            return lista;
        }
        private GruppoModel creaGruppoModel(ArticoloDS.GRUPPIRow gruppo)
        {
            Anagrafica a = new Anagrafica();

            GruppoModel gruppoModel = new GruppoModel();
            gruppoModel.Brand = a.EstraiBrandModel(gruppo.IDBRAND);
            gruppoModel.Codice = gruppo.CODICE;
            gruppoModel.Colore = gruppo.IsCOLOREGRUPPONull() ? Color.White.Name : gruppo.COLOREGRUPPO;
            gruppoModel.Descrizione = gruppo.IsDESCRIZIONENull() ? string.Empty : gruppo.DESCRIZIONE;
            gruppoModel.IdGruppo = gruppo.IDGRUPPO;

            return gruppoModel;
        }

        private GruppoModel creaGruppoModel(decimal idGruppo)
        {
            ArticoloDS.GRUPPIRow gruppo = EstraiGruppo(idGruppo);
            return creaGruppoModel(gruppo);
        }
        private GruppoRepartoModel creaGruppoRepartoModel(ArticoloDS.GRUPPIREPARTIRow gruppoReparto)
        {
            Anagrafica a = new Anagrafica();

            GruppoRepartoModel gruppoRepartoModel = new GruppoRepartoModel();
            gruppoRepartoModel.Reparto = a.CreaRepartoModel(gruppoReparto.IDREPARTO);
            gruppoRepartoModel.Gruppo = creaGruppoModel(gruppoReparto.IDGRUPPO);
            gruppoRepartoModel.IdGruppoReparto = gruppoReparto.IDGRUPPOREPARTO;
            return gruppoRepartoModel;
        }

        private ProdottoFinitoModel CreaProdottoFinitoModel(ArticoloDS.PRODOTTIFINITIRow prodottoFinito)
        {
            Anagrafica a = new Anagrafica();
            ProdottoFinitoModel p = new ProdottoFinitoModel();
            p.IdProdottoFinito = prodottoFinito.IDPRODOTTOFINITO;
            p.Brand = a.EstraiBrandModel(prodottoFinito.IDBRAND);
            p.Colore = a.EstraiColoreModel(prodottoFinito.IDCOLORE);
            p.TipoProdotto = a.EstraiTipoProdottoModel(prodottoFinito.IDTIPOPRODOTTO);
            p.Modello = prodottoFinito.MODELLO;
            p.Codice = prodottoFinito.CODICE;
            p.Descrizione = prodottoFinito.IsDESCRIZIONENull() ? string.Empty : prodottoFinito.DESCRIZIONE;
            p.CodiceDefinitivo = prodottoFinito.IsCODICEDEFINITIVONull() ? string.Empty : prodottoFinito.CODICEDEFINITIVO;
            p.CodiceProvvisorio = prodottoFinito.IsCODICEPROVVISORIONull() ? string.Empty : prodottoFinito.CODICEPROVVISORIO;
            p.Prevenivo = prodottoFinito.PREVENTIVO == SiNo.Si;
            p.Preserie = prodottoFinito.PRESERIE == SiNo.Si;
            p.Produzione = prodottoFinito.PRODUZIONE == SiNo.Si;

            return p;
        }


        public ProdottoFinitoModel CreaProdottoFinitoModel(decimal idProdottoFinito)
        {
            ArticoloDS.PRODOTTIFINITIRow prodottoFinito = EstraiProdottoFinito(idProdottoFinito);
            return CreaProdottoFinitoModel(prodottoFinito);
        }

        private ArticoloDS.PRODOTTIFINITIRow EstraiProdottoFinito(decimal idProdottoFinito)
        {
            ArticoloDS.PRODOTTIFINITIRow prodottoFinito = _ds.PRODOTTIFINITI.Where(x => x.IDPRODOTTOFINITO == idProdottoFinito).FirstOrDefault();
            if (prodottoFinito == null)
            {
                using (ArticoloBusiness bArticolo = new ArticoloBusiness())
                {
                    bArticolo.FillProdottiFiniti(_ds, idProdottoFinito, true);
                }
            }
            return _ds.PRODOTTIFINITI.Where(x => x.IDPRODOTTOFINITO == idProdottoFinito).FirstOrDefault();
        }

        private ArticoloDS.PREVENTIVIRow EstraiPreventivo(decimal idPreventivo)
        {
            ArticoloDS.PREVENTIVIRow preventivo = _ds.PREVENTIVI.Where(x => x.IDPREVENTIVO == idPreventivo).FirstOrDefault();
            if (preventivo == null)
            {
                using (ArticoloBusiness bArticolo = new ArticoloBusiness())
                {
                    bArticolo.EstraiPreventivo(_ds, idPreventivo);
                }
            }
            return _ds.PREVENTIVI.Where(x => x.IDPREVENTIVO == idPreventivo).FirstOrDefault();
        }

        private ArticoloDS.PREVENTIVICOSTIRow EstraiPreventivoCosto(decimal idPreventivoCosto)
        {
            ArticoloDS.PREVENTIVICOSTIRow preventivoCosto = _ds.PREVENTIVICOSTI.Where(x => x.IDPREVENTIVOCOSTO == idPreventivoCosto).FirstOrDefault();
            if (preventivoCosto == null)
            {
                using (ArticoloBusiness bArticolo = new ArticoloBusiness())
                {
                    bArticolo.EstraiPreventivoCosto(_ds, idPreventivoCosto);
                }
            }
            return _ds.PREVENTIVICOSTI.Where(x => x.IDPREVENTIVOCOSTO == idPreventivoCosto).FirstOrDefault();
        }

        private ArticoloDS.GRUPPIRow EstraiGruppo(decimal idGruppo)
        {
            ArticoloDS.GRUPPIRow gruppo = _ds.GRUPPI.Where(x => x.IDGRUPPO == idGruppo).FirstOrDefault();
            if (gruppo == null)
            {
                using (ArticoloBusiness bArticolo = new ArticoloBusiness())
                {
                    bArticolo.FillGruppi(_ds, true);
                }
            }
            return _ds.GRUPPI.Where(x => x.IDGRUPPO == idGruppo).FirstOrDefault();
        }

        private ArticoloDS.GRUPPIREPARTIRow EstraiGruppoReparto(decimal idGruppoReparto)
        {
            ArticoloDS.GRUPPIREPARTIRow gruppo = _ds.GRUPPIREPARTI.Where(x => x.IDGRUPPOREPARTO == idGruppoReparto).FirstOrDefault();
            if (gruppo == null)
            {
                using (ArticoloBusiness bArticolo = new ArticoloBusiness())
                {
                    bArticolo.FillGruppiReparti(_ds, true);
                }
            }
            return _ds.GRUPPIREPARTI.Where(x => x.IDGRUPPOREPARTO == idGruppoReparto).FirstOrDefault();
        }
        public bool EsistonoProdottiFinitiDuplicati(string codice, string modello, decimal idColore, decimal idBrand, out string messaggio)
        {
            messaggio = string.Empty;
            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                bArticolo.FillProdottiFiniti(_ds, false);

                if (_ds.PRODOTTIFINITI.Any(x => x.CODICE == codice.Trim().ToUpper() && x.IDCOLORE == idColore && x.CANCELLATO == SiNo.Si))
                {
                    messaggio = "Un prodotto finito con questo codice e questo colore è presente ma è stato cancellato";
                    return true;
                }
                if (_ds.PRODOTTIFINITI.Any(x => x.CODICE == codice.Trim().ToUpper() && x.IDCOLORE == idColore && x.CANCELLATO == SiNo.No))
                {
                    messaggio = "Un prodotto finito con questo codice e questo colore è già presente";
                    return true;
                }
                if (_ds.PRODOTTIFINITI.Any(x => x.MODELLO == modello.Trim().ToUpper() && x.IDCOLORE == idColore && x.CANCELLATO == SiNo.Si))
                {
                    messaggio = "Un prodotto finito con questo modello e questo colore è presente ma è stato cancellato";
                    return true;
                }
                if (_ds.PRODOTTIFINITI.Any(x => x.MODELLO == modello.Trim().ToUpper() && x.IDCOLORE == idColore && x.CANCELLATO == SiNo.No))
                {
                    messaggio = "Un prodotto finito con questo modello e questo colore è già presente";
                    return true;
                }

                return false;
            }
        }

        public List<ArticoloModel> CreaListArticoloModel(List<decimal> idArticoli)
        {
            List<ArticoloModel> articoli = new List<ArticoloModel>();
            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                bArticolo.FillArticoli(_ds, idArticoli, true);

                foreach (decimal idArticolo in idArticoli)
                {
                    ArticoloDS.ARTICOLIRow articolo = _ds.ARTICOLI.Where(x => x.IDARTICOLO == idArticolo).FirstOrDefault();
                    if (articolo != null)
                    {
                        ArticoloModel aModel = CreaArticoloModel(articolo);
                        articoli.Add(aModel);
                    }
                }
                return articoli;

            }
        }

        private ArticoloDS.ARTICOLIRow EstraiArticolo(decimal idArticolo)
        {
            ArticoloDS.ARTICOLIRow articolo = _ds.ARTICOLI.Where(x => x.IDARTICOLO == idArticolo).FirstOrDefault();
            if (articolo == null)
            {
                using (ArticoloBusiness bArticolo = new ArticoloBusiness())
                {
                    bArticolo.FillArticolo(_ds, idArticolo, true);
                }
            }
            return _ds.ARTICOLI.Where(x => x.IDARTICOLO == idArticolo).FirstOrDefault();
        }

        public ArticoloModel CreaArticoloModel(decimal idArticolo)
        {
            ArticoloDS.ARTICOLIRow articolo = EstraiArticolo(idArticolo);
            return CreaArticoloModel(articolo);
        }

        private string GetImageUrl(ArticoloDS.ARTICOLIRow articolo)
        {
            if (articolo.IsIDMAGAZZNull()) return _rvlImageSite + "NoImage.png";

            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                string nomeFile = bArticolo.GetImageNameFile(articolo.IDMAGAZZ);

                if (string.IsNullOrEmpty(nomeFile)) return _rvlImageSite + "NoImage.png";

                if (System.IO.Path.GetPathRoot(nomeFile) == "R:\\")
                {
                    string newUrl = _rvlImageSite.Replace("rvlimmagini", "rvlimmaginir");
                    string newPath = nomeFile.ToUpper().Replace("R:\\", string.Empty);
                    newPath = newPath.Replace("\\", "/");
                    return newUrl + newPath;
                }
                return _rvlImageSite + nomeFile;
            }

        }

        private ArticoloModel CreaArticoloModel(ArticoloDS.ARTICOLIRow articolo)
        {
            ColoreModel coloreModel = new ColoreModel();
            if (!articolo.IsIDCOLORENull())
                coloreModel = _anagrafica.EstraiColoreModel(articolo.IDCOLORE);

            BrandModel brandModel = _anagrafica.EstraiBrandModel(articolo.IDBRAND);
            ArticoloModel articoloModel = new ArticoloModel()
            {
                Brand = brandModel,
                Colore = coloreModel,
                DataModifica = articolo.DATAMODIFICA,
                Descrizione = articolo.IsDESCRIZIONENull() ? string.Empty : articolo.DESCRIZIONE,
                IdArticolo = articolo.IDARTICOLO,
                IDMAGAZZ = articolo.IsIDMAGAZZNull() ? string.Empty : articolo.IDMAGAZZ,
                Modello = articolo.IsMODELLONull() ? string.Empty : articolo.MODELLO,
                ProgressivoSAM = articolo.IsPROGRESSIVOSAMNull() ? 0 : articolo.PROGRESSIVOSAM,
                UtenteModifica = articolo.UTENTEMODIFICA,
                CodiceCliente = articolo.IsCODICECLIENTENull() ? string.Empty : articolo.CODICECLIENTE,
                CodiceProvvisorio = articolo.IsCODICEPROVVISORIONull() ? string.Empty : articolo.CODICEPROVVISORIO,
                CodiceSAM = articolo.IsCODICESAMNull() ? string.Empty : articolo.CODICESAM,
                ImageUrl = GetImageUrl(articolo)

            };
            return articoloModel;
        }

        public void RimuoviArticolo(decimal idArticolo, string account)
        {
            ArticoloDS.ARTICOLIRow articolo = EstraiArticolo(idArticolo);
            if (articolo == null) return;
            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                articolo.CANCELLATO = SiNo.Si;
                articolo.DATAMODIFICA = DateTime.Now;
                articolo.UTENTEMODIFICA = account;

                bArticolo.UpdateTable(_ds.ARTICOLI.TableName, _ds);
            }
        }

        public void CancellaGruppo(decimal idGruppo, string account)
        {
            ArticoloDS.GRUPPIRow gruppo = EstraiGruppo(idGruppo);
            if (gruppo == null) return;
            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                gruppo.CANCELLATO = SiNo.Si;
                gruppo.DATAMODIFICA = DateTime.Now;
                gruppo.UTENTEMODIFICA = account;

                bArticolo.UpdateTable(_ds.GRUPPI.TableName, _ds);
            }
        }

        public void CancellaGruppoReparto(decimal idGruppoReparto, string account)
        {
            ArticoloDS.GRUPPIREPARTIRow gruppoReparto = EstraiGruppoReparto(idGruppoReparto);
            if (gruppoReparto == null) return;
            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                gruppoReparto.CANCELLATO = SiNo.Si;
                gruppoReparto.DATAMODIFICA = DateTime.Now;
                gruppoReparto.UTENTEMODIFICA = account;

                bArticolo.UpdateTable(_ds.GRUPPIREPARTI.TableName, _ds);
            }
        }

        public string CreaProdottoFinito(decimal idBrand, decimal idColore, decimal idTipoProdotto, string codice, string modello, string descrizione, string codiceProvvisorio, string codiceDefinitivo, bool preventivo, bool preserie, bool produzione, string account)
        {

            codice = correggiString(codice, 10);
            modello = correggiString(modello, 30);
            descrizione = correggiString(descrizione, 80);
            codiceProvvisorio = correggiString(codiceProvvisorio, 15);
            codiceDefinitivo = correggiString(codiceDefinitivo, 15);

            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                ArticoloDS.PRODOTTIFINITIRow prodottoFinito = _ds.PRODOTTIFINITI.NewPRODOTTIFINITIRow();
                prodottoFinito.CODICE = codice;
                prodottoFinito.MODELLO = modello;
                prodottoFinito.IDBRAND = idBrand;
                prodottoFinito.IDCOLORE = idColore;
                prodottoFinito.IDTIPOPRODOTTO = idTipoProdotto;
                prodottoFinito.DESCRIZIONE = descrizione;
                prodottoFinito.CODICEDEFINITIVO = codiceDefinitivo;
                prodottoFinito.CODICEPROVVISORIO = codiceProvvisorio;
                prodottoFinito.PREVENTIVO = preventivo ? SiNo.Si : SiNo.No;
                prodottoFinito.PRESERIE = preserie ? SiNo.Si : SiNo.No;
                prodottoFinito.PRODUZIONE = produzione ? SiNo.Si : SiNo.No;

                prodottoFinito.CANCELLATO = SiNo.No;
                prodottoFinito.DATAMODIFICA = DateTime.Now;
                prodottoFinito.UTENTEMODIFICA = account;


                _ds.PRODOTTIFINITI.AddPRODOTTIFINITIRow(prodottoFinito);
                bArticolo.UpdateTable(_ds.PRODOTTIFINITI.TableName, _ds);
            }
            return "Prodotto finito creato correttamente";
        }


        public string ModificaProdottoFinito(decimal idProdottoFinito, string descrizione, string codiceProvvisorio, string codiceDefinitivo, bool preventivo, bool preserie, bool produzione, string account)
        {
            descrizione = correggiString(descrizione, 80);
            codiceProvvisorio = correggiString(codiceProvvisorio, 15);
            codiceDefinitivo = correggiString(codiceDefinitivo, 15);

            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                bArticolo.FillProdottiFiniti(_ds, idProdottoFinito, true);
                ArticoloDS.PRODOTTIFINITIRow prodottoFinito = _ds.PRODOTTIFINITI.Where(x => x.IDPRODOTTOFINITO == idProdottoFinito).FirstOrDefault();
                if (prodottoFinito == null)
                    return "Impossibile trovare il prodotto finito";

                prodottoFinito.DESCRIZIONE = descrizione;
                prodottoFinito.CODICEDEFINITIVO = codiceDefinitivo;
                prodottoFinito.CODICEPROVVISORIO = codiceProvvisorio;
                prodottoFinito.PREVENTIVO = preventivo ? SiNo.Si : SiNo.No;
                prodottoFinito.PRESERIE = preserie ? SiNo.Si : SiNo.No;
                prodottoFinito.PRODUZIONE = produzione ? SiNo.Si : SiNo.No;

                prodottoFinito.CANCELLATO = SiNo.No;
                prodottoFinito.DATAMODIFICA = DateTime.Now;
                prodottoFinito.UTENTEMODIFICA = account;


                bArticolo.UpdateTable(_ds.PRODOTTIFINITI.TableName, _ds);
            }
            return "Prodotto finito modificato correttamente";
        }

        public List<PreventivoModel> CreaListaPreventivoModel(decimal idProdottoFinito)
        {
            _ds.PREVENTIVI.Clear();
            _ds.ELEMENTIPREVENTIVO.Clear();
            List<PreventivoModel> prevetivi = new List<PreventivoModel>();
            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                bArticolo.FillPreventivi(_ds, idProdottoFinito, true);
                bArticolo.FillElementiPreventivo(_ds, idProdottoFinito, true);

                foreach (ArticoloDS.PREVENTIVIRow preventivo in _ds.PREVENTIVI)
                    prevetivi.Add(creaPreventivoModel(preventivo));

                return prevetivi;

            }
        }
        public List<CostoFissoPreventivoModel> CreaListaCostoFissoPreventivoModel(decimal idPreventivoCosti)
        {
            _ds.COSTIFISSIPREVENTIVO.Clear();
            List<CostoFissoPreventivoModel> costiFissiPreventivo = new List<CostoFissoPreventivoModel>();
            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                bArticolo.FillCostiFissiPreventivo(_ds, idPreventivoCosti, true);

                foreach (ArticoloDS.COSTIFISSIPREVENTIVORow costoFissoPreventivo in _ds.COSTIFISSIPREVENTIVO)
                    costiFissiPreventivo.Add(creaCostoFissoPreventivoModel(costoFissoPreventivo));

                return costiFissiPreventivo;
            }
        }

        private CostoFissoPreventivoModel creaCostoFissoPreventivoModel(ArticoloDS.COSTIFISSIPREVENTIVORow costiFissiPreventivo)
        {

            if (costiFissiPreventivo == null) return null;

            CostoFissoPreventivoModel costoFissoPreventivoModel = new CostoFissoPreventivoModel();
            costoFissoPreventivoModel.IdCostoFissoPreventivo = costiFissiPreventivo.IDCOSTIFISSIPREVENTIVO;
            costoFissoPreventivoModel.IdPreventivoCosto = costiFissiPreventivo.IDPREVENTIVOCOSTO;
            costoFissoPreventivoModel.Codice = costiFissiPreventivo.CODICE;
            costoFissoPreventivoModel.Descrizione = costiFissiPreventivo.IsDESCRIZIONENull() ? string.Empty : costiFissiPreventivo.DESCRIZIONE;
            costoFissoPreventivoModel.Ricarico = costiFissiPreventivo.RICARICO;
            costoFissoPreventivoModel.Costo = costiFissiPreventivo.COSTO;
            costoFissoPreventivoModel.Prezzo = costiFissiPreventivo.PREZZO;
            return costoFissoPreventivoModel;
        }
        public List<PreventivoCostoModel> CreaListaPreventivoCostiModel(decimal idPreventivo)
        {
            _ds.PREVENTIVICOSTI.Clear();
            _ds.ELEMENTICOSTIPREVENTIVI.Clear();
            List<PreventivoCostoModel> prevetivi = new List<PreventivoCostoModel>();
            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                bArticolo.FillPreventiviCosti(_ds, idPreventivo, true);

                foreach (ArticoloDS.PREVENTIVICOSTIRow preventivo in _ds.PREVENTIVICOSTI)
                    prevetivi.Add(creaPreventivoCostoModel(preventivo));

                return prevetivi;
            }
        }
        private PreventivoCostoModel creaPreventivoCostoModel(ArticoloDS.PREVENTIVICOSTIRow preventivo)
        {

            if (preventivo == null) return null;

            PreventivoCostoModel prevenivoCostoModel = new PreventivoCostoModel();
            prevenivoCostoModel.Descrizione = preventivo.IsDESCRIZIONENull() ? string.Empty : preventivo.DESCRIZIONE;
            prevenivoCostoModel.Nota = preventivo.IsNOTANull() ? string.Empty : preventivo.NOTA;
            prevenivoCostoModel.Versione = preventivo.VERSIONE;
            prevenivoCostoModel.Margine = preventivo.MARGINE;
            prevenivoCostoModel.Prezzo = preventivo.PREZZO;
            prevenivoCostoModel.Costo = preventivo.COSTO;

            prevenivoCostoModel.IdPreventivoCosto = preventivo.IDPREVENTIVOCOSTO;
            prevenivoCostoModel.Preventvo = creaPreventivoModel(EstraiPreventivo(preventivo.IDPREVENTIVO));

            return prevenivoCostoModel;
        }
        private PreventivoModel creaPreventivoModel(ArticoloDS.PREVENTIVIRow preventivo)
        {
            ProcessoGalvanico pg = new ProcessoGalvanico();
            Galvanica g = new Galvanica();
            List<TelaioModel> telai = g.CreaListaTelaioModel();

            if (preventivo == null) return null;
            PreventivoModel prevenivoModel = new PreventivoModel();
            prevenivoModel.Descrizione = preventivo.IsDESCRIZIONENull() ? string.Empty : preventivo.DESCRIZIONE;
            prevenivoModel.Nota = preventivo.IsNOTANull() ? string.Empty : preventivo.NOTA;
            prevenivoModel.Versione = preventivo.VERSIONE;
            prevenivoModel.IdPreventivo = preventivo.IDPREVENTIVO;
            prevenivoModel.ProdottoFinito = CreaProdottoFinitoModel(preventivo.IDPRODOTTOFINITO);
            if (preventivo.IsIDPROCESSONull())
                prevenivoModel.Processo = ProcessoModel.ProcessoVuoto();
            else
                prevenivoModel.Processo = pg.CreaProcessoModel(preventivo.IDPROCESSO, telai);

            return prevenivoModel;
        }

        public string CreaPreventivoCosto(decimal versione, string descrizione, decimal idPreventivo, string nota, string account)
        {
            descrizione = correggiString(descrizione, 30);
            nota = correggiString(nota, 200);

            PreventivoModel preventivo = creaPreventivoModel(EstraiPreventivo(idPreventivo));
            if (preventivo == null) return "Preventivo inesistente";

            if (versione <= 0) return "Codice versione errato";

            if (string.IsNullOrEmpty(descrizione))
                return "La descrizione è obbligatoria";

            if (CreaListaPreventivoCostiModel(idPreventivo).Any(x => x.Versione == versione))
                return "Questa versione esiste già";

            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                ArticoloDS.PREVENTIVICOSTIRow preventivoCosto = _ds.PREVENTIVICOSTI.NewPREVENTIVICOSTIRow();
                preventivoCosto.DESCRIZIONE = descrizione;
                preventivoCosto.NOTA = nota;
                preventivoCosto.VERSIONE = versione;
                preventivoCosto.IDPREVENTIVO = idPreventivo;
                preventivoCosto.COSTO = 0;
                preventivoCosto.MARGINE = 0;
                preventivoCosto.PREZZO = 0;

                preventivoCosto.CANCELLATO = SiNo.No;
                preventivoCosto.DATAMODIFICA = DateTime.Now;
                preventivoCosto.UTENTEMODIFICA = account;

                _ds.PREVENTIVICOSTI.AddPREVENTIVICOSTIRow(preventivoCosto);
                bArticolo.UpdateTable(_ds.PREVENTIVICOSTI.TableName, _ds);

            }

            return "Preventivo creato correttamente";
        }

        public string CreaPreventivo(decimal versione, string descrizione, decimal idProdottoFinito, string nota, string account)
        {
            descrizione = correggiString(descrizione, 30);
            nota = correggiString(nota, 100);

            ProdottoFinitoModel prodotto = CreaProdottoFinitoModel(idProdottoFinito);
            if (prodotto == null) return "Prodotto finito inesistente";

            if (versione <= 0) return "Codice versione errato";

            if (string.IsNullOrEmpty(descrizione))
                return "La descrizione è obbligatoria";

            if (CreaListaPreventivoModel(idProdottoFinito).Any(x => x.Versione == versione))
                return "Questa versione esiste già";

            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                ArticoloDS.PREVENTIVIRow preventivo = _ds.PREVENTIVI.NewPREVENTIVIRow();
                preventivo.DESCRIZIONE = descrizione;
                preventivo.NOTA = nota;
                preventivo.VERSIONE = versione;
                preventivo.IDPRODOTTOFINITO = idProdottoFinito;

                preventivo.CANCELLATO = SiNo.No;
                preventivo.DATAMODIFICA = DateTime.Now;
                preventivo.UTENTEMODIFICA = account;

                _ds.PREVENTIVI.AddPREVENTIVIRow(preventivo);
                bArticolo.UpdateTable(_ds.PREVENTIVI.TableName, _ds);

            }

            return "Preventivo creato correttamente";
        }

        public string ModificaPreventivo(decimal idPreventivo, decimal idProcesso, string nota, string account)
        {
            nota = correggiString(nota, 100);

            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                ArticoloDS.PREVENTIVIRow preventivo = EstraiPreventivo(idPreventivo);
                preventivo.NOTA = nota;

                if (idProcesso != ElementiVuoti.ProcessoGalvanicoVuoto)
                    preventivo.IDPROCESSO = idProcesso;

                preventivo.CANCELLATO = SiNo.No;
                preventivo.DATAMODIFICA = DateTime.Now;
                preventivo.UTENTEMODIFICA = account;

                bArticolo.UpdateTable(_ds.PREVENTIVI.TableName, _ds);
            }
            return "Preventivo modificato correttamente";
        }

        public string ModificaPreventivoCosto(decimal idPreventivoCosti, string nota, decimal prezzo, decimal margine, decimal costo, string account)
        {

            nota = correggiString(nota, 200);

            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                ArticoloDS.PREVENTIVICOSTIRow preventivoCosto = EstraiPreventivoCosto(idPreventivoCosti);
                preventivoCosto.NOTA = nota;
                preventivoCosto.PREZZO = prezzo;
                preventivoCosto.MARGINE = margine;
                preventivoCosto.COSTO = costo;

                preventivoCosto.CANCELLATO = SiNo.No;
                preventivoCosto.DATAMODIFICA = DateTime.Now;
                preventivoCosto.UTENTEMODIFICA = account;

                bArticolo.UpdateTable(_ds.PREVENTIVICOSTI.TableName, _ds);
            }
            return "Preventivo costo modificato correttamente";
        }
        public string ModificaGruppo(decimal idGruppo, string codice, string descizione, string colore, string account)
        {
            codice = correggiString(codice, 10);
            descizione = correggiString(descizione, 30);

            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                ArticoloDS.GRUPPIRow gruppo = EstraiGruppo(idGruppo);
                gruppo.CODICE = codice;
                gruppo.DESCRIZIONE = descizione;
                gruppo.COLOREGRUPPO = colore;

                gruppo.CANCELLATO = SiNo.No;
                gruppo.DATAMODIFICA = DateTime.Now;
                gruppo.UTENTEMODIFICA = account;

                bArticolo.UpdateTable(_ds.GRUPPI.TableName, _ds);
            }
            return "Gruppo modificato correttamente";
        }
        public string ModificaGruppoReparto(decimal idGruppoReparto, decimal idGruppo, string account)
        {
            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                ArticoloDS.GRUPPIREPARTIRow gruppoReparto = EstraiGruppoReparto(idGruppoReparto);
                if (gruppoReparto == null) return "Gruppo reparto non trovato";

                gruppoReparto.IDGRUPPO = idGruppo;

                gruppoReparto.CANCELLATO = SiNo.No;
                gruppoReparto.DATAMODIFICA = DateTime.Now;
                gruppoReparto.UTENTEMODIFICA = account;

                bArticolo.UpdateTable(_ds.GRUPPI.TableName, _ds);
            }
            return "Gruppo modificato correttamente";
        }

        public string CreaGruppoReparto(decimal idReparto, decimal idGruppo, string account)
        {
            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {

                ArticoloDS.GRUPPIREPARTIRow gruppoReparto = _ds.GRUPPIREPARTI.NewGRUPPIREPARTIRow();

                gruppoReparto.IDGRUPPO = idGruppo;
                gruppoReparto.IDREPARTO = idReparto;

                gruppoReparto.CANCELLATO = SiNo.No;
                gruppoReparto.DATAMODIFICA = DateTime.Now;
                gruppoReparto.UTENTEMODIFICA = account;
                _ds.GRUPPIREPARTI.AddGRUPPIREPARTIRow(gruppoReparto);

                bArticolo.UpdateTable(_ds.GRUPPIREPARTI.TableName, _ds);
            }
            return "Gruppo reparto modificato correttamente";
        }


        public List<ElementoPreventivoModel> CreaListaElementoPreventivoModel(decimal idPreventivo)
        {
            List<ElementoPreventivoModel> elementi = new List<ElementoPreventivoModel>();

            if (!_ds.ELEMENTIPREVENTIVO.Any(x => x.IDPREVENTIVO == idPreventivo))
            {
                using (ArticoloBusiness bArticolo = new ArticoloBusiness())
                {
                    bArticolo.FillElementiPreventivo(_ds, idPreventivo);
                }
            }

            foreach (ArticoloDS.ELEMENTIPREVENTIVORow elementoDatabase in _ds.ELEMENTIPREVENTIVO.Where(x => x.IDPREVENTIVO == idPreventivo && x.CANCELLATO == SiNo.No))
                elementi.Add(creaElementoPreventivoModel(elementoDatabase));

            return elementi;
        }

        public List<ElementoCostoPreventivoModel> CreaListaElementoCostoPreventivoModel(decimal idPreventivoCosto)
        {
            List<ElementoCostoPreventivoModel> elementi = new List<ElementoCostoPreventivoModel>();

            if (!_ds.ELEMENTICOSTIPREVENTIVI.Any(x => x.IDPREVENTIVOCOSTO == idPreventivoCosto))
            {
                using (ArticoloBusiness bArticolo = new ArticoloBusiness())
                {
                    bArticolo.FillElementiCostiPreventivo(_ds, idPreventivoCosto, true);
                }
            }

            foreach (ArticoloDS.ELEMENTICOSTIPREVENTIVIRow elementoCosto in _ds.ELEMENTICOSTIPREVENTIVI.Where(x => x.IDPREVENTIVOCOSTO == idPreventivoCosto && x.CANCELLATO == SiNo.No))
                elementi.Add(creaElementoCostoPreventivoModel(elementoCosto));

            return elementi;
        }
        private ElementoCostoPreventivoModel creaElementoCostoPreventivoModel(ArticoloDS.ELEMENTICOSTIPREVENTIVIRow elementoCostoPreventivo)
        {
            Anagrafica a = new Anagrafica();
            ElementoCostoPreventivoModel elementoModel = new ElementoCostoPreventivoModel();
            elementoModel.IdElementoCosto = elementoCostoPreventivo.IDELEMENTOCOSTO;
            elementoModel.IdPreventivoCosto = elementoCostoPreventivo.IDPREVENTIVOCOSTO;
            elementoModel.ElementoPreventivo = creaElementoPreventivoModel(elementoCostoPreventivo.IDELEMENTOPREVENTIVO);
            elementoModel.Ricarico = elementoCostoPreventivo.RICARICO;
            elementoModel.CostoOrario = elementoCostoPreventivo.COSTO;
            elementoModel.IncludiPreventivo = elementoCostoPreventivo.INCLUDIPREVENTIVO == SiNo.Si;
            elementoModel.IdEsterna = elementoCostoPreventivo.IsIDESTERNANull() ? -1 : elementoCostoPreventivo.IDESTERNA;
            elementoModel.TabellaEsterna = elementoCostoPreventivo.IsTABELLAESTERNANull() ? string.Empty : elementoCostoPreventivo.TABELLAESTERNA;
            elementoModel.PezziOrari = elementoCostoPreventivo.PEZZIORARI;
            elementoModel.Quantita = elementoCostoPreventivo.QUANTITA;
            elementoModel.CostoArticolo = elementoCostoPreventivo.COSTOARTICOLO;
            elementoModel.CostoCompleto = elementoCostoPreventivo.COSTOCOMPLETO;
            elementoModel.CostoFigli = elementoCostoPreventivo.COSTOFIGLI;

            return elementoModel;
        }
        private ElementoPreventivoModel creaElementoPreventivoModel(decimal idElementoreventivo)
        {
            ArticoloDS.ELEMENTIPREVENTIVORow elementoPreventivo = _ds.ELEMENTIPREVENTIVO.Where(x => x.IDELEMENTOPREVENTIVO == idElementoreventivo).FirstOrDefault();
            if (elementoPreventivo == null)
            {
                using (ArticoloBusiness bArticolo = new ArticoloBusiness())
                {
                    bArticolo.EstraiElementoPreventivo(_ds, idElementoreventivo);
                    elementoPreventivo = _ds.ELEMENTIPREVENTIVO.Where(x => x.IDELEMENTOPREVENTIVO == idElementoreventivo).FirstOrDefault();
                    if (elementoPreventivo == null) return null;
                }
            }
            return creaElementoPreventivoModel(elementoPreventivo);

        }
        private ElementoPreventivoModel creaElementoPreventivoModel(ArticoloDS.ELEMENTIPREVENTIVORow elementoPreventivo)
        {
            Anagrafica a = new Anagrafica();
            ElementoPreventivoModel elementoModel = new ElementoPreventivoModel();
            elementoModel.Articolo = elementoPreventivo.IsARTICOLONull() ? string.Empty : elementoPreventivo.ARTICOLO;
            elementoModel.Codice = elementoPreventivo.CODICE;
            elementoModel.CostoOrario = elementoPreventivo.IsCOSTONull() ? 0 : elementoPreventivo.COSTO;
            elementoModel.Descrizione = elementoPreventivo.DESCRIZIONE;
            elementoModel.IdElementoPreventivo = elementoPreventivo.IDELEMENTOPREVENTIVO;
            elementoModel.IdEsterna = elementoPreventivo.IsIDESTERNANull() ? -1 : elementoPreventivo.IDESTERNA;
            elementoModel.IdPadre = elementoPreventivo.IsIDPADRENull() ? -1 : elementoPreventivo.IDPADRE;
            elementoModel.IdPreventivo = elementoPreventivo.IDPREVENTIVO;
            elementoModel.IncludiPreventivo = elementoPreventivo.INCLUDIPREVENTIVO == SiNo.Si;
            elementoModel.Peso = elementoPreventivo.IsPESONull() ? 0 : elementoPreventivo.PESO;
            elementoModel.PezziOrari = elementoPreventivo.IsPEZZIORARINull() ? 0 : elementoPreventivo.PEZZIORARI;
            elementoModel.Quantita = elementoPreventivo.QUANTITA;
            elementoModel.Nota = elementoPreventivo.IsNOTANull() ? string.Empty : elementoPreventivo.NOTA;
            if (!elementoPreventivo.IsIDREPARTONull())
                elementoModel.Reparto = a.CreaRepartoModel(elementoPreventivo.IDREPARTO);
            elementoModel.Ricarico = elementoPreventivo.IsRICARICONull() ? 0 : elementoPreventivo.RICARICO;
            elementoModel.Superficie = elementoPreventivo.IsSUPERFICIENull() ? 0 : elementoPreventivo.SUPERFICIE;
            elementoModel.TabellaEsterna = elementoPreventivo.IsTABELLAESTERNANull() ? string.Empty : elementoPreventivo.TABELLAESTERNA;

            return elementoModel;
        }


        public void SalvaElementiPreventivo(List<ElementoPreventivoModel> elementiPreventivoModel, decimal idPreventivo, string account)
        {
            _ds.ELEMENTIPREVENTIVO.Clear();
            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                bArticolo.FillElementiPreventivo(_ds, idPreventivo);
            }

            foreach (ArticoloDS.ELEMENTIPREVENTIVORow elementoDatabase in _ds.ELEMENTIPREVENTIVO.Where(x => x.IDPREVENTIVO == idPreventivo))
            {
                ElementoPreventivoModel elementoPreventivoModel = elementiPreventivoModel.Where(x => x.IdElementoPreventivo == elementoDatabase.IDELEMENTOPREVENTIVO).FirstOrDefault();
                if (elementoPreventivoModel == null)
                {
                    elementoDatabase.CANCELLATO = SiNo.Si;
                }
                else
                {
                    string articolo = elementoPreventivoModel.Articolo.Trim().ToUpper();
                    elementoDatabase.ARTICOLO = correggiString(elementoPreventivoModel.Articolo, 30);
                    elementoDatabase.CODICE = correggiString(elementoPreventivoModel.Codice, 10);
                    elementoDatabase.COSTO = elementoPreventivoModel.CostoOrario;
                    elementoDatabase.DESCRIZIONE = correggiString(elementoPreventivoModel.Descrizione, 40);
                    elementoDatabase.NOTA = elementoPreventivoModel.Nota;

                    if (elementoPreventivoModel.IdEsterna == -1) elementoDatabase.SetIDESTERNANull();
                    else elementoDatabase.IDESTERNA = elementoPreventivoModel.IdEsterna;

                    if (elementoPreventivoModel.IdPadre == -1) elementoDatabase.SetIDPADRENull();
                    else elementoDatabase.IDPADRE = elementoPreventivoModel.IdPadre;

                    elementoDatabase.PESO = elementoPreventivoModel.Peso;
                    elementoDatabase.PEZZIORARI = elementoPreventivoModel.PezziOrari;
                    elementoDatabase.QUANTITA = elementoPreventivoModel.Quantita;

                    if (elementoPreventivoModel.Reparto == null) elementoDatabase.SetIDREPARTONull();
                    else elementoDatabase.IDREPARTO = elementoPreventivoModel.Reparto.IdReparto;

                    elementoDatabase.RICARICO = elementoPreventivoModel.Ricarico;
                    elementoDatabase.SUPERFICIE = elementoPreventivoModel.Superficie;

                    elementoDatabase.TABELLAESTERNA = correggiString(elementoPreventivoModel.TabellaEsterna, 25);
                    elementoDatabase.INCLUDIPREVENTIVO = elementoPreventivoModel.IncludiPreventivo ? SiNo.Si : SiNo.No;
                }

                elementoDatabase.DATAMODIFICA = DateTime.Now;
                elementoDatabase.UTENTEMODIFICA = account;
            }

            foreach (ElementoPreventivoModel elementoPreventivoModel in elementiPreventivoModel)
            {
                if (!_ds.ELEMENTIPREVENTIVO.Any(x => x.IDELEMENTOPREVENTIVO == elementoPreventivoModel.IdElementoPreventivo))
                {
                    ArticoloDS.ELEMENTIPREVENTIVORow elementoNuovo = _ds.ELEMENTIPREVENTIVO.NewELEMENTIPREVENTIVORow();
                    elementoNuovo.IDELEMENTOPREVENTIVO = elementoPreventivoModel.IdElementoPreventivo;
                    elementoNuovo.IDPREVENTIVO = idPreventivo;

                    elementoNuovo.ARTICOLO = correggiString(elementoPreventivoModel.Articolo, 30);
                    elementoNuovo.CODICE = correggiString(elementoPreventivoModel.Codice, 10);
                    elementoNuovo.COSTO = elementoPreventivoModel.CostoOrario;
                    elementoNuovo.DESCRIZIONE = correggiString(elementoPreventivoModel.Descrizione, 40);
                    elementoNuovo.NOTA = elementoPreventivoModel.Nota;

                    if (elementoPreventivoModel.IdEsterna == -1) elementoNuovo.SetIDESTERNANull();
                    else elementoNuovo.IDESTERNA = elementoPreventivoModel.IdEsterna;

                    if (elementoPreventivoModel.IdPadre == -1) elementoNuovo.SetIDPADRENull();
                    else elementoNuovo.IDPADRE = elementoPreventivoModel.IdPadre;

                    elementoNuovo.PESO = elementoPreventivoModel.Peso;
                    elementoNuovo.PEZZIORARI = elementoPreventivoModel.PezziOrari;
                    elementoNuovo.QUANTITA = elementoPreventivoModel.Quantita;

                    if (elementoPreventivoModel.Reparto == null) elementoNuovo.SetIDREPARTONull();
                    else elementoNuovo.IDREPARTO = elementoPreventivoModel.Reparto.IdReparto;

                    elementoNuovo.RICARICO = elementoPreventivoModel.Ricarico;
                    elementoNuovo.SUPERFICIE = elementoPreventivoModel.Superficie;

                    elementoNuovo.TABELLAESTERNA = correggiString(elementoPreventivoModel.TabellaEsterna, 25);
                    elementoNuovo.INCLUDIPREVENTIVO = elementoPreventivoModel.IncludiPreventivo ? SiNo.Si : SiNo.No;

                    elementoNuovo.CANCELLATO = SiNo.No;
                    elementoNuovo.DATAMODIFICA = DateTime.Now;
                    elementoNuovo.UTENTEMODIFICA = account;

                    _ds.ELEMENTIPREVENTIVO.AddELEMENTIPREVENTIVORow(elementoNuovo);
                }
            }

            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
                bArticolo.UpdateTable(_ds.ELEMENTIPREVENTIVO.TableName, _ds);
        }

        public void SalvaElementiCostoPreventivo(List<ElementoCostoPreventivoModel> elementiCostoPreventivoModel, decimal idPreventivoCosto, string account)
        {
            _ds.ELEMENTICOSTIPREVENTIVI.Clear();
            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                bArticolo.FillElementiCostiPreventivo(_ds, idPreventivoCosto, true);
            }

            foreach (ArticoloDS.ELEMENTICOSTIPREVENTIVIRow elementoDatabase in _ds.ELEMENTICOSTIPREVENTIVI.Where(x => x.IDPREVENTIVOCOSTO == idPreventivoCosto))
            {
                ElementoCostoPreventivoModel elementoCostoPreventivoModel = elementiCostoPreventivoModel.Where(x => x.IdElementoCosto == elementoDatabase.IDELEMENTOCOSTO).FirstOrDefault();
                if (elementoCostoPreventivoModel == null)
                {
                    elementoDatabase.CANCELLATO = SiNo.Si;
                }
                else
                {
                    elementoDatabase.RICARICO = elementoCostoPreventivoModel.Ricarico;
                    elementoDatabase.COSTO = elementoCostoPreventivoModel.CostoOrario;
                    elementoDatabase.INCLUDIPREVENTIVO = elementoCostoPreventivoModel.IncludiPreventivo ? SiNo.Si : SiNo.No;

                    if (elementoCostoPreventivoModel.IdEsterna == -1) elementoDatabase.SetIDESTERNANull();
                    else elementoDatabase.IDESTERNA = elementoCostoPreventivoModel.IdEsterna;
                    elementoDatabase.TABELLAESTERNA = correggiString(elementoCostoPreventivoModel.TabellaEsterna, 25);

                    elementoDatabase.PEZZIORARI = elementoCostoPreventivoModel.PezziOrari;
                    elementoDatabase.QUANTITA = elementoCostoPreventivoModel.Quantita;
                    elementoDatabase.COSTOARTICOLO = elementoCostoPreventivoModel.CostoArticolo;
                    elementoDatabase.COSTOCOMPLETO = elementoCostoPreventivoModel.CostoCompleto;
                    elementoDatabase.COSTOFIGLI = elementoCostoPreventivoModel.CostoFigli;
                }

                elementoDatabase.DATAMODIFICA = DateTime.Now;
                elementoDatabase.UTENTEMODIFICA = account;
            }

            foreach (ElementoCostoPreventivoModel elementCostoPreventivo in elementiCostoPreventivoModel)
            {
                if (!_ds.ELEMENTICOSTIPREVENTIVI.Any(x => x.IDELEMENTOCOSTO == elementCostoPreventivo.IdElementoCosto))
                {
                    ArticoloDS.ELEMENTICOSTIPREVENTIVIRow elementoNuovo = _ds.ELEMENTICOSTIPREVENTIVI.NewELEMENTICOSTIPREVENTIVIRow();
                    elementoNuovo.IDELEMENTOCOSTO = elementCostoPreventivo.IdElementoCosto;
                    elementoNuovo.IDPREVENTIVOCOSTO = idPreventivoCosto;
                    elementoNuovo.IDELEMENTOPREVENTIVO = elementCostoPreventivo.ElementoPreventivo.IdElementoPreventivo;

                    elementoNuovo.RICARICO = elementCostoPreventivo.Ricarico;
                    elementoNuovo.COSTO = elementCostoPreventivo.CostoOrario;
                    elementoNuovo.INCLUDIPREVENTIVO = elementCostoPreventivo.IncludiPreventivo ? SiNo.Si : SiNo.No;

                    if (elementCostoPreventivo.IdEsterna == -1) elementoNuovo.SetIDESTERNANull();
                    else elementoNuovo.IDESTERNA = elementCostoPreventivo.IdEsterna;
                    elementoNuovo.TABELLAESTERNA = correggiString(elementCostoPreventivo.TabellaEsterna, 25);

                    elementoNuovo.PEZZIORARI = elementCostoPreventivo.PezziOrari;
                    elementoNuovo.QUANTITA = elementCostoPreventivo.Quantita;
                    elementoNuovo.COSTOARTICOLO = elementCostoPreventivo.CostoArticolo;
                    elementoNuovo.COSTOCOMPLETO = elementCostoPreventivo.CostoCompleto;
                    elementoNuovo.COSTOFIGLI = elementCostoPreventivo.CostoFigli;

                    elementoNuovo.CANCELLATO = SiNo.No;
                    elementoNuovo.DATAMODIFICA = DateTime.Now;
                    elementoNuovo.UTENTEMODIFICA = account;

                    _ds.ELEMENTICOSTIPREVENTIVI.AddELEMENTICOSTIPREVENTIVIRow(elementoNuovo);
                }
            }

            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
                bArticolo.UpdateTable(_ds.ELEMENTICOSTIPREVENTIVI.TableName, _ds);
        }

        public void SalvaElementiCostoFisso(List<CostoFissoPreventivoModel> elementiCostiFissiPreventivo, decimal idPreventivoCosto, string account)
        {
            _ds.COSTIFISSIPREVENTIVO.Clear();
            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                bArticolo.FillCostiFissiPreventivo(_ds, idPreventivoCosto, true);
            }

            foreach (ArticoloDS.COSTIFISSIPREVENTIVORow elementoDatabase in _ds.COSTIFISSIPREVENTIVO.Where(x => x.IDPREVENTIVOCOSTO == idPreventivoCosto))
            {
                CostoFissoPreventivoModel elementoCostoFissoPreventivoModel = elementiCostiFissiPreventivo.Where(x => x.IdCostoFissoPreventivo == elementoDatabase.IDCOSTIFISSIPREVENTIVO).FirstOrDefault();
                if (elementoCostoFissoPreventivoModel == null)
                {
                    elementoDatabase.CANCELLATO = SiNo.Si;
                }
                else
                {
                    elementoDatabase.CODICE = elementoCostoFissoPreventivoModel.Codice;
                    elementoDatabase.DESCRIZIONE = elementoCostoFissoPreventivoModel.Descrizione;

                    elementoDatabase.RICARICO = elementoCostoFissoPreventivoModel.Ricarico;
                    elementoDatabase.COSTO = elementoCostoFissoPreventivoModel.Costo;
                    elementoDatabase.PREZZO = elementoCostoFissoPreventivoModel.Prezzo;
                }

                elementoDatabase.DATAMODIFICA = DateTime.Now;
                elementoDatabase.UTENTEMODIFICA = account;
            }

            foreach (CostoFissoPreventivoModel elementCostoPreventivo in elementiCostiFissiPreventivo)
            {
                if (!_ds.COSTIFISSIPREVENTIVO.Any(x => x.IDCOSTIFISSIPREVENTIVO == elementCostoPreventivo.IdCostoFissoPreventivo))
                {
                    ArticoloDS.COSTIFISSIPREVENTIVORow elementoNuovo = _ds.COSTIFISSIPREVENTIVO.NewCOSTIFISSIPREVENTIVORow();
                    elementoNuovo.IDCOSTIFISSIPREVENTIVO = elementCostoPreventivo.IdCostoFissoPreventivo;
                    elementoNuovo.IDPREVENTIVOCOSTO = idPreventivoCosto;
                    elementoNuovo.CODICE = elementCostoPreventivo.Codice;
                    elementoNuovo.DESCRIZIONE = elementCostoPreventivo.Descrizione;

                    elementoNuovo.RICARICO = elementCostoPreventivo.Ricarico;
                    elementoNuovo.COSTO = elementCostoPreventivo.Costo;
                    elementoNuovo.PREZZO = elementCostoPreventivo.Prezzo;

                    elementoNuovo.CANCELLATO = SiNo.No;
                    elementoNuovo.DATAMODIFICA = DateTime.Now;
                    elementoNuovo.UTENTEMODIFICA = account;

                    _ds.COSTIFISSIPREVENTIVO.AddCOSTIFISSIPREVENTIVORow(elementoNuovo);
                }
            }

            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
                bArticolo.UpdateTable(_ds.COSTIFISSIPREVENTIVO.TableName, _ds);
        }

        public static void RicalcolaCostoFigliListaElementiCostoPreventiviModel(List<ElementoCostoPreventivoModel> lista)
        {
            List<ElementoCostoPreventivoModel> radici = lista.Where(x => x.ElementoPreventivo.IdPadre == -1).ToList();
            foreach (ElementoCostoPreventivoModel radice in radici)
            {
                calcolaCostoCompleto(lista, radice);
            }
        }

        private static decimal calcolaCostoCompleto(List<ElementoCostoPreventivoModel> lista, ElementoCostoPreventivoModel elementoPadre)
        {
            decimal costoFigli = 0;
            foreach (ElementoCostoPreventivoModel figlio in lista.Where(x => x.ElementoPreventivo.IdPadre == elementoPadre.ElementoPreventivo.IdElementoPreventivo))
                costoFigli += calcolaCostoCompleto(lista, figlio) * figlio.ElementoPreventivo.Quantita;

            elementoPadre.CostoFigli = costoFigli;
            if (elementoPadre.IncludiPreventivo)
                elementoPadre.CostoCompleto = elementoPadre.CostoArticolo + costoFigli;
            else
                elementoPadre.CostoCompleto = costoFigli;

            return elementoPadre.CostoCompleto;
        }


        public string CreaGruppo(string codice, string descrizione, decimal idbrand, string colore, string account)
        {
            descrizione = correggiString(descrizione, 30);
            codice = correggiString(codice, 10);


            if (string.IsNullOrEmpty(codice))
                return "Il codice è obbligatorio";

            if (CreaListaGruppoModel().Any(x => x.Codice == codice && x.Brand.IdBrand == idbrand))
                return "Questo codice esiste già per questo brand";

            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                ArticoloDS.GRUPPIRow gruppo = _ds.GRUPPI.NewGRUPPIRow();
                gruppo.DESCRIZIONE = descrizione;
                gruppo.CODICE = codice;
                gruppo.IDBRAND = idbrand;
                gruppo.COLOREGRUPPO = colore;

                gruppo.CANCELLATO = SiNo.No;
                gruppo.DATAMODIFICA = DateTime.Now;
                gruppo.UTENTEMODIFICA = account;

                _ds.GRUPPI.AddGRUPPIRow(gruppo);
                bArticolo.UpdateTable(_ds.GRUPPI.TableName, _ds);

            }

            return "Gruppo creato correttamente";
        }
    }
}
