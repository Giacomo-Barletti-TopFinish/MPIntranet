using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPIntranet.Models.Anagrafica;

namespace MPIntranet.Models.Documenti
{
    public class DocumentoModel
    {
        public decimal IdDocumento { get; set; }
        public TipoDocumentoModel TipoDocumento { get; set; }
        public string Filename{ get; set; }

    }

    public class DocumentoModelContainer
    {
        public decimal IdEsterna { get; set; }

        public string TabellaEsterna { get; set; }

        public List<DocumentoModel> Documenti { get; set; }
    }
}
