using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Anagrafica
{
    public class TipoDocumentoModel
    {
        public decimal IdTipoDocumento { get; set; }
        public string Descrizione { get; set; }
        public DateTime DataModifica { get; set; }
        public string UtenteModifica { get; set; }
        public override string ToString()
        {
            return Descrizione;
        }
    }
}
