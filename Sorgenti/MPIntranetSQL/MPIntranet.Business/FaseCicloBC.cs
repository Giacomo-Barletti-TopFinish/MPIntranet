using MPIntranet.DataAccess.Articoli;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class FaseCicloBC
    {
        public string Descrizione { get; set; }
        public string IdComponente { get; set; }
        public string Operazione { get; set; }
        public string CollegamentoDiBa { get; set; }
        public string UMQuantita { get; set; }
        public double Quantita { get; set; }
        public string AreaProduzione { get; set; }
        public string Task { get; set; }
        public string SchedaProcesso { get; set; }
        public string CollegamentoCiclo { get; set; }
        public decimal PezziPeriodo { get; set; }
        public decimal Periodo { get; set; }
        public decimal Setup { get; set; }
        public decimal Attesa { get; set; }
        public decimal Movimentazione { get; set; }
        public string Errore { get; set; }
        public string Nota { get; set; }

        public static List<FaseCicloBC> EstraiListaFaseCiclo(string codiceCiclo)
        {
            List<FaseCicloBC> fasiCiclo = new List<FaseCicloBC>();
            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                bArticolo.GetCicliBCTestata(ds, codiceCiclo);
                bArticolo.GetCicliBCCommenti(ds, codiceCiclo);

                ArticoliDS.CicliBCTestataRow testata = ds.CicliBCTestata.Where(x => x.No_ == codiceCiclo).FirstOrDefault();
                if (testata == null) return fasiCiclo;

                bArticolo.GetCicliBCDettaglio(ds, codiceCiclo);
                List<ArticoliDS.CicliBCDettaglioRow> dettagli = ds.CicliBCDettaglio.Where(x => x.Routing_No_ == codiceCiclo).OrderBy(x => x.Operation_No_).ToList();

                foreach (ArticoliDS.CicliBCDettaglioRow riga in ds.CicliBCDettaglio)
                {
                    FaseCicloBC faseCiclo = CreaFaseCiclo(riga, codiceCiclo, ds);
                    fasiCiclo.Add(faseCiclo);
                }
            }
            return fasiCiclo;
        }



        private static FaseCicloBC CreaFaseCiclo(ArticoliDS.CicliBCDettaglioRow riga, string codiceCiclo, ArticoliDS ds)
        {
            if (riga == null) return null;
            FaseCicloBC faseCiclo = new FaseCicloBC();
            faseCiclo.IdComponente = codiceCiclo;
            faseCiclo.Descrizione = riga.Description;
            faseCiclo.Operazione = riga.Operation_No_;
            faseCiclo.CollegamentoDiBa = string.Empty;
            faseCiclo.Quantita = 0;
            faseCiclo.UMQuantita = string.Empty;
            faseCiclo.AreaProduzione = riga.Work_Center_No_;
            faseCiclo.Task = riga.Standard_Task_Code;
            faseCiclo.SchedaProcesso = riga.MTP_Card_Code;
            faseCiclo.CollegamentoCiclo = string.IsNullOrEmpty(riga.Routing_Link_Code) ? string.Empty : riga.Routing_Link_Code;
            faseCiclo.PezziPeriodo = riga.Lot_Size;
            faseCiclo.Periodo = riga.Run_Time;
            faseCiclo.Setup = riga.Setup_Time;
            faseCiclo.Attesa = riga.Wait_Time;
            faseCiclo.Movimentazione = riga.Move_Time;
            faseCiclo.Errore = string.Empty;
            faseCiclo.Nota = string.Empty;

            List<ArticoliDS.CicliBCCommentiRow> commenti = ds.CicliBCCommenti.Where(x => x.Routing_No_ == codiceCiclo && x.Operation_No_ == riga.Operation_No_).ToList();
            string nota = string.Empty;
            foreach (ArticoliDS.CicliBCCommentiRow commento in commenti)
                nota += commento.Comment;

            nota = nota.Trim();
            int posizione = nota.IndexOf(FaseCiclo.EtichettaSchedaProcesso);
            if (posizione > -1)
            {
                nota = nota.Substring(posizione + FaseCiclo.EtichettaSchedaProcesso.Length + 1);
                string[] str = nota.Split(' ');
                if (str.Count() > 0)
                {
                    faseCiclo.SchedaProcesso = str[0];
                    nota = nota.Replace(str[0], string.Empty).Trim();
                }
            }
            faseCiclo.Nota = nota.Trim();

            return faseCiclo;
        }

    }
}
