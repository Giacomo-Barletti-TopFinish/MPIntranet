using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Finiture_Burattovarie
{
   public class ProcessiModel
    {
        public decimal IdFbvProcesso { get; set; }
        public decimal IdArticolo{ get; set; }
        public decimal IdColore { get; set; }
        public string Descrizione { get; set; }
        public string Standard { get; set; }

    }
}
