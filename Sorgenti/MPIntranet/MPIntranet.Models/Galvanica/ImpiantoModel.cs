using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Galvanica
{
    public class ImpiantoModel
    {
        public decimal IdImpianto { get; set; }
        public string Descrizione{ get; set; }
        public static ImpiantoModel ImpiantoVuoto()
        {
            ImpiantoModel impianto = new ImpiantoModel();
            impianto.IdImpianto = ElementiVuoti.ImpiantoVuoto;
            return impianto;
        }
    }
}
  
