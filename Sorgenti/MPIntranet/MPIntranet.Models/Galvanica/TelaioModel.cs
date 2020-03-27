using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Galvanica
{
    public class TelaioModel
    {
        public decimal IdTelaio { get; set; }
        public string Codice { get; set; }
        public decimal Pezzi { get; set; }
        public string TipoMontaggio { get; set; }
        public decimal CostoStandard { get; set; }

        public override string ToString()
        {
            return string.Format("{0}({1})", Codice, Pezzi);
        }
    }
}
