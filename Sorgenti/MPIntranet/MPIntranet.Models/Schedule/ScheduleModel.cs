using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Schedule
{
    public class ScheduleModel
    {
        public decimal IdSchedule { get; set; }

        public string Servizio { get; set; }

        public DateTime DataEsecuzione { get; set; }

        public string OraEsecuzione { get; set; }

        public string Eseguita { get; set; }

        public string Frequenza { get; set; }


    }
}
