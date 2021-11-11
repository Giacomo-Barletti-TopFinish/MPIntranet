﻿using MPIntranet.DataAccess.SchedeProcesso;
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
        private CaratteristicheItem _caratteristiche;
        public CaratteristicheItem Caratteristiche
        {
            get
            {
                if (_caratteristiche == null)
                {
                    _caratteristiche = new CaratteristicheItem(Anagrafica);
                }
                return _caratteristiche;
            }
        }
        public List<SPValoreScheda> ValoriScheda { get; set; }
        public static List<SpScheda> EstraiListaSPScheda(bool soloNonCancellati)
        {
            SchedeProcessoDS ds = new SchedeProcessoDS();
            using (SchedeProcessoBusiness bScheda = new SchedeProcessoBusiness())
            {
                bScheda.FillSPScheda(ds, soloNonCancellati);
            }

            return creaListaSchede(ds);
        }
        public static List<SpScheda> TrovaSchede(string Codice, string Descrizione, int idBrand, string Anagrafica)
        {
            SchedeProcessoDS ds = new SchedeProcessoDS();
            using (SchedeProcessoBusiness bScheda = new SchedeProcessoBusiness())
            {
                bScheda.TrovaScheda(Codice, Descrizione, idBrand, Anagrafica, ds, true);
            }
            return creaListaSchede(ds);
        }

        private static List<SpScheda> creaListaSchede(SchedeProcessoDS ds)
        {
            List<SpScheda> schede = new List<SpScheda>();
            foreach (SchedeProcessoDS.SPSCHEDERow riga in ds.SPSCHEDE)
            {
                SpScheda scheda = CreaScheda(riga, ds);
                schede.Add(scheda);
            }
            return schede;
        }

        public static List<SpScheda> TrovaSchede(string AreaProduzione, string Task, string Anagrafica)
        {
            SchedeProcessoDS ds = new SchedeProcessoDS();
            using (SchedeProcessoBusiness bScheda = new SchedeProcessoBusiness())
            {
                bScheda.TrovaScheda(AreaProduzione, Task, Anagrafica, ds, true);
            }
            return creaListaSchede(ds);
        }

        public static List<SpScheda> EstraiListaSPScheda(string IDSPMaster, bool soloNonCancellati)
        {
            SchedeProcessoDS ds = new SchedeProcessoDS();
            using (SchedeProcessoBusiness bScheda = new SchedeProcessoBusiness())
            {
                bScheda.FillSPScheda(IDSPMaster, ds, soloNonCancellati);
            }

            return creaListaSchede(ds);

        }
        public override string ToString()
        {
            return Codice + " - " + Descrizione;
        }
        private static SpScheda CreaScheda(SchedeProcessoDS.SPSCHEDERow riga, SchedeProcessoDS ds)
        {

            if (riga == null) return null;
            SpScheda controllo = new SpScheda();
            controllo.IdSPScheda = riga.IDSPSCHEDA;
            controllo.Master = SPMaster.EstraiSPMaster(riga.IDSPMASTER);
            controllo.Codice = riga.CODICE;
            controllo.Descrizione = riga.DESCRIZIONE;
            controllo.Brand = Brand.EstraiBrand(riga.IDBRAND);
            controllo.Anagrafica = riga.ANAGRAFICA;
            controllo.AreaProduzione = riga.AREAPRODUZIONE;
            controllo.Task = riga.TASK;
            controllo.Cancellato = riga.CANCELLATO;
            controllo.DataModifica = riga.DATAMODIFICA;
            controllo.UtenteModifica = riga.UTENTEMODIFICA;
            controllo.ValoriScheda = SPValoreScheda.EstraiListaSPValoreScheda(riga.IDSPSCHEDA, true, ds);

            return controllo;
        }
        public static SpScheda CreaSchedaVuota(int idSPMaster)
        {
            SpScheda controllo = new SpScheda();
            controllo.IdSPScheda = ElementiVuoti.SPScheda;
            controllo.Master = SPMaster.EstraiSPMaster(idSPMaster);
            controllo.Codice = string.Empty;
            controllo.Descrizione = string.Empty;
            controllo.Brand = Brand.CreaBrandVuoto();
            controllo.Anagrafica = string.Empty;
            controllo.AreaProduzione = string.Empty;
            controllo.Task = string.Empty;
            controllo.ValoriScheda = new List<SPValoreScheda>();
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

                SchedeProcessoDS.SPSCHEDERow riga = ds.SPSCHEDE.Where(x => x.IDSPSCHEDA == idScheda).FirstOrDefault();
                if (riga != null)
                {
                    //                    riga.CODICE = codice.ToUpper();
                    riga.DESCRIZIONE = descrizione.ToUpper();
                    riga.IDBRAND = IdBrand;
                    riga.ANAGRAFICA = anagrafica.ToUpper();
                    riga.DATAMODIFICA = DateTime.Now;
                    riga.UTENTEMODIFICA = account;
                }
                else
                {
                    riga = ds.SPSCHEDE.NewSPSCHEDERow();
                    riga.CODICE = "SP";// codice.ToUpper();
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
                {
                    if (!string.IsNullOrEmpty(controllo.Filename))
                        controllo.Valore = (controllo.Filename.Length > 30) ? controllo.Filename.Substring(0, 30) : controllo.Filename;
                    SPValoreScheda.SalvaValoreScheda(controllo.IDValore, controllo.IDElemento, riga.IDSPSCHEDA, controllo.Valore, controllo.Filedata, account, ds);
                }

                bScheda.UpdateTableSPScheda(ds);
                bScheda.UpdateTable(ds.SPVALORISCHEDE.TableName, ds);
                ds.AcceptChanges();
                riga.CODICE = string.Format("SP{0}", riga.IDSPSCHEDA.ToString().PadLeft(8, '0'));
                bScheda.UpdateTableSPScheda(ds);
                string messaggio = string.Format("Scheda {0} creata correttamente. ID scheda {1}", riga.CODICE, riga.IDSPSCHEDA);
                return "Scheda creata correttamente";
            }

        }
    }
}






