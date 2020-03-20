using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Manutenzione
{
    public class MacchinaModel
    {
        public decimal IdMacchina { get; set; }
        public string NumeroSerie { get; set; }
        public string Descrizione { get; set; }
        public string Nota { get; set; }
        public string Luogo { get; set; }
        public DittaModel Ditta{ get; set; }
        public string DataCostruzione{ get; set; }
        public MacchinaModel Padre{ get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1})",Descrizione,NumeroSerie);
        }
    }
}
