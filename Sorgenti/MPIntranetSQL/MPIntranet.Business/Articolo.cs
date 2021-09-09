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
    public class Articolo : BaseModel
    {
        public int IdArticolo { get; set; }
        public Brand Brand { get; set; }
        public string Descrizione { get; set; }
        public string Anagrafica { get; set; }
        public string Colore { get; set; }
        public string CodiceCliente { get; set; }
        public override string ToString()
        {
            if (string.IsNullOrEmpty(Anagrafica))
                return Descrizione;
            else
                return string.Format("{0} - {1}", Anagrafica, Descrizione);
        }
        public static Articolo EstraiArticolo(int idArticolo)
        {
            List<Articolo> lista = EstraiListaArticoli(false);
            return lista.Where(x => x.IdArticolo == idArticolo).FirstOrDefault();
        }
        public static Articolo EstraiArticolo(string anagrafica)
        {
            List<Articolo> lista = EstraiListaArticoli(anagrafica, false);
            return lista.Where(x => x.Anagrafica == anagrafica).FirstOrDefault();
        }
        public string CodiceClienteEsteso
        {
            get
            {
                if (string.IsNullOrEmpty(CodiceCliente)) return Brand.Descrizione;
                return string.Format("{0} - {1}", Brand.Descrizione.Trim(), CodiceCliente.Trim());
            }
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
                Articolo articolo = CreaArticolo(riga);
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
                Articolo articolo = CreaArticolo(riga);
                articoli.Add(articolo);
            }
            return articoli;
        }

        private static Articolo CreaArticolo(ArticoliDS.ARTICOLIRow riga)
        {

            if (riga == null) return null;
            Articolo articolo = new Articolo();
            articolo.IdArticolo = riga.IDARTICOLO;
            articolo.Brand = Brand.EstraiBrand(riga.IDBRAND);
            articolo.Descrizione = riga.DESCRIZIONE;
            articolo.CodiceCliente = riga.IsCODICECLIENTENull() ? string.Empty : riga.CODICECLIENTE;
            articolo.Colore = riga.IsCOLORENull() ? string.Empty : riga.COLORE;
            articolo.Anagrafica = riga.IsANAGRAFICANull() ? string.Empty : riga.ANAGRAFICA;

            articolo.Cancellato = riga.CANCELLATO;
            articolo.DataModifica = riga.DATAMODIFICA;
            articolo.Descrizione = riga.DESCRIZIONE;
            articolo.UtenteModifica = riga.UTENTEMODIFICA;

            return articolo;
        }

        public void Cancella()
        {
            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                bArticolo.GetArticolo(ds, IdArticolo);
                ArticoliDS.ARTICOLIRow articoloDs = ds.ARTICOLI.Where(x => x.IDARTICOLO == IdArticolo).FirstOrDefault();
                if (articoloDs != null)
                {
                    this.Cancellato = true;
                    articoloDs.CANCELLATO = true;
                    bArticolo.UpdateTable(ds.ARTICOLI.TableName, ds);
                }
            }
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

        public static List<Articolo> TrovaArticoli(string anagrafica, string descrizione, int idBrand, string codiceCliente, string colore)
        {
            List<Articolo> articoli = new List<Articolo>();
            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                bArticolo.TrovaArticoli(ds, true, idBrand, anagrafica, descrizione, codiceCliente, colore);

                foreach (ArticoliDS.ARTICOLIRow riga in ds.ARTICOLI)
                {
                    Articolo articolo = CreaArticolo(riga);
                    articoli.Add(articolo);
                }
                return articoli;
            }
        }

    }

}
