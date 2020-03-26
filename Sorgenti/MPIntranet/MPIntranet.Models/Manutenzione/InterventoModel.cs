using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Manutenzione
{
    public class InterventoModel
    {
        public decimal IdIntervento { get; set; }
        public string Descrizione { get; set; }
        public decimal Durata { get; set; }
        public MacchinaModel Macchina { get; set; }
        public ManutentoreModel Manutentore{ get; set; }
        public decimal IdSerie { get; set; }
        public string Frequenza { get; set; }
        public string Nota { get; set; }
        public string Luogo { get; set; }
        public string Stato { get; set; }
        public DateTime DataIntervento { get; set; }
    }
}
