using MPIntranet.ScheduledServices.Properties;
using MPIntranet.Servicemanagers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
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
                using (GestioneOrdiniCliente gos = new GestioneOrdiniCliente())
                {
                    LogHelper.LogInfo("Inizio attivita");
                    gos.DoIt();
                    LogHelper.LogInfo("Fine attivita");
                }
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
