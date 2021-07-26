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
    public class Componente : BaseModel
    {
        public int IdComponente { get; set; }
        public int IdDiba { get; set; }
        public int IdPadre { get; set; }
        public string Anagrafica { get; set; }
        public string Errore { get; set; }
        public string Descrizione { get; set; }
        public string CollegamentoDiBa { get; set; }
        public string UMQuantita { get; set; }
        public double Quantita { get; set; }
        public List<FaseCiclo> FasiCiclo { get; set; }

        public static List<Componente> EstraiListaComponenti(int idDiba)
        {
            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                bArticolo.GetCOMPONENTI(ds, idDiba, true);
                bArticolo.GetFASICICLO(ds, idDiba, true);
            }
            List<Componente> componenti = new List<Componente>();
            foreach (ArticoliDS.COMPONENTIRow riga in ds.COMPONENTI)
            {
                Componente componente = CreaComponente(riga, ds);
                componenti.Add(componente);
            }
            return componenti;
        }
        private static Componente CreaComponente(ArticoliDS.COMPONENTIRow riga, ArticoliDS ds)
        {

            if (riga == null) return null;
            Componente componente = new Componente();
            componente.IdDiba = riga.IDDIBA;
            componente.IdComponente = riga.IDCOMPONENTE;
            componente.IdPadre = riga.IsIDPADRENull() ? 0 : riga.IDPADRE;
            componente.Anagrafica = riga.IsANAGRAFICANull() ? string.Empty : riga.ANAGRAFICA;
            componente.Descrizione = riga.DESCRIZIONE;
            componente.CollegamentoDiBa = riga.IsCOLLEGAMENTODIBANull() ? string.Empty : riga.COLLEGAMENTODIBA;
            componente.UMQuantita = riga.IsUMQUANTITANull() ? string.Empty : riga.UMQUANTITA;
            componente.Quantita = riga.IsUMQUANTITANull() ? 0 : riga.QUANTITA;

            componente.Errore = string.Empty;
            componente.FasiCiclo = new List<FaseCiclo>();

            componente.Cancellato = riga.CANCELLATO;
            componente.DataModifica = riga.DATAMODIFICA;
            componente.UtenteModifica = riga.UTENTEMODIFICA;

            componente.FasiCiclo = FaseCiclo.EstraiListaFaseCiclo(componente, ds);

            return componente;
        }

        public Componente Copia(int idComponente, int idPadre)
        {
            int idFaseCiclo = 0;
            Componente componente = new Componente();
            componente.IdDiba = IdDiba;
            componente.IdComponente = idComponente;
            componente.IdPadre = idPadre;
            componente.Anagrafica = Anagrafica;
            componente.Descrizione = Descrizione;
            componente.CollegamentoDiBa = CollegamentoDiBa;
            componente.UMQuantita = UMQuantita;
            componente.Quantita = Quantita;

            componente.Cancellato = Cancellato;
            componente.DataModifica = DataModifica;
            componente.UtenteModifica = UtenteModifica;
            componente.FasiCiclo = new List<FaseCiclo>();

            if (FasiCiclo == null) FasiCiclo = new List<FaseCiclo>();
            foreach (FaseCiclo fc in FasiCiclo)
                componente.FasiCiclo.Add(fc.Copia(idFaseCiclo -= 10, idComponente));

            return componente;
        }

        public static void SalvaListaComponenti(List<Componente> componenti, string utente)
        {
            if (componenti.Count() == 0) return;

            int idDiba = componenti[0].IdDiba;
            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                bArticolo.GetCOMPONENTI(ds, idDiba, true);
                bArticolo.GetFASICICLO(ds, idDiba, true);

                List<int> idComponentiAttivi = componenti.Select(x => x.IdComponente).ToList();
                List<int> idComponentiDaCancellare = ds.COMPONENTI.Where(x => !idComponentiAttivi.Contains(x.IDCOMPONENTE)).Select(x => x.IDCOMPONENTE).ToList();
                foreach (int idComponenteDaCancellare in idComponentiDaCancellare)
                {
                    ArticoliDS.COMPONENTIRow componenteDaCancellare = ds.COMPONENTI.Where(x => x.RowState != System.Data.DataRowState.Deleted && x.IDCOMPONENTE == idComponenteDaCancellare).FirstOrDefault();
                    componenteDaCancellare.CANCELLATO = true;
                    componenteDaCancellare.UTENTEMODIFICA = utente;
                    componenteDaCancellare.DATAMODIFICA = DateTime.Now;
                }

                foreach (Componente componente in componenti.OrderByDescending(x => x.IdPadre))
                {
                    ArticoliDS.COMPONENTIRow rigaComponente = ds.COMPONENTI.Where(x => x.RowState != System.Data.DataRowState.Deleted && x.IDCOMPONENTE == componente.IdComponente).FirstOrDefault();

                    if (rigaComponente == null || componente.IdComponente < 0)
                    {
                        rigaComponente = ds.COMPONENTI.NewCOMPONENTIRow();
                        rigaComponente.IDCOMPONENTE = componente.IdComponente;
                        if (componente.IdPadre != 0)
                            rigaComponente.IDPADRE = componente.IdPadre;
                        rigaComponente.IDDIBA = componente.IdDiba;
                        rigaComponente.DESCRIZIONE = componente.Descrizione.ToUpper();
                        rigaComponente.ANAGRAFICA = componente.Anagrafica.ToUpper();
                        rigaComponente.COLLEGAMENTODIBA = componente.CollegamentoDiBa.ToUpper();
                        rigaComponente.QUANTITA = componente.Quantita;
                        rigaComponente.UMQUANTITA = componente.UMQuantita.ToUpper();
                        rigaComponente.CANCELLATO = false;
                        rigaComponente.DATAMODIFICA = DateTime.Now;
                        rigaComponente.UTENTEMODIFICA = utente;

                        ds.COMPONENTI.AddCOMPONENTIRow(rigaComponente);
                    }
                    else
                    {
                        if (componente.IdPadre != 0)
                            rigaComponente.IDPADRE = componente.IdPadre;
                        rigaComponente.DESCRIZIONE = componente.Descrizione.ToUpper();
                        rigaComponente.ANAGRAFICA = componente.Anagrafica.ToUpper();
                        rigaComponente.COLLEGAMENTODIBA = componente.CollegamentoDiBa.ToUpper();
                        rigaComponente.QUANTITA = componente.Quantita;
                        rigaComponente.UMQUANTITA = componente.UMQuantita.ToUpper();
                        rigaComponente.CANCELLATO = false;
                        rigaComponente.DATAMODIFICA = DateTime.Now;
                        rigaComponente.UTENTEMODIFICA = utente;
                    }
                    FaseCiclo.SalvaListaFaseCiclo(componente.FasiCiclo, utente, ds);
                }
                DataRow[] root = ds.COMPONENTI.Where(x => x.IsIDPADRENull()).ToArray();
                DataRow[] altriNodi = ds.COMPONENTI.Where(x => !x.IsIDPADRENull()).OrderByDescending(x => x.IDPADRE).ToArray();


                bArticolo.UpdateComponentiTable(ds.COMPONENTI.TableName, root);
                bArticolo.UpdateComponentiTable(ds.COMPONENTI.TableName, altriNodi);

                bArticolo.UpdateTable(ds.FASICICLO.TableName, ds);

            }

        }

        public string CreaEtichetta()
        {
            if (string.IsNullOrEmpty(Anagrafica))
                return string.Format("{0} {1}", IdComponente, Descrizione).Trim();
            else
                return string.Format("{0} {1} ({2})", IdComponente, Descrizione, Anagrafica).Trim();
        }

        public static bool VerificaListaPerSalvataggio(List<Componente> componenti)
        {
            bool esito = true;
            foreach (Componente componente in componenti)
            {
                componente.Errore = string.Empty;
                if (componente.Anagrafica != null && componente.Anagrafica.Length > 20)
                {
                    esito = false;
                    componente.Errore = "Anagrafica è troppo lunga ";
                }
                if (string.IsNullOrEmpty(componente.Descrizione))
                {
                    esito = false;
                    componente.Errore = "Descrizione obbligatoria ";
                }
                else if (componente.Descrizione.Length > 50)
                {
                    esito = false;
                    componente.Errore = "Descrizione troppo lunga ";
                }
                if (componente.Quantita <= 0)
                {
                    esito = false;
                    componente.Errore = "Inserire Quantità ";
                }
                if (componente.IdDiba < 0)
                {
                    esito = false;
                    componente.Errore = "Codice diba non valido ";
                }
                if (string.IsNullOrEmpty(componente.CollegamentoDiBa))
                {
                    esito = false;
                    componente.CollegamentoDiBa = ExpCicloBusinessCentral.CodiceCollegamentoStandard;
                }

            }
            return esito;
        }
    }
}