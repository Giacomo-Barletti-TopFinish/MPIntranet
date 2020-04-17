using MPIntranet.Common;
using MPIntranet.DataAccess.Articolo;
using MPIntranet.Entities;
using MPIntranet.Models;
using MPIntranet.Models.Anagrafica;
using MPIntranet.Models.Articolo;
using MPIntranet.Models.Galvanica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class Articolo
    {
        private ArticoloDS _ds = new ArticoloDS();
        private RVLDS _dsRVL = new RVLDS();
        private Anagrafica _anagrafica = new Anagrafica();
        private Galvanica _galvanica = new Galvanica();
        private string _rvlImageSite;

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

        public decimal EstraId()
        {
            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
                return bArticolo.EstraiId();
        }
        public List<ProdottoFinitoModel> TrovaProdottiFiniti(decimal idBrand, decimal idColore, decimal idTipoProdotto, string codice, string modello, string descrizione, string codiceProvvisorio, string codiceDefinitivo, bool preventivo, bool preserie, bool produzione)
        {
            codice = codice.Trim().ToUpper();
            modello = modello.Trim().ToUpper();
            descrizione = descrizione.Trim().ToUpper();
            codiceProvvisorio = codiceProvvisorio.Trim().ToUpper();
            codiceDefinitivo = codiceDefinitivo.Trim().ToUpper();
            codice = codice.Length > 10 ? codice.Substring(0, 10) : codice;
            codiceDefinitivo = codiceDefinitivo.Length > 15 ? codiceDefinitivo.Substring(0, 15) : codiceDefinitivo;
            codiceProvvisorio = codiceProvvisorio.Length > 15 ? codiceProvvisorio.Substring(0, 15) : codiceProvvisorio;
            descrizione = descrizione.Length > 80 ? descrizione.Substring(0, 80) : descrizione;
            modello = modello.Length > 30 ? modello.Substring(0, 30) : modello;
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

        public string CreaProdottoFinito(decimal idBrand, decimal idColore, decimal idTipoProdotto, string codice, string modello, string descrizione, string codiceProvvisorio, string codiceDefinitivo, bool preventivo, bool preserie, bool produzione, string account)
        {
            codice = codice.Trim().ToUpper();
            modello = modello.Trim().ToUpper();
            descrizione = descrizione.Trim().ToUpper();
            codiceProvvisorio = codiceProvvisorio.Trim().ToUpper();
            codiceDefinitivo = codiceDefinitivo.Trim().ToUpper();
            codice = codice.Length > 10 ? codice.Substring(0, 10) : codice;
            codiceDefinitivo = codiceDefinitivo.Length > 15 ? codiceDefinitivo.Substring(0, 15) : codiceDefinitivo;
            codiceProvvisorio = codiceProvvisorio.Length > 15 ? codiceProvvisorio.Substring(0, 15) : codiceProvvisorio;
            descrizione = descrizione.Length > 80 ? descrizione.Substring(0, 80) : descrizione;
            modello = modello.Length > 30 ? modello.Substring(0, 30) : modello;

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
            descrizione = descrizione.Trim().ToUpper();
            codiceProvvisorio = codiceProvvisorio.Trim().ToUpper();
            codiceDefinitivo = codiceDefinitivo.Trim().ToUpper();
            codiceDefinitivo = codiceDefinitivo.Length > 15 ? codiceDefinitivo.Substring(0, 15) : codiceDefinitivo;
            codiceProvvisorio = codiceProvvisorio.Length > 15 ? codiceProvvisorio.Substring(0, 15) : codiceProvvisorio;
            descrizione = descrizione.Length > 80 ? descrizione.Substring(0, 80) : descrizione;

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

        private PreventivoModel creaPreventivoModel(ArticoloDS.PREVENTIVIRow preventivo)
        {
            if (preventivo == null) return null;
            PreventivoModel prevenivoModel = new PreventivoModel();
            prevenivoModel.Descrizione = preventivo.IsDESCRIZIONENull() ? string.Empty : preventivo.DESCRIZIONE;
            prevenivoModel.Nota = preventivo.IsNOTANull() ? string.Empty : preventivo.NOTA;
            prevenivoModel.Versione = preventivo.VERSIONE;
            prevenivoModel.IdPrevenivo = preventivo.IDPREVENTIVO;
            prevenivoModel.ProdottoFinito = CreaProdottoFinitoModel(preventivo.IDPRODOTTOFINITO);
            return prevenivoModel;
        }


        public string CreaPreventivo(decimal versione, string descrizione, decimal idProdottoFinito, string nota, string account)
        {
            descrizione = descrizione.Trim().ToUpper();
            descrizione = descrizione.Length > 30 ? descrizione.Substring(0, 30) : descrizione;

            nota = nota.Trim().ToUpper();
            nota = nota.Length > 100 ? nota.Substring(0, 100) : nota;

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

        public string ModificaPreventivo(decimal idPreventivo, string nota, string account)
        {
            nota = nota.Trim().ToUpper();
            nota = nota.Length > 100 ? nota.Substring(0, 100) : nota;

            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                ArticoloDS.PREVENTIVIRow preventivo = EstraiPreventivo(idPreventivo);
                preventivo.NOTA = nota;

                preventivo.CANCELLATO = SiNo.No;
                preventivo.DATAMODIFICA = DateTime.Now;
                preventivo.UTENTEMODIFICA = account;

                bArticolo.UpdateTable(_ds.PREVENTIVI.TableName, _ds);
            }
            return "Preventivo modificato correttamente";
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

            foreach (ArticoloDS.ELEMENTIPREVENTIVORow elementoDatabase in _ds.ELEMENTIPREVENTIVO.Where(x => x.IDPREVENTIVO == idPreventivo))
                elementi.Add(creaElementoPreventivoModel(elementoDatabase));

            return elementi;
        }

        private ElementoPreventivoModel creaElementoPreventivoModel(ArticoloDS.ELEMENTIPREVENTIVORow elementoPreventivo)
        {
            Anagrafica a = new Anagrafica();
            ElementoPreventivoModel elementoModel = new ElementoPreventivoModel();
            elementoModel.Articolo = elementoPreventivo.IsARTICOLONull() ? string.Empty : elementoPreventivo.ARTICOLO;
            elementoModel.Codice = elementoPreventivo.CODICE;
            elementoModel.Costo = elementoPreventivo.IsCOSTONull() ? 0 : elementoPreventivo.COSTO;
            elementoModel.Descrizione = elementoPreventivo.DESCRIZIONE;
            elementoModel.IdElementoPreventivo = elementoPreventivo.IDELEMENTOPREVENTIVO;
            elementoModel.IdEsterna = elementoPreventivo.IsIDESTERNANull() ? -1 : elementoPreventivo.IDESTERNA;
            elementoModel.IdPadre = elementoPreventivo.IsIDPADRENull() ? -1 : elementoPreventivo.IDPADRE;
            elementoModel.IdPreventivo = elementoPreventivo.IDPREVENTIVO;
            elementoModel.IncludiPreventivo = elementoPreventivo.INCLUDIPREVENTIVO == SiNo.Si;
            elementoModel.Peso = elementoPreventivo.IsPESONull() ? 0 : elementoPreventivo.PESO;
            elementoModel.PezziOrari = elementoPreventivo.IsPEZZIORARINull() ? 0 : elementoPreventivo.PEZZIORARI;
            elementoModel.Quantita = elementoPreventivo.QUANTITA;
            if (!elementoPreventivo.IsIDREPARTONull())
                elementoModel.Reparto = a.CreaRepartoModel(elementoPreventivo.IDREPARTO);
            elementoModel.Ricarico = elementoPreventivo.IsRICARICONull() ? 0 : elementoPreventivo.RICARICO;
            elementoModel.Superficie = elementoPreventivo.IsSUPERFICIENull() ? 0 : elementoPreventivo.SUPERFICIE;
            elementoModel.TabellaEsterna = elementoPreventivo.IsTABELLAESTERNANull() ? string.Empty : elementoPreventivo.TABELLAESTERNA;

            return elementoModel;
        }
        public void SalvaElementiPreventivo(List<ElementoPreventivoModel> elementiPreventivoModel, decimal idPreventivo, string account)
        {

            if (!_ds.ELEMENTIPREVENTIVO.Any(x => x.IDPREVENTIVO == idPreventivo))
            {
                using (ArticoloBusiness bArticolo = new ArticoloBusiness())
                {
                    bArticolo.FillElementiPreventivo(_ds, idPreventivo);
                }
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
                    elementoDatabase.ARTICOLO = elementoPreventivoModel.Articolo;
                    elementoDatabase.CODICE = elementoPreventivoModel.Codice;
                    elementoDatabase.COSTO = elementoPreventivoModel.Costo;
                    elementoDatabase.DESCRIZIONE = elementoPreventivoModel.Descrizione;

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

                    elementoDatabase.TABELLAESTERNA = elementoPreventivoModel.TabellaEsterna;
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

                    elementoNuovo.ARTICOLO = elementoPreventivoModel.Articolo;
                    elementoNuovo.CODICE = elementoPreventivoModel.Codice;
                    elementoNuovo.COSTO = elementoPreventivoModel.Costo;
                    elementoNuovo.DESCRIZIONE = elementoPreventivoModel.Descrizione;

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

                    elementoNuovo.TABELLAESTERNA = elementoPreventivoModel.TabellaEsterna;
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
    }
}
