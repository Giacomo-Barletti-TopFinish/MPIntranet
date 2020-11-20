using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Report
{
    public class BolleVenditaModel
    {
        public string Azienda { get; set; }
        public string CodiceTipoO { get; set; }
        public string DescrizioneTipoO { get; set; }
        public string Causale { get; set; }
        public string DescrizioneCausale { get; set; }
        public string FullNumDoc { get; set; }
        public DateTime DataDocumento { get; set; }
        public string Numero { get; set; }
        public string Segnalatore { get; set; }
        public string Cliente { get; set; }
        public string NumeroRiga { get; set; }
        public string Modello { get; set; }
        public decimal Quantita { get; set; }
        public decimal Prezzo { get; set; }
        public decimal Valore { get; set; }
        public string Ordine { get; set; }
        public string DataOrdine { get; set; }
        public string DataRichiesta { get; set; }
        public string DataConferma { get; set; }

        public string Riferimento { get; set; }
    }
}
