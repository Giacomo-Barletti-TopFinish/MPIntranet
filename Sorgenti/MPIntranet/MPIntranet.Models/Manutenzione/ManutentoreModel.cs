using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Manutenzione
{
    public class ManutentoreModel
    {
        public decimal IdManutentore { get; set; }
        public string NomeCognome { get; set; }
        public string Account { get; set; }
        public string Nota { get; set; }
        public DittaModel Ditta { get; set; }
        public RiferimentoModelContainer Riferimenti { get; set; }
    }
}
