using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Anagrafica
{
    public class ColoreModel
    {
        public decimal IdColore { get; set; }
        public string Codice { get; set; }
        public string Descrizione { get; set; }
        public decimal IdBrand { get; set; }
        public string Brand { get; set; }
        public string CodiceFigurativo { get; set; }
        public string CodiceCliente { get; set; }

        public override string ToString()
        {
            return string.Format("{0}-{1}", CodiceFigurativo, Descrizione);
        }
        public static ColoreModel ColoreNullo()
        {
            ColoreModel colore = new ColoreModel();
            colore.IdColore = ElementiVuoti.ColoreVuoto;
            colore.IdBrand = ElementiVuoti.BrandVuoto;
            return colore;
        }
    }
}
