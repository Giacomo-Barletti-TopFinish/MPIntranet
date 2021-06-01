﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Finiture_Burattovarie
{
    public class ProprietaModel
    {
        public decimal IdFbvProprieta { get; set; }
        public decimal IdFbvGruppo { get; set; }
        public string Codice { get; set; }
        public string Descrizione { get; set; }

        public override string ToString()
        {
            return string.Format("{0}-{1}",Codice,Descrizione);
        }
    }
}