using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Text;

namespace MPIntranet.Security
{
    public class Dominio
    {
        public static bool ValidaCredenziali(string account, string password)
        {
            bool valid = false;
            using (PrincipalContext domainctx = new PrincipalContext(ContextType.Domain))
            {
                valid = domainctx.ValidateCredentials(account, password);
                UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(domainctx, IdentityType.SamAccountName, account);

                if (userPrincipal.Enabled.HasValue && userPrincipal.Enabled.Value == false) return false;
            }
            return valid;
        }

        private static bool AppartieneAlGruppo(string gruppo)
        {
            string username = Environment.UserName;

            //  PrincipalContext domainctx = new PrincipalContext(ContextType.Domain,"example","DC=example,DC=com");
            PrincipalContext domainctx = new PrincipalContext(ContextType.Domain);
            UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(domainctx, IdentityType.SamAccountName, username);

            bool isMember = userPrincipal.IsMemberOf(domainctx, IdentityType.Name, gruppo);

            return isMember;
        }

        private static bool AppartieneAlGruppo(string gruppo, string account)
        {
            PrincipalContext domainctx = new PrincipalContext(ContextType.Domain);
            UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(domainctx, IdentityType.SamAccountName, account);

            bool isMember = userPrincipal.IsMemberOf(domainctx, IdentityType.Name, gruppo);

            return isMember;

        }
        public static List<GroupPrincipal> EstraiGruppi(string account)
        {
            List<GroupPrincipal> result = new List<GroupPrincipal>();

            PrincipalContext yourDomain = new PrincipalContext(ContextType.Domain);
            UserPrincipal user = UserPrincipal.FindByIdentity(yourDomain, account);

            if (user != null)
            {
                PrincipalSearchResult<Principal> groups = user.GetAuthorizationGroups();

                foreach (Principal p in groups)
                {
                    if (p is GroupPrincipal)
                    {
                        result.Add((GroupPrincipal)p);
                    }
                }
            }

            return result;
        }
    }
}
