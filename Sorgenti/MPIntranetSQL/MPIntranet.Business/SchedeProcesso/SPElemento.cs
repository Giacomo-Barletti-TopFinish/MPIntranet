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
    public class SPElemento : BaseModel
    {

        public int IdSPElemento { get; set; }
        public int IdSPControllo { get; set; }
        public int IdSPMaster { get; set; }
        public string Testo { get; set; }
        public string Tipo { get; set; }
        public int Sequenza { get; set; }
        public bool Obbligatorio { get; set; }
        public SPControllo Controllo { get; set; }
        public bool ElementoObbligatorioMaster { get; set; }

        public static List<SPElemento> EstraiListaSPElementi(int IdSPMaster, bool soloNonCancellati, SchedeProcessoDS ds)
        {
            using (SchedeProcessoBusiness bScheda = new SchedeProcessoBusiness())
            {
                ds.SPELEMENTI.Clear();
                bScheda.FillElementi(ds, IdSPMaster, soloNonCancellati);
            }

            List<SPElemento> controlli = new List<SPElemento>();
            foreach (SchedeProcessoDS.SPELEMENTIRow riga in ds.SPELEMENTI)
            {
                SPElemento elemento = CreaElemento(riga);
                controlli.Add(elemento);
            }
            return controlli;

        }
        public static SPElemento EstraiElemento(int IdSPElemento, bool ElementoObbligatorioMaster)
        {
            SchedeProcessoDS ds = new SchedeProcessoDS();
            using (SchedeProcessoBusiness bScheda = new SchedeProcessoBusiness())
            {
                ds.SPELEMENTIOBBLIGATORI.Clear();

                if (ElementoObbligatorioMaster)
                {
                    bScheda.GetElementoObbligatorio(ds, IdSPElemento);
                    SchedeProcessoDS.SPELEMENTIOBBLIGATORIRow riga = ds.SPELEMENTIOBBLIGATORI.Where(x => x.IDSPELEMENTOOBBLIGATORIO == IdSPElemento).FirstOrDefault();
                    if (riga != null)
                        return CreaElementoObbligatorio(riga);
                }
                else
                {
                    bScheda.GetElemento(ds, IdSPElemento);
                    SchedeProcessoDS.SPELEMENTIRow riga = ds.SPELEMENTI.Where(x => x.IDSPELEMENTO == IdSPElemento).FirstOrDefault();
                    if (riga != null)
                        return CreaElemento(riga);
                }
                return null;
            }

        }

        public static List<SPElemento> EstraiListaSPElementiObbligatori(int idSchedaObbligatoria, bool soloNonCancellati)
        {
            SchedeProcessoDS ds = new SchedeProcessoDS();
            using (SchedeProcessoBusiness bScheda = new SchedeProcessoBusiness())
            {
                ds.SPELEMENTIOBBLIGATORI.Clear();
                bScheda.FillElementiObbligatori(ds, idSchedaObbligatoria, soloNonCancellati);
            }

            List<SPElemento> controlli = new List<SPElemento>();
            foreach (SchedeProcessoDS.SPELEMENTIOBBLIGATORIRow riga in ds.SPELEMENTIOBBLIGATORI)
            {
                SPElemento elemento = CreaElementoObbligatorio(riga);
                controlli.Add(elemento);
            }
            return controlli;

        }
        private static SPElemento CreaElemento(SchedeProcessoDS.SPELEMENTIRow riga)
        {
            if (riga == null) return null;
            SPElemento elemento = new SPElemento();
            elemento.IdSPElemento = riga.IDSPELEMENTO;
            elemento.IdSPControllo = riga.IsIDSPCONTROLLONull() ? -1 : riga.IDSPCONTROLLO;
            elemento.IdSPMaster = riga.IDSPMASTER;
            elemento.Testo = riga.IsTESTONull() ? string.Empty : riga.TESTO;
            elemento.Tipo = riga.TIPOELEMENTO;
            elemento.Sequenza = riga.SEQUENZA;
            elemento.Obbligatorio = riga.IsOBBLIGATORIONull() ? false : riga.OBBLIGATORIO;
            elemento.ElementoObbligatorioMaster = false;
            elemento.Cancellato = riga.CANCELLATO;
            elemento.DataModifica = riga.DATAMODIFICA;
            elemento.UtenteModifica = riga.UTENTEMODIFICA;

            if (elemento.Tipo == TipoSPElemento.CONTROLLO)
                elemento.Controllo = SPControllo.EstraiSPControllo(elemento.IdSPControllo);

            return elemento;
        }
        private static SPElemento CreaElementoObbligatorio(SchedeProcessoDS.SPELEMENTIOBBLIGATORIRow riga)
        {
            if (riga == null) return null;
            SPElemento elemento = new SPElemento();
            elemento.IdSPElemento = riga.IDSPELEMENTOOBBLIGATORIO;
            elemento.IdSPControllo = riga.IsIDSPCONTROLLONull() ? -1 : riga.IDSPCONTROLLO;
            elemento.IdSPMaster = -1;
            elemento.Testo = riga.IsTESTONull() ? string.Empty : riga.TESTO;
            elemento.Tipo = riga.TIPOELEMENTO;
            elemento.Sequenza = riga.SEQUENZA;
            elemento.Obbligatorio = riga.IsOBBLIGATORIONull() ? false : riga.OBBLIGATORIO;
            elemento.ElementoObbligatorioMaster = true;
            elemento.Cancellato = riga.CANCELLATO;
            elemento.DataModifica = riga.DATAMODIFICA;
            elemento.UtenteModifica = riga.UTENTEMODIFICA;

            if (elemento.Tipo == TipoSPElemento.CONTROLLO)
                elemento.Controllo = SPControllo.EstraiSPControllo(elemento.IdSPControllo);

            return elemento;
        }
        public override string ToString()
        {
            return Testo;
        }

        public static void SalvaElemento(int idElemento, int idControllo, int idSPMaster, string testo, string tipo, bool obbligatorio, int sequenza, string account)
        {

            SchedeProcessoDS ds = new SchedeProcessoDS();
            SalvaElemento(idElemento, idControllo, idSPMaster, testo, tipo, obbligatorio, sequenza, account, ds);
        }

        public static void SalvaElemento(int idElemento, int idControllo, int idSPMaster, string testo, string tipo, bool obbligatorio, int sequenza, string account, SchedeProcessoDS ds)
        {

            if (testo.Length > 25) testo = testo.Substring(0, 25);

            using (SchedeProcessoBusiness bScheda = new SchedeProcessoBusiness())
            {

                if (!ds.SPELEMENTI.Any(x => x.IDSPELEMENTO == idElemento))
                    bScheda.GetElemento(ds, idElemento);

                SchedeProcessoDS.SPELEMENTIRow riga = ds.SPELEMENTI.Where(x => x.IDSPELEMENTO == idElemento).FirstOrDefault();
                if (idElemento < 0 && riga != null)
                {
                    while (riga != null)
                    {
                        idElemento--;
                        riga = ds.SPELEMENTI.Where(x => x.IDSPELEMENTO == idElemento).FirstOrDefault();
                    }
                }
                if (riga != null)
                {
                    riga.OBBLIGATORIO = obbligatorio;
                    riga.TIPOELEMENTO = tipo;
                    if (tipo == TipoSPElemento.CONTROLLO)
                        riga.IDSPCONTROLLO = idControllo;
                    riga.TESTO = testo;
                    riga.SEQUENZA = sequenza;
                    riga.DATAMODIFICA = DateTime.Now;
                    riga.UTENTEMODIFICA = account;
                }
                else
                {
                    riga = ds.SPELEMENTI.NewSPELEMENTIRow();
                    riga.IDSPMASTER = idSPMaster;
                    riga.IDSPELEMENTO = idElemento;
                    riga.OBBLIGATORIO = obbligatorio;
                    riga.TESTO = testo;
                    riga.TIPOELEMENTO = tipo;
                    if (tipo == TipoSPElemento.CONTROLLO)
                        riga.IDSPCONTROLLO = idControllo;
                    riga.SEQUENZA = sequenza;
                    riga.CANCELLATO = false;
                    riga.DATAMODIFICA = DateTime.Now;
                    riga.UTENTEMODIFICA = account.ToUpper();
                    ds.SPELEMENTI.AddSPELEMENTIRow(riga);
                }

            }
        }

    }
}
