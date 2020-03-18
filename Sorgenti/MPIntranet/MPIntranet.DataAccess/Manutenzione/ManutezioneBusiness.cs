using MPIntranet.DataAccess.Core;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.Manutenzione
{
    public class ManutezioneBusiness: MPIntranetBusinessBase
    {
        public ManutezioneBusiness() : base() { }

        [DataContext]
        public void FillDitte(ManutenzioneDS ds, bool soloNonCancellati)
        {
            ManutenzioneAdapter a = new ManutenzioneAdapter(DbConnection, DbTransaction);
            a.FillDitte(ds,soloNonCancellati);
        }
        [DataContext]
        public void FillManutentori(ManutenzioneDS ds, bool soloNonCancellati)
        {
            ManutenzioneAdapter a = new ManutenzioneAdapter(DbConnection, DbTransaction);
            a.FillManutentori(ds, soloNonCancellati);
        }
        [DataContext]
        public void FillRiferimenti(ManutenzioneDS ds, bool soloNonCancellati)
        {
            ManutenzioneAdapter a = new ManutenzioneAdapter(DbConnection, DbTransaction);
            a.FillRiferimenti(ds, soloNonCancellati);
        }

        [DataContext(true)]
        public void UpdateTable(string tablename, ManutenzioneDS ds)
        {
            ManutenzioneAdapter a = new ManutenzioneAdapter(DbConnection, DbTransaction);
            a.UpdateTable(tablename, ds);
        }

    }
}
