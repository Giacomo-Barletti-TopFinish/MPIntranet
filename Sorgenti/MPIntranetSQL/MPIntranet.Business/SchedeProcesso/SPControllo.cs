using MPIntranet.DataAccess.SchedeProcesso;
using MPIntranet.Entities;
using MPIntranet.Models;
using MPIntranet.Models.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business.SchedeProcesso
{

    public class TipoSPControllo
    {
        public const string NUMERO = "NUMERO";
        public const string TESTO = "TESTO";
        public const string DATA = "DATA";
        public const string CHECKBOX = "CHECKBOX";
        public const string LISTA = "LISTA";
        public const string IMMAGINE = "IMMAGINE";
    }

    public class SPControllo : BaseModel
    {
        public int IdSPControllo { get; set; }
        public string Codice { get; set; }
        public string Descrizione { get; set; }
        public string Tipo { get; set; }
        public double Minimo { get; set; }
        public double Massimo { get; set; }
        public double Default { get; set; }

        public List<SPElementoLista> Elementi = new List<SPElementoLista>();

        public static List<SPControllo> EstraiListaSPControlli(bool soloNonCancellati)
        {
            SchedeProcessoDS ds = new SchedeProcessoDS();
            using (SchedeProcessoBusiness bScheda = new SchedeProcessoBusiness())
            {
                bScheda.FillSPControlli(ds, soloNonCancellati);
            }

            List<SPControllo> controlli = new List<SPControllo>();
            foreach (SchedeProcessoDS.SPCONTROLLIRow riga in ds.SPCONTROLLI)
            {
                SPControllo controllo = CreaControllo(riga, ds);
                controlli.Add(controllo);
            }
            return controlli;

        }

        private static SPControllo CreaControllo(SchedeProcessoDS.SPCONTROLLIRow riga, SchedeProcessoDS ds)
        {
            if (riga == null) return null;
            SPControllo controllo = new SPControllo();
            controllo.IdSPControllo = riga.IDSPCONTROLLO;
            controllo.Codice = riga.CODICE;
            controllo.Descrizione = riga.DESCRIZIONE;
            controllo.Tipo = riga.TIPO;
            controllo.Minimo = riga.IsMINIMONull() ? 0 : riga.MINIMO;
            controllo.Massimo = riga.IsMASSIMONull() ? 0 : riga.MASSIMO;
            controllo.Default = riga.IsDEFAULTNull() ? 0 : riga.DEFAULT;

            controllo.Cancellato = riga.CANCELLATO;
            controllo.DataModifica = riga.DATAMODIFICA;
            controllo.Descrizione = riga.DESCRIZIONE;
            controllo.UtenteModifica = riga.UTENTEMODIFICA;

            controllo.Elementi = SPElementoLista.EstraiListaSPElementiLista(riga.IDSPCONTROLLO, true, ds);

            return controllo;
        }

        public override string ToString()
        {
            return Codice + " - " + Descrizione;
        }

        public static SPControllo EstraiSPControllo(int idControllo)
        {
            SchedeProcessoDS ds = new SchedeProcessoDS();
            using (SchedeProcessoBusiness bScheda = new SchedeProcessoBusiness())
            {
                bScheda.GetControllo(ds, idControllo);
            }

            SchedeProcessoDS.SPCONTROLLIRow riga = ds.SPCONTROLLI.FirstOrDefault();
            if (riga == null) return null;

            return CreaControllo(riga, ds);
        }

        public static string SalvaControllo(int idControllo, string codice, string descrizione, string tipo, double minimo, double massimo, double Default, ElementoLista[] lista, string account)
        {

            SchedeProcessoDS ds = new SchedeProcessoDS();
            using (SchedeProcessoBusiness bScheda = new SchedeProcessoBusiness())
            {
                bScheda.GetControllo(ds, idControllo);

                SchedeProcessoDS.SPCONTROLLIRow riga = ds.SPCONTROLLI.Where(x => x.IDSPCONTROLLO == idControllo).FirstOrDefault();

                if (riga != null)
                {
                    riga.CODICE = codice.ToUpper();
                    riga.DESCRIZIONE = descrizione.ToUpper();
                    riga.TIPO = tipo.ToUpper();
                    riga.MINIMO = minimo;
                    riga.MASSIMO = massimo;
                    riga.DEFAULT = Default;
                    riga.DATAMODIFICA = DateTime.Now;
                    riga.UTENTEMODIFICA = account;
                }
                else
                {
                    riga = ds.SPCONTROLLI.NewSPCONTROLLIRow();
                    riga.CODICE = codice.ToUpper();
                    riga.DESCRIZIONE = descrizione.ToUpper();
                    riga.MINIMO = minimo;
                    riga.TIPO = tipo.ToUpper();
                    riga.MASSIMO = massimo;
                    riga.DEFAULT = Default;
                    riga.CANCELLATO = false;
                    riga.DATAMODIFICA = DateTime.Now;
                    riga.UTENTEMODIFICA = account.ToUpper();
                    ds.SPCONTROLLI.AddSPCONTROLLIRow(riga);
                }

                if (tipo == TipoSPControllo.LISTA)
                {
                    foreach (ElementoLista elemento in lista)
                    {
                        int sequenza = 1;
                        if (!string.IsNullOrEmpty(elemento.Sequenza))
                            Int32.TryParse(elemento.Sequenza, out sequenza);
                        SPElementoLista.SalvaElemento(elemento.IDElemento, riga.IDSPCONTROLLO, elemento.Codice, elemento.Descrizione, sequenza, account, ds);
                    }
                }

                bScheda.UpdateTableSPControlli(ds);
                bScheda.UpdateTable(ds.SPELEMENTILISTA.TableName, ds);


            }
            return "Controllo creato correttamente";
        }
    }
}
