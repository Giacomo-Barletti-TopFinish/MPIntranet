﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Finiture_Burattovarie
{
    public class FasiModel
    {
        public decimal IdFbvFase { get; set; }
        public string Codice { get; set; }
        public string Descrizione { get; set; }
        public decimal Ricarico { get; set; }
        public decimal CostoOrario { get; set; }
    }
}
