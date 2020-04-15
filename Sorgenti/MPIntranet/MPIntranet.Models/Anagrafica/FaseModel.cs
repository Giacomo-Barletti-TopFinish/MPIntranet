using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Anagrafica
{
    public class FaseModel
    {
        public decimal IdFase { get; set; }
        public string Codice { get; set; }
        public string Descrizione { get; set; }
        public RepartoModel Reparto { get; set; }
        public decimal Ricarico { get; set; }
        public decimal Costo { get; set; }
        public bool IncludiPreventivo { get; set; }
        public decimal IdEsterna { get; set; }
        public string TabellaEsterna { get; set; }

        public override string ToString()
        {
            return string.Format("{0}-{1}", Codice, Descrizione);
        }
    }
}
