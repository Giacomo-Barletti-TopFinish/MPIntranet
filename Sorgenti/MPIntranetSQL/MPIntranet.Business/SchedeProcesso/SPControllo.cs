using MPIntranet.DataAccess.SchedeProcesso;
using MPIntranet.Entities;
using MPIntranet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business.SchedeProcesso
{

    public class TipoSPControllo
    {
        public static readonly string NUMERO = "NUMERO";
        public static readonly string TESTO = "TESTO";
        public static readonly string DATA = "DATA";
        public static readonly string CHECKBOX = "CHECKBOX";
        public static readonly string LISTA = "LISTA";
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
                SPControllo controllo = CreaControllo(riga);
                controlli.Add(controllo);
            }
            return controlli;

        }

        private static SPControllo CreaControllo(SchedeProcessoDS.SPCONTROLLIRow riga)
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

            return controllo;
        }

        public override string ToString()
        {
            return Codice + " - " + Descrizione;
        }

        public static SPControllo EstraiSPControllo(int idControllo)
        {
            List<SPControllo> lista = EstraiListaSPControlli(false);
            return lista.Where(x => x.IdSPControllo == idControllo).FirstOrDefault();
        }

        public static string SalvaControllo(int idControllo, string codice, string descrizione, string Tipo, double Minimo, double Massimo, double Default, string codiceCliente, string codiceColore, string account)
        {

            SchedeProcessoDS ds = new SchedeProcessoDS();
            using (SchedeProcessoBusiness bScheda = new SchedeProcessoBusiness())
            {
                bScheda.GetControllo(ds, idControllo);

                SchedeProcessoDS.SPCONTROLLIRow riga = ds.SPCONTROLLI.Where(x => x.IDSPCONTROLLO == idControllo).FirstOrDefault();

                if (riga != null)
                {
                    riga.CODICE = codice;
                    riga.DESCRIZIONE = descrizione;
                    riga.MINIMO = Minimo;
                    riga.MASSIMO = Massimo;
                    riga.DEFAULT = Default;
                    riga.DATAMODIFICA = DateTime.Now;
                    riga.UTENTEMODIFICA = account;
                }
                else
                {
                    riga = ds.SPCONTROLLI.NewSPCONTROLLIRow();
                    riga.CODICE = codice;
                    riga.DESCRIZIONE = descrizione;
                    riga.MINIMO = Minimo;
                    riga.MASSIMO = Massimo;
                    riga.DEFAULT = Default;
                    riga.CANCELLATO = false;
                    riga.DATAMODIFICA = DateTime.Now;
                    riga.UTENTEMODIFICA = account;
                    ds.SPCONTROLLI.AddSPCONTROLLIRow(riga);
                }

                bScheda.UpdateTable(ds.SPCONTROLLI.TableName, ds);
            }
            return "Controllo creato correttamente";
        }
    }
}
