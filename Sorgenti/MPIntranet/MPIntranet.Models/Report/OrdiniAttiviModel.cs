using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Report
{
    public class OrdiniAttiviModel
    {
        public string Cliente { get; set; }
        public decimal Quantita { get; set; }
        public decimal QuantitaNonSpedita{ get; set; }
        public decimal QuantitaAnnullata { get; set; }
        public decimal QuantitaScaduta{ get; set; }
        public decimal Valore { get; set; }
        public decimal ValoreNonSpedito { get; set; }
        public decimal ValoreAnnullato { get; set; }
        public decimal ValoreScaduto { get; set; }
        public decimal ValoreNonScaduto { get; set; }
        public decimal PercScadutoCliente { get; set; }
        public decimal PercScadutoSulTotale{ get; set; }
        public string Azienda { get; set; }
    }
}
