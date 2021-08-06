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

        public List<Componente> Componenti { get; set; }

        public void Cancella(string utente)
        {
            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                bArticolo.GetDistintaBase(ds, IdDiba);
                ArticoliDS.DIBARow riga = ds.DIBA.Where(x => x.IDDIBA == IdDiba).FirstOrDefault();
                if (riga != null)
                {
                    riga.CANCELLATO = true;
                    riga.UTENTEMODIFICA = utente;
                    riga.DATAMODIFICA = DateTime.Now;

                }
                bArticolo.UpdateTable(ds.DIBA.TableName, ds);
            }
        }

        public void CreaDaDistintaBC(DistintaBC distintaBC, int idDiba, string utente)
        {
            int idComponente = 0;
            int idPadre = 0;
            creaDaDistintaBCRicorsiva(distintaBC, string.Empty, 0, idDiba, utente, ref idComponente);

        }
        private void creaDaDistintaBCRicorsiva(DistintaBC distintaBC, string anagraficaPadre, int idPadre, int idDiba, string utente, ref int idComponente)
        {
            foreach (ComponenteBC componenteBC in distintaBC.Componenti.Where(x => x.IdPadre == anagraficaPadre))
            {
                idComponente--;
                Componente componente = Componente.CreaComponente(componenteBC, idDiba, idComponente, idPadre, utente);
                Componenti.Add(componente);
                foreach (ComponenteBC figlio in distintaBC.Componenti.Where(x => x.IdPadre == componenteBC.Anagrafica))
                    creaDaDistintaBCRicorsiva(distintaBC, componenteBC.Anagrafica, componente.IdComponente, idDiba, utente, ref idComponente);
            }
        }
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

            distinta.Cancellato = riga.CANCELLATO;
            distinta.DataModifica = riga.DATAMODIFICA;
            distinta.UtenteModifica = riga.UTENTEMODIFICA;
            distinta.Componenti = Componente.EstraiListaComponenti(riga.IDDIBA);
            return distinta;
        }

        public void Copia(DistintaBase distintaDestinazione, string utente)
        {
            int idComponente = 0;
            int idPadre = 0;
            copiaDistintaRicorsiva(distintaDestinazione, 0, utente, ref idComponente);

        }
        private void copiaDistintaRicorsiva(DistintaBase distintaDestinazione, int idPadre, string utente, ref int idComponente)
        {
            foreach (Componente componenteOrigine in Componenti.Where(x => x.IdPadre == idPadre))
            {
                idComponente--;
                Componente componenteNuovo = componenteOrigine.Copia(idComponente, idPadre, distintaDestinazione.IdDiba);
                distintaDestinazione.Componenti.Add(componenteNuovo);

                foreach (Componente figlioOrigine in Componenti.Where(x => x.IdPadre == componenteOrigine.IdComponente))
                    copiaDistintaRicorsiva(distintaDestinazione, componenteOrigine.IdComponente, utente, ref idComponente);
            }
        }
        public void ConvertiAnagraficaInProduzione()
        {
            foreach (Componente componente in Componenti)
            {
                componente.Anagrafica = convertiAnagraficaProduzione(componente.Anagrafica);

                foreach (FaseCiclo fase in componente.FasiCiclo)
                    fase.Anagrafica = convertiAnagraficaProduzione(fase.Anagrafica);
            }
        }
        private string convertiAnagraficaProduzione(string anagraficaDaConvertire)
        {
            if (!string.IsNullOrEmpty(anagraficaDaConvertire) && anagraficaDaConvertire.Length > 2)
            {
                if (anagraficaDaConvertire[1] == '-')
                    return "A" + anagraficaDaConvertire.Remove(0, 1);
            }
            return anagraficaDaConvertire;
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

        public bool CorreggiCollegamentoDibaCiclo(out string errori)
        {
            errori = string.Empty;
            Componente articolo = Componenti.Where(x => x.IdPadre == 0).FirstOrDefault();
            articolo.CollegamentoDiBa = string.Empty;
            bool esito = verificaCodiceCollegamentoRicorsivo(articolo, out errori);
            return esito;
        }

        private bool verificaCodiceCollegamentoRicorsivo(Componente articolo, out string errori)
        {
            errori = string.Empty;
            StringBuilder sbErrori = new StringBuilder();

            bool esito = true;
            List<Componente> componentiFigli = Componenti.Where(x => x.IdPadre == articolo.IdComponente).ToList();
            componentiFigli.ForEach(x => x.CollegamentoDiBa = ExpCicloBusinessCentral.CodiceCollegamentoStandard);
            List<FaseCiclo> fasi = articolo.FasiCiclo.OrderBy(x => x.Operazione).ToList();
            if (componentiFigli.Count > 0)
            {
                if (fasi.Count > 0)
                {
                    fasi[0].CollegamentoCiclo = ExpCicloBusinessCentral.CodiceCollegamentoStandard;
                    fasi[0].Errore = string.Empty;
                    if (!string.IsNullOrEmpty(fasi[0].Anagrafica))
                    {
                        string msg = string.Format("La fase {0} dell'articolo {1} non dovrebbe avere alcuna anagrafica valorizzata. Verificare codice collegamento ciclo.", fasi[0].IdFaseCiclo, articolo.IdComponente);
                        sbErrori.AppendLine(msg);
                        esito = false;
                        fasi[0].Errore = msg;
                    }
                }
                foreach (Componente figlio in componentiFigli)
                {
                    errori = string.Empty;
                    esito = esito && verificaCodiceCollegamentoRicorsivo(figlio, out errori);
                    sbErrori.AppendLine(errori);
                }
            }
            bool trovataAnagrafica = false;
            foreach (FaseCiclo fase in fasi)
            {
                fase.Errore = string.Empty;
                fase.CollegamentoCiclo = string.Empty;
                fase.CollegamentoDiBa = string.Empty;

                if (trovataAnagrafica)
                {
                    fase.CollegamentoCiclo = ExpCicloBusinessCentral.CodiceCollegamentoStandard;
                    trovataAnagrafica = false;
                }
                if (!string.IsNullOrEmpty(fase.Anagrafica))
                {
                    trovataAnagrafica = true;
                    fase.CollegamentoDiBa = ExpCicloBusinessCentral.CodiceCollegamentoStandard;
                }
            }

            if (fasi.Count > 0 && !string.IsNullOrEmpty(fasi[fasi.Count - 1].Anagrafica))
            {
                string msg = string.Format("La fase {0} dell'articolo {1} non dovrebbe avere alcuna anagrafica valorizzata. Verificare codice collegamento ciclo e diba.", fasi[fasi.Count - 1].IdFaseCiclo, articolo.IdComponente);
                sbErrori.AppendLine(msg);
                esito = false;
                fasi[fasi.Count - 1].Errore = msg;
            }

            errori = sbErrori.ToString();
            return esito;
        }
    }
}
