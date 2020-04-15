﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Anagrafica
{
    public class RepartoModel
    {
        public decimal IdReparto { get; set; }
        public string Codice { get; set; }
        public string DescrizioneBreve { get; set; }
        public string Descrizione{ get; set; }

        public override string ToString()
        {
            return string.Format("{0}-{1}", Codice, DescrizioneBreve);
        }
    }
}
