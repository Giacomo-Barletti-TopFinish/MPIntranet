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
        public const string SESSIONE = "SESSIONE";
        public const string CONTROLLO = "CONTROLLO";
    }
    public class SPMaster : BaseModel
    {
        public int IdSPMaster { get; set; }
        public string Codice { get; set; }
        public string Descrizione { get; set; }
        public string AreaProduzione { get; set; }
        public string Task { get; set; }

        public List<SPElemento> Elementi = new List<SPElemento>();
        public List<SPElemento> ElementiObbligatori = new List<SPElemento>();
        public int IdSchedaObbligatoria { get; set; }


        public static List<SPMaster> EstraiListaSPMaster(bool soloNonCancellati)
        {
            SchedeProcessoDS ds = new SchedeProcessoDS();
            using (SchedeProcessoBusiness bScheda = new SchedeProcessoBusiness())
            {
                bScheda.FillSPMaster(ds, soloNonCancellati);
            }

            List<SPMaster> masters = new List<SPMaster>();
            foreach (SchedeProcessoDS.SPMASTERSRow riga in ds.SPMASTERS)
            {
                SPMaster master = CreaMaster(riga, ds);
                masters.Add(master);
            }
            return masters;

        }

        public static List<SPMaster> EstraiListaSPMaster(string areaProduzione, string task, bool soloNonCancellati)
        {
            SchedeProcessoDS ds = new SchedeProcessoDS();
            using (SchedeProcessoBusiness bScheda = new SchedeProcessoBusiness())
            {
                bScheda.FillSPMaster(areaProduzione, task, ds, soloNonCancellati);
            }

            List<SPMaster> masters = new List<SPMaster>();
            foreach (SchedeProcessoDS.SPMASTERSRow riga in ds.SPMASTERS)
            {
                SPMaster master = CreaMaster(riga, ds);
                masters.Add(master);
            }
            return masters;

        }

        public override string ToString()
        {
            return Codice + " - " + Descrizione;
        }

        private static SPMaster CreaMaster(SchedeProcessoDS.SPMASTERSRow riga, SchedeProcessoDS ds)
        {
            if (riga == null) return null;
            SPMaster master = new SPMaster();
            master.IdSPMaster = riga.IDSPMASTER;
            master.Codice = riga.CODICE;
            master.Descrizione = riga.DESCRIZIONE;
            master.AreaProduzione = riga.AREAPRODUZIONE;
            master.Task = riga.TASK;
            master.IdSchedaObbligatoria = riga.IDSCHEDAOBBLIGATORIA;

            master.Cancellato = riga.CANCELLATO;
            master.DataModifica = riga.DATAMODIFICA;
            master.Descrizione = riga.DESCRIZIONE;
            master.UtenteModifica = riga.UTENTEMODIFICA;

            master.Elementi = SPElemento.EstraiListaSPElementi(riga.IDSPMASTER, true, ds);
            master.ElementiObbligatori = SPElemento.EstraiListaSPElementiObbligatori(riga.IDSCHEDAOBBLIGATORIA, true);

            return master;
        }
        public static SPMaster EstraiSPMaster(int idMaster)
        {

            SchedeProcessoDS ds = new SchedeProcessoDS();
            using (SchedeProcessoBusiness bScheda = new SchedeProcessoBusiness())
            {
                bScheda.GetSPMaster(ds, idMaster);
            }

            SchedeProcessoDS.SPMASTERSRow riga = ds.SPMASTERS.FirstOrDefault();
            if (riga == null) return null;

            return CreaMaster(riga, ds);

        }

        public static string SalvaMaster(int idMaster, string codice, string descrizione, string areaProduzione, string task, ElementoMaster[] elementiLista, string account)
        {
            return SalvaMaster(idMaster, codice, descrizione, areaProduzione, task, elementiLista, account, 1);
        }
        public static string SalvaMaster(int idMaster, string codice, string descrizione, string areaProduzione, string task, ElementoMaster[] elementiLista, string account, int idSchedaObbligatoria)
        {

            SchedeProcessoDS ds = new SchedeProcessoDS();
            using (SchedeProcessoBusiness bScheda = new SchedeProcessoBusiness())
            {
                bScheda.GetSPMaster(ds, idMaster);
                bScheda.FillElementi(ds, idMaster, true);

                SchedeProcessoDS.SPMASTERSRow riga = ds.SPMASTERS.Where(x => x.IDSPMASTER == idMaster).FirstOrDefault();

                if (string.IsNullOrEmpty(codice))
                {
                    int maxIDSPMasyer = bScheda.GetMaxIDSPMaster() + 1;
                    codice = "MA" + maxIDSPMasyer.ToString().PadLeft(ds.SPMASTERS.CODICEColumn.MaxLength - 2, '0');
                }

                if (riga != null)
                {
                    riga.CODICE = codice.ToUpper();
                    riga.DESCRIZIONE = descrizione.ToUpper();
                    riga.AREAPRODUZIONE = areaProduzione.ToUpper();
                    riga.TASK = task.ToUpper();
                    riga.DATAMODIFICA = DateTime.Now;
                    riga.UTENTEMODIFICA = account.ToUpper();
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
                    riga.IDSCHEDAOBBLIGATORIA = idSchedaObbligatoria;
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

                List<int> idControlliObbligatori = SPElemento.EstraiListaSPElementiObbligatori(1, true).Select(x => x.IdSPControllo).Distinct().ToList();
                int sequenza = 0;
                foreach (ElementoMaster elemento in elementiLista)
                {
                    if (!idControlliObbligatori.Contains(elemento.IDControllo))
                    {
                        sequenza++;
                        SPElemento.SalvaElemento(elemento.IDElemento, elemento.IDControllo, riga.IDSPMASTER, elemento.Testo, elemento.Tipo, elemento.Obbligatorio, sequenza, account, ds);
                    }
                }
                bScheda.UpdateTableSPMaster(ds);
                bScheda.UpdateTable(ds.SPELEMENTI.TableName, ds);


            }
            return "Master creato correttamente";
        }
    }
}