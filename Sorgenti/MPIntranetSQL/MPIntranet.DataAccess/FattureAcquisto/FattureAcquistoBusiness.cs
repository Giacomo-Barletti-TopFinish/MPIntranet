using MPIntranet.DataAccess.Core;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.FattureAcquisto
{
    public class FattureAcquistoBusiness : MPIntranetBusinessBase
    {
        public FattureAcquistoBusiness() : base() { }

        [DataContext]
        public void FillFornitoriFattureAcquisto(FattureAcquistoDS ds)
        {
            FattureAcquistoAdapter a = new FattureAcquistoAdapter(DbConnection, DbTransaction);
            a.FillFornitoriFattureAcquisto(ds);
        }
        [DataContext]
        public void FillFattureAcquisto(FattureAcquistoDS ds, string codiceFornitore)
        {
            FattureAcquistoAdapter a = new FattureAcquistoAdapter(DbConnection, DbTransaction);
            a.FillFattureAcquisto(ds, codiceFornitore);
        }
        [DataContext]
        public void FillFattureAcquistoDettaglio(FattureAcquistoDS ds, int IdDocumento, int tipoDocumento)
        {
            FattureAcquistoAdapter a = new FattureAcquistoAdapter(DbConnection, DbTransaction);
            a.FillFattureAcquistoDettaglio(ds, IdDocumento, tipoDocumento);
        }
    }
}
