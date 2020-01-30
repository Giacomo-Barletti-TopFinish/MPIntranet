using MPIntranet.Models.Anagrafica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Articolo
{
    public class ArticoloModel
    {
        public decimal IdArticolo { get; set; }
        public string CodiceSAM { get; set; }
        public decimal ProgressivoSAM { get; set; }
        public string Descrizione { get; set; }
        public string Modello { get; set; }
        public string IDMAGAZZ { get; set; }
        public string CodiceCliente { get; set; }
        public string CodiceProvvisorio { get; set; }
        public DateTime DataModifica { get; set; }
        public string UtenteModifica { get; set; }
        public BrandModel Brand { get; set; }
        public ColoreModel Colore { get; set; }
        public string ImageUrl{ get; set; }
    }
}
