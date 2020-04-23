using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Anagrafica
{
    public class CostoFissoModel
    {
        public decimal IdCostoFisso { get; set; }
        public string Codice { get; set; }
        public string Descrizione { get; set; }
        public decimal Costo { get; set; }
        public decimal Ricarico { get; set; }
        public override string ToString()
        {
            return string.Format("{0}-{1}", Codice, Descrizione);
        }
    }
}
