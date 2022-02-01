using MPIntranet.DataAccess.FattureAcquisto;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class FatturaAcquisto
    {
        public int IDDocumento { get; set; }
        public int TipoDocumento { get; set; }
        public string CodiceFornitore { get; set; }
        public string Fornitore { get; set; }
        public string Riferimento { get; set; }
        public decimal Importo { get; set; }
        public DateTime Data { get; set; }


        public static List<FatturaAcquisto> EstraiListaFattureAcquisto(string codiceFornitore)
        {
            FattureAcquistoDS ds = new FattureAcquistoDS();
            using (FattureAcquistoBusiness bFatturaAcquisto = new FattureAcquistoBusiness())
            {
                bFatturaAcquisto.FillFattureAcquisto(ds, codiceFornitore);
            }

            List<FatturaAcquisto> fatture = new List<FatturaAcquisto>();
            foreach (FattureAcquistoDS.FattureAcquistoTestataRow riga in ds.FattureAcquistoTestata)
            {
                FatturaAcquisto fattura = CreaFatturaAcquisto(riga);
                fatture.Add(fattura);
            }
            return fatture;

        }

        private static FatturaAcquisto CreaFatturaAcquisto(FattureAcquistoDS.FattureAcquistoTestataRow riga)
        {
            if (riga == null) return null;
            FatturaAcquisto fattura = new FatturaAcquisto();
            fattura.CodiceFornitore = riga._EOS_Pay_to_Vendor_No_;
            fattura.IDDocumento = riga.EOS_Source_Doc__Entry_No_;
            fattura.TipoDocumento = riga.EOS_Document_Type;
            fattura.Fornitore = riga._EOS_Pay_to_Name;
            fattura.Riferimento = riga.EOS_Vendor_Invoice_No_;
            fattura.Importo = riga.EOS_Check_Total;
            fattura.Data = riga.EOS_Receipt_Date;

            return fattura;
        }
    }

    public class FatturaAcquistoDettaglio
    {
        public int IDDocumento { get; set; }
        public int TipoDocumento { get; set; }
        public string CodiceFornitore { get; set; }
        public string Fornitore { get; set; }
        public int NumeroRiga { get; set; }
        public string Descrizione { get; set; }
        public decimal Quantita { get; set; }
        public decimal Costo { get; set; }
        public decimal Valore { get; set; }
        public string UM { get; set; }

        public static List<FatturaAcquistoDettaglio> EstraiListaFatturaAcquistoDettaglio(int IdDocumento, int tipoDocumento)
        {
            FattureAcquistoDS ds = new FattureAcquistoDS();
            using (FattureAcquistoBusiness bFatturaAcquisto = new FattureAcquistoBusiness())
            {
                bFatturaAcquisto.FillFattureAcquistoDettaglio(ds, IdDocumento, tipoDocumento);
            }

            List<FatturaAcquistoDettaglio> fatture = new List<FatturaAcquistoDettaglio>();
            foreach (FattureAcquistoDS.FattureAcquistoDettaglioRow riga in ds.FattureAcquistoDettaglio)
            {
                FatturaAcquistoDettaglio fattura = CreaFatturaAcquistoDettaglio(riga);
                fatture.Add(fattura);
            }
            return fatture;

        }

        private static FatturaAcquistoDettaglio CreaFatturaAcquistoDettaglio(FattureAcquistoDS.FattureAcquistoDettaglioRow riga)
        {
            if (riga == null) return null;
            FatturaAcquistoDettaglio dettaglio = new FatturaAcquistoDettaglio();
            dettaglio.CodiceFornitore = riga._EOS_Pay_to_Vendor_No_;
            dettaglio.IDDocumento = riga.EOS_Source_Doc__Entry_No_;
            dettaglio.TipoDocumento = riga.EOS_Document_Type;
            dettaglio.Fornitore = riga._EOS_Pay_to_Name;
            dettaglio.NumeroRiga = riga.EOS_Line_No_;
            dettaglio.Descrizione = riga.EOS_Description;
            dettaglio.Quantita = riga.EOS_Quantity;
            dettaglio.Costo = riga.EOS_Direct_Unit_Cost;
            dettaglio.Valore = riga.EOS_Line_Amount;
            dettaglio.UM = riga.EOS_Original_UoM_Code;

            return dettaglio;
        }
        public string EstraiRiga()
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("it-IT");
            string str = string.Format("{0};{1};{2};{3};{4}", NumeroRiga, Descrizione, Quantita.ToString("G", culture), Costo.ToString("G", culture), Valore.ToString("G", culture));
            return str;
        }
    }
}
