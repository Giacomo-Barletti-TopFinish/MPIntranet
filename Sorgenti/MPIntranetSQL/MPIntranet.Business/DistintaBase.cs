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
    public class DistintaBase : BaseModel
    {
        public int IdDiba { get; set; }
        public int Versione { get; set; }
        public TipoDistinta TipoDistinta { get; set; }
        public Articolo Articolo { get; set; }
        public string Descrizione { get; set; }
        public bool Standard { get; set; }
        public List<FaseDistinta> Fasi { get; set; }

        public List<Componente> Componenti { get; set; }

        public static DistintaBase EstraiDistintaBase(int idDiba)
        {
            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                bArticolo.GetDistintaBase(ds, idDiba);
            }
            ArticoliDS.DIBARow riga = ds.DIBA.Where(x => x.IDDIBA == idDiba).FirstOrDefault();
            return CreaDistintaBase(riga);
        }
        public bool TrovaComponente(int IdCompenente, out Componente componenteTrovato)
        {
            componenteTrovato = null;
            foreach (Componente componente in Componenti)
            {
                if (componente.IdComponente == IdCompenente)
                {
                    componenteTrovato = componente;
                    return true;
                }
            }
            return false;
        }
        public static List<DistintaBase> EstraiListaDistinteBase(int idArticolo)
        {
            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                bArticolo.FillDistintaBase(ds, idArticolo, true);
            }
            List<DistintaBase> distinte = new List<DistintaBase>();
            foreach (ArticoliDS.DIBARow riga in ds.DIBA)
            {
                DistintaBase distinta = CreaDistintaBase(riga);
                distinte.Add(distinta);
            }
            return distinte;
        }
        private static DistintaBase CreaDistintaBase(ArticoliDS.DIBARow riga)
        {

            if (riga == null) return null;
            DistintaBase distinta = new DistintaBase();
            distinta.IdDiba = riga.IDDIBA;
            distinta.TipoDistinta = TipoDistinta.EstraiTipoDistinta(riga.IDTIPODIBA);
            distinta.Articolo = Articolo.EstraiArticolo(riga.IDARTICOLO);
            distinta.Descrizione = riga.DESCRIZIONE;
            distinta.Versione = riga.VERSIONE;
            distinta.Standard = riga.STANDARD;

            distinta.Componenti = new List<Componente>();
            distinta.Fasi = new List<FaseDistinta>();

            distinta.Cancellato = riga.CANCELLATO;
            distinta.DataModifica = riga.DATAMODIFICA;
            distinta.UtenteModifica = riga.UTENTEMODIFICA;
            distinta.Fasi = FaseDistinta.EstraiListaFaseDistinta(riga.IDDIBA);
            distinta.Componenti = Componente.EstraiListaComponenti(riga.IDDIBA);
            return distinta;
        }

        public static string CreaDistinta(int idArticolo, int idTipoDistinta, int versione, string descrizione, bool standard, string account, out int idDiba)
        {
            idDiba = ElementiVuoti.DistintaBase;
            Articolo articolo = Articolo.EstraiArticolo(idArticolo);
            if (articolo == null) return "Articolo non valido";

            TipoDistinta tipoDistinta = TipoDistinta.EstraiTipoDistinta(idTipoDistinta);
            if (tipoDistinta == null) return "Tipo distinta non valido";

            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                ArticoliDS.DIBARow dibaNuova = ds.DIBA.NewDIBARow();
                dibaNuova.IDARTICOLO = idArticolo;
                dibaNuova.IDTIPODIBA = idTipoDistinta;
                dibaNuova.DESCRIZIONE = descrizione;
                dibaNuova.VERSIONE = versione;
                dibaNuova.STANDARD = standard;
                dibaNuova.CANCELLATO = false;
                dibaNuova.DATAMODIFICA = DateTime.Now;
                dibaNuova.UTENTEMODIFICA = account;

                ds.DIBA.AddDIBARow(dibaNuova);
                bArticolo.UpdateDistintaBaseTable(ds);
                idDiba = dibaNuova.IDDIBA;
            }
            return "Distinta creata correttamente";
        }

        public void SalvaListaFasiDistinta(string utente)
        {
            if (Fasi.Count() == 0) return;
            int idDiba = Fasi[0].IdDiba;

            FaseDistinta.SalvaListaFasiDistinta(Fasi, utente);
        }

        public void Salva(string utente)
        {
            if (Componenti.Count() == 0) return;

            Componente.SalvaListaComponenti(Componenti, utente);
        }
        public bool VerificaPerSalvataggio()
        {
            bool esito = true;
            esito = Componente.VerificaListaPerSalvataggio(Componenti);

            return esito;
        }

        public bool Esporta(List<ExpDistintaBusinessCentral> distinteExport, List<ExpCicloBusinessCentral> cicliExport, out string errori)
        {
            errori = string.Empty;

            bool esito = true;
            Componente articolo = Componenti.Where(x => x.IdPadre == 0).FirstOrDefault();
            esito = esito && creaListaEsportaRicorsiva(distinteExport, cicliExport, articolo, out errori);

            return esito;
        }

        private bool creaListaEsportaRicorsiva(List<ExpDistintaBusinessCentral> distinteExport, List<ExpCicloBusinessCentral> cicliExport, Componente articolo, out string errori)
        {
            bool esito = true;
            errori = string.Empty;
            string errore = string.Empty;

            StringBuilder sb = new StringBuilder();
            string codiceDistinta = articolo.Anagrafica;
            ExpDistintaBusinessCentral distinta = new ExpDistintaBusinessCentral(codiceDistinta);
            ExpCicloBusinessCentral ciclo = new ExpCicloBusinessCentral(codiceDistinta);
            foreach (FaseCiclo faseCiclo in articolo.FasiCiclo.OrderByDescending(x => x.Operazione))
            {
                if (string.IsNullOrEmpty(faseCiclo.Anagrafica))
                {
                    errore = string.Empty;
                    if (!ciclo.AggiungiFase(faseCiclo, out errore))
                    {
                        esito = false;
                        sb.AppendLine(errore);
                    }
                }
                else
                {
                    ExpComponenteDistintaBusinessCentral componente = new ExpComponenteDistintaBusinessCentral(faseCiclo.Anagrafica, faseCiclo.Quantita, faseCiclo.CollegamentoDiBa, faseCiclo.UMQuantita, faseCiclo.IdFaseCiclo, articolo.Anagrafica);
                    distinta.Componenti.Add(componente);
                    distinteExport.Add(distinta);
                    if (ciclo.Fasi.Count > 0)
                        cicliExport.Add(ciclo);
                    codiceDistinta = componente.Anagrafica;
                    distinta = new ExpDistintaBusinessCentral(codiceDistinta);
                    ciclo = new ExpCicloBusinessCentral(codiceDistinta);
                    errore = string.Empty;

                    if (!ciclo.AggiungiFase(faseCiclo, out errore))
                    {
                        esito = false;
                        sb.AppendLine(errore);
                    }
                }
            }
            List<Componente> componentiArticolo = Componenti.Where(x => x.IdPadre == articolo.IdComponente).ToList();
            foreach (Componente componenteArticolo in componentiArticolo)
            {
                ExpComponenteDistintaBusinessCentral componente = new ExpComponenteDistintaBusinessCentral(componenteArticolo.Anagrafica, componenteArticolo.Quantita, componenteArticolo.CollegamentoDiBa, componenteArticolo.UMQuantita, componenteArticolo.IdComponente, codiceDistinta);
                distinta.Componenti.Add(componente);
            }
            distinteExport.Add(distinta);
            if (ciclo.Fasi.Count > 0)
                cicliExport.Add(ciclo);

            foreach (Componente componenteArticolo in componentiArticolo)
            {
                errore = string.Empty;
                esito = esito && creaListaEsportaRicorsiva(distinteExport, cicliExport, componenteArticolo, out errore);
                sb.AppendLine(errore);
            }
            errori = sb.ToString();
            return esito;
        }
    }
}
