using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class ExpCicloBusinessCentral
    {
        public static string CodiceStandard = "IMPORT";
        public string Codice;
        public List<FaseCicloBusinessCentral> Fasi;
        public ExpCicloBusinessCentral(string Codice)
        {
            this.Codice = Codice;
            Fasi = new List<FaseCicloBusinessCentral>();
        }

        public bool AggiungiFase(FaseDistinta faseDistinta, int operazione, out string errori)
        {
            faseDistinta.Errore = string.Empty;
            errori = string.Empty;
            bool esito = true;
            StringBuilder sb = new StringBuilder();
            if (faseDistinta != null && string.IsNullOrEmpty(faseDistinta.Anagrafica))
            {
                FaseCicloBusinessCentral f = new FaseCicloBusinessCentral();
                f.Operazione = operazione;
                operazione += 10;
                f.AreaProduzione = faseDistinta.AreaProduzione;
                if (string.IsNullOrEmpty(f.AreaProduzione))
                {
                    sb.AppendLine(string.Format("Fase {0} Area di produzione nulla", faseDistinta.IdFaseDiba));
                    faseDistinta.Errore = "Area produzione non valorizzata ";
                    esito = false;
                }
                f.TempoLavorazione = faseDistinta.Periodo;
                if (f.TempoLavorazione <= 0)
                {
                    sb.AppendLine(string.Format("Fase {0} tempo lavorazione nullo", faseDistinta.IdFaseDiba));
                    faseDistinta.Errore += " periodo non valorizzato ";
                    esito = false;
                }

                f.Collegamento = faseDistinta.CollegamentoCiclo;
                f.DimensioneLotto = faseDistinta.PezziOrari;
                f.Task = faseDistinta.Task;
                if (string.IsNullOrEmpty(f.Task))
                {
                    sb.AppendLine(string.Format("Fase {0} task non valorizzato", faseDistinta.IdFaseDiba));
                    faseDistinta.Errore += " task non valorizzato ";
                    esito = false;
                }
                f.Commenti = new List<string>();
                if (esito)
                    Fasi.Add(f);
                errori = sb.ToString();
            }
            else
                return false;
            return esito;
        }
    }

    public class FaseCicloBusinessCentral
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
