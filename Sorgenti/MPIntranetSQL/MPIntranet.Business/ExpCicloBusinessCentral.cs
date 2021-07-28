using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class ExpCicloBusinessCentral
    {
        public static string CodiceCollegamentoStandard = "IMPORT";
        public string Codice;
        public List<ExpFaseCicloBusinessCentral> Fasi;
        public ExpCicloBusinessCentral(string Codice)
        {
            this.Codice = Codice;
            Fasi = new List<ExpFaseCicloBusinessCentral>();
        }

        public bool AggiungiFase(FaseDistinta faseDistinta, int operazione, out string errori)
        {
            faseDistinta.Errore = string.Empty;
            errori = string.Empty;
            bool esito = true;
            StringBuilder sb = new StringBuilder();
            if (faseDistinta != null && string.IsNullOrEmpty(faseDistinta.Anagrafica))
            {
                ExpFaseCicloBusinessCentral f = new ExpFaseCicloBusinessCentral();
                f.Operazione = operazione;
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
        public bool AggiungiFase(FaseCiclo faseCiclo, int operazione, out string errori)
        {
            faseCiclo.Errore = string.Empty;
            errori = string.Empty;
            bool esito = true;
            StringBuilder sb = new StringBuilder();
            if (faseCiclo != null)//&& string.IsNullOrEmpty(faseCiclo.Anagrafica))
            {
                ExpFaseCicloBusinessCentral f = new ExpFaseCicloBusinessCentral();
                f.Operazione = operazione;
                operazione += 10;
                f.AreaProduzione = faseCiclo.AreaProduzione;
                if (string.IsNullOrEmpty(f.AreaProduzione))
                {
                    sb.AppendLine(string.Format("Fase {0} Area di produzione nulla", faseCiclo.IdFaseCiclo));
                    faseCiclo.Errore = "Area produzione non valorizzata ";
                    esito = false;
                }
                f.TempoLavorazione = faseCiclo.Periodo;
                if (f.TempoLavorazione <= 0)
                {
                    sb.AppendLine(string.Format("Fase {0} tempo lavorazione nullo", faseCiclo.IdFaseCiclo));
                    faseCiclo.Errore += " periodo non valorizzato ";
                    esito = false;
                }

                f.Collegamento = faseCiclo.CollegamentoCiclo;
                f.DimensioneLotto = faseCiclo.PezziPeriodo;
                f.Task = faseCiclo.Task;
                if (string.IsNullOrEmpty(f.Task))
                {
                    sb.AppendLine(string.Format("Fase {0} task non valorizzato", faseCiclo.IdFaseCiclo));
                    faseCiclo.Errore += " task non valorizzato ";
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
        public bool AggiungiFase(FaseCiclo faseCiclo, out string errori)
        {
            faseCiclo.Errore = string.Empty;
            errori = string.Empty;
            bool esito = true;
            StringBuilder sb = new StringBuilder();
            if (faseCiclo != null)//&& string.IsNullOrEmpty(faseCiclo.Anagrafica))
            {
                ExpFaseCicloBusinessCentral f = new ExpFaseCicloBusinessCentral();
                f.Operazione = faseCiclo.Operazione;
                f.AreaProduzione = faseCiclo.AreaProduzione;
                if (string.IsNullOrEmpty(faseCiclo.Anagrafica))
                {
                    if (string.IsNullOrEmpty(faseCiclo.AreaProduzione))
                    {
                        sb.AppendLine(string.Format("Fase {0} Area di produzione nulla", faseCiclo.IdFaseCiclo));
                        faseCiclo.Errore = "Area produzione non valorizzata ";
                        esito = false;
                    }
                    if (string.IsNullOrEmpty(faseCiclo.Task))
                    {
                        sb.AppendLine(string.Format("Fase {0} task non valorizzato", faseCiclo.IdFaseCiclo));
                        faseCiclo.Errore += " task non valorizzato ";
                        esito = false;
                    }

                }

                f.TempoLavorazione = (faseCiclo.Periodo == 0) ? 0 : faseCiclo.PezziPeriodo / faseCiclo.Periodo;
                if (f.TempoLavorazione <= 0)
                {
                    sb.AppendLine(string.Format("Fase {0} tempo lavorazione nullo", faseCiclo.IdFaseCiclo));
                    faseCiclo.Errore += " periodo non valorizzato ";
                    esito = false;
                }

                f.Collegamento = faseCiclo.CollegamentoCiclo;
                f.DimensioneLotto = faseCiclo.PezziPeriodo;
                f.Task = faseCiclo.Task;
                f.Commenti = new List<string>();
                string commento = string.Empty; ;
                if (!string.IsNullOrEmpty(faseCiclo.SchedaProcesso))
                    commento = string.Format("{0} {1} ", FaseCiclo.EtichettaSchedaProcesso, faseCiclo.SchedaProcesso);
                commento = commento + " " + faseCiclo.Nota;

                if (!string.IsNullOrEmpty(commento))
                {
                    f.Commenti = SeparaStringa(commento.Trim(), 80);
                }
                if (esito)
                    Fasi.Add(f);
                errori = sb.ToString();
            }
            else
                return false;
            return esito;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("CICLO {0}", Codice));
            Fasi.ForEach(x => sb.AppendLine(x.ToString()));
            return sb.ToString();
        }
        private List<string> SeparaStringa(string stringa, int lunghezzaMassima)
        {
            List<string> stringhe = new List<string>();

            string stringaModificata = stringa.Replace("+", " + ");
            stringaModificata = stringaModificata.Replace("-", " - ");
            stringaModificata = stringaModificata.Replace("  ", " ");

            string[] str = stringaModificata.Split(' ');
            string stringaComposta = string.Empty;
            for (int i = 0; i < str.Length; i++)
            {
                if ((stringaComposta.Length + str[i].Length + 1) < lunghezzaMassima)
                {
                    stringaComposta = stringaComposta + " " + str[i];
                }
                else
                {
                    stringhe.Add(stringaComposta);
                    stringaComposta = str[i];
                }
                if (i == str.Length - 1)
                {
                    stringhe.Add(stringaComposta);
                }
            }
            return stringhe;
        }
    }

    public class ExpFaseCicloBusinessCentral
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

        public override string ToString()
        {
            return string.Format("   -> {0}  {1} {2}", Operazione, AreaProduzione, Task);
        }
    }
}
