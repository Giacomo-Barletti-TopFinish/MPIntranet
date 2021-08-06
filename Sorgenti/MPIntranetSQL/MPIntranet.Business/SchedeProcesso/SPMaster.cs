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
    public class TipoSPElemento
    {
        public static readonly string SESSIONE = "SESSIONE";
        public static readonly string CONTROLLO = "CONTROLLO";
    }
    public class SPMasters : BaseModel
    {
        public int IdSPMaster { get; set; }
        public string Codice { get; set; }
        public string Descrizione { get; set; }
        public string AreaProduzione { get; set; }
        public string Task { get; set; }

        public List<SPElemento> Elementi = new List<SPElemento>();


        public static List<SPMasters> EstraiListaSPMaster(bool soloNonCancellati)
        {
            SchedeProcessoDS ds = new SchedeProcessoDS();
            using (SchedeProcessoBusiness bScheda = new SchedeProcessoBusiness())
            {
                bScheda.FillSPMaster(ds, soloNonCancellati);
            }

            List<SPMasters> masters = new List<SPMasters>();
            foreach (SchedeProcessoDS.SPMASTERSRow riga in ds.SPMASTERS)
            {
                SPMasters master = CreaMaster(riga, ds);
                masters.Add(master);
            }
            return masters;

        }

        public static List<SPMasters> EstraiListaSPMaster(string areaProduzione, string task, bool soloNonCancellati)
        {
            SchedeProcessoDS ds = new SchedeProcessoDS();
            using (SchedeProcessoBusiness bScheda = new SchedeProcessoBusiness())
            {
                bScheda.FillSPMaster(areaProduzione, task, ds, soloNonCancellati);
            }

            List<SPMasters> masters = new List<SPMasters>();
            foreach (SchedeProcessoDS.SPMASTERSRow riga in ds.SPMASTERS)
            {
                SPMasters master = CreaMaster(riga, ds);
                masters.Add(master);
            }
            return masters;

        }

        public override string ToString()
        {
            return Codice + " - " + Descrizione;
        }

        private static SPMasters CreaMaster(SchedeProcessoDS.SPMASTERSRow riga, SchedeProcessoDS ds)
        {
            if (riga == null) return null;
            SPMasters controllo = new SPMasters();
            controllo.IdSPMaster = riga.IDSPMASTER;
            controllo.Codice = riga.CODICE;
            controllo.Descrizione = riga.DESCRIZIONE;
            controllo.AreaProduzione = riga.AREAPRODUZIONE;
            controllo.Task = riga.TASK;

            controllo.Cancellato = riga.CANCELLATO;
            controllo.DataModifica = riga.DATAMODIFICA;
            controllo.Descrizione = riga.DESCRIZIONE;
            controllo.UtenteModifica = riga.UTENTEMODIFICA;

            controllo.Elementi = SPElemento.EstraiListaSPElementi(riga.IDSPMASTER, true, ds);

            return controllo;
        }
        public static SPMasters EstraiSPMaster(int idMaster)
        {
            List<SPMasters> lista = EstraiListaSPMaster(false);
            return lista.Where(x => x.IdSPMaster == idMaster).FirstOrDefault();
        }

        public static string SalvaMaster(int idMaster, string codice, string descrizione, string areaProduzione, string task, ElementoMaster[] elementiLista, string account)
        {

            SchedeProcessoDS ds = new SchedeProcessoDS();
            using (SchedeProcessoBusiness bScheda = new SchedeProcessoBusiness())
            {
                bScheda.GetSPMaster(ds, idMaster);
                bScheda.FillElementi(ds, idMaster, true);

                SchedeProcessoDS.SPMASTERSRow riga = ds.SPMASTERS.Where(x => x.IDSPMASTER == idMaster).FirstOrDefault();

                if (riga != null)
                {
                    riga.CODICE = codice.ToUpper();
                    riga.DESCRIZIONE = descrizione.ToUpper();
                    riga.AREAPRODUZIONE = areaProduzione.ToUpper();
                    riga.TASK = task.ToUpper();
                    riga.DATAMODIFICA = DateTime.Now;
                    riga.UTENTEMODIFICA = account;
                }
                else
                {
                    riga = ds.SPMASTERS.NewSPMASTERSRow();
                    riga.CODICE = codice.ToUpper();
                    riga.DESCRIZIONE = descrizione.ToUpper();
                    riga.AREAPRODUZIONE = areaProduzione.ToUpper();
                    riga.TASK = task.ToUpper();
                    riga.CANCELLATO = false;
                    riga.DATAMODIFICA = DateTime.Now;
                    riga.UTENTEMODIFICA = account.ToUpper();
                    ds.SPMASTERS.AddSPMASTERSRow(riga);
                }

                if (idMaster > 0)
                {
                    List<int> listaIdElementi = elementiLista.Where(x => x.IDElemento > 0).Select(x => x.IDElemento).Distinct().ToList();
                    foreach (SchedeProcessoDS.SPELEMENTIRow elemento in ds.SPELEMENTI)
                    {
                        if (!listaIdElementi.Contains(elemento.IDSPELEMENTO))
                        {
                            elemento.CANCELLATO = true;
                            elemento.DATAMODIFICA = DateTime.Now;
                            elemento.UTENTEMODIFICA = account;
                        }
                    }
                }

                int sequenza = 0;
                foreach (ElementoMaster elemento in elementiLista)
                {
                    sequenza++;

                    SPElemento.SalvaElemento(elemento.IDElemento, elemento.IDControllo, riga.IDSPMASTER, elemento.Testo, elemento.Tipo, elemento.Obbligatorio, sequenza, account, ds);
                }

                bScheda.UpdateTableSPMaster(ds);
                bScheda.UpdateTable(ds.SPELEMENTI.TableName, ds);


            }
            return "Master creato correttamente";
        }
    }
}