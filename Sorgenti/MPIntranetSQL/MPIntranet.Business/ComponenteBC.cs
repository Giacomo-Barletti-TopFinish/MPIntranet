using MPIntranet.DataAccess.Articoli;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class ComponenteBC
    {
        public int IdComponente { get; set; }
        public string IdPadre { get; set; }
        public string Anagrafica { get; set; }
        public string Errore { get; set; }
        public string Descrizione { get; set; }
        public string CollegamentoDiBa { get; set; }
        public string UMQuantita { get; set; }
        public decimal Quantita { get; set; }
        public List<FaseCicloBC> FasiCiclo { get; set; }
        public int IdComponentePadre { get; set; } 
        public static ComponenteBC CreaComponente(ArticoliDS.DistinteBCDettaglioRow riga, int idComponente, int IdCompoentePadre)
        {

            if (riga == null) return null;
            ComponenteBC componente = new ComponenteBC();
            componente.IdComponente = idComponente;
            componente.IdComponentePadre = IdCompoentePadre;
            componente.IdPadre = riga.Production_BOM_No_;
            componente.Anagrafica = riga.No_;
            componente.Descrizione = riga.Description;
            componente.CollegamentoDiBa = riga.Routing_Link_Code;
            componente.UMQuantita = riga.Unit_of_Measure_Code;
            componente.Quantita = riga.Quantity;

            componente.Errore = string.Empty;
            componente.FasiCiclo = new List<FaseCicloBC>();


            componente.FasiCiclo = FaseCicloBC.EstraiListaFaseCiclo(componente.Anagrafica);

            return componente;
        }

        public static ComponenteBC CreaComponente(int idComponente ,string anagrafica, string descrizione, int IdCompoentePadre)
        {

            ComponenteBC componente = new ComponenteBC();
            componente.IdComponente = idComponente;
            componente.IdComponentePadre = IdCompoentePadre;
            componente.IdPadre = string.Empty;
            componente.Anagrafica = anagrafica;
            componente.Descrizione = descrizione;
            componente.CollegamentoDiBa = string.Empty;
            componente.UMQuantita = "NR";
            componente.Quantita = 1;

            componente.Errore = string.Empty;
            componente.FasiCiclo = new List<FaseCicloBC>();


            componente.FasiCiclo = FaseCicloBC.EstraiListaFaseCiclo(componente.Anagrafica);

            return componente;
        }

        public string CreaEtichetta()
        {
            return Anagrafica.Trim();
        }

    }
}
