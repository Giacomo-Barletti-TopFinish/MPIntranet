using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using NAV;

namespace MPIntranet.WS
{
    public class BCServices
    {
        private string _user = "eos_ws";
        private string _url = "https://srv-bc.viamattei.metal-plus.it:7148/PROD_WS/ODataV4/Company('METALPLUS')/";
        private string _password = "V0Wz3MIxhXb2OvTv6y81pahROq6pFmqtPk3PTlnOzws=";
        private NAV.NAV _nav;
        public void CreaConnessione()
        {
            Uri uri = new Uri(_url);
            _nav = new NAV.NAV(uri);
            _nav.Credentials = new NetworkCredential(_user, _password);
        }

        public void Salva()
        {
            try
            {
                if (_nav == null) return;
                _nav.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    message = message + Environment.NewLine + ex.Message;
                    if (ex is Microsoft.OData.ODataErrorException)
                    {
                        message = message + Environment.NewLine + ex.Message;
                    }
                }
                Exception newex = new Exception(message);
                throw (newex);
            }
        }
        public TestataDIBA EstraiTestataDIBA(string No)
        {
            if (_nav == null) return null;

            TestataDIBA t = _nav.TestataDIBA.Where(x => x.No == No).FirstOrDefault();
            return t;
        }

        public List<RigheDIBA> EstraiRigheDIBA(string No)
        {
            if (_nav == null) return null;

            List<RigheDIBA> righe = _nav.RigheDIBA.Where(x => x.Production_BOM_No == No).ToList();
            return righe;
        }
        public List<RigheDIBA> EstraiComponenti(string NoComponente)
        {
            if (_nav == null) return null;

            List<RigheDIBA> componenti = _nav.RigheDIBA.Where(x => x.No == NoComponente).ToList();
            return componenti;
        }



        public void CambiaStatoDB(string No, string stato)
        {
            TestataDIBA testata = EstraiTestataDIBA(No);
            testata.Status = stato;
            _nav.UpdateObject(testata);
            Salva();
        }

        public void CambiaDescrizioneDB(string No, string descrizione)
        {
            TestataDIBA testata = EstraiTestataDIBA(No);
            testata.Description= descrizione;
            _nav.UpdateObject(testata);
            Salva();
        }
       

    }

}
