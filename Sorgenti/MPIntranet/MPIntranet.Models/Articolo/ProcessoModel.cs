using MPIntranet.Models.Galvanica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Articolo
{
    public class ProcessoModel
    {
        public decimal IdProcesso { get; set; }
        public decimal IdArticolo { get; set; }
        public string Descrizione { get; set; }
        public ImpiantoModel Impianto { get; set; }
        public List<FaseProcessoModel> Fasi { get; set; }
    }

    public class FaseProcessoModel
    {
        public decimal IdFaseProcesso { get; set; }
        public decimal IdProcesso { get; set; }
        public VascaModel Vasca { get; set; }
        public string Durata { get; set; }
        public decimal Corrente { get; set; }
        public decimal Sequenza { get; set; }
    }
}
