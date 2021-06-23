using MPIntranet.DataAccess.OrdiniProduzione;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public enum Avanzamento { InRitardo = 0, RitardoCiclo, InTempo }

    public class OrdineProduzione
    {
        public Avanzamento Avanzamento { get; set; }
        public int Status { get; set; }
        public int Operazione { get; set; }
        public string CodiceOrdineProduzione { get; set; }
        public string Anagrafica { get; set; }
        public string Descrizione { get; set; }
        public string Magazzino { get; set; }
        public string Collocazione { get; set; }
        public decimal Quantita { get; set; }
        public decimal QuantitaFinita { get; set; }
        public decimal QuantitaResidua { get; set; }
        public decimal QuantitaScarti { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime OraInizio { get; set; }
        public DateTime DataFine { get; set; }
        public DateTime OraFine { get; set; }
        public string Articolo { get; set; }

        List<FaseOrdineProduzione> Fasi { get; set; }

        public static List<OrdineProduzione> EstraiListaOrdineProduzione()
        {
            OrdiniProduzioneDS ds = new OrdiniProduzioneDS();
            using (OrdiniProduzioneBusiness bOrdineProduzione = new OrdiniProduzioneBusiness())
            {
                bOrdineProduzione.FillArticoliOrdiniProduzione(ds);
            }

            List<OrdineProduzione> ordiniProduzione = new List<OrdineProduzione>();
            foreach (OrdiniProduzioneDS.ArticoliOrdiniProduzioneRow riga in ds.ArticoliOrdiniProduzione)
            {
                OrdineProduzione oProduzione = CreaOrdineProduzione(riga);
                ordiniProduzione.Add(oProduzione);
            }
            return ordiniProduzione;
        }

        private static OrdineProduzione CreaOrdineProduzione(OrdiniProduzioneDS.ArticoliOrdiniProduzioneRow riga)
        {
            if (riga == null) return null;
            OrdineProduzione oProduzioneand = new OrdineProduzione();
            oProduzioneand.Status = riga.Status;
            oProduzioneand.Operazione = riga.Line_No_;
            oProduzioneand.CodiceOrdineProduzione = riga.Prod__Order_No_;
            oProduzioneand.Anagrafica = riga.Item_No_;
            oProduzioneand.Descrizione = riga.Description;
            oProduzioneand.Magazzino = riga.Location_Code;
            oProduzioneand.Collocazione = riga.Bin_Code;
            oProduzioneand.Quantita = Decimal.Round(riga.Quantity, 2, MidpointRounding.AwayFromZero);
            oProduzioneand.QuantitaFinita = Decimal.Round(riga.Finished_Quantity, 2, MidpointRounding.AwayFromZero);
            oProduzioneand.QuantitaResidua = Decimal.Round(riga.Remaining_Quantity, 2, MidpointRounding.AwayFromZero);
            oProduzioneand.QuantitaScarti = Decimal.Round(riga.Scrap__, 2, MidpointRounding.AwayFromZero);
            oProduzioneand.DataInizio = riga.Starting_Date;
            oProduzioneand.OraInizio = riga.Starting_Time;
            oProduzioneand.DataFine = riga.Ending_Date;
            oProduzioneand.OraFine = riga.Ending_Time;
            oProduzioneand.Articolo = riga.Routing_No_;

            oProduzioneand.Avanzamento = Avanzamento.InTempo;

            oProduzioneand.Fasi = FaseOrdineProduzione.EstraiListaFaseOrdineProduzione(riga.Prod__Order_No_);
            return oProduzioneand;
        }

        public void Verifica(DateTime dataVerifica)
        {
            bool esito = true;
            foreach (FaseOrdineProduzione fase in Fasi)
                esito = esito & fase.Verifica(dataVerifica);

            if (DataFine < dataVerifica && QuantitaResidua > 0)
                Avanzamento = Avanzamento.InRitardo;
            else if (esito)
                Avanzamento = Avanzamento.InTempo;
            else
                Avanzamento = Avanzamento.RitardoCiclo;

        }
    }
}