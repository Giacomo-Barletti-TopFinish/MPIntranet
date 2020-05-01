using MPIntranet.Models.Anagrafica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Galvanica
{
    public class VascaModel
    {
        public decimal IdVasca{ get; set; }
        public string DescrizioneBreve { get; set; }
        public string Descrizione { get; set; }
        public bool AbilitaStrato{ get; set; }
        public decimal IdImpianto{ get; set; }
        public string Impianto { get; set; }
        public DateTime DataModifica { get; set; }
        public string UtenteModifica { get; set; }
        public MaterialeModel Materiale { get; set; }
    }
}
