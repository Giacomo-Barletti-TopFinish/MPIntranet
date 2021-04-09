using MPIntranet.DataAccess.Articoli;
using MPIntranet.Entities;
using MPIntranet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class Articolo
    {
        private ArticoloModel _model;
        public ArticoloModel EstraiModello()
        {
            return _model;
        }
        public ArticoloModel Model
        {
            get
            {
                return _model;
            }
        }

        public int ID
        {
            get
            {
                if (_model == null) return ElementiVuoti.Brand;
                return _model.IdArticolo;
            }
        }

        public static Articolo EstraiArticolo(int idArticolo)
        {
            List<Articolo> lista = EstraiListaArticoli(false);
            return lista.Where(x => x.ID == idArticolo).FirstOrDefault();
        }
        public static Articolo EstraiArticolo(string anagrafica)
        {
            List<Articolo> lista = EstraiListaArticoli(anagrafica, false);
            return lista.Where(x => x.Model.Anagrafica == anagrafica).FirstOrDefault();
        }

        public static List<Articolo> EstraiListaArticoli(bool soloNonCancellati)
        {
            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                bArticolo.FillArticoli(ds, soloNonCancellati);
            }

            List<Articolo> articoli = new List<Articolo>();
            foreach (ArticoliDS.ARTICOLIRow riga in ds.ARTICOLI)
            {
                ArticoloModel model = CreaModello(riga);
                Articolo articolo = new Articolo();
                articolo._model = model;
                articoli.Add(articolo);
            }
            return articoli;
        }

        public static List<Articolo> EstraiListaArticoli(string anagrafica, bool soloNonCancellati)
        {
            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                bArticolo.FillArticoli(anagrafica, ds, soloNonCancellati);
            }

            List<Articolo> articoli = new List<Articolo>();
            foreach (ArticoliDS.ARTICOLIRow riga in ds.ARTICOLI)
            {
                ArticoloModel model = CreaModello(riga);
                Articolo articolo = new Articolo();
                articolo._model = model;
                articoli.Add(articolo);
            }
            return articoli;
        }

        private static ArticoloModel CreaModello(ArticoliDS.ARTICOLIRow riga)
        {

            if (riga == null) return null;
            ArticoloModel model = new ArticoloModel();
            model.IdArticolo = riga.IDARTICOLO;
            model.Brand = Brand.EstraiBrand(riga.IDBRAND).Model;
            model.Descrizione = riga.DESCRIZIONE;
            model.CodiceCliente = riga.IsCODICECLIENTENull() ? string.Empty : riga.CODICECLIENTE;
            model.Colore = riga.IsCOLORENull() ? string.Empty : riga.COLORE;
            model.Anagrafica = riga.IsANAGRAFICANull() ? string.Empty : riga.ANAGRAFICA;

            model.Cancellato = riga.CANCELLATO;
            model.DataModifica = riga.DATAMODIFICA;
            model.Descrizione = riga.DESCRIZIONE;
            model.UtenteModifica = riga.UTENTEMODIFICA;

            return model;
        }


        public static string CreaArticolo(int idBrand, string anagrafica, string descrizione, string codiceCliente, string codiceColore, string account)
        {
            Brand brand = Brand.EstraiBrand(idBrand);
            if (brand == null) return "Brand non valido";

            Articolo articolo = Articolo.EstraiArticolo(anagrafica);
            if (articolo != null)
                return "Esiste già un articolo con questa anagrafica";

            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                ArticoliDS.ARTICOLIRow articolonuovo = ds.ARTICOLI.NewARTICOLIRow();
                articolonuovo.IDBRAND = idBrand;
                articolonuovo.DESCRIZIONE = descrizione;
                articolonuovo.CANCELLATO = false;
                articolonuovo.DATAMODIFICA = DateTime.Now;
                articolonuovo.UTENTEMODIFICA = account;

                if (!string.IsNullOrEmpty(anagrafica))
                    articolonuovo.ANAGRAFICA = anagrafica;
                if (!string.IsNullOrEmpty(codiceCliente))
                    articolonuovo.CODICECLIENTE = codiceCliente;
                if (!string.IsNullOrEmpty(codiceColore))
                    articolonuovo.COLORE = codiceColore;

                ds.ARTICOLI.AddARTICOLIRow(articolonuovo);
                bArticolo.UpdateTable(ds.ARTICOLI.TableName, ds);
            }
            return "Articolo creato correttamente";
        }
     
    }

}
