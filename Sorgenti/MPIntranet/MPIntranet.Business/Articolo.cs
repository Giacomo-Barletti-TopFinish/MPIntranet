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

    }

}
