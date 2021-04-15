using MPIntranet.Business;
using MPIntranet.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPIntranetWeb
{
    public class DocumentoCaricatoModel
    {
        public string TabellaEsterna { get; set; }
        public int IdEsterna { get; set; }
        public string SelectedTipoDocumento { get; set; }
        public List<Documento> Documenti { get; set; }

        public List<MPIntranetListItem> TipiDocumento { get; set; }
        public HttpPostedFileBase Attachment { get; set; }
    }
}