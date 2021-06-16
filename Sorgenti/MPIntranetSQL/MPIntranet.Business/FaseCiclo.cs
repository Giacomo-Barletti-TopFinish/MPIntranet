using MPIntranet.DataAccess.Articoli;
using MPIntranet.Entities;
using MPIntranet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class FaseCiclo : BaseModel
    {
        public int IdFaseCiclo { get; set; }
        public int IdDiba { get; set; }
        public string Descrizione { get; set; }
        public int IdComponente { get; set; }
        public int Operazione { get; set; }
        public string Anagrafica { get; set; }
        public string CollegamentoDiBa { get; set; }
        public string UMQuantita { get; set; }
        public double Quantita { get; set; }
        public string AreaProduzione { get; set; }
        public string Task { get; set; }
        public string SchedaProcesso { get; set; }
        public string CollegamentoCiclo { get; set; }
        public double PezziPeriodo { get; set; }
        public double Periodo { get; set; }
        public double Setup { get; set; }
        public double Attesa { get; set; }
        public double Movimentazione { get; set; }
        public string Errore { get; set; }

        public static List<FaseCiclo> EstraiListaFaseCiclo(int idDiba)
        {
            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                bArticolo.GetFASICICLO(ds, idDiba, true);
            }
            List<FaseCiclo> fasiCiclo = new List<FaseCiclo>();
            foreach (ArticoliDS.FASICICLORow riga in ds.FASICICLO)
            {
                FaseCiclo faseCiclo = CreaFaseCiclo(riga);
                fasiCiclo.Add(faseCiclo);
            }
            return fasiCiclo;
        }

        public static List<FaseCiclo> EstraiListaFaseCiclo(Componente componente, ArticoliDS ds)
        {
            List<FaseCiclo> fasiCiclo = new List<FaseCiclo>();
            foreach (ArticoliDS.FASICICLORow riga in ds.FASICICLO.Where(x => x.IDCOMPONENTE == componente.IdComponente))
            {
                FaseCiclo faseCiclo = CreaFaseCiclo(riga);
                fasiCiclo.Add(faseCiclo);
            }
            return fasiCiclo;
        }
        public FaseCiclo Copia(int nuovaIdFaseCiclo, int nuovoIdCOmponente)
        {
            FaseCiclo faseCiclo = new FaseCiclo();

            faseCiclo.IdDiba = IdDiba;
            faseCiclo.IdFaseCiclo = nuovaIdFaseCiclo;
            faseCiclo.IdComponente = nuovoIdCOmponente;
            faseCiclo.Descrizione = Descrizione;
            faseCiclo.Anagrafica = Anagrafica;
            faseCiclo.CollegamentoDiBa = CollegamentoDiBa;
            faseCiclo.Quantita = Quantita;
            faseCiclo.UMQuantita = UMQuantita;
            faseCiclo.Operazione = Operazione;
            faseCiclo.AreaProduzione = AreaProduzione;
            faseCiclo.Task = Task;
            faseCiclo.SchedaProcesso = SchedaProcesso;
            faseCiclo.CollegamentoCiclo = CollegamentoCiclo;
            faseCiclo.PezziPeriodo = PezziPeriodo;
            faseCiclo.Periodo = Periodo;
            faseCiclo.Setup = Setup;
            faseCiclo.Attesa = Attesa;
            faseCiclo.Movimentazione = Movimentazione;
            faseCiclo.Errore = string.Empty;
            faseCiclo.Cancellato = Cancellato;
            faseCiclo.DataModifica = DataModifica;
            faseCiclo.UtenteModifica = UtenteModifica;
            return faseCiclo;
        }
        private static FaseCiclo CreaFaseCiclo(ArticoliDS.FASICICLORow riga)
        {

            if (riga == null) return null;
            FaseCiclo faseCiclo = new FaseCiclo();
            faseCiclo.IdDiba = riga.IDDIBA;
            faseCiclo.IdFaseCiclo = riga.IDFASECICLO;
            faseCiclo.IdComponente = riga.IDCOMPONENTE;
            faseCiclo.Descrizione = riga.IsDESCRIZIONENull() ? string.Empty : riga.DESCRIZIONE;
            faseCiclo.Operazione = riga.OPERAZIONE;
            faseCiclo.Anagrafica = riga.IsANAGRAFICANull() ? string.Empty : riga.ANAGRAFICA;
            faseCiclo.CollegamentoDiBa = riga.IsCOLLEGAMENTODIBANull() ? string.Empty : riga.COLLEGAMENTODIBA;
            faseCiclo.Quantita = riga.IsQUANTITANull() ? 0 : riga.QUANTITA;
            faseCiclo.UMQuantita = riga.IsUMQUANTITANull() ? string.Empty : riga.UMQUANTITA;
            faseCiclo.AreaProduzione = riga.IsAREAPRODUZIONENull() ? string.Empty : riga.AREAPRODUZIONE;
            faseCiclo.Task = riga.IsTASKNull() ? string.Empty : riga.TASK;
            faseCiclo.SchedaProcesso = riga.IsSCHEDAPROCESSONull() ? string.Empty : riga.SCHEDAPROCESSO;
            faseCiclo.CollegamentoCiclo = riga.IsCOLLEGAMENTOCICLONull() ? string.Empty : riga.COLLEGAMENTOCICLO;
            faseCiclo.PezziPeriodo = riga.IsPEZZIPERIODONull() ? 0 : riga.PEZZIPERIODO;
            faseCiclo.Periodo = riga.IsPERIODONull() ? 0 : riga.PERIODO;
            faseCiclo.Setup = riga.IsSETUPNull() ? 0 : riga.SETUP;
            faseCiclo.Attesa = riga.IsATTESANull() ? 0 : riga.ATTESA;
            faseCiclo.Movimentazione = riga.IsMOVIMENTAZIONENull() ? 0 : riga.MOVIMENTAZIONE;
            faseCiclo.Errore = string.Empty;
            faseCiclo.Cancellato = riga.CANCELLATO;
            faseCiclo.DataModifica = riga.DATAMODIFICA;
            faseCiclo.UtenteModifica = riga.UTENTEMODIFICA;
            return faseCiclo;
        }

        public static void SalvaListaFaseCiclo(List<FaseCiclo> fasiCiclo, string utente, ArticoliDS ds)
        {
            if (fasiCiclo.Count() == 0) return;
            int idComponente = fasiCiclo[0].IdComponente;

            int idDiba = fasiCiclo[0].IdDiba;
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                List<int> idFasiCicloAttive = fasiCiclo.Select(x => x.IdFaseCiclo).ToList();
                List<int> idFasiCicloDaCancellare = ds.FASICICLO.Where(x => !idFasiCicloAttive.Contains(x.IDFASECICLO) && x.IDCOMPONENTE == idComponente).Select(x => x.IDFASECICLO).ToList();
                foreach (int idFaseCicloDaCancellare in idFasiCicloDaCancellare)
                {
                    ArticoliDS.FASICICLORow faseCicloDaCancellare = ds.FASICICLO.Where(x => x.RowState != System.Data.DataRowState.Deleted && x.IDFASECICLO == idFaseCicloDaCancellare).FirstOrDefault();
                    faseCicloDaCancellare.CANCELLATO = true;
                    faseCicloDaCancellare.UTENTEMODIFICA = utente;
                    faseCicloDaCancellare.DATAMODIFICA = DateTime.Now;
                }

                foreach (FaseCiclo faseCiclo in fasiCiclo)
                {
                    ArticoliDS.FASICICLORow rigaFaseCiclo = ds.FASICICLO.Where(x => x.RowState != System.Data.DataRowState.Deleted && x.IDFASECICLO == faseCiclo.IdFaseCiclo && x.IDCOMPONENTE == idComponente).FirstOrDefault();

                    if (rigaFaseCiclo == null)
                    {
                        rigaFaseCiclo = ds.FASICICLO.NewFASICICLORow();
                        rigaFaseCiclo.IDFASECICLO = faseCiclo.IdFaseCiclo;
                        rigaFaseCiclo.IDCOMPONENTE = faseCiclo.IdComponente;
                        rigaFaseCiclo.IDDIBA = faseCiclo.IdDiba;
                        rigaFaseCiclo.ANAGRAFICA = faseCiclo.Anagrafica.ToUpper();
                        rigaFaseCiclo.COLLEGAMENTODIBA = faseCiclo.CollegamentoDiBa.ToUpper();
                        rigaFaseCiclo.QUANTITA = faseCiclo.Quantita;
                        rigaFaseCiclo.UMQUANTITA = faseCiclo.UMQuantita.ToUpper();
                        rigaFaseCiclo.OPERAZIONE = faseCiclo.Operazione;
                        rigaFaseCiclo.DESCRIZIONE = faseCiclo.Descrizione.ToUpper();
                        rigaFaseCiclo.AREAPRODUZIONE = faseCiclo.AreaProduzione.ToUpper();
                        rigaFaseCiclo.TASK = faseCiclo.Task.ToUpper();
                        rigaFaseCiclo.SCHEDAPROCESSO = faseCiclo.SchedaProcesso.ToUpper();
                        rigaFaseCiclo.COLLEGAMENTOCICLO = faseCiclo.CollegamentoCiclo.ToUpper();
                        rigaFaseCiclo.PEZZIPERIODO = faseCiclo.PezziPeriodo;
                        rigaFaseCiclo.PERIODO = faseCiclo.Periodo;
                        rigaFaseCiclo.SETUP = faseCiclo.Setup;
                        rigaFaseCiclo.ATTESA = faseCiclo.Attesa;
                        rigaFaseCiclo.MOVIMENTAZIONE = faseCiclo.Movimentazione;
                        rigaFaseCiclo.CANCELLATO = false;
                        rigaFaseCiclo.DATAMODIFICA = DateTime.Now;
                        rigaFaseCiclo.UTENTEMODIFICA = utente;

                        ds.FASICICLO.AddFASICICLORow(rigaFaseCiclo);
                    }
                    else
                    {
                        rigaFaseCiclo.ANAGRAFICA = faseCiclo.Anagrafica.ToUpper();
                        rigaFaseCiclo.COLLEGAMENTODIBA = faseCiclo.CollegamentoDiBa.ToUpper();
                        rigaFaseCiclo.QUANTITA = faseCiclo.Quantita;
                        rigaFaseCiclo.UMQUANTITA = faseCiclo.UMQuantita.ToUpper();
                        rigaFaseCiclo.OPERAZIONE = faseCiclo.Operazione;
                        rigaFaseCiclo.DESCRIZIONE = faseCiclo.Descrizione.ToUpper();
                        rigaFaseCiclo.AREAPRODUZIONE = faseCiclo.AreaProduzione.ToUpper();
                        rigaFaseCiclo.TASK = faseCiclo.Task.ToUpper();
                        rigaFaseCiclo.SCHEDAPROCESSO = faseCiclo.SchedaProcesso.ToUpper();
                        rigaFaseCiclo.COLLEGAMENTOCICLO = faseCiclo.CollegamentoCiclo.ToUpper();
                        rigaFaseCiclo.PEZZIPERIODO = faseCiclo.PezziPeriodo;
                        rigaFaseCiclo.PERIODO = faseCiclo.Periodo;
                        rigaFaseCiclo.SETUP = faseCiclo.Setup;
                        rigaFaseCiclo.ATTESA = faseCiclo.Attesa;
                        rigaFaseCiclo.MOVIMENTAZIONE = faseCiclo.Movimentazione;
                        rigaFaseCiclo.CANCELLATO = false;
                        rigaFaseCiclo.DATAMODIFICA = DateTime.Now;
                        rigaFaseCiclo.UTENTEMODIFICA = utente;
                    }
                }
            }

        }
    }
}
