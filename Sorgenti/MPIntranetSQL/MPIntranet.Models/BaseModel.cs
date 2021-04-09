using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models
{
    public class BaseModel
    {
        public bool Cancellato { get; set; }
        public DateTime DataModifica { get; set; }
        public string UtenteModifica { get; set; }
    }
}
