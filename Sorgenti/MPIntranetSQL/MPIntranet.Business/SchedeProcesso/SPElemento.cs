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


        public static List<SPElemento> EstraiListaSPElementi(int IdSPMaster, bool soloNonCancellati, SchedeProcessoDS ds)
        {
            using (SchedeProcessoBusiness bScheda = new SchedeProcessoBusiness())
            {
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

        private static SPElemento CreaElemento(SchedeProcessoDS.SPELEMENTIRow riga)
        {
            if (riga == null) return null;
            SPElemento controllo = new SPElemento();
            controllo.IdSPElemento = riga.IDSPELEMENTO;
            controllo.IdSPControllo = riga.IsIDSPCONTROLLONull() ? -1 : riga.IDSPCONTROLLO;
            controllo.IdSPMaster = riga.IDSPMASTER;
            controllo.Testo = riga.IsTESTONull() ? string.Empty : riga.TESTO;
            controllo.Tipo = riga.TIPOELEMENTO;
            controllo.Sequenza = riga.SEQUENZA;
            controllo.Obbligatorio = riga.IsOBBLIGATORIONull() ? false : riga.OBBLIGATORIO;

            controllo.Cancellato = riga.CANCELLATO;
            controllo.DataModifica = riga.DATAMODIFICA;
            controllo.UtenteModifica = riga.UTENTEMODIFICA;

            return controllo;
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
