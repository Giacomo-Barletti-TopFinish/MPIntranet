using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Manutenzione
{
    public class RiferimentoModel
    {
        public decimal IdRiferimento { get; set; }

        public string Etichetta { get; set; }

        public string Riferimento { get; set; }

        public string Tipologia { get; set; }


    }

    public class RiferimentoModelContainer
    {
        public decimal IdEsterna { get; set; }

        public string TabellaEsterna { get; set; }

        public List<RiferimentoModel> Riferimenti { get; set; }
    }
}
