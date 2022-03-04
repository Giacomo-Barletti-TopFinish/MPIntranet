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
        public string Codice { get; set; }
        public List<ExpFaseCicloBusinessCentral> Fasi;
        public bool Selezionato { get; set; }
        public string Errore { get; set; }
        public string Esito { get; set; }
        public string Stato { get; set; }

        public ExpCicloBusinessCentral(string Codice)
        {
            this.Codice = Codice;
            Fasi = new List<ExpFaseCicloBusinessCentral>();
        }

        //public bool AggiungiFase(FaseDistinta faseDistinta, int operazione, out string errori)
        //{
        //    faseDistinta.Errore = string.Empty;
        //    errori = string.Empty;
        //    bool esito = true;
        //    StringBuilder sb = new StringBuilder();
        //    if (faseDistinta != null && string.IsNullOrEmpty(faseDistinta.Anagrafica))
        //    {
        //        ExpFaseCicloBusinessCentral f = new ExpFaseCicloBusinessCentral(Codice);
        //        f.Operazione = operazione;
        //        f.AreaProduzione = faseDistinta.AreaProduzione;
        //        if (string.IsNullOrEmpty(f.AreaProduzione))
        //        {
        //            sb.AppendLine(string.Format("Anagrafica {1} - Fase {0} Area di produzione nulla", faseDistinta.IdFaseDiba, faseDistinta.Anagrafica));
        //            faseDistinta.Errore = "Area produzione non valorizzata ";
        //            esito = false;
        //        }
        //        f.TempoLavorazione = faseDistinta.Periodo;
        //        if (f.TempoLavorazione <= 0)
        //        {
        //            sb.AppendLine(string.Format("Anagrafica {1} - Fase {0} tempo lavorazione nullo", faseDistinta.IdFaseDiba, faseDistinta.Anagrafica));
        //            faseDistinta.Errore += " periodo non valorizzato ";
        //            esito = false;
        //        }

        //        f.Collegamento = faseDistinta.CollegamentoCiclo;
        //        f.DimensioneLotto = faseDistinta.PezziOrari;
        //        f.Task = faseDistinta.Task;
        //        if (string.IsNullOrEmpty(f.Task))
        //        {
        //            sb.AppendLine(string.Format("Anagrafica {1} - Fase {0} task non valorizzato", faseDistinta.IdFaseDiba, faseDistinta.Anagrafica));
        //            faseDistinta.Errore += " task non valorizzato ";
        //            esito = false;
        //        }
        //        f.Commenti = new List<string>();
        //        if (esito)
        //            Fasi.Add(f);
        //        errori = sb.ToString();
        //    }
        //    else
        //        return false;
        //    return esito;
        //}
        //public bool AggiungiFase(FaseCiclo faseCiclo, int operazione, out string errori)
        //{
        //    faseCiclo.Errore = string.Empty;
        //    errori = string.Empty;
        //    bool esito = true;
        //    StringBuilder sb = new StringBuilder();
        //    if (faseCiclo != null)//&& string.IsNullOrEmpty(faseCiclo.Anagrafica))
        //    {
        //        ExpFaseCicloBusinessCentral f = new ExpFaseCicloBusinessCentral(Codice);
        //        f.Operazione = operazione;
        //        operazione += 10;
        //        f.AreaProduzione = faseCiclo.AreaProduzione;
        //        if (string.IsNullOrEmpty(f.AreaProduzione))
        //        {
        //            sb.AppendLine(string.Format("ID Componente {1} - Fase {0} Area di produzione nulla", faseCiclo.IdFaseCiclo, faseCiclo.IdComponente));
        //            faseCiclo.Errore = "Area produzione non valorizzata ";
        //            esito = false;
        //        }
        //        f.TempoLavorazione = faseCiclo.Periodo;
        //        if (f.TempoLavorazione <= 0)
        //        {
        //            sb.AppendLine(string.Format("ID Componente {1} - Fase {0} tempo lavorazione nullo", faseCiclo.IdFaseCiclo, faseCiclo.IdComponente));
        //            faseCiclo.Errore += " periodo non valorizzato ";
        //            esito = false;
        //        }

        //        f.Collegamento = faseCiclo.CollegamentoCiclo;
        //        f.DimensioneLotto = faseCiclo.PezziPeriodo;
        //        f.Task = faseCiclo.Task;
        //        if (string.IsNullOrEmpty(f.Task))
        //        {
        //            sb.AppendLine(string.Format("ID Componente {1} - Fase {0} task non valorizzato", faseCiclo.IdFaseCiclo, faseCiclo.IdComponente));
        //            faseCiclo.Errore += " task non valorizzato ";
        //            esito = false;
        //        }
        //        f.Commenti = new List<string>();
        //        if (esito)
        //            Fasi.Add(f);
        //        errori = sb.ToString();
        //    }
        //    else
        //        return false;
        //    return esito;
        //}
        public bool AggiungiFase(FaseCiclo faseCiclo, out string errori)
        {
            faseCiclo.Errore = string.Empty;
            errori = string.Empty;
            bool esito = true;
            StringBuilder sb = new StringBuilder();
            if (faseCiclo != null)//&& string.IsNullOrEmpty(faseCiclo.Anagrafica))
            {
                ExpFaseCicloBusinessCentral f = new ExpFaseCicloBusinessCentral(Codice);
                f.Operazione = faseCiclo.Operazione;
                f.Descrizione = faseCiclo.Descrizione;
                f.AreaProduzione = faseCiclo.AreaProduzione;
                f.SchedaProcesso = faseCiclo.SchedaProcesso;
                if (string.IsNullOrEmpty(faseCiclo.Anagrafica))
                {
                    if (string.IsNullOrEmpty(faseCiclo.AreaProduzione))
                    {
                        sb.AppendLine(string.Format("ID Componente {1} - Fase {0} Area di produzione nulla", faseCiclo.IdFaseCiclo, faseCiclo.IdComponente));
                        faseCiclo.Errore = "Area produzione non valorizzata ";
                        esito = false;
                    }
                    if (string.IsNullOrEmpty(faseCiclo.Task))
                    {
                        sb.AppendLine(string.Format("ID Componente {1} - Fase {0} task non valorizzato", faseCiclo.IdFaseCiclo, faseCiclo.IdComponente));
                        faseCiclo.Errore += " task non valorizzato ";
                        esito = false;
                    }

                }

                //                f.TempoLavorazione = (faseCiclo.Periodo == 0) ? 0 : faseCiclo.PezziPeriodo / faseCiclo.Periodo;
                f.TempoLavorazione = faseCiclo.Periodo;
                //if (f.TempoLavorazione <= 0 && !string.IsNullOrEmpty(faseCiclo.AreaProduzione) && !string.IsNullOrEmpty(faseCiclo.Task))
                //{
                //    sb.AppendLine(string.Format("ID Componente {1} - Fase {0} tempo lavorazione nullo", faseCiclo.IdFaseCiclo, faseCiclo.IdComponente));
                //    faseCiclo.Errore += " periodo non valorizzato ";
                //    esito = false;
                //}

                f.Collegamento = faseCiclo.CollegamentoCiclo;
                f.DimensioneLotto = faseCiclo.PezziPeriodo;
                f.Task = faseCiclo.Task;
                f.Commenti = new List<string>();
                string commento = string.Empty; 
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

        public void RinumeraCodiceOperazione()
        {
            int operazione = 10;
            foreach (ExpFaseCicloBusinessCentral fase in Fasi.OrderBy(x => x.Operazione))
            {
                fase.Operazione = operazione;
                operazione += 10;
            }
        }
    }

    public class ExpFaseCicloBusinessCentral
    {
        public int ID { get; set; }
        public string Versione = string.Empty;
        public int Operazione { get; set; }
        public string Tipo = "Area di produzione";
        public string AreaProduzione { get; set; }
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
        public string SchedaProcesso;
        public string Task { get; set; }
        public string Condizione = string.Empty;
        public string Caratteristica = string.Empty;
        public string LogicheLavorazione = string.Empty;
        public List<string> Commenti = new List<string>();
        public string Descrizione { get; set; }

        public bool Selezionato { get; set; }
        public string Errore { get; set; }
        public string CodiceCiclo { get; set; }
        public string Esito { get; set; }

        public string CommentiConcatenati()
        {
            StringBuilder str = new StringBuilder();
            foreach (string c in Commenti)
                str.Append(string.Format("{0} ", c));
            return str.ToString().Trim();
        }
        public ExpFaseCicloBusinessCentral(string codiceCiclo)
        {
            CodiceCiclo = codiceCiclo;
        }
        public override string ToString()
        {
            return string.Format("   -> {0}  {1} {2}", Operazione, AreaProduzione, Task);
        }
    }
}
