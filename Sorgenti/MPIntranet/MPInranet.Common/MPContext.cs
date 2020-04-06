using MPIntranet.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Common
{
    public class MPContext
    {
        public bool UtenteConnesso;

        public Utente Utente;

        public static MPContext CreaContesto()
        {
            MPContext contesto = new MPContext();

            contesto.UtenteConnesso = true;
            contesto.Utente = new Security.Utente();
            return contesto;
        }
    }
}
