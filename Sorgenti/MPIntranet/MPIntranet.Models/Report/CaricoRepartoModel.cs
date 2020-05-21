using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Report
{
    public class CaricoRepartoModel
    {
        public string Azienda { get; set; }
        public string Destipolancio { get; set; }
        public string Codicetipoo { get; set; }
        public string Ragionesoc { get; set; }
        public string Nummovfase { get; set; }
        public string Nomecommessa { get; set; }
        public string Segnalatore { get; set; }
        public string Codtipomovfase { get; set; }
        public string Modello_Lancio { get; set; }
        public string Modello_Wip { get; set; }
        public string Elencofasi { get; set; }
        public DateTime Datamovfase { get; set; }
        public decimal Qta { get; set; }
        public decimal Qtadater { get; set; }
        public decimal IdReparto { get; set; }
    }
}
