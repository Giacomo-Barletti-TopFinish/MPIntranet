using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Report
{
    public class ReportQuantitaModel
    {
        public string Codiceclifo { get; set; }
        public string Ragionesoc { get; set; }
        public string ElencoFasi { get; set; }
        public decimal Somma { get; set; }
        public decimal Perc { get; set; }
    }
}
