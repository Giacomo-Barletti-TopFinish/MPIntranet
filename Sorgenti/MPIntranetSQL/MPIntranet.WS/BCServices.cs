using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using NAV;
using Microsoft.OData.Client;
using System.ServiceModel;

namespace MPIntranet.WS
{
    public class BCServices
    {
        private string _user = "eos_ws";
        private string _url = "https://srv-bc.viamattei.metal-plus.it:7148/PROD_WS/ODataV4/Company('METALPLUS')/";
        private string _password = "V0Wz3MIxhXb2OvTv6y81pahROq6pFmqtPk3PTlnOzws=";
        private NAV.NAV _nav;
        private int timer = 1500;
        string _azienda = "METALPLUS";
        public void CreaConnessione()
        {
            Uri uri = new Uri(_url);
            _nav = new NAV.NAV(uri);
            _nav.Credentials = new NetworkCredential(_user, _password);
        }
        public void PostingRegMag()
        {
            string url = "https://srv-bc.viamattei.metal-plus.it:7147/PROD_WS/WS/METALPLUS/Codeunit/PostingRegMag";
            if (_azienda != "METALPLUS")
                url = "https://srv-bc.viamattei.metal-plus.it:7147/PROD_WS/WS/METALPLUS%2008092021/Codeunit/PostingRegMag";

            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Security.Mode = BasicHttpSecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;

            ServicePostingRegMag.PostingRegMag_PortClient ws = new ServicePostingRegMag.PostingRegMag_PortClient(binding, new EndpointAddress(url));
            ws.ClientCredentials.UserName.UserName = _user;
            ws.ClientCredentials.UserName.Password = _password;
            ws.WSPostItemJnl();
        }
        public void CreaConnessione(string azienda)
        {
            _azienda = azienda;
            string url = "https://srv-bc.viamattei.metal-plus.it:7148/PROD_WS/ODataV4/Company('" + _azienda + "')/";
            Uri uri = new Uri(url);
            _nav = new NAV.NAV(uri);
            _nav.Credentials = new NetworkCredential(_user, _password);
        }

