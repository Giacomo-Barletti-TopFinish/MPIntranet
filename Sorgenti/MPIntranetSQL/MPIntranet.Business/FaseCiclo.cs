﻿using MPIntranet.DataAccess.Articoli;
using MPIntranet.Entities;
using MPIntranet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class FaseCiclo : BaseModel
    {
        public int IdFaseCiclo { get; set; }
        public int IdDiba { get; set; }
        public string Descrizione { get; set; }
        public int IdComponente { get; set; }
        public string AreaProduzione { get; set; }
        public string Task { get; set; }
        public string SchedaProcesso { get; set; }
        public string CollegamentoCiclo { get; set; }
        public double PezziPeriodo { get; set; }
        public double Periodo { get; set; }
        public double Setup { get; set; }
        public double Attesa { get; set; }
        public double Movimentazione { get; set; }
        public string Errore { get; set; }

        public static List<FaseCiclo> EstraiListaFaseCiclo(int idDiba)
        {
            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                bArticolo.GetFASICICLO(ds, idDiba, true);
            }
            List<FaseCiclo> fasiCiclo = new List<FaseCiclo>();
            foreach (ArticoliDS.FASICICLORow riga in ds.FASICICLO)
            {
                FaseCiclo faseCiclo = CreaFaseCiclo(riga);
                fasiCiclo.Add(faseCiclo);
            }
            return fasiCiclo;
        }
        private static FaseCiclo CreaFaseCiclo(ArticoliDS.FASICICLORow riga)
        {

            if (riga == null) return null;
            FaseCiclo distinta = new FaseCiclo();
            distinta.IdDiba = riga.IDDIBA;
            distinta.IdFaseCiclo = riga.IDFASECICLO;
            distinta.IdComponente = riga.IDCOMPONENTE;
            distinta.Descrizione = riga.IsDESCRIZIONENull() ? string.Empty : riga.DESCRIZIONE;
            distinta.AreaProduzione = riga.IsAREAPRODUZIONENull() ? string.Empty : riga.AREAPRODUZIONE;
            distinta.Task = riga.IsTASKNull() ? string.Empty : riga.TASK;
            distinta.SchedaProcesso = riga.IsSCHEDAPROCESSONull() ? string.Empty : riga.SCHEDAPROCESSO;
            distinta.CollegamentoCiclo = riga.IsCOLLEGAMENTOCICLONull() ? string.Empty : riga.COLLEGAMENTOCICLO;
            distinta.PezziPeriodo = riga.IsPEZZIPERIODONull() ? 0 : riga.PEZZIPERIODO;
            distinta.Periodo = riga.IsPERIODONull() ? 0 : riga.PERIODO;
            distinta.Setup = riga.IsSETUPNull() ? 0 : riga.SETUP;
            distinta.Attesa = riga.IsATTESANull() ? 0 : riga.ATTESA;
            distinta.Movimentazione = riga.IsMOVIMENTAZIONENull() ? 0 : riga.MOVIMENTAZIONE;
            distinta.Errore = string.Empty;
            distinta.Cancellato = riga.CANCELLATO;
            distinta.DataModifica = riga.DATAMODIFICA;
            distinta.UtenteModifica = riga.UTENTEMODIFICA;
            return distinta;
        }
    }
}
