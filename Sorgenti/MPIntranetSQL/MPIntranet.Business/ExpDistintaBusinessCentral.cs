using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class ExpDistintaBusinessCentral
    {
        public string Codice;
        public List<ExpComponenteDistintaBusinessCentral> Componenti = new List<ExpComponenteDistintaBusinessCentral>();
        public string Versione = string.Empty;

        public ExpDistintaBusinessCentral(string Codice, List<ExpComponenteDistintaBusinessCentral> Componenti)
        {
            this.Codice = Codice;
            this.Componenti = Componenti;
        }
        public ExpDistintaBusinessCentral(string Codice)
        {
            this.Codice = Codice;
            this.Componenti = new List<ExpComponenteDistintaBusinessCentral>(); ;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("DISTINTA {0}",Codice));
            Componenti.ForEach(x => sb.AppendLine(x.ToString()));
            return sb.ToString();
        }
    }

    public class ExpComponenteDistintaBusinessCentral
    {
        public int ID { get; set; }
        public string Tipo = "Articolo";
        public string Descrizione = string.Empty;
        public string CodiceUM = "KG";
        public string Anagrafica { get; set; }
        public double Quantita { get; set; }
        public string Collegamento;
        public double Scarto = 0;
        public double Arrotondamento = 1.0D / 1000;
        public double PrecisionQuantity = 0;
        public string FormulaQuantita = string.Empty;
        public string Condizione = string.Empty;
        public string ArticoloNeutro = string.Empty;
        public string Formula = string.Empty;
        public string DistintaPadre { get; set; }
        public bool Selezionato { get; set; }
        public string Errore { get; set; }
        public string Esito { get; set; }
        public ExpComponenteDistintaBusinessCentral(string Anagrafica, double Quantita, string Collegamento, string UM, int ID, string DistintaPadre)
        {
            this.Anagrafica = Anagrafica;
            this.Quantita = Quantita;
            this.Collegamento = Collegamento;
            this.CodiceUM = UM;
            this.ID = ID;
            this.DistintaPadre = DistintaPadre;
        }

        public override string ToString()
        {
            return string.Format("   -> {0}  {1} {2}", Anagrafica, Quantita.ToString(), CodiceUM);
        }
    }
}
