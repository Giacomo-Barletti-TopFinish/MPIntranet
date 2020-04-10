using MPIntranet.Models.Anagrafica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Articolo
{
    public class ProdottoFinitoModel
    {
        public decimal IdProdottoFinito { get; set; }
        public string Codice { get; set; }
        public string Modello { get; set; }
        public BrandModel Brand { get; set; }
        public ColoreModel Colore { get; set; }
        public TipoProdottoModel TipoProdotto { get; set; }
        public string Descrizione { get; set; }
        public string CodiceDefinitivo{ get; set; }
        public string CodiceProvvisorio { get; set; }
        public bool Prevenivo { get; set; }
        public bool Preserie { get; set; }
        public bool Produzione { get; set; }

    }
}
