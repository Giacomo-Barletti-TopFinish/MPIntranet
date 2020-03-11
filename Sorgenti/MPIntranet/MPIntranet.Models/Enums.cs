﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models
{
    public enum TipoRicerca { Scheda = 1, Processo }

    public class SiNo
    {
        public const string Si = "S";
        public const string No = "N";
    }

    public class TipologiaRiferimento
    {
        public const string Email = "EMAIL";
        public const string Telefono = "TELEFONO";
    }

}
