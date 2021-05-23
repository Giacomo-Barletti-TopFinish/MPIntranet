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

        public static List<FaseDistinta> EstraiListaFaseDistinta(int idDiba)
        {
            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                bArticolo.FillFASIDIBA(ds, idDiba);
            }

            List<FaseDistinta> fasi = new List<FaseDistinta>();
            foreach (ArticoliDS.FASIDIBARow riga in ds.FASIDIBA)
            {
                FaseDistinta faseDistinta = CreaFaseDistinta(riga, idDiba);
                fasi.Add(faseDistinta);
            }
            return fasi;
        }

        private static FaseDistinta CreaFaseDistinta(ArticoliDS.FASIDIBARow riga, int idDiba)
        {
            if (riga == null) return null;
            FaseDistinta fase = new FaseDistinta(idDiba);
            fase.IdFaseDiba = riga.IDFASEDIBA;
            fase.IdPadre = riga.IsIDPADRENull() ? 0 : riga.IDPADRE;
            fase.IdDiba = riga.IDDIBA;
            fase.Descrizione = riga.DESCRIZIONE;
            fase.Anagrafica = riga.ANAGRAFICA;
            fase.AreaProduzione = riga.AREAPRODUZIONE;
            fase.Task = riga.TASK;
            fase.SchedaProcesso = riga.IsSCHEDAPROCESSONull() ? string.Empty : riga.SCHEDAPROCESSO;
            fase.CollegamentoCiclo = riga.IsCOLLEGAMENTOCICLONull() ? string.Empty : riga.COLLEGAMENTOCICLO;
            fase.CollegamentoDiba = riga.IsCOLLEGAMENTODIBANull() ? string.Empty : riga.COLLEGAMENTODIBA;
            fase.Quantita = riga.QUANTITA;
            fase.PezziOrari = riga.IsPEZZIPERIODONull() ? 0 : riga.PEZZIPERIODO;
            fase.Periodo = riga.IsPERIODONull() ? 0 : riga.PERIODO;
            fase.UMQuantita = riga.IsUMQUANTITANull() ? string.Empty : riga.UMQUANTITA;
            fase.Setup = riga.IsSETUPNull() ? 0 : riga.SETUP;
            fase.Attesa = riga.IsATTESANull() ? 0 : riga.ATTESA;
            fase.Movimentazione = riga.IsMOVIMENTAZIONENull() ? 0 : riga.MOVIMENTAZIONE;
            fase.Cancellato = riga.CANCELLATO;
            fase.DataModifica = riga.DATAMODIFICA;
            fase.UtenteModifica = riga.UTENTEMODIFICA;

            return fase;
        }

        public static void SalvaListaFasiDistinta(List<FaseDistinta> fasi, string utente)
        {
            if (fasi.Count() == 0) return;

            int idDiba = fasi[0].IdDiba;
            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                bArticolo.FillFASIDIBA(ds, idDiba);

                List<int> idFaseGriglia = fasi.Select(x => x.IdFaseDiba).ToList();
                List<int> idFasiDaCencellare = ds.FASIDIBA.Where(x => !idFaseGriglia.Contains(x.IDFASEDIBA)).Select(x => x.IDFASEDIBA).ToList();
                foreach (int idFaseDaCancellare in idFasiDaCencellare)
                {
                    ArticoliDS.FASIDIBARow faseDaCancellare = ds.FASIDIBA.Where(x => x.RowState != System.Data.DataRowState.Deleted && x.IDFASEDIBA == idFaseDaCancellare).FirstOrDefault();
                    faseDaCancellare.CANCELLATO = true;
                    faseDaCancellare.UTENTEMODIFICA = utente;
                    faseDaCancellare.DATAMODIFICA = DateTime.Now;
                }

                foreach (FaseDistinta fd in fasi)
                {
                    ArticoliDS.FASIDIBARow faseDistinta = ds.FASIDIBA.Where(x => x.RowState != System.Data.DataRowState.Deleted && x.IDFASEDIBA == fd.IdFaseDiba).FirstOrDefault();

                    if (faseDistinta == null)
                    {
                        faseDistinta = ds.FASIDIBA.NewFASIDIBARow();
                        if (fd.IdPadre != 0)
                            faseDistinta.IDPADRE = fd.IdPadre;
                        faseDistinta.IDDIBA = fd.IdDiba;
                        faseDistinta.DESCRIZIONE = fd.Descrizione;
                        faseDistinta.ANAGRAFICA = fd.Anagrafica;
                        faseDistinta.AREAPRODUZIONE = fd.AreaProduzione;
                        faseDistinta.TASK = fd.Task;
                        faseDistinta.SCHEDAPROCESSO = fd.SchedaProcesso;
                        faseDistinta.COLLEGAMENTOCICLO = fd.CollegamentoCiclo;
                        faseDistinta.COLLEGAMENTODIBA = fd.CollegamentoDiba;
                        faseDistinta.QUANTITA = fd.Quantita;
                        faseDistinta.PEZZIPERIODO = fd.PezziOrari;
                        faseDistinta.PERIODO = fd.Periodo;
                        faseDistinta.UMQUANTITA = fd.UMQuantita;
                        faseDistinta.SETUP = fd.Setup;
                        faseDistinta.ATTESA = fd.Attesa;
                        faseDistinta.MOVIMENTAZIONE = fd.Movimentazione;
                        faseDistinta.CANCELLATO = false;
                        faseDistinta.DATAMODIFICA = DateTime.Now;
                        faseDistinta.UTENTEMODIFICA = utente;

                        ds.FASIDIBA.AddFASIDIBARow(faseDistinta);
                    }
                    else
                    {
                        if (fd.IdPadre != 0)
                            faseDistinta.IDPADRE = fd.IdPadre;
                        faseDistinta.DESCRIZIONE = fd.Descrizione;
                        faseDistinta.ANAGRAFICA = fd.Anagrafica;
                        faseDistinta.AREAPRODUZIONE = fd.AreaProduzione;
                        faseDistinta.TASK = fd.Task;
                        faseDistinta.SCHEDAPROCESSO = fd.SchedaProcesso;
                        faseDistinta.COLLEGAMENTOCICLO = fd.CollegamentoCiclo;
                        faseDistinta.COLLEGAMENTODIBA = fd.CollegamentoDiba;
                        faseDistinta.QUANTITA = fd.Quantita;
                        faseDistinta.PEZZIPERIODO = fd.PezziOrari;
                        faseDistinta.PERIODO = fd.Periodo;
                        faseDistinta.UMQUANTITA = fd.UMQuantita;
                        faseDistinta.SETUP = fd.Setup;
                        faseDistinta.ATTESA = fd.Attesa;
                        faseDistinta.MOVIMENTAZIONE = fd.Movimentazione;
                        faseDistinta.CANCELLATO = false;
                        faseDistinta.DATAMODIFICA = DateTime.Now;
                        faseDistinta.UTENTEMODIFICA = utente;
                    }

                }
                bArticolo.UpdateFaseDistintaBaseTable(ds);
            }

        }


    }
}
