using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Anagrafica
{
    public class MateriaPrimaModel
    {
        public decimal IdMateriaPrima { get; set; }
        public string Codice { get; set; }
        public string Descrizione { get; set; }
        public string Materiale { get; set; }
        public decimal Ricarico { get; set; }
        public decimal Costo { get; set; }
        public bool IncludiPreventivo { get; set; }
    }
}
