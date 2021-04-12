using MPIntranet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class Documento : BaseModel
    {
        public int IdDocumento { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public string Filename { get; set; }
        public string Estensione { get; set; }
        public int IdEsterna { get; set; }
        public string TabellaEsterna { get; set; }
        public Blocco Blocco { get; set; }
    }
}
