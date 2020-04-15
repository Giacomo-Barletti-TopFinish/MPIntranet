using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Articolo
{
    public class PreventivoModel
    {
        public decimal IdPrevenivo { get; set; }
        public decimal Versione { get; set; }
        public string Descrizione { get; set; }
        public string Nota { get; set; }
        public ProdottoFinitoModel ProdottoFinito { get; set; }

        public override string ToString()
        {
            return string.Format("{0}-{1}", Versione.ToString(), Descrizione);
        }
    }
}
