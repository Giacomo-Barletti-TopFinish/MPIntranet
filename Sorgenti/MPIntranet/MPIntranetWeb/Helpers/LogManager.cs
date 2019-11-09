using log4net;
using MPIntranet.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MPIntranetWeb.Helpers
{
    public class LogManager
    {
        private const string ApplicationName = "MPIntranetWeb";
        private static readonly ILog _logger = log4net.LogManager.GetLogger("MPIntranetWeb");

        public static void WriteException(Exception ex)
        {
            _logger.Fatal("------------------------------- ECCEZIONE ---------------------------------------------");
            _logger.Fatal(ApplicationName, ex);
            LogMessaggi.ScriviErrore(ex.Message, ex.StackTrace, string.Empty);
        }

        public static void WriteException(string Controller, string Method, Exception ex)
        {
            _logger.Fatal("------------------------------- ECCEZIONE ---------------------------------------------");
            string modulo = string.Format("CONTROLLER:{0}    ACTION:{1}", Controller, Method);
            _logger.Fatal(modulo);
            _logger.Fatal(ApplicationName, ex);
            Exception innerException = ex.InnerException;
            StringBuilder messaggioErrore = new StringBuilder();
            messaggioErrore.Append(ex.Message);

            while (innerException != null)
            {
                _logger.Fatal("INNER EXCEPTION");
                _logger.Fatal(ApplicationName, innerException);
                innerException = innerException.InnerException;
                messaggioErrore.AppendLine(innerException.Message);
            }

            LogMessaggi.ScriviErrore(messaggioErrore.ToString(), ex.StackTrace, modulo);
        }

        public static void WriteException(ExceptionContext ex, string account)
        {
            string actionName = ex.RouteData.Values["action"].ToString();
            string controllerName = ex.RouteData.Values["controller"].ToString();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("EXCEPTION INFORMATION");
            sb.AppendLine(string.Format("     CONTROLLER: {0}", controllerName));
            sb.AppendLine(string.Format("     ACTION: {0}", actionName));
            sb.AppendLine(string.Format("     ACCOUNT: {0}", account));

            foreach (string param in ex.RequestContext.HttpContext.Request.Params.AllKeys)
            {
                sb.AppendLine(string.Format("     {0}: {1}", param, ex.RequestContext.HttpContext.Request.Params[param]));
            }

            _logger.Fatal(sb.ToString());
            _logger.Fatal(ex.Controller, ex.Exception);
            if (ex.Exception.InnerException != null)
                _logger.Fatal("Inner exception", ex.Exception.InnerException);

            LogMessaggi.ScriviErrore(ex.Exception.Message, ex.Exception.StackTrace, string.Format("{0} - {1}", controllerName, actionName));
        }

        public static void WriteMessage(string message)
        {
            _logger.Info(message);
            LogMessaggi.ScriviInformazione(message, string.Empty);
        }

        public static void WriteWarning(string message)
        {
            _logger.Warn(message);
            LogMessaggi.ScriviAllarme(message, string.Empty);
        }

        public static void WriteError(string message)
        {
            _logger.Error(message);
        }
    }
}