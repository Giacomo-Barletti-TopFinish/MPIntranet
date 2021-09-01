using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Json
{
    [DataContract]
    public class ElementoLista 
    {
        [DataMember(Name = "IDElemento")]
        public int IDElemento { get; set; }
        [DataMember(Name = "Codice")]
        public string Codice { get; set; }
        [DataMember(Name = "Descrizione")]
        public string Descrizione{ get; set; }
        [DataMember(Name = "Sequenza")]
        public string Sequenza { get; set; }

    }
}
