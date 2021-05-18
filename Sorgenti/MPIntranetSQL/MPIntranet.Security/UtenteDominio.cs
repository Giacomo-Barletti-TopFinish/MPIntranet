using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.AccountManagement;

namespace MPIntranet.Security
{
    public class UtenteDominio
    {
        private UserPrincipal userPrincipal;
        public bool AbilitaAnagrafica { get; private set; }
        public bool AbilitaDistintaBase { get; private set; }
        public bool AbilitaCosti { get; private set; }

        public string DisplayName { get; private set; }
        public string FULLNAMEUSER { get; private set; }

        public string IDUSER { get; private set; }

        public UtenteDominio()
        {
            string username = Environment.UserName;

            AbilitaAnagrafica = false;
            AbilitaDistintaBase = false;
            AbilitaCosti = false;
            FULLNAMEUSER = "Sconosciuto";
            DisplayName = "Sconosciuto";
            IDUSER = string.Empty;

            //  PrincipalContext domainctx = new PrincipalContext(ContextType.Domain,"example","DC=example,DC=com");
            PrincipalContext domainctx = new PrincipalContext(ContextType.Domain);

            userPrincipal = UserPrincipal.FindByIdentity(domainctx, IdentityType.SamAccountName, username);

            if (userPrincipal != null)
            {
                AbilitaAnagrafica = userPrincipal.IsMemberOf(domainctx, IdentityType.Name, GruppiDominio.Anagrafica);
                AbilitaDistintaBase = userPrincipal.IsMemberOf(domainctx, IdentityType.Name, GruppiDominio.DistintaBase);
                AbilitaCosti = userPrincipal.IsMemberOf(domainctx, IdentityType.Name, GruppiDominio.Costi);
                FULLNAMEUSER = userPrincipal.DisplayName.Length > 50 ? userPrincipal.DisplayName.Substring(0, 50) : userPrincipal.DisplayName;
                IDUSER = userPrincipal.UserPrincipalName;
                DisplayName = userPrincipal.DisplayName;
            }
        }
    }
}
