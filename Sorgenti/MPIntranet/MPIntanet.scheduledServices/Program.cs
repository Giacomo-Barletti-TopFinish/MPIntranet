using MPIntanet.ScheduledServices.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MPIntanet.ScheduledServices
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            log4net.Config.XmlConfigurator.Configure();

            ScheduledService scheduledService = new ScheduledService();

            if (Settings.Default.StartAsApplication)
            {
                scheduledService.OnStartAsApplication();
            }
            else
            {
                ServiceBase[] servicesToRun = new ServiceBase[] { scheduledService };
                ServiceBase.Run(servicesToRun);
            }

        }
    }
}
