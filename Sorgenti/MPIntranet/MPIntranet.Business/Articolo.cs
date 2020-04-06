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


    }

}
