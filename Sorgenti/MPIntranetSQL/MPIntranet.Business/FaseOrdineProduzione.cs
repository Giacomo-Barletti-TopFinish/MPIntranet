using MPIntranet.DataAccess.OrdiniProduzione;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class FaseOrdineProduzione
    {
        public string OrdineProduzione { get; set; }
        public string Operazione { get; set; }
        public string AreaProduzione { get; set; }
        public string DescrizioneAreaProduzione { get; set; }
        public decimal Setup { get; set; }
        public decimal Run { get; set; }
        public decimal Wait { get; set; }
        public decimal Move { get; set; }
        public decimal Lotto { get; set; }
        public string SetupUM { get; set; }
        public string RunUM { get; set; }
        public string WaitUM { get; set; }
        public string MoveUM { get; set; }
        public string Task { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime OraInizio { get; set; }
        public DateTime DataFine { get; set; }
        public DateTime OraFine { get; set; }
        public string Ciclo { get; set; }
        public decimal QuantitaInput { get; set; }
        public bool WIP { get; set; }
        public decimal QuantitaOutput { get; set; }
        public string DataVersamento { get; set; }
        public Avanzamento Avanzamento { get; set; }

        public static List<FaseOrdineProduzione> EstraiListaFaseOrdineProduzione(string codiceOrdineProduzione)
        {
            OrdiniProduzioneDS ds = new OrdiniProduzioneDS();
            using (OrdiniProduzioneBusiness bOrdineProduzione = new OrdiniProduzioneBusiness())
            {
                bOrdineProduzione.FillFasiOrdiniProduzione(ds, codiceOrdineProduzione);
                bOrdineProduzione.FillVersamentiFasiOrdiniProduzione(ds, codiceOrdineProduzione);
            }

            List<FaseOrdineProduzione> fasi = new List<FaseOrdineProduzione>();
            foreach (OrdiniProduzioneDS.FasiOrdiniProduzioneRow riga in ds.FasiOrdiniProduzione)
            {
                FaseOrdineProduzione fase = CreaFaseOrdineProduzione(riga);
                OrdiniProduzioneDS.VersamentiFasiOrdiniProduzioneRow versamento = ds.VersamentiFasiOrdiniProduzione.Where(x => x.Operation_No_ == fase.Operazione).FirstOrDefault();
                if(versamento!=null)
                {
                    fase.DataVersamento = versamento.Document_Date.ToShortDateString();
                    if(fase.WIP)
                        fase.QuantitaOutput = versamento.Invoiced_Quantity;
                    else
                        fase.QuantitaOutput = versamento.Output_Quantity;
                }
                fasi.Add(fase);
            }
            return fasi;
        }

        private static FaseOrdineProduzione CreaFaseOrdineProduzione(OrdiniProduzioneDS.FasiOrdiniProduzioneRow riga)
        {
            if (riga == null) return null;
            FaseOrdineProduzione oProduzioneand = new FaseOrdineProduzione();
            oProduzioneand.OrdineProduzione = riga.Prod__Order_No_;
            oProduzioneand.Operazione = riga.Operation_No_;
            oProduzioneand.AreaProduzione = riga.Work_Center_No_;
            oProduzioneand.DescrizioneAreaProduzione = riga.Description;
            oProduzioneand.Setup = riga.Setup_Time;
            oProduzioneand.Run = riga.Run_Time;
            oProduzioneand.Wait = riga.Wait_Time;
            oProduzioneand.Move = Decimal.Round(riga.Move_Time, 2, MidpointRounding.AwayFromZero);
            oProduzioneand.Lotto = riga.Lot_Size;// Decimal.Round(riga.Finished_Quantity, 2, MidpointRounding.AwayFromZero);
            oProduzioneand.SetupUM = riga.Setup_Time_Unit_of_Meas__Code;
            oProduzioneand.RunUM = riga.Run_Time_Unit_of_Meas__Code;
            oProduzioneand.WaitUM = riga.Wait_Time_Unit_of_Meas__Code;
            oProduzioneand.MoveUM = riga.Move_Time_Unit_of_Meas__Code;
            oProduzioneand.Task = riga.Standard_Task_Code;

            oProduzioneand.OraInizio = riga.Starting_Time;
            oProduzioneand.DataFine = riga.Ending_Date;
            oProduzioneand.OraFine = riga.Ending_Time;
            oProduzioneand.Ciclo = riga.Routing_No_;
            oProduzioneand.QuantitaInput = riga.Input_Quantity;
            oProduzioneand.WIP = riga.WIP_Item == 0;
            oProduzioneand.QuantitaOutput = 0;
            oProduzioneand.DataVersamento = string.Empty;

            oProduzioneand.Avanzamento = Avanzamento.InTempo;
            return oProduzioneand;
        }

        public bool Verifica(DateTime dataVerifica)
        {
            if (DataFine < dataVerifica && QuantitaOutput < QuantitaInput)
            {
                Avanzamento = Avanzamento.InRitardo;
                return false;
            }
            else
            {
                Avanzamento = Avanzamento.InTempo;
                return true;
            }
        }
    }
}
