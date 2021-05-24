using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Entities
{
    public class Ciclo
    {
        public static string CodiceStandard = "IMPORT";
        public string Codice;
        public List<Fase> Fasi;
        public Ciclo( string Codice)
        {
            this.Codice = Codice;
            Fasi = new List<Fase>();
        }
    }

    public class Fase
    {
        public int ID;
        public string Versione = string.Empty;
        public int Operazione;
        public string Tipo = "Area di produzione";
        public string AreaProduzione;
        public double TempoSetup = 0;
        public double TempoLavorazione;
        public double TempoAttesa = 0;
        public double TempoSpostamento = 0;
        public double DimensioneLotto = 0;
        public string UMSetup = "ORE";
        public string UMLavorazione = "ORE";
        public string UMAttesa = "ORE";
        public string UMSpostamento = "ORE";
        public string Collegamento;
        public string Task;
        public string Condizione = string.Empty;
        public string Caratteristica = string.Empty;
        public string LogicheLavorazione = string.Empty;
        public List<string> Commenti = new List<string>();
    }
}
