using MPIntranet.DataAccess.Security;
using MPIntranet.Entities;
using MPIntranet.Models.Common;
using MPIntranet.Models.Security;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace MPIntranet.Security
{
    public class Account
    {
        private const int TokenValidityInMinutes = 3000;
        private const int BlockFailedCount = 30000;
        private const int PasswordLength = 8;
        private const int TokenLength = 32;
        private const int MinRandomPasswordValue = 65;
        private const int MaxRandomPasswordValue = 90;

        public Account()
        {

        }

        public string VerificaAccount(string account, string password, string ipAddress)
        {
            if (Dominio.ValidaCredenziali(account, password))
            {
                string token = GeneraToken();
                SecurityDS ds = new SecurityDS();
                using (SecurityBusiness bSecurity = new SecurityBusiness())
                {
                    bSecurity.SaveToken(account, token, TokenValidityInMinutes, ipAddress);
                    return token;
                }
            }
            return string.Empty;
        }

        private static string GeneraToken()
        {
            using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
            {

                StringBuilder tokenBuilder = new StringBuilder(TokenLength);
                Random randomizer = new Random();

                for (int i = 0; i < TokenLength; i++)
                {
                    int randomNumber = randomizer.Next(MinRandomPasswordValue, MaxRandomPasswordValue);
                    char ch = Convert.ToChar(randomNumber);
                    tokenBuilder.Append(ch);
                }

                return tokenBuilder.ToString();
            }
        }
        public static TokenModel GetTokenModel(string token)
        {
            using (SecurityBusiness bSecurity = new SecurityBusiness())
            {
                SecurityDS ds = new SecurityDS();

                bSecurity.GetToken(ds, token);
                SecurityDS.TOKENRow t = ds.TOKEN.Where(x => x.TOKEN == token).FirstOrDefault();
                if (t == null) return null;

                TokenModel tok = new TokenModel()
                {
                    IpAddress = t.IsIPADDRESSNull() ? string.Empty : t.IPADDRESS,
                    Token = token,
                    Account = t.UTENTE
                };

                return tok;
            }
        }

        public List<MenuModel> CreateMenuModel(string account)
        {
            SecurityDS ds = new SecurityDS();
            using (SecurityBusiness bSecurity = new SecurityBusiness())
            {
                bSecurity.FillMenu(ds);
                bSecurity.FillAccountMenu(account, ds);
            }

            List<int> idMenuAbilitati = ds.ABILITAZIONI.Where(x => x.UTENTE == account).Select(x => (int)x.IDMENU).ToList();

            List<MenuModel> menu = new List<MenuModel>();
            foreach (SecurityDS.MENURow row in ds.MENU.Where(x => x.IsIDMENUPADRENull()))
            {
                MenuModel elementoMenu = CreaMenu(ds, row.IDMENU, idMenuAbilitati);
                menu.Add(elementoMenu);
            }



            return menu;
        }

        private MenuModel CreaMenu(SecurityDS ds, decimal idMenu, List<int> idMenuAbilitati)
        {
            SecurityDS.MENURow row = ds.MENU.Where(x => x.IDMENU == idMenu).FirstOrDefault();

            MenuModel padre = new MenuModel();
            padre.IdMenu = (int)row.IDMENU;
            padre.Etichetta = row.ETICHETTA;
            padre.HRef = row.IsHREFNull() ? string.Empty : row.HREF;
            padre.OnClick = row.IsONCLICKNull() ? string.Empty : row.ONCLICK;
            padre.Font = row.IsFONTNull() ? string.Empty : row.FONT;
            padre.MenuFiglio = new List<MenuModel>();
            padre.Abilitato = idMenuAbilitati.Contains(padre.IdMenu) ? true : false;

            foreach (SecurityDS.MENURow rowFiglio in ds.MENU.Where(x => !x.IsIDMENUPADRENull() && x.IDMENUPADRE == row.IDMENU).OrderBy(x => x.SEQUENZA))
            {
                MenuModel figlio = CreaMenu(ds, rowFiglio.IDMENU, idMenuAbilitati);
                padre.MenuFiglio.Add(figlio);
            }
            return padre;
        }      

        public void SalvaMenuUtente(string account, int[] idMenu)
        {
            SecurityDS ds = new SecurityDS();
            using (SecurityBusiness bSecurity = new SecurityBusiness())
            {
                bSecurity.FillAccountMenu(account, ds);

                if (idMenu == null)
                {
                    foreach (SecurityDS.ABILITAZIONIRow row in ds.ABILITAZIONI.ToList())
                        row.Delete();
                    bSecurity.SalvaMenuUtente(ds);
                    return;
                }

                foreach (SecurityDS.ABILITAZIONIRow row in ds.ABILITAZIONI.Where(x => !idMenu.Contains((int)x.IDMENU)).ToList())
                    row.Delete();

                foreach (int idm in idMenu)
                {
                    SecurityDS.ABILITAZIONIRow row = ds.ABILITAZIONI.Where(x => x.RowState != System.Data.DataRowState.Deleted && x.IDMENU == idm).FirstOrDefault();
                    if (row == null)
                    {
                        SecurityDS.ABILITAZIONIRow newrow = ds.ABILITAZIONI.NewABILITAZIONIRow();
                        newrow.IDMENU = idm;
                        newrow.UTENTE = account;
                        ds.ABILITAZIONI.AddABILITAZIONIRow(newrow);
                    }
                }
                bSecurity.SalvaMenuUtente(ds);
            }
        }

        public bool VerificaAbilitazioneUtente(int idMenu, string account)
        {
            using (SecurityBusiness bSecurity = new SecurityBusiness())
            {
                SecurityDS ds = new SecurityDS();
                bSecurity.FillAccountMenu(account, ds);

                return ds.ABILITAZIONI.Any(x => x.IDMENU == idMenu);
            }
        }
    }
}
