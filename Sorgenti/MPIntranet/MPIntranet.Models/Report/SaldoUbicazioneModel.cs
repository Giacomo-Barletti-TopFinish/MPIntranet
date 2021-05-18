using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Report
{
    public class SaldoUbicazioneModel
    {
        public string Modello { get; set; }
        public string CodiceMagazzino { get; set; }
        public string Categoria { get; set; }
        public decimal Costo { get; set; }
        public decimal Quantita { get; set; }
        public decimal Valore { get; set; }
        public decimal QuantitaNettaDisponibile { get; set; }
    }
}
