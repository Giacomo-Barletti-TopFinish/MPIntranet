using MPIntranet.DataAccess.SchedeProcesso;
using MPIntranet.Entities;
using MPIntranet.Models;
using MPIntranet.Models.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business.SchedeProcesso
{
    public class SPElementoLista : BaseModel
    {
        public int IdSPElementoLista { get; set; }
        public string Codice { get; set; }
        public string Descrizione { get; set; }
        public int Sequenza { get; set; }
        public bool Default { get; set; }


        public static List<SPElementoLista> EstraiListaSPElementiLista(int IdSPControllo, bool soloNonCancellati, SchedeProcessoDS ds)
        {
            using (SchedeProcessoBusiness bScheda = new SchedeProcessoBusiness())
            {
                bScheda.FillElementiLista(ds, IdSPControllo, soloNonCancellati);
            }

            List<SPElementoLista> controlli = new List<SPElementoLista>();
            foreach (SchedeProcessoDS.SPELEMENTILISTARow riga in ds.SPELEMENTILISTA)
            {
                SPElementoLista controelementolo = CreaElementoLista(riga);
                controlli.Add(controelementolo);
            }
            return controlli;

        }

        private static SPElementoLista CreaElementoLista(SchedeProcessoDS.SPELEMENTILISTARow riga)
        {
            if (riga == null) return null;
            SPElementoLista controllo = new SPElementoLista();
            controllo.IdSPElementoLista = riga.IDSPELEMENTOLISTA;
            controllo.Codice = riga.CODICE;
            controllo.Descrizione = riga.DESCRIZIONE;
            controllo.Sequenza = riga.SEQUENZA;
            controllo.Default = riga.IsDEFAULTNull() ? false : riga.DEFAULT;

            controllo.Cancellato = riga.CANCELLATO;
            controllo.DataModifica = riga.DATAMODIFICA;
            controllo.UtenteModifica = riga.UTENTEMODIFICA;

            return controllo;
        }

        public override string ToString()
        {
            return Codice + " - " + Descrizione;
        }

        public static SPElementoLista EstraiSPElementoLista(int idElementoLista)
        {
            SchedeProcessoDS ds = new SchedeProcessoDS();
            using (SchedeProcessoBusiness bScheda = new SchedeProcessoBusiness())
            {
                bScheda.GetElementoLista(ds, idElementoLista);
            }
            SchedeProcessoDS.SPELEMENTILISTARow riga = ds.SPELEMENTILISTA.Where(x => x.IDSPELEMENTOLISTA == idElementoLista).FirstOrDefault();
            if (riga == null) return null;

            return CreaElementoLista(riga);
        }

        public static void SalvaElemento(int idElemento, int idControllo, string codice, string descrizione, int sequenza, string account,SchedeProcessoDS ds)
        {
            using (SchedeProcessoBusiness bScheda = new SchedeProcessoBusiness())
            {
                bScheda.GetElementoLista(ds, idElemento);

                SchedeProcessoDS.SPELEMENTILISTARow riga = ds.SPELEMENTILISTA.Where(x => x.IDSPELEMENTOLISTA == idElemento).FirstOrDefault();
                if(idElemento<0 && riga !=null)
                {
                    while(riga !=null)
                    {
                        idElemento--;
                        riga = ds.SPELEMENTILISTA.Where(x => x.IDSPELEMENTOLISTA == idElemento).FirstOrDefault();
                    }
                }
                if (riga != null)
                {
                    riga.CODICE = codice.ToUpper();
                    riga.DESCRIZIONE = descrizione.ToUpper();
                    riga.SEQUENZA = sequenza;
                    riga.DATAMODIFICA = DateTime.Now;
                    riga.UTENTEMODIFICA = account;
                }
                else
                {
                    riga = ds.SPELEMENTILISTA.NewSPELEMENTILISTARow();
                    riga.CODICE = codice.ToUpper();
                    riga.DESCRIZIONE = descrizione.ToUpper();
                    riga.IDSPCONTROLLO = idControllo;
                    riga.SEQUENZA = sequenza;
                    riga.CANCELLATO = false;
                    riga.DATAMODIFICA = DateTime.Now;
                    riga.UTENTEMODIFICA = account.ToUpper();
                    ds.SPELEMENTILISTA.AddSPELEMENTILISTARow(riga);
                }

            }
        }
        public static void SalvaElemento(int idElemento, int idControllo,string codice, string descrizione, int sequenza, string account)
        {

            SchedeProcessoDS ds = new SchedeProcessoDS();
            SalvaElemento(idElemento, idControllo, codice, descrizione, sequenza, account, ds);
        }

    }
}
