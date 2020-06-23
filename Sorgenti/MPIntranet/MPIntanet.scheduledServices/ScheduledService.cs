using MPIntranet.Business;
using MPIntranet.Common;
using MPIntranet.Entities;
using MPIntranet.ScheduledServices.Properties;
using MPIntranet.Servicemanagers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MPIntranet.ScheduledServices
{
    public partial class ScheduledService : ServiceBase
    {
        private object _syncRoot = new object();

        private Timer _tmrAsync;
        private bool _isAsync = false;

        private bool IsAsync
        {
            get
            {
                lock (_syncRoot)
                    return _isAsync;
            }
            set
            {
                lock (_syncRoot)
                    _isAsync = value;
            }
        }
        private void AsyncOperationCallback(Object stateInfo)
        {
            if (IsAsync)
                return;

            IsAsync = true;
            try
            {
                using (ScheduleServicesDS ds = new ScheduleServicesDS())
                {
                    Schedule schedule = new Schedule();
                    LogHelper.LogInfo("inizio attività");
                    schedule.EstraiSchedule(ds);
                    foreach (ScheduleServicesDS.SCHEDULERow riga in ds.SCHEDULE)
                    {
                        string[] elementi = riga.ORAESECUZIONE.Split(':');
                        if (elementi.Length < 2 || elementi.Length > 3)
                        {
                            LogHelper.LogError(string.Format("Errore nella stringa ora {0} del servizio schedulato id: {1} ", riga.ORAESECUZIONE, riga.IDSCHEDULE));
                            return;
                        }

                        int ora = 0;
                        int minuti = 0;
                        int secondi = 0;

                        if (!int.TryParse(elementi[0], out ora))
                        {
                            LogHelper.LogError(string.Format("Errore nella conversione della stringa ora {0} del servizio schedulato id: {1} ", riga.ORAESECUZIONE, riga.IDSCHEDULE));
                            return;
                        }
                        if (!int.TryParse(elementi[1], out minuti))
                        {
                            LogHelper.LogError(string.Format("Errore nella conversione della stringa ora {0} del servizio schedulato id: {1} ", riga.ORAESECUZIONE, riga.IDSCHEDULE));
                            return;
                        }
                        if (elementi.Length == 3)
                        {
                            if (!int.TryParse(elementi[2], out secondi))
                            {
                                LogHelper.LogError(string.Format("Errore nella conversione della stringa ora {0} del servizio schedulato id: {1} ", riga.ORAESECUZIONE, riga.IDSCHEDULE));
                                return;
                            }
                        }

                        DateTime oraSchedulata = new DateTime(riga.DATAESECUZIONE.Year, riga.DATAESECUZIONE.Month, riga.DATAESECUZIONE.Day, ora, minuti, secondi);
                        if(oraSchedulata<DateTime.Now)
                        {

                            riga.ESEGUITA = SiNo.Si;
                            schedule.RischedulaServizio(riga,ds);
                            schedule.SalvaModificheSchedulazione(ds);

                            IScheduledTask task = schedule.EstraiScheduledTask(riga);
                            try
                            {
                                task.Esegui();
                            }
                            catch (Exception exc)
                            {
                                LogHelper.LogError("Errore in task.esegui", exc);
                            }






                            
                        }
                    }


                }
                //using (GestioneOrdiniCliente gos = new GestioneOrdiniCliente())
                //{
                //    LogHelper.LogInfo("Inizio attivita");
                //    gos.DoIt();
                //    LogHelper.LogInfo("Fine attivita");
                //}
            }
            catch (Exception ex)
            {
                LogHelper.LogError("Errore in AsyncOperationCallback", ex);
            }
            finally
            {
                IsAsync = false;
            }
        }

        public ScheduledService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                LogHelper.LogInfo("#### SCHEDULED SERVICE IN FASE DI AVVIO ####");
                LogHelper.LogInfo(string.Format("PERIOD IMPOSTATO {0} SECONDI", Settings.Default.Period));

                _tmrAsync = new Timer(new TimerCallback(AsyncOperationCallback), null, 5000, Settings.Default.Period * 1000);
                LogHelper.LogInfo("#### TRASFERIMENTI SERVICE AVVIATO ####");
            }
            catch (Exception ex)
            {
                LogHelper.LogError("Errore in OnStart", ex);
            }
        }
        public void OnStartAsApplication()
        {
            OnStart(new string[] { });
            Thread.Sleep(Timeout.Infinite);
        }
        protected override void OnStop()
        {
            LogHelper.LogInfo("#### SCHEDULED SERVICE FERMATO ####");
        }
    }
}
