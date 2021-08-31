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
    public class SpScheda : BaseModel
    {
        public int IdSPScheda { get; set; }
        public int IdSPMaster { get; set; }
        public string Codice { get; set; }
        public string Descrizione { get; set; }
        public string Anagrafica { get; set; }
        public int IdBrand { get; set; }
        public string AreaProduzione { get; set; }
        public string Task { get; set; }



        public static List<SpScheda> EstraiListaSPScheda(bool soloNonCancellati)
        {
            SchedeProcessoDS ds = new SchedeProcessoDS();
            using (SchedeProcessoBusiness bScheda = new SchedeProcessoBusiness())
            {
                bScheda.FillSPScheda(ds, soloNonCancellati);
            }

            List<SpScheda> schedas = new List<SpScheda>();
            foreach (SchedeProcessoDS.SPSCHEDERow riga in ds.SPSCHEDE)
            {
                SpScheda scheda = CreaScheda(riga, ds);
                schedas.Add(scheda);
            }
            return schedas;

        }
        public static List<SpScheda> EstraiListaScheda(string IDSPMaster, bool soloNonCancellati)
        {
            SchedeProcessoDS ds = new SchedeProcessoDS();
            using (SchedeProcessoBusiness bScheda = new SchedeProcessoBusiness())
            {
                bScheda.FillSPScheda(IDSPMaster, ds, soloNonCancellati);
            }

            List<SpScheda> schede = new List<SpScheda>();
            foreach (SchedeProcessoDS.SPSCHEDERow riga in ds.SPSCHEDE)
            {
                SpScheda scheda = CreaScheda(riga, ds);
                schede.Add(scheda);
            }
            return schede;

        }
        public override string ToString()
        {
            return Codice + " - " + Descrizione;
        }
        private static SpScheda CreaScheda(SchedeProcessoDS.SPSCHEDERow riga, SchedeProcessoDS ds)
        {
            if (riga == null) return null;
            SpScheda controllo = new SpScheda();
            controllo.IdSPMaster = riga.IDSPMASTER;
            controllo.Codice = riga.CODICE;
            controllo.Descrizione = riga.DESCRIZIONE;
            controllo.IdBrand = riga.IDBRAND;
            controllo.Anagrafica = riga.ANAGRAFICA;
            controllo.AreaProduzione = riga.AREAPRODUZIONE;
            controllo.Task = riga.TASK;
            controllo.Cancellato = riga.CANCELLATO;
            controllo.DataModifica = riga.DATAMODIFICA;
            controllo.Descrizione = riga.DESCRIZIONE;
            controllo.UtenteModifica = riga.UTENTEMODIFICA;

            return controllo;
        }

        public static SpScheda EstraiSPScheda(int idScheda)
        {
            SchedeProcessoDS ds = new SchedeProcessoDS();
            using (SchedeProcessoBusiness bScheda = new SchedeProcessoBusiness())
            {
                bScheda.GetSPScheda(idScheda, ds);
            }
            return CreaScheda(ds.SPSCHEDE.Where(x => x.IDSPSCHEDA == idScheda).FirstOrDefault(), ds);
        }

        public static string SalvaScheda(int idScheda, int IdSPMaster, string anagrafica, int IdBrand, string codice, string descrizione, string areaProduzione, string task, string account)
        {

            SchedeProcessoDS ds = new SchedeProcessoDS();
            using (SchedeProcessoBusiness bScheda = new SchedeProcessoBusiness())
            {
                bScheda.GetSPScheda(ds, idScheda);

                SchedeProcessoDS.SPSCHEDERow riga = ds.SPSCHEDE.Where(x => x.IDSPMASTER == idScheda).FirstOrDefault();


                if (riga != null)
                {
                    riga.CODICE = codice.ToUpper();
                    riga.DESCRIZIONE = descrizione.ToUpper();
                    riga.IDBRAND = IdBrand;
                    riga.ANAGRAFICA = anagrafica.ToUpper();
                    riga.DATAMODIFICA = DateTime.Now;
                    riga.UTENTEMODIFICA = account;
                }
                else
                {
                    riga = ds.SPSCHEDE.NewSPSCHEDERow();
                    riga.CODICE = codice.ToUpper();
                    riga.DESCRIZIONE = descrizione.ToUpper();
                    riga.IDSPMASTER = IdSPMaster;
                    riga.AREAPRODUZIONE = areaProduzione.ToUpper();
                    riga.TASK = task.ToUpper();
                    riga.IDBRAND = IdBrand;
                    riga.ANAGRAFICA = anagrafica.ToUpper();
                    riga.CANCELLATO = false;
                    riga.DATAMODIFICA = DateTime.Now;
                    riga.UTENTEMODIFICA = account.ToUpper();
                    ds.SPSCHEDE.AddSPSCHEDERow(riga);
                }

                bScheda.UpdateTableSPScheda(ds);

                return "Scheda creata correttamente";
            }
        }
    }
}






