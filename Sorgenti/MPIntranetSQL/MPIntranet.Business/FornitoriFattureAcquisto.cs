using MPIntranet.DataAccess.FattureAcquisto;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class FornitoriFattureAcquisto
    {
        public string Codice { get; set; }
        public string RagioneSociale { get; set; }

        public static List<FornitoriFattureAcquisto> EstraiListaFornitoriFattureAcquisto()
        {
            FattureAcquistoDS ds = new FattureAcquistoDS();
            using (FattureAcquistoBusiness bFatturaAcquisto = new FattureAcquistoBusiness())
            {
                bFatturaAcquisto.FillFornitoriFattureAcquisto(ds);
            }

            List<FornitoriFattureAcquisto> fornitori = new List<FornitoriFattureAcquisto>();
            foreach (FattureAcquistoDS.FornitoriFattureAquistoRow riga in ds.FornitoriFattureAquisto)
            {
                FornitoriFattureAcquisto fornitore = CreaFornitoriFattureAcquisto(riga);
                fornitori.Add(fornitore);
            }
            return fornitori;
        }

        private static FornitoriFattureAcquisto CreaFornitoriFattureAcquisto(FattureAcquistoDS.FornitoriFattureAquistoRow riga)
        {
            if (riga == null) return null;
            FornitoriFattureAcquisto fornitori = new FornitoriFattureAcquisto();
            fornitori.RagioneSociale= riga._EOS_Pay_to_Name;
            fornitori.Codice = riga._EOS_Pay_to_Vendor_No_;
            return fornitori;
        }

        public override string ToString()
        {
            return RagioneSociale;
        }
    }
}
