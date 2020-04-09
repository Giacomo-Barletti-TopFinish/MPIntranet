﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Anagrafica
{
    public class MaterialeModel
    {
        public decimal IdMateriale { get; set; }
        public string Codice{ get; set; }
        public string Descrizione{ get; set; }
        public string Prezioso { get; set; }
        public DateTime DataModifica { get; set; }
        public string UtenteModifica { get; set; }
        public decimal PesoSpecifico{ get; set; }

        public override string ToString()
        {
            return string.Format("{0}({1})",Codice,Descrizione);
        }
    }
}
