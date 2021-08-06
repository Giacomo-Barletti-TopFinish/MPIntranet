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
        public string Nota { get; set; }

        public static string EtichettaSchedaProcesso = "#SP:";
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
            foreach (ArticoliDS.FASICICLORow riga in ds.FASICICLO.Where(x => x.IDCOMPONENTE == componente.IdComponente).OrderByDescending(x => x.OPERAZIONE))
            {
                FaseCiclo faseCiclo = CreaFaseCiclo(riga);
                fasiCiclo.Add(faseCiclo);
            }
            return fasiCiclo;
        }
        public static List<FaseCiclo> EstraiListaFaseCiclo(ComponenteBC componenteBC, Componente componente)
        {
            List<FaseCiclo> fasiCiclo = new List<FaseCiclo>();
            int idFaseCiclo = componente.IdComponente * 1000;
            if (idFaseCiclo > 0) idFaseCiclo = idFaseCiclo * -1;

            foreach (FaseCicloBC faseBC in componenteBC.FasiCiclo)
            {
                idFaseCiclo--;
                FaseCiclo faseCiclo = CreaFaseCiclo(faseBC, componente, idFaseCiclo);
                fasiCiclo.Add(faseCiclo);
            }
            return fasiCiclo;
        }
        public FaseCiclo Copia(int nuovaIdFaseCiclo, int nuovoIdCOmponente)
        {

            return Copia(nuovaIdFaseCiclo, nuovoIdCOmponente, IdDiba);
        }

        public FaseCiclo Copia(int nuovaIdFaseCiclo, int nuovoIdCOmponente, int idDiba)
        {
            FaseCiclo faseCiclo = new FaseCiclo();

            faseCiclo.IdDiba = idDiba;
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
            faseCiclo.Nota = Nota;
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
            faseCiclo.Nota = riga.IsNOTANull() ? string.Empty : riga.NOTA;
            return faseCiclo;
        }
        private static FaseCiclo CreaFaseCiclo(FaseCicloBC faseCicloBC, Componente componente, int idFaseCiclo)
        {

            if (faseCicloBC == null) return null;
            FaseCiclo faseCiclo = new FaseCiclo();
            faseCiclo.IdDiba = componente.IdDiba;
            faseCiclo.IdFaseCiclo = idFaseCiclo;
            faseCiclo.IdComponente = componente.IdComponente;
            faseCiclo.Descrizione = faseCicloBC.Descrizione;
            faseCiclo.Operazione = Int32.Parse(faseCicloBC.Operazione);
            faseCiclo.Anagrafica = string.Empty;
            faseCiclo.CollegamentoDiBa = string.Empty;
            faseCiclo.Quantita = 0;
            faseCiclo.UMQuantita = string.Empty;
            faseCiclo.AreaProduzione = faseCicloBC.AreaProduzione;
            faseCiclo.Task = faseCicloBC.Task;
            faseCiclo.SchedaProcesso = faseCicloBC.SchedaProcesso;
            faseCiclo.CollegamentoCiclo = faseCicloBC.CollegamentoCiclo;
            faseCiclo.PezziPeriodo = (double)faseCicloBC.PezziPeriodo;
            faseCiclo.Periodo = (double)faseCicloBC.Periodo;
            faseCiclo.Setup = (double)faseCicloBC.Setup;
            faseCiclo.Attesa = (double)faseCicloBC.Attesa;
            faseCiclo.Movimentazione = (double)faseCicloBC.Movimentazione;
            faseCiclo.Errore = string.Empty;
            faseCiclo.Cancellato = false;
            faseCiclo.DataModifica = DateTime.Now;
            faseCiclo.UtenteModifica = componente.UtenteModifica;
            faseCiclo.Nota = faseCicloBC.Nota;
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
                        if (faseCiclo.IdComponente == 0 && faseCiclo.IdFaseCiclo == 0) return;
                        rigaFaseCiclo = ds.FASICICLO.NewFASICICLORow();
                        rigaFaseCiclo.IDFASECICLO = faseCiclo.IdFaseCiclo;
                        rigaFaseCiclo.IDCOMPONENTE = faseCiclo.IdComponente;
                        rigaFaseCiclo.IDDIBA = faseCiclo.IdDiba;
                        if (!string.IsNullOrEmpty(faseCiclo.Anagrafica))
                            rigaFaseCiclo.ANAGRAFICA = string.IsNullOrEmpty(faseCiclo.Anagrafica) ? string.Empty : faseCiclo.Anagrafica.ToUpper();
                        rigaFaseCiclo.COLLEGAMENTODIBA = string.IsNullOrEmpty(faseCiclo.CollegamentoDiBa) ? string.Empty : faseCiclo.CollegamentoDiBa.ToUpper();
                        rigaFaseCiclo.QUANTITA = faseCiclo.Quantita;
                        rigaFaseCiclo.UMQUANTITA = string.IsNullOrEmpty(faseCiclo.UMQuantita) ? string.Empty : faseCiclo.UMQuantita.ToUpper();
                        rigaFaseCiclo.OPERAZIONE = faseCiclo.Operazione;
                        rigaFaseCiclo.DESCRIZIONE = string.IsNullOrEmpty(faseCiclo.Descrizione) ? string.Empty : faseCiclo.Descrizione.ToUpper();
                        rigaFaseCiclo.AREAPRODUZIONE = string.IsNullOrEmpty(faseCiclo.AreaProduzione) ? string.Empty : faseCiclo.AreaProduzione.ToUpper();
                        rigaFaseCiclo.TASK = string.IsNullOrEmpty(faseCiclo.Task) ? string.Empty : faseCiclo.Task.ToUpper();
                        rigaFaseCiclo.SCHEDAPROCESSO = string.IsNullOrEmpty(faseCiclo.SchedaProcesso) ? string.Empty : faseCiclo.SchedaProcesso.ToUpper();
                        rigaFaseCiclo.COLLEGAMENTOCICLO = string.IsNullOrEmpty(faseCiclo.CollegamentoCiclo) ? string.Empty : faseCiclo.CollegamentoCiclo.ToUpper();
                        rigaFaseCiclo.PEZZIPERIODO = faseCiclo.PezziPeriodo;
                        rigaFaseCiclo.PERIODO = faseCiclo.Periodo;
                        rigaFaseCiclo.SETUP = faseCiclo.Setup;
                        rigaFaseCiclo.ATTESA = faseCiclo.Attesa;
                        rigaFaseCiclo.MOVIMENTAZIONE = faseCiclo.Movimentazione;
                        rigaFaseCiclo.CANCELLATO = false;
                        rigaFaseCiclo.DATAMODIFICA = DateTime.Now;
                        rigaFaseCiclo.UTENTEMODIFICA = utente;
                        rigaFaseCiclo.NOTA = string.IsNullOrEmpty(faseCiclo.Nota) ? string.Empty : faseCiclo.Nota.ToUpper();

                        ds.FASICICLO.AddFASICICLORow(rigaFaseCiclo);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(faseCiclo.Anagrafica))
                            rigaFaseCiclo.ANAGRAFICA = string.IsNullOrEmpty(faseCiclo.Anagrafica) ? string.Empty : faseCiclo.Anagrafica.ToUpper();
                        rigaFaseCiclo.COLLEGAMENTODIBA = string.IsNullOrEmpty(faseCiclo.CollegamentoDiBa) ? string.Empty : faseCiclo.CollegamentoDiBa.ToUpper();
                        rigaFaseCiclo.QUANTITA = faseCiclo.Quantita;
                        rigaFaseCiclo.UMQUANTITA = string.IsNullOrEmpty(faseCiclo.UMQuantita) ? string.Empty : faseCiclo.UMQuantita.ToUpper();
                        rigaFaseCiclo.OPERAZIONE = faseCiclo.Operazione;
                        rigaFaseCiclo.DESCRIZIONE = string.IsNullOrEmpty(faseCiclo.Descrizione) ? string.Empty : faseCiclo.Descrizione.ToUpper();
                        rigaFaseCiclo.AREAPRODUZIONE = string.IsNullOrEmpty(faseCiclo.AreaProduzione) ? string.Empty : faseCiclo.AreaProduzione.ToUpper();
                        rigaFaseCiclo.TASK = string.IsNullOrEmpty(faseCiclo.Task) ? string.Empty : faseCiclo.Task.ToUpper();
                        rigaFaseCiclo.SCHEDAPROCESSO = string.IsNullOrEmpty(faseCiclo.SchedaProcesso) ? string.Empty : faseCiclo.SchedaProcesso.ToUpper();
                        rigaFaseCiclo.COLLEGAMENTOCICLO = string.IsNullOrEmpty(faseCiclo.CollegamentoCiclo) ? string.Empty : faseCiclo.CollegamentoCiclo.ToUpper();
                        rigaFaseCiclo.PEZZIPERIODO = faseCiclo.PezziPeriodo;
                        rigaFaseCiclo.PERIODO = faseCiclo.Periodo;
                        rigaFaseCiclo.SETUP = faseCiclo.Setup;
                        rigaFaseCiclo.ATTESA = faseCiclo.Attesa;
                        rigaFaseCiclo.MOVIMENTAZIONE = faseCiclo.Movimentazione;
                        rigaFaseCiclo.CANCELLATO = false;
                        rigaFaseCiclo.DATAMODIFICA = DateTime.Now;
                        rigaFaseCiclo.UTENTEMODIFICA = utente;
                        rigaFaseCiclo.NOTA = string.IsNullOrEmpty(faseCiclo.Nota) ? string.Empty : faseCiclo.Nota.ToUpper();
                    }
                }
            }

        }
    }
}
