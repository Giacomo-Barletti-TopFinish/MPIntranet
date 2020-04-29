using MPIntranet.Models.Anagrafica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Articolo
{
    public class PreventivoCostoModel
    {
        public decimal IdPreventivoCosto { get; set; }
        public decimal Versione { get; set; }
        public string Descrizione { get; set; }
        public string Nota { get; set; }
        public PreventivoModel Preventvo { get; set; }
        public decimal Margine { get; set; }
        public decimal Prezzo { get; set; }
        public decimal Costo { get; set; }

        public override string ToString()
        {
            return string.Format("{0}-{1}", Versione.ToString(), Descrizione);
        }
    }

    public class ElementoCostoPreventivoModel
    {
        public decimal IdElementoCosto { get; set; }
        public decimal IdPreventivoCosto { get; set; }
        public ElementoPreventivoModel ElementoPreventivo { get; set; }
        public decimal Ricarico { get; set; }
        public decimal CostoOrario { get; set; }
        public bool IncludiPreventivo { get; set; }
        public decimal IdEsterna { get; set; }
        public string TabellaEsterna { get; set; }
        public decimal PezziOrari { get; set; }
        public decimal Quantita { get; set; }
        public decimal CostoArticolo { get; set; }
        public decimal CostoFigli{ get; set; }
        public decimal CostoCompleto { get; set; }
        public override string ToString()
        {
            return ElementoPreventivo.ToString();
        }
    }

    public class CostoFissoPreventivoModel
    {
        public decimal IdCostoFissoPreventivo { get; set; }
        public decimal IdPreventivoCosto { get; set; }
        public string Codice { get; set; }
        public string Descrizione { get; set; }
        public decimal Ricarico { get; set; }
        public decimal Costo { get; set; }
        public decimal Prezzo { get; set; }
        public override string ToString()
        {
            return string.Format("{0}-{1}", Codice, Descrizione);
        }
    }
}
