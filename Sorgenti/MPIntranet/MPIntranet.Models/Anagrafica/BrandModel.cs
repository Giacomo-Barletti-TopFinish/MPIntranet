using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Anagrafica
{
    public class BrandModel
    {
        public decimal IdBrand { get; set; }
        public string Brand{ get; set; }
        public string CodiceGestionale{ get; set; }
        public string PrefissoColore { get; set; }
        public DateTime DataModifica { get; set; }
        public string UtenteModifica { get; set; }
    }
}
