using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Json
{
    [DataContract]
    public class SalvaProcessoJson
    {
        [DataMember(Name = "idFaseProcesso")]
        public decimal IdFaseProcesso { get; set; }
        [DataMember(Name = "idvasca")]
        public decimal IdVasca { get; set; }
        [DataMember(Name = "durata")]
        public string Durata{ get; set; }
        [DataMember(Name = "corrente")]
        public string Corrente { get; set; }
    }
}
