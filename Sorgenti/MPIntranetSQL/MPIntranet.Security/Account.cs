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

        public void CreaAccount(string account, bool copia, string daCopiare)
        {
            SecurityDS ds = new SecurityDS();
            using (SecurityBusiness bSecurity = new SecurityBusiness())
            {
                if (copia)
                {
                    bSecurity.FillAccountMenu(daCopiare, ds);
                    List<decimal> menu = ds.ABILITAZIONI.Where(x => x.UTENTE == daCopiare).Select(x => x.IDMENU).Distinct().ToList();

                    foreach (decimal idm in menu)
                    {
                        SecurityDS.ABILITAZIONIRow newrow = ds.ABILITAZIONI.NewABILITAZIONIRow();
                        newrow.IDMENU = idm;
                        newrow.UTENTE = account;
                        ds.ABILITAZIONI.AddABILITAZIONIRow(newrow);
                    }
                }
                else
                {
                    bSecurity.FillMenu(ds);

                    foreach (int idm in ds.MENU.Where(x => x.IsAZIONENull()).Select(x => x.IDMENU))
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

        public List<MenuModel> CreateMenuModel(string account, bool mostratutto)
        {
            SecurityDS ds = new SecurityDS();
            using (SecurityBusiness bSecurity = new SecurityBusiness())
            {
                bSecurity.FillMenu(ds);
                bSecurity.FillAccountMenu(account, ds);
            }

            List<int> idMenuAbilitati = ds.ABILITAZIONI.Where(x => x.UTENTE == account).Select(x => (int)x.IDMENU).ToList();

            List<MenuModel> menu = new List<MenuModel>();
            List<SecurityDS.MENURow> menuDaVisualizzare = ds.MENU.Where(x => x.IsIDMENUPADRENull()).ToList();
            if (!mostratutto)
                menuDaVisualizzare = ds.MENU.Where(x => x.IsIDMENUPADRENull() && x.IsAZIONENull()).ToList();
            foreach (SecurityDS.MENURow row in menuDaVisualizzare)
            {
                MenuModel elementoMenu = CreaMenu(ds, row.IDMENU, idMenuAbilitati, mostratutto);
                menu.Add(elementoMenu);
            }
            return menu;
        }


        private MenuModel CreaMenu(SecurityDS ds, decimal idMenu, List<int> idMenuAbilitati, bool mostratutto)
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
            padre.Azione = !row.IsAZIONENull();

            if (mostratutto)
                foreach (SecurityDS.MENURow rowFiglio in ds.MENU.Where(x => !x.IsIDMENUPADRENull() && x.IDMENUPADRE == row.IDMENU).OrderBy(x => x.SEQUENZA))
                {
                    MenuModel figlio = CreaMenu(ds, rowFiglio.IDMENU, idMenuAbilitati, mostratutto);
                    padre.MenuFiglio.Add(figlio);
                }
            else
                foreach (SecurityDS.MENURow rowFiglio in ds.MENU.Where(x => !x.IsIDMENUPADRENull() && x.IDMENUPADRE == row.IDMENU && x.IsAZIONENull()).OrderBy(x => x.SEQUENZA))
                {
                    MenuModel figlio = CreaMenu(ds, rowFiglio.IDMENU, idMenuAbilitati, mostratutto);
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

        public void RimuoviAccount(string account)
        {
            SecurityDS ds = new SecurityDS();
            using (SecurityBusiness bSecurity = new SecurityBusiness())
            {
                bSecurity.FillAccountMenu(account, ds);

                foreach (SecurityDS.ABILITAZIONIRow row in ds.ABILITAZIONI.ToList())
                    row.Delete();
                bSecurity.SalvaMenuUtente(ds);
                return;
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

        public static List<decimal> MenuAbilitatiPerUtente(string account)
        {
            using (SecurityBusiness bSecurity = new SecurityBusiness())
            {
                SecurityDS ds = new SecurityDS();
                bSecurity.FillAccountMenu(account, ds);
                return ds.ABILITAZIONI.Select(x => x.IDMENU).Distinct().ToList();
            }
        }
        public bool VerificaAbilitazioneUtente(string controller, string action, string account)
        {
            using (SecurityBusiness bSecurity = new SecurityBusiness())
            {
                SecurityDS ds = new SecurityDS();
                bSecurity.FillAccountMenu(account, ds);
                bSecurity.FillMenu(ds);

                string azione = string.Format("/{0}/{1}", controller.ToUpper(), action.ToUpper());
                SecurityDS.MENURow menu = ds.MENU.Where(x => !x.IsHREFNull() && x.HREF.ToUpper() == azione).FirstOrDefault();
                if (menu == null) return true; // non esiste nella tabella manu allora accesso libero
                return ds.ABILITAZIONI.Any(x => x.IDMENU == menu.IDMENU);
            }
        }

        public List<string> EstraiListaUtentiAbilitati()
        {
            using (SecurityBusiness bSecurity = new SecurityBusiness())
            {
                return bSecurity.EstraiListaUtentiAbilitati();
            }
        }
    }
}
