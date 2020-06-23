using MPIntranet.DataAccess.Core;
using MPIntranet.DataAccess.Schedule;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.ScheduledServices
{
    public class ScheduleBusiness : MPIntranetBusinessBase
    {

        public ScheduleBusiness() : base() { }

        [DataContext]

        public void FillSchedule(ScheduleServicesDS ds, bool soloNonEseguiti)
        {
            ScheduleAdapter a = new ScheduleAdapter(DbConnection, DbTransaction);
            a.FillSchedule(ds, soloNonEseguiti);
        }

        [DataContext(true)]
        public void UpdateTable(string tablename, ScheduleServicesDS ds)
        {
            ScheduleAdapter a = new ScheduleAdapter(DbConnection, DbTransaction);
            a.UpdateTable(tablename, ds);
        }



    }

    
    
}
