using MPIntranet.DataAccess.Articoli;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class DistintaBC
    {
        public string Codice { get; set; }
        public string Descrizione { get; set; }
        public string Descrizione2 { get; set; }
        public string UnitaMisura { get; set; }
        public int Stato { get; set; }
        public List<ComponenteBC> Componenti { get; set; }

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

            distinta.Componenti = new List<ComponenteBC>();
            return distinta;
        }
        public void CaricaDistintaCompleta()
        {
            Componenti.Add(ComponenteBC.CreaComponente(Codice, Descrizione));
            aggiungiComponenteBC(Componenti, Codice);
        }

        private void aggiungiComponenteBC(List<ComponenteBC> Componenti, string codiceDistinta)
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
                        ComponenteBC componente = ComponenteBC.CreaComponente(dettaglio);
                        Componenti.Add(componente);
                        aggiungiComponenteBC(Componenti, componente.Anagrafica);
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
