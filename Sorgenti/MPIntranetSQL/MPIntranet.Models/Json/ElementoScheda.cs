using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Json
{
    [DataContract]
    public class ElementoScheda
    {
        [DataMember(Name = "IDValore")]
        public int IDValore { get; set; }
        [DataMember(Name = "IDElemento")]
        public int IDElemento { get; set; }
        [DataMember(Name = "Valore")]
        public string Valore { get; set; }
        [DataMember(Name = "Filename")]
        public string Filename { get; set; }
        [DataMember(Name = "Filedata")]
        public string Filedata { get; set; }

    }
}
