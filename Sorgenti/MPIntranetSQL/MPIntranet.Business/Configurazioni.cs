using MPIntranet.DataAccess.Security;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public static class Configurazioni
    {
        public static string PathPDM
        {
            get
            {
                SecurityDS.CONFIGURAZIONIRow configurazione = EstraiValoreConfigurazioni("PathPDN");
                if (configurazione == null) return string.Empty;
                return configurazione.VALORE;
            }
        }

        private static SecurityDS.CONFIGURAZIONIRow EstraiValoreConfigurazioni(string codice)
        {
            SecurityDS ds = new SecurityDS();
            using (SecurityBusiness bSecurity = new SecurityBusiness())
            {
                bSecurity.EstraiConfigurazioni(ds, codice);
                return ds.CONFIGURAZIONI.Where(x => x.CODICE == codice).FirstOrDefault();
            }
        }
    }
}
