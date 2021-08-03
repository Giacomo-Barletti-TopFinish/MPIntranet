using MPIntranet.DataAccess.Articoli;
using MPIntranet.Entities;
using MPIntranet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class FaseDistinta : BaseModel
    {
        public int IdFaseDiba { get; set; }
        public int IdPadre { get; set; }
        public int IdDiba { get; set; }
        public string Descrizione { get; set; }
        public string Anagrafica { get; set; }
        public string AreaProduzione { get; set; }
        public string Task { get; set; }
        public string SchedaProcesso { get; set; }
        public string CollegamentoDiba { get; set; }
        public string CollegamentoCiclo { get; set; }
        public double Quantita { get; set; }
        public double PezziOrari { get; set; }
        public double Periodo { get; set; }
        public string UMQuantita { get; set; }
        public double Setup { get; set; }
        public double Attesa { get; set; }
        public double Movimentazione { get; set; }
        public string Errore { get; set; }

        public FaseDistinta(int idDiba)
        {
            IdDiba = idDiba;
        }

        public FaseDistinta CopiaFase(int idFaseDistinta, int idPadre)
        {
            FaseDistinta faseCopiata = new FaseDistinta(IdDiba);
            faseCopiata.IdFaseDiba = idFaseDistinta;
            faseCopiata.IdPadre = idPadre;
            faseCopiata.Descrizione = Descrizione;
            faseCopiata.Anagrafica = Anagrafica;
            faseCopiata.AreaProduzione = AreaProduzione;
            faseCopiata.Task = Task;
            faseCopiata.SchedaProcesso = SchedaProcesso;
            faseCopiata.CollegamentoCiclo = CollegamentoCiclo;
            faseCopiata.CollegamentoDiba = CollegamentoDiba;
            faseCopiata.Quantita = Quantita;
            faseCopiata.PezziOrari = PezziOrari;
            faseCopiata.Periodo = Periodo;
            faseCopiata.UMQuantita = UMQuantita;
            faseCopiata.Setup = Setup;
            faseCopiata.Attesa = Attesa;
            faseCopiata.Movimentazione = Movimentazione;
            faseCopiata.Cancellato = Cancellato;
            faseCopiata.DataModifica = DataModifica;
            faseCopiata.UtenteModifica = UtenteModifica;
            return faseCopiata;
        }

        //public static List<FaseDistinta> EstraiListaFaseDistinta(int idDiba)
        //{
        //    ArticoliDS ds = new ArticoliDS();
        //    using (ArticoliBusiness bArticolo = new ArticoliBusiness())
        //    {
        //        bArticolo.FillFASIDIBA(ds, idDiba);
        //    }

        //    List<FaseDistinta> fasi = new List<FaseDistinta>();
        //    foreach (ArticoliDS.FASIDIBARow riga in ds.FASIDIBA)
        //    {
        //        FaseDistinta faseDistinta = CreaFaseDistinta(riga, idDiba);
        //        fasi.Add(faseDistinta);
        //    }
        //    return fasi;
        //}

        //private static FaseDistinta CreaFaseDistinta(ArticoliDS.FASIDIBARow riga, int idDiba)
        //{
        //    if (riga == null) return null;
        //    FaseDistinta fase = new FaseDistinta(idDiba);
        //    fase.IdFaseDiba = riga.IDFASEDIBA;
        //    fase.IdPadre = riga.IsIDPADRENull() ? 0 : riga.IDPADRE;
        //    fase.IdDiba = riga.IDDIBA;
        //    fase.Descrizione = riga.DESCRIZIONE;
        //    fase.Anagrafica = riga.ANAGRAFICA;
        //    fase.AreaProduzione = riga.AREAPRODUZIONE;
        //    fase.Task = riga.TASK;
        //    fase.SchedaProcesso = riga.IsSCHEDAPROCESSONull() ? string.Empty : riga.SCHEDAPROCESSO;
        //    fase.CollegamentoCiclo = riga.IsCOLLEGAMENTOCICLONull() ? string.Empty : riga.COLLEGAMENTOCICLO;
        //    fase.CollegamentoDiba = riga.IsCOLLEGAMENTODIBANull() ? string.Empty : riga.COLLEGAMENTODIBA;
        //    fase.Quantita = riga.QUANTITA;
        //    fase.PezziOrari = riga.IsPEZZIPERIODONull() ? 0 : riga.PEZZIPERIODO;
        //    fase.Periodo = riga.IsPERIODONull() ? 0 : riga.PERIODO;
        //    fase.UMQuantita = riga.IsUMQUANTITANull() ? string.Empty : riga.UMQUANTITA;
        //    fase.Setup = riga.IsSETUPNull() ? 0 : riga.SETUP;
        //    fase.Attesa = riga.IsATTESANull() ? 0 : riga.ATTESA;
        //    fase.Movimentazione = riga.IsMOVIMENTAZIONENull() ? 0 : riga.MOVIMENTAZIONE;
        //    fase.Cancellato = riga.CANCELLATO;
        //    fase.DataModifica = riga.DATAMODIFICA;
        //    fase.UtenteModifica = riga.UTENTEMODIFICA;

        //    return fase;
        //}

        public static FaseDistinta CreaFaseDistinta(ArticoliDS.DistinteBCTestataRow riga, ArticoliDS.CicliBCDettaglioRow ciclo, int idFaseDiba, int idPadre)
        {
            if (riga == null || ciclo == null) return null;
            FaseDistinta fase = new FaseDistinta(1);
            fase.IdFaseDiba = idFaseDiba;
            fase.IdPadre = idPadre;
            fase.IdDiba = 1;
            fase.Descrizione = string.Empty;
            fase.Anagrafica = riga.No_;
            fase.AreaProduzione = ciclo.Work_Center_No_;
            fase.Task = ciclo.Standard_Task_Code;
            fase.SchedaProcesso = string.Empty;
            fase.CollegamentoCiclo = ciclo.Routing_Link_Code;
            fase.CollegamentoDiba = string.Empty;
            fase.Quantita = 1;
            fase.PezziOrari = (double)ciclo.Lot_Size;
            fase.Periodo = (double)ciclo.Run_Time;
            fase.UMQuantita = riga.Unit_of_Measure_Code;
            fase.Setup = (double)ciclo.Setup_Time;
            fase.Attesa = (double)ciclo.Wait_Time;
            fase.Movimentazione = (double)ciclo.Move_Time;
            fase.Cancellato = false;
            fase.DataModifica = DateTime.Now;
            fase.UtenteModifica = string.Empty;

            return fase;
        }
        public static FaseDistinta CreaFaseDistinta(ArticoliDS.DistinteBCDettaglioRow riga, ArticoliDS.CicliBCDettaglioRow ciclo, int idFaseDiba, int idPadre)
        {
            if (riga == null || ciclo == null) return null;
            FaseDistinta fase = new FaseDistinta(1);
            fase.IdFaseDiba = idFaseDiba;
            fase.IdPadre = idPadre;
            fase.IdDiba = 1;
            fase.Descrizione = string.Empty;
            fase.Anagrafica = riga.No_;
            fase.AreaProduzione = ciclo.Work_Center_No_;
            fase.Task = ciclo.Standard_Task_Code;
            fase.SchedaProcesso = string.Empty;
            fase.CollegamentoCiclo = ciclo.Routing_Link_Code;
            fase.CollegamentoDiba = riga.Routing_Link_Code;
            fase.Quantita = (double)riga.Quantity_per;
            fase.PezziOrari = (double)ciclo.Lot_Size;
            fase.Periodo = (double)ciclo.Run_Time;
            fase.UMQuantita = riga.Unit_of_Measure_Code;
            fase.Setup = (double)ciclo.Setup_Time;
            fase.Attesa = (double)ciclo.Wait_Time;
            fase.Movimentazione = (double)ciclo.Move_Time;
            fase.Cancellato = false;
            fase.DataModifica = DateTime.Now;
            fase.UtenteModifica = string.Empty;

            return fase;
        }
        public static FaseDistinta CreaFaseDistinta(ArticoliDS.CicliBCDettaglioRow ciclo, int idFaseDiba, int idPadre)
        {
            if (ciclo == null) return null;
            FaseDistinta fase = new FaseDistinta(1);
            fase.IdFaseDiba = idFaseDiba;
            fase.IdPadre = idPadre;
            fase.IdDiba = 1;
            fase.Descrizione = string.Empty;
            fase.Anagrafica = string.Empty;
            fase.AreaProduzione = ciclo.Work_Center_No_;
            fase.Task = ciclo.Standard_Task_Code;
            fase.SchedaProcesso = string.Empty;
            fase.CollegamentoCiclo = ciclo.Routing_Link_Code;
            fase.CollegamentoDiba = string.Empty;
            fase.Quantita = 1;
            fase.PezziOrari = (double)ciclo.Lot_Size;
            fase.Periodo = (double)ciclo.Run_Time;
            fase.UMQuantita = string.Empty;
            fase.Setup = (double)ciclo.Setup_Time;
            fase.Attesa = (double)ciclo.Wait_Time;
            fase.Movimentazione = (double)ciclo.Move_Time;
            fase.Cancellato = false;
            fase.DataModifica = DateTime.Now;
            fase.UtenteModifica = string.Empty;

            return fase;
        }

    }
}
