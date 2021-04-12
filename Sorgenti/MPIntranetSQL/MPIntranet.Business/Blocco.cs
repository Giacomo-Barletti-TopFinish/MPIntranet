using MPIntranet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class Blocco
    {
        public int IdBlocco { get; set; }
        public string Utente { get; set; }
        public DateTime InizioBlocco { get; set; }
        public DateTime? FineBlocco { get; set; }
    }
}
