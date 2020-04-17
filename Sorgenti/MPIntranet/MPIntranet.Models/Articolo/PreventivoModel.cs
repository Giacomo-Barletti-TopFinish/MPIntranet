using MPIntranet.Models.Anagrafica;
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

    public class ElementoPreventivoModel
    {
        public decimal IdElementoPreventivo { get; set; }
        public decimal IdPadre { get; set; }
        public string Codice { get; set; }
        public RepartoModel Reparto { get; set; }
        public decimal Ricarico { get; set; }
        public decimal Costo { get; set; }
        public bool IncludiPreventivo { get; set; }
        public decimal IdEsterna { get; set; }
        public string TabellaEsterna { get; set; }
        public decimal PezziOrari { get; set; }
        public decimal Peso { get; set; }
        public decimal Superficie { get; set; }
        public decimal Quantita { get; set; }
        public string Descrizione { get; set; }
        public string Articolo { get; set; }
        public override string ToString()
        {
            string str = Codice;
            if (string.IsNullOrEmpty(Articolo))
                str = string.Format("{0}-{1}", Articolo, str);

            if (Reparto != null)
                str += string.Format("({0})", Reparto.Codice);

            return str;
        }
    }
}
