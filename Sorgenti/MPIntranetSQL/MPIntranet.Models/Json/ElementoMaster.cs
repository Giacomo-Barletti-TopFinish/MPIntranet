using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Json
{
    [DataContract]
    public class ElementoMaster
    {
        [DataMember(Name = "IDElemento")]
        public int IDElemento { get; set; }
        [DataMember(Name = "IDControllo")]
        public int IDControllo { get; set; }
        [DataMember(Name = "Testo")]
        public string Testo { get; set; }
        [DataMember(Name = "Tipo")]
        public string Tipo{ get; set; }
        [DataMember(Name = "Obbligatorio")]
        public bool Obbligatorio{ get; set; }

    }
}

