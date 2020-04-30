using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Anagrafica
{
    public class PrezzoMaterialeModel
    {
        public decimal IdPrezzoMateriale { get; set; }
        public DateTime DataInizioValidita { get; set; }
        public decimal Prezzo{ get; set; }
        public string Nota { get; set; }
        public MaterialeModel Materiale{ get; set; }

      
    }
}
