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

        public static List<Componente> EstraiListaCompoenti(int idDiba)
        {
            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                bArticolo.GetCOMPONENTI(ds, idDiba, true);
            }
            List<Componente> componenti = new List<Componente>();
            foreach (ArticoliDS.COMPONENTIRow riga in ds.COMPONENTI)
            {
                Componente componente = CreaComponente(riga);
                componenti.Add(componente);
            }
            return componenti;
        }
        private static Componente CreaComponente(ArticoliDS.COMPONENTIRow riga)
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
            return componente;
        }

        public static void SalvaListaComponenti(List<Componente> componenti, string utente)
        {
            if (componenti.Count() == 0) return;

            int idDiba = componenti[0].IdDiba;
            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                bArticolo.GetCOMPONENTI(ds, idDiba, false);

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
                        rigaComponente.DESCRIZIONE = componente.Descrizione;
                        rigaComponente.ANAGRAFICA = componente.Anagrafica;
                        rigaComponente.COLLEGAMENTODIBA = componente.CollegamentoDiBa;
                        rigaComponente.QUANTITA = componente.Quantita;
                        rigaComponente.UMQUANTITA = componente.UMQuantita;
                        rigaComponente.CANCELLATO = false;
                        rigaComponente.DATAMODIFICA = DateTime.Now;
                        rigaComponente.UTENTEMODIFICA = utente;

                        ds.COMPONENTI.AddCOMPONENTIRow(rigaComponente);
                    }
                    else
                    {
                        if (componente.IdPadre != 0)
                            rigaComponente.IDPADRE = componente.IdPadre;
                        rigaComponente.DESCRIZIONE = componente.Descrizione;
                        rigaComponente.ANAGRAFICA = componente.Anagrafica;
                        rigaComponente.COLLEGAMENTODIBA = componente.CollegamentoDiBa;
                        rigaComponente.QUANTITA = componente.Quantita;
                        rigaComponente.UMQUANTITA = componente.UMQuantita;
                        rigaComponente.CANCELLATO = false;
                        rigaComponente.DATAMODIFICA = DateTime.Now;
                        rigaComponente.UTENTEMODIFICA = utente;
                    }

                }
                //                DataRow[] componentiEsistenti = ds.COMPONENTI.Where(x => x.IDCOMPONENTE >= 0).OrderBy(x => x.IDPADRE).ToArray();
                DataRow[] primicomponenti = ds.COMPONENTI.Where(x => x.IsIDPADRENull()).ToArray();

                DataRow[] componentiNuovi = ds.COMPONENTI.Where(x => !x.IsIDPADRENull()).OrderByDescending(x => x.IDPADRE).ToArray();


                bArticolo.UpdateComponentiTable(ds.COMPONENTI.TableName, primicomponenti);
                bArticolo.UpdateComponentiTable(ds.COMPONENTI.TableName, componentiNuovi);
//                bArticolo.UpdateComponentiTable(ds.COMPONENTI.TableName, drs2);
            }

        }

        public static bool VerificaListaComponentiPerSalvataggio(List<Componente> componenti)
        {
            bool esito = true;
            foreach (Componente componente in componenti)
            {
                componente.Errore = string.Empty;
                if (componente.Anagrafica != null && componente.Anagrafica.Length > 20)
                {
                    esito = false;
                    componente.Errore = "Anagrafica è troppo lunga";
                }
                if (string.IsNullOrEmpty(componente.Descrizione))
                {
                    esito = false;
                    componente.Errore = "Descrizione obbligatoria";
                }
                else if (componente.Descrizione.Length > 50)
                {
                    esito = false;
                    componente.Errore = "Descrizione troppo lunga";
                }
                if (componente.Quantita <= 0)
                {
                    esito = false;
                    componente.Errore = "Inserire Quantità ";
                }
                if (componente.IdDiba < 0)
                {
                    esito = false;
                    componente.Errore = "Codice diba non valido";
                }
            }
            return esito;
        }
    }
}