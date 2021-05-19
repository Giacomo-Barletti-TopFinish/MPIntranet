using MPIntranet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class FaseDistinta: BaseModel
    {
        public int IdFaseDiba { get; set; }
        public int IdPadre { get; set; }
        public int IdDiba { get; set; }
        public string Descrizione { get; set; }
        public string Anagrafica { get; set; }
        public string AreaProduzione{ get; set; }
        public string Task { get; set; }
        public string SchedaProcesso { get; set; }
        public string CollegamentoDiba { get; set; }
        public string CollegamentoCiclo { get; set; }
        public decimal Quantita{ get; set; }
        public decimal PezziOrari { get; set; }
        public decimal Periodo { get; set; }
        public string UMQuantita{ get; set; }
        public decimal Setup { get; set; }
        public decimal Attesa{ get; set; }
        public decimal Movimentazione{ get; set; }

        public FaseDistinta(int idDiba)
        {
            IdDiba = idDiba;
        }

    }
}
