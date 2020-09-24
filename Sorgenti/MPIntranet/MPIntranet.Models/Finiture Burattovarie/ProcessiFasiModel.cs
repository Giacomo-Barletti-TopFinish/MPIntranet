using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Finiture_Burattovarie
{
    class ProcessiFasiModel
    {
        public decimal IdFbvProcessiFasi { get; set; }
        public decimal IdFbvFase { get; set; }
        public decimal IdFbvAttributi { get; set; }
        public string PezziOrari { get; set; }
        public DateTime Durata { get; set; }
        public string Sequenza { get; set; }
        public string Quantita { get; set; }
        public string Velocita { get; set; }
        public string Vibratore { get; set; }
        public string Barattolo { get; set; }
        public string Ricarico { get; set; }
        public string CostoOrario { get; set; }
    }
}