        public void Salva()
        {
            try
            {
                if (_nav == null) return;
                _nav.SaveChanges();
                System.Threading.Thread.Sleep(timer);
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
            try
            {
                TestataDIBA t = _nav.TestataDIBA.Where(x => x.No == No).FirstOrDefault();
                return t;
            }
            catch
            {
                return null;
            }
        }
        public List<Allegati> EstraiAllegati(string Anagrafica)
        {
            if (_nav == null) return null;
            try
            {
                List<Allegati> t = _nav.Allegati.Where(x => x.No == Anagrafica).ToList();

                return t;
            }
            catch
            {
                return null;
            }
        }
        public Articoli EstraiArticolo(string Anagrafica)
        {
            if (_nav == null) return null;
            try
            {
                Articoli t = _nav.Articoli.Where(x => x.No == Anagrafica).FirstOrDefault();
                return t;
            }
            catch
            {
                return null;
            }
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

        public List<RigheDIBA> EstraiComponenti(string NoComponente, string NoDistinta, string versioneDistinta)
        {
            if (_nav == null) return null;

            List<RigheDIBA> componenti = _nav.RigheDIBA.Where(x => x.No == NoComponente && x.Production_BOM_No == NoDistinta && x.Version_Code == versioneDistinta).ToList();
            return componenti;
        }


        public void CambiaStatoDB(string No, string stato)
        {
            TestataDIBA testata = EstraiTestataDIBA(No);
            if (testata == null)
            {
                throw new Exception(string.Format("Distinta {0} non trovata", No));
            }
            if (testata.Status != stato)
            {
                testata.Status = stato;
                _nav.UpdateObject(testata);
                Salva();
            }
        }

        public void CambiaDescrizioneDB(string No, string descrizione)
        {
            TestataDIBA testata = EstraiTestataDIBA(No);
            testata.Description = descrizione;
            _nav.UpdateObject(testata);
            Salva();
        }

        public void AggiungiComponente(string NoDistinta, string versioneDistinta, int numeroRiga, string tipo, string No, string descrizione, string UM,
            decimal quantitaPer, string collegamento, decimal scarto, decimal arrotondamento)
        {
            RigheDIBA componente = new RigheDIBA();

            componente.Production_BOM_No = NoDistinta;
            componente.Version_Code = versioneDistinta;
            componente.Line_No = numeroRiga;
            componente.Type = tipo;
            componente.No = No;
            componente.Description = descrizione;
            componente.Unit_of_Measure_Code = UM;
            componente.Quantity_per = quantitaPer;
            componente.Routing_Link_Code = collegamento;
            componente.Scrap_Percent = scarto;
            componente.MTP_Precious_Quantity = arrotondamento;
            _nav.AddToRigheDIBA(componente);
            Salva();
        }


        public void RimuoviComponente(string NoDistinta, string versioneDistinta, int numeroRiga, string No, bool conSalvataggio)
        {
            List<RigheDIBA> componenti = EstraiComponenti(No, NoDistinta, versioneDistinta);
            componenti = componenti.Where(x => x.Line_No == numeroRiga).ToList();

            foreach (RigheDIBA r in componenti)
                _nav.DeleteObject(r);

            if (conSalvataggio)
                Salva();
        }

        public void ModificaComponente(string NoDistinta, string versioneDistinta, int numeroRiga, string No, string descrizione,
       decimal quantitaPer, string collegamento, decimal scarto, decimal arrotondamento)
        {

            List<RigheDIBA> componenti = EstraiComponenti(No, NoDistinta, versioneDistinta);
            componenti = componenti.Where(x => x.Line_No == numeroRiga).ToList();
            if (componenti.Count == 1)
            {
                RigheDIBA componente = componenti[0];

                componente.Production_BOM_No = NoDistinta;
                componente.Version_Code = versioneDistinta;
                componente.Line_No = numeroRiga;
                componente.No = No;
                componente.Description = descrizione;
                componente.Quantity_per = quantitaPer;
                componente.Routing_Link_Code = collegamento;
                componente.Scrap_Percent = scarto;
                componente.MTP_Precious_Quantity = arrotondamento;
                _nav.UpdateObject(componente);
                Salva();
            }

        }

        public Cicli EstraiTestataCiclo(string NoCiclo)
        {
            if (_nav == null) return null;
            try
            {
                Cicli t = _nav.Cicli.Where(x => x.No == NoCiclo).FirstOrDefault();
                return t;

            }
            catch
            {
                return null;
            }
        }

        public List<RigheCICLO> EstraiRigheCICLO(string NoCiclo)
        {
            if (_nav == null) return null;
            //       List<RigheCICLO> righe = _nav.RigheCICLO.ToList();
            List<RigheCICLO> righe = _nav.RigheCICLO.Where(x => x.Routing_No == NoCiclo).ToList();
            return righe;
        }
        public void CambiaStatoCiclo(string NoCiclo, string stato)
        {
            Cicli testata = EstraiTestataCiclo(NoCiclo);
            if (testata.Status != stato)
            {
                testata.Status = stato;
                _nav.UpdateObject(testata);
                Salva();
            }
        }

        public void CambiaDescrizioneCiclo(string NoCiclo, string descrizione)
        {
            Cicli c = EstraiTestataCiclo(NoCiclo);
            c.Description = descrizione;
            _nav.UpdateObject(c);
            Salva();
        }
        public void AggiungiFase(string NoCiclo, string versioneCiclo, string operazione, string tipo, string areaProduzione, string task, decimal setup, string UMSetup,
         decimal lavorazione, string UMLavorazione, decimal attesa, string UMAttesa, decimal spostamento, string UMSpostamento,
      decimal dimensioneLotto, string collegamento, string condizione, string logica, string caratteristica, string descrizione)
        {
            RigheCICLO fase = new RigheCICLO();
            fase.Description = descrizione;
            fase.Lot_Size = dimensioneLotto;
            fase.Move_Time = spostamento;
            fase.Move_Time_Unit_of_Meas_Code = UMSpostamento;
            fase.No = areaProduzione;
            fase.Operation_No = operazione;
            fase.Routing_No = NoCiclo;
            fase.Run_Time = lavorazione;
            fase.Run_Time_Unit_of_Meas_Code = UMLavorazione;
            fase.Setup_Time = setup;
            fase.Setup_Time_Unit_of_Meas_Code = UMSetup;
            fase.Standard_Task_Code = task;
            fase.Type = tipo;
            fase.Version_Code = versioneCiclo;
            fase.Wait_Time = attesa;
            fase.Wait_Time_Unit_of_Meas_Code = UMAttesa;
            fase.Routing_Link_Code = collegamento;
            _nav.AddToRigheCICLO(fase);
            Salva();
        }

        public void CreaRegistrazioneMagazzino(string ubicazione, string collocazione, string documento, int lineNumber, decimal quantita, string anagrafica)
        {
            string batchName = "REGWS";
            RegMesWS nuovo = new RegMesWS();
            nuovo.Bin_Code = collocazione;
            nuovo.Document_No = documento;
            nuovo.Entry_Type = "Positive Adjmt.";
            nuovo.Journal_Batch_Name = batchName;
            nuovo.Journal_Template_Name = "ARTICOLO";
            nuovo.Line_No = lineNumber;
            nuovo.Location_Code = ubicazione;
            nuovo.Quantity = quantita;
            nuovo.Item_No = anagrafica;
            nuovo.Unit_Cost = 0;
            nuovo.Posting_Date = DateTime.Today;
            _nav.AddToRegMesWS(nuovo);

            Salva();
        }

        public void RimuoviFase(string NoCiclo, string versioneCiclo, string operazione, bool conSalvataggio)
        {
            List<RigheCICLO> componenti = EstraiRigheCICLO(NoCiclo);
            componenti = componenti.Where(x => x.Operation_No == operazione).ToList();

            foreach (RigheCICLO r in componenti)
                _nav.DeleteObject(r);

            if (conSalvataggio)
                Salva();
        }

        public void ModificaFase(string NoCiclo, string versioneCiclo, string operazione, string tipo, string areaProduzione, string task, decimal setup, string UMSetup,
       decimal lavorazione, string UMLavorazione, decimal attesa, string UMAttesa, decimal spostamento, string UMSpostamento,
    decimal dimensioneLotto, string collegamento, string condizione, string logica, string caratteristica, string descrizione)
        {
            List<RigheCICLO> fasi = EstraiRigheCICLO(NoCiclo);
            fasi = fasi.Where(x => x.Version_Code == versioneCiclo && x.Operation_No == operazione).ToList();
            if (fasi.Count == 1)
            {

                RigheCICLO fase = fasi[0];
                fase.Description = descrizione;
                fase.Lot_Size = dimensioneLotto;
                fase.Move_Time = spostamento;
                fase.Move_Time_Unit_of_Meas_Code = UMSpostamento;
                fase.No = areaProduzione;
                fase.Operation_No = operazione;
                fase.Routing_No = NoCiclo;
                fase.Run_Time = lavorazione;
                fase.Run_Time_Unit_of_Meas_Code = UMLavorazione;
                fase.Setup_Time = setup;
                fase.Setup_Time_Unit_of_Meas_Code = UMSetup;
                fase.Standard_Task_Code = task;
                fase.Type = tipo;
                fase.Version_Code = versioneCiclo;
                fase.Wait_Time = attesa;
                fase.Wait_Time_Unit_of_Meas_Code = UMAttesa;
                fase.Routing_Link_Code = collegamento;

                _nav.UpdateObject(fase);
                Salva();
            }
        }

        public List<CommentiFasi> EstraiCommenti(string NoCiclo, string versioneCiclo)
        {
            if (_nav == null) return null;

            List<CommentiFasi> t = _nav.CommentiFasi.Where(x => x.Routing_No == NoCiclo && x.Version_Code == versioneCiclo).ToList();
            return t;
        }

        public void RimuoviCommento(string NoCiclo, string versioneCiclo, string operazione, bool conSalvataggio)
        {
            List<CommentiFasi> commenti = _nav.CommentiFasi.Where(x => x.Routing_No == NoCiclo && x.Version_Code == versioneCiclo).ToList();
            commenti = commenti.Where(x => x.Operation_No == operazione).ToList();

            foreach (CommentiFasi r in commenti)
                _nav.DeleteObject(r);
            if (conSalvataggio)
                Salva();
        }
        public void AggiungiCommento(string NoCiclo, string versioneCiclo, string operazione, string commento)
        {

            List<string> commenti = SeparaStringa(commento, 80);
            int lineNumber = 10;
            foreach (string str in commenti)
            {
                CommentiFasi cf = new CommentiFasi();
                cf.Comment = str;
                cf.Date = DateTime.Now;
                cf.Line_No = lineNumber;
                lineNumber += 10;

                cf.Operation_No = operazione;
                cf.Routing_No = NoCiclo;
                cf.Version_Code = versioneCiclo;

                _nav.AddToCommentiFasi(cf);
            }
            Salva();

        }

        private List<string> SeparaStringa(string stringa, int lunghezzaMassima)
        {
            List<string> stringhe = new List<string>();

            string stringaModificata = stringa.Replace("+", " + ");
            stringaModificata = stringaModificata.Replace("-", " - ");
            stringaModificata = stringaModificata.Replace("  ", " ");

            string[] str = stringaModificata.Split(' ');
            string stringaComposta = string.Empty;
            for (int i = 0; i < str.Length; i++)
            {
                if ((stringaComposta.Length + str[i].Length + 1) < lunghezzaMassima)
                {
                    stringaComposta = stringaComposta + " " + str[i];
                }
                else
                {
                    stringhe.Add(stringaComposta);
                    stringaComposta = str[i];
                }
                if (i == str.Length - 1)
                {
                    stringhe.Add(stringaComposta);
                }
            }
            return stringhe;
        }
        public string CreaOdDPConfermato(string Anagrafica, DateTime data, decimal quantita, string ubicazione, string descrizione, string descrizione2)

        {

            NAV.ODPConfermato oDP = new ODPConfermato();

            oDP.Source_No = Anagrafica;
            oDP.Due_Date = data;
            oDP.Location_Code = ubicazione;
            oDP.Quantity = quantita;
            oDP.Description = descrizione;
            oDP.Description_2 = descrizione2;
            oDP.Status = "Confermato";
            oDP.No = string.Empty;
            _nav.AddToODPConfermato(oDP);
            Salva();
            oDP.Description = descrizione;
            oDP.Description_2 = descrizione2;
            _nav.UpdateObject(oDP);
            Salva();
            return oDP.No;
        }
        public void RegMag(string Anagrafica, DateTime Due_Date, decimal Quantity, string Location_Code, string Description, string Description2)

        {

            NAV.ODPRilasciato oDP = new ODPRilasciato();
            oDP.Source_No = Anagrafica;
            oDP.Due_Date = Due_Date;
            oDP.Location_Code = Location_Code;
            oDP.Quantity = Quantity;
            oDP.Description = Description;
            oDP.Description_2 = Description2;
            oDP.Status = "Rilasciato";
            oDP.No = string.Empty;
            _nav.AddToODPRilasciato(oDP);
            Salva();
        }
        public List<ODPRilasciato> EstraiOdPRilasciati()
        {
            List<ODPRilasciato> odps = _nav.ODPRilasciato.ToList();
            return odps;

        }

        public ODPRilasciato EstraiOdPRilasciato(string codice)
        {
            return _nav.ODPRilasciato.Where(x => x.No == codice).FirstOrDefault();

        }

        public void ModificaDescrizioneOdp(string No, string Description, string Description2)

        {

            NAV.ODPRilasciato oDP = _nav.ODPRilasciato.Where(x => x.No == No).FirstOrDefault();
            oDP.Description = Description;
            oDP.Description_2 = Description2;
            _nav.UpdateObject(oDP);
            Salva();
        }
        public List<RegMagazzino> EstraiMagazzino()
        {
            if (_nav == null) return null;


            List<RegMagazzino> t = _nav.RegMagazzino.ToList();
            _nav.AddToRegMagazzino(t[0]);
            Salva();
            return t;

        }

    }

}
