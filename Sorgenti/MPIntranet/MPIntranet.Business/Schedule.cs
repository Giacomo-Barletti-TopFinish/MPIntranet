using MPIntranet.Common;
using MPIntranet.DataAccess.ScheduledServices;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public interface IScheduledTask
    {
        void Esegui();
    }

    public class Servizi
    {
        public const string AggiornaCommesse = "AggiornaCommesse";
        public const string StoricizzaOrdineCliente = "StoricizzaOrdineCliente";
    }

    public class AggiornaCommesse : IScheduledTask
    {
        void IScheduledTask.Esegui()
        {

        }
    }

    public class Schedule : BusinessBase
    {
        private ScheduleServicesDS _ds = new ScheduleServicesDS();

        public void EstraiSchedule(ScheduleServicesDS ds)
        {

            using (ScheduleBusiness bSchedule = new ScheduleBusiness())
            {
                bSchedule.FillSchedule(_ds, true);
            }
        }

        public IScheduledTask EstraiScheduledTask(ScheduleServicesDS.SCHEDULERow scheduledRow)
        {
            switch (scheduledRow.SERVIZIO)
            {
                case Servizi.AggiornaCommesse:
                    return new AggiornaCommesse();

                default:
                    return null;
            }
        }

        public void SalvaModificheSchedulazione(ScheduleServicesDS ds)
        {
            using (ScheduleBusiness bSchedule = new ScheduleBusiness())
            {
                bSchedule.UpdateTable(_ds.SCHEDULE.TableName, ds);
            }
        }

        public void RischedulaServizio(ScheduleServicesDS.SCHEDULERow scheduledRow, ScheduleServicesDS ds)
        {
            switch (scheduledRow.FREQUENZA)
            {
                case "GIORNALIERA":
                    ScheduleServicesDS.SCHEDULERow nuovaSchedulazione = ds.SCHEDULE.NewSCHEDULERow();
                    nuovaSchedulazione.DATAESECUZIONE = scheduledRow.DATAESECUZIONE.AddDays(1);
                    nuovaSchedulazione.ORAESECUZIONE = scheduledRow.ORAESECUZIONE;
                    nuovaSchedulazione.FREQUENZA = scheduledRow.FREQUENZA;
                    nuovaSchedulazione.ESEGUITA = SiNo.No;
                    nuovaSchedulazione.SERVIZIO = scheduledRow.SERVIZIO;
                    ds.SCHEDULE.AddSCHEDULERow(nuovaSchedulazione);
                    break;
            }
        }

    }
}









