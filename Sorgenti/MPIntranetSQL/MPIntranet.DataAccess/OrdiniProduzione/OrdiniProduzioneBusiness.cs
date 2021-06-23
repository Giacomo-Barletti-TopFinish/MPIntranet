using MPIntranet.DataAccess.Core;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.OrdiniProduzione
{
    public class OrdiniProduzioneBusiness : MPIntranetBusinessBase
    {
        public OrdiniProduzioneBusiness() : base() { }

        [DataContext]
        public void FillArticoliOrdiniProduzione(OrdiniProduzioneDS ds)
        {
            OrdiniProduzioneAdapter a = new OrdiniProduzioneAdapter(DbConnection, DbTransaction);
            a.FillArticoliOrdiniProduzione(ds);
        }
        [DataContext]
        public void FillVersamentiFasiOrdiniProduzione(OrdiniProduzioneDS ds, string codiceOrdineProduzione)
        {
            OrdiniProduzioneAdapter a = new OrdiniProduzioneAdapter(DbConnection, DbTransaction);
            a.FillVersamentiFasiOrdiniProduzione(ds, codiceOrdineProduzione);
        }
        [DataContext]
        public void FillFasiOrdiniProduzione(OrdiniProduzioneDS ds, string codiceOrdineProduzione)
        {
            OrdiniProduzioneAdapter a = new OrdiniProduzioneAdapter(DbConnection, DbTransaction);
            a.FillFasiOrdiniProduzione(ds, codiceOrdineProduzione);
        }

    }
}
