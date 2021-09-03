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
    public class SPValoreScheda : BaseModel
    {
        public int IdSPValoreScheda { get; set; }
        public int IdSPElemento { get; set; }
        public int IdSPScheda { get; set; }
        public string Codice { get; set; }
        public string Descrizione { get; set; }
        public String Tipo { get; set; }
        public string Valore { get; set; }

        public static List<SPValoreScheda> EstraiListaSPValoreScheda(int IdSPScheda, bool soloNonCancellati, SchedeProcessoDS ds)
        {
            using (SchedeProcessoBusiness bScheda = new SchedeProcessoBusiness())
            {
                bScheda.FillValoriSchede(ds, IdSPScheda, soloNonCancellati);
            }

            List<SPValoreScheda> valori = new List<SPValoreScheda>();
            foreach (SchedeProcessoDS.SPVALORISCHEDERow riga in ds.SPVALORISCHEDE)
            {
                SPValoreScheda elemento = CreaValoreScheda(riga);
                valori.Add(elemento);
            }
            return valori;

        }

        private static SPValoreScheda CreaValoreScheda(SchedeProcessoDS.SPVALORISCHEDERow riga)
        {
            if (riga == null) return null;
            SPValoreScheda elemento = new SPValoreScheda();
            elemento.IdSPValoreScheda = riga.IDSPVALORESCHEDA;
            elemento.IdSPElemento = riga.IDSPELEMENTO;
            elemento.IdSPScheda = riga.IDSPSCHEDA;
            elemento.Codice = riga.IsCODICENull() ? string.Empty : riga.CODICE;
            elemento.Descrizione = riga.IsDESCRIZIONENull() ? string.Empty : riga.DESCRIZIONE;
            elemento.Tipo = riga.IsTIPONull() ? string.Empty : riga.TIPO;
            string valore = riga.IsVALORETNull() ? string.Empty : riga.VALORET;
            if (!riga.IsVALOREDNull()) valore = riga.VALORED.ToShortDateString();
            if (!riga.IsVALORENNull()) valore = riga.VALOREN.ToString();

            elemento.Valore = valore;

            elemento.Cancellato = riga.CANCELLATO;
            elemento.DataModifica = riga.DATAMODIFICA;
            elemento.UtenteModifica = riga.UTENTEMODIFICA;

            return elemento;
        }
        public static void SalvaValoreScheda(int idValoreScheda, int idElemento, int idSPScheda, string valore, string account)
        {
            SchedeProcessoDS ds = new SchedeProcessoDS();
            SalvaValoreScheda(idValoreScheda, idElemento, idSPScheda, valore, account, ds);
        }

        public static void SalvaValoreScheda(int idValoreScheda, int idElemento, int idSPScheda, string valore, string account, SchedeProcessoDS ds)
        {

            using (SchedeProcessoBusiness bScheda = new SchedeProcessoBusiness())
            {

                if (!ds.SPVALORISCHEDE.Any(x => x.IDSPVALORESCHEDA == idValoreScheda))
                    bScheda.GetValoreScheda(ds, idValoreScheda);

                SchedeProcessoDS.SPVALORISCHEDERow riga = ds.SPVALORISCHEDE.Where(x => x.IDSPVALORESCHEDA == idValoreScheda).FirstOrDefault();
                if (idValoreScheda < 0 && riga != null)
                {
                    while (riga != null)
                    {
                        idValoreScheda--;
                        riga = ds.SPVALORISCHEDE.Where(x => x.IDSPVALORESCHEDA == idValoreScheda).FirstOrDefault();
                    }
                }
                if (riga != null)
                {

                    riga.VALORET = valore.ToUpper();
                    riga.DATAMODIFICA = DateTime.Now;
                    riga.UTENTEMODIFICA = account;
                }
                else
                {
                    riga = ds.SPVALORISCHEDE.NewSPVALORISCHEDERow();
                    riga.IDSPSCHEDA= idSPScheda;
                    riga.IDSPELEMENTO= idElemento;
                    riga.VALORET = valore.ToUpper();

                    riga.CANCELLATO = false;
                    riga.DATAMODIFICA = DateTime.Now;
                    riga.UTENTEMODIFICA = account.ToUpper();
                    ds.SPVALORISCHEDE.AddSPVALORISCHEDERow(riga);
                }

            }
        }
    }
}