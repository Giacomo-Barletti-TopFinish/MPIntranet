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
        public string Codice { get; set; }
        public string Descrizione { get; set; }
        public string Anagrafica { get; set; }
        public string AreaProduzione { get; set; }
        public string Task { get; set; }
        public Brand Brand { get; set; }
        public SPMaster Master { get; set; }

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
        public static List<SpScheda> TrovaSchede(string Codice, string Descrizione, int idBrand, string Anagrafica)
        {
            SchedeProcessoDS ds = new SchedeProcessoDS();
            using (SchedeProcessoBusiness bScheda = new SchedeProcessoBusiness())
            {
                bScheda.TrovaScheda(Codice, Descrizione, idBrand, Anagrafica, ds, true);
            }
            List<SpScheda> schede = new List<SpScheda>();
            foreach (SchedeProcessoDS.SPSCHEDERow riga in ds.SPSCHEDE)
            {
                SpScheda scheda = CreaScheda(riga, ds);
                schede.Add(scheda);
            }
            return schede;
        }

        public static List<SpScheda> EstraiListaSPScheda(string IDSPMaster, bool soloNonCancellati)
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
            controllo.Master = SPMaster.EstraiSPMaster(riga.IDSPMASTER);
            controllo.Codice = riga.CODICE;
            controllo.Descrizione = riga.DESCRIZIONE;
            controllo.Brand = Brand.EstraiBrand(riga.IDBRAND);
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

        public static string SalvaScheda(int idScheda, int IdSPMaster, string anagrafica, int IdBrand, string codice, string descrizione, string areaProduzione, string task, List<ElementoScheda> controlli, string account)
        {

            SchedeProcessoDS ds = new SchedeProcessoDS();
            using (SchedeProcessoBusiness bScheda = new SchedeProcessoBusiness())
            {
                bScheda.GetSPScheda(ds, idScheda);
                bScheda.FillValoriSchede(ds, idScheda, true);

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

                if (idScheda > 0)
                {
                    List<int> listaIdValori = controlli.Where(x => x.IDElemento > 0).Select(x => x.IDElemento).Distinct().ToList();
                    foreach (SchedeProcessoDS.SPVALORISCHEDERow elemento in ds.SPVALORISCHEDE)
                    {
                        if (!listaIdValori.Contains(elemento.IDSPELEMENTO))
                        {
                            elemento.CANCELLATO = true;
                            elemento.DATAMODIFICA = DateTime.Now;
                            elemento.UTENTEMODIFICA = account;
                        }
                    }
                }

                int sequenza = 0;
                foreach (ElementoScheda controllo in controlli)
                    SPValoreScheda.SalvaValoreScheda(controllo.IDValore, controllo.IDElemento, riga.IDSPSCHEDA, controllo.Valore, account, ds);


                bScheda.UpdateTableSPScheda(ds);
                bScheda.UpdateTable(ds.SPVALORISCHEDE.TableName, ds);
                return "Scheda creata correttamente";
            }
        }
    }
}






