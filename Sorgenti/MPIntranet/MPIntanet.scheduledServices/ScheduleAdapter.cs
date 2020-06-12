using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.ScheduledServices
{
    public class ScheduleAdapter : MPIntranetAdapterBase
    {
        public ScheduleAdapter(System.Data.IDbConnection connection) :
            base(connection);
    }
}
