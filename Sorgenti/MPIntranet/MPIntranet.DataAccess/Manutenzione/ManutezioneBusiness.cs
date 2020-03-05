﻿using MPIntranet.DataAccess.Core;
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
        public void FillDitte(ManutenzioneDS ds)
        {
            ManutenzioneAdapter a = new ManutenzioneAdapter(DbConnection, DbTransaction);
            a.FillDitte(ds);
        }

        [DataContext(true)]
        public void UpdateTable(string tablename, ManutenzioneDS ds)
        {
            ManutenzioneAdapter a = new ManutenzioneAdapter(DbConnection, DbTransaction);
            a.UpdateTable(tablename, ds);
        }

    }
}
