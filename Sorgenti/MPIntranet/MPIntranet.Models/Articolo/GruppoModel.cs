using MPIntranet.Entities;
using MPIntranet.Models.Anagrafica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Articolo
{
    public class GruppoModel
    {
        public decimal IdGruppo { get; set; }
        public string Codice { get; set; }
        public string Descrizione { get; set; }
        public BrandModel Brand { get; set; }
        public string Colore { get; set; }

        public override string ToString()
        {
            return Codice;
        }

        public static GruppoModel GruppoVuoto
        {
            get
            {
                GruppoModel g = new GruppoModel();
                g.Brand = null;
                g.Codice = string.Empty;
                g.Colore = string.Empty;
                g.Descrizione = string.Empty;
                g.IdGruppo = ElementiVuoti.GruppoVuoto;
                return g;
            }
        }
    }

    public class GruppoRepartoModel
    {
        public decimal IdGruppoReparto { get; set; }
        public RepartoModel Reparto { get; set; }
        public GruppoModel Gruppo { get; set; }
    }
}
