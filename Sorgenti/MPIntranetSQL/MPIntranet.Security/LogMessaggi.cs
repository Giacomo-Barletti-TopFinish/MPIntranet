using MPIntranet.DataAccess.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Security
{
    public static class LogMessaggi
    {
        public static void ScriviInformazione(string messaggio, string modulo)
        {
            string tipoMessaggio = "INFO";

            using (SecurityBusiness bSecurity = new SecurityBusiness())
            {
                bSecurity.SaveMessaggioLog(messaggio, string.Empty, modulo, tipoMessaggio);
            }
        }

        public static void ScriviAllarme(string messaggio, string modulo)
        {
            string tipoMessaggio = "ALLARME";

            using (SecurityBusiness bSecurity = new SecurityBusiness())
            {
                bSecurity.SaveMessaggioLog(messaggio, string.Empty, modulo, tipoMessaggio);
            }
        }

        public static void ScriviErrore(string messaggio, string stack, string modulo)
        {
            string tipoMessaggio = "ERRORE";

            using (SecurityBusiness bSecurity = new SecurityBusiness())
            {
                bSecurity.SaveMessaggioLog(messaggio, stack, modulo, tipoMessaggio);
            }
        }
    }
}
