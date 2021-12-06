using MPIntranet.Business.SchedeProcesso;
using MPIntranet.DataAccess.Articoli;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    /// <summary>
    /// Classe per la gestione delle distinte provenienti da business central
    /// </summary>
    public class DistintaBC
    {
        public string Codice { get; set; }
        public string Descrizione { get; set; }
        public string Descrizione2 { get; set; }
        public string UnitaMisura { get; set; }
        public string Versione { get; set; }
        public int Stato { get; set; }
        public List<ComponenteBC> Componenti { get; set; }
        private int idComponente = 0;
        public static DistintaBC EstraiDistintaBase(string idDiba)
        {
            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                bArticolo.GetDistinteBCTestata(ds, idDiba);
            }
            ArticoliDS.DistinteBCTestataRow riga = ds.DistinteBCTestata.Where(x => x.No_ == idDiba).FirstOrDefault();
            return CreaDistintaBC(riga);
        }

        public void CaricaSchedeProcesso()
        {
            foreach (ComponenteBC componente in Componenti)
            {
                if (!string.IsNullOrEmpty(componente.Anagrafica))
                {
                    List<SpScheda> schede = SpScheda.EstraiSPScheda(componente.Anagrafica, true);
                    if (schede.Count > 0)
                    {
                        foreach (FaseCicloBC fase in componente.FasiCiclo)
                        {
                            SpScheda scheda = schede.Where(x => x.AreaProduzione == fase.AreaProduzione && x.Task == fase.Task).FirstOrDefault();
                            if (scheda != null)
                            {
                                fase.SchedaProcesso = scheda.Codice;
                                foreach (SPValoreScheda valore in scheda.ValoriScheda)
                                {
                                    switch (valore.IdSPControllo)
                                    {
                                        case 145:
                                            {
                                                decimal v;
                                                if (decimal.TryParse(valore.Valore, out v))
                                                    fase.PezziPeriodo = v;
                                            }
                                            break;

                                        case 147:
                                            {
                                                decimal v;
                                                if (decimal.TryParse(valore.Valore, out v))
                                                    fase.Periodo = v;
                                            }
                                            break;

                                        case 15:
                                            {
                                                decimal v;
                                                if (decimal.TryParse(valore.Valore, out v))
                                                {
                                                    fase.PezziPeriodo = v;
                                                    fase.Periodo = 1;
                                                }
                                            }
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public static List<DistintaBC> EstraiListaDistinteBase(string codiceTestata)
        {
            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                bArticolo.GetDistinteBCTestata(ds, codiceTestata);
            }
            List<DistintaBC> distinte = new List<DistintaBC>();
            foreach (ArticoliDS.DistinteBCTestataRow riga in ds.DistinteBCTestata)
            {
                DistintaBC distinta = CreaDistintaBC(riga);
                distinte.Add(distinta);
            }
            return distinte;
        }
        private static DistintaBC CreaDistintaBC(ArticoliDS.DistinteBCTestataRow riga)
        {

            if (riga == null) return null;
            DistintaBC distinta = new DistintaBC();
            distinta.Codice = riga.No_;
            distinta.Descrizione = riga.Description;
            distinta.Descrizione2 = riga.Description_2;
            distinta.UnitaMisura = riga.Unit_of_Measure_Code;
            distinta.Stato = riga.Status;
            distinta.Versione = riga.Version_Nos_;

            distinta.Componenti = new List<ComponenteBC>();
            return distinta;
        }
        public void CaricaDistintaCompleta()
        {
            idComponente++;
            Componenti.Add(ComponenteBC.CreaComponente(idComponente, Codice, Descrizione, 0));
            aggiungiComponenteBC(Componenti, Codice, idComponente);
        }

        private void aggiungiComponenteBC(List<ComponenteBC> Componenti, string codiceDistinta, int IdComponentePadre)
        {
            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticoli = new ArticoliBusiness())
            {
                bArticoli.GetDistinteBCTestata(ds, codiceDistinta);
                List<ArticoliDS.DistinteBCTestataRow> testata = ds.DistinteBCTestata.Where(x => x.No_ == codiceDistinta).ToList();

                if (testata == null) return;
                bArticoli.GetDistinteBCDettaglio(ds, codiceDistinta);

                List<ArticoliDS.DistinteBCDettaglioRow> dettagli = ds.DistinteBCDettaglio.Where(x => x.Production_BOM_No_ == codiceDistinta).ToList();
                if (dettagli.Count > 0)
                {
                    foreach (ArticoliDS.DistinteBCDettaglioRow dettaglio in dettagli)
                    {
                        idComponente++;
                        ComponenteBC componente = ComponenteBC.CreaComponente(dettaglio, idComponente, IdComponentePadre);
                        Componenti.Add(componente);
                        aggiungiComponenteBC(Componenti, componente.Anagrafica, idComponente);
                    }
                }
            }
        }
        private List<FaseDistinta> estraiListaFasi(string codiceTestata, int idFaseDistinta, int idPadre)
        {
            ArticoliDS ds = new ArticoliDS();
            List<FaseDistinta> fasi = new List<FaseDistinta>();

            using (ArticoliBusiness bArticoli = new ArticoliBusiness())
            {
                bArticoli.GetDistinteBCTestata(ds, codiceTestata);
                bArticoli.GetDistinteBCDettaglio(ds, codiceTestata);
                bArticoli.GetCicliBCTestata(ds, codiceTestata);
                bArticoli.GetCicliBCDettaglio(ds, codiceTestata);
                ArticoliDS.DistinteBCTestataRow testata = ds.DistinteBCTestata.Where(x => x.No_ == codiceTestata).FirstOrDefault();
                List<ArticoliDS.CicliBCDettaglioRow> cicli = ds.CicliBCDettaglio.Where(x => x.Routing_No_ == codiceTestata).ToList();

                for (int i = 0; i < cicli.Count; i++)
                {
                    if (i == 0)
                    {
                        FaseDistinta fase = FaseDistinta.CreaFaseDistinta(testata, cicli[i], idFaseDistinta, idPadre);
                        fasi.Add(fase);
                        idPadre = idFaseDistinta;
                    }
                    else
                    {
                        FaseDistinta fase = FaseDistinta.CreaFaseDistinta(cicli[i], idFaseDistinta, idPadre);
                        fasi.Add(fase);
                        idPadre = idFaseDistinta;
                    }
                    idFaseDistinta++;
                }
                List<ArticoliDS.DistinteBCDettaglioRow> componenti = ds.DistinteBCDettaglio.Where(x => x.Production_BOM_No_ == codiceTestata).ToList();

                foreach (ArticoliDS.DistinteBCDettaglioRow componente in componenti)
                {
                    fasi.AddRange(estraiListaFasi(componente.No_, idFaseDistinta, idPadre));
                }

            }

            return fasi;
        }
        public bool TrovaComponente(string Anagrafica, out ComponenteBC componenteTrovato)
        {
            componenteTrovato = null;
            foreach (ComponenteBC componente in Componenti)
            {
                if (componente.Anagrafica == Anagrafica)
                {
                    componenteTrovato = componente;
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Codice, Descrizione);
        }

    }

}
