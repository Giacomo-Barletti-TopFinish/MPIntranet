using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models
{
    public class ArticoloModel:BaseModel
    {
        public int IdArticolo{ get; set; }
        public BrandModel Brand{ get; set; }
        public string Descrizione { get; set; }
        public string Anagrafica { get; set; }
        public string Colore{ get; set; }
        public string CodiceCliente{ get; set; }
    }
}
