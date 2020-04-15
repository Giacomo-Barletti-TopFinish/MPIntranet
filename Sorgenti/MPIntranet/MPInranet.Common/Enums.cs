using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Common
{
    public enum TipoRicerca { Scheda = 1, Processo,ProdottoFinito,Preventivo}

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

    public class TabelleEsterne
    {
        public const string Ditte = "DITTE";
        public const string Manutentori= "MANUTENTORI";
        public const string Macchine = "MACCHINE";
        public const string ProdottiFiniti = "PRODOTTI FINITI";
    }

}
