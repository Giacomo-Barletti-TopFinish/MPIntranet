using MPIntranet.Common;
using MPIntranet.DataAccess.Manutenzione;
using MPIntranet.Entities;
using MPIntranet.Models;
using MPIntranet.Models.Manutenzione;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class Manutenzione: BusinessBase
    {
        private ManutenzioneDS _ds = new ManutenzioneDS();

        public string CreaDitta(string ragioneSociale, string account)
        {
            string dittaStr = correggiString(ragioneSociale, 45);

            using (ManutezioneBusiness bManutenzione = new ManutezioneBusiness())
            {
                bManutenzione.FillDitte(_ds, false);

                if (_ds.DITTE.Any(x => x.RAGIONESOCIALE.Trim() == dittaStr))
                    return "Ditta già inserita a sistema";

                ManutenzioneDS.DITTERow ditta = _ds.DITTE.NewDITTERow();

                ditta.CANCELLATO = SiNo.No;
                ditta.DATAMODIFICA = DateTime.Now;
                ditta.UTENTEMODIFICA = account;
                ditta.RAGIONESOCIALE = dittaStr;
                _ds.DITTE.AddDITTERow(ditta);

                bManutenzione.UpdateTable(_ds.DITTE.TableName, _ds);
            }
            return string.Empty;
        }

        public string CreaManutentore(string NomeCognome, string Account, decimal IdDitta, string Nota, string account)
        {
            string nomeCognome = correggiString(NomeCognome, 45);
            string utente = correggiString(Account, 45);
            string nota = correggiString(Nota, 100);

            using (ManutezioneBusiness bManutenzione = new ManutezioneBusiness())
            {
                bManutenzione.FillManutentori(_ds, false);

                if (_ds.MANUTENTORI.Any(x => x.NOMECOGNOME.Trim() == nomeCognome))
                    return "Manutentore già inserito a sistema";

                ManutenzioneDS.MANUTENTORIRow manutentore = _ds.MANUTENTORI.NewMANUTENTORIRow();

                manutentore.CANCELLATO = SiNo.No;
                manutentore.DATAMODIFICA = DateTime.Now;
                manutentore.UTENTEMODIFICA = account;
                manutentore.NOMECOGNOME = nomeCognome;
                manutentore.ACCOUNT = utente;
                manutentore.IDDITTA = IdDitta;
                manutentore.NOTA = nota;

                _ds.MANUTENTORI.AddMANUTENTORIRow(manutentore);

                bManutenzione.UpdateTable(_ds.MANUTENTORI.TableName, _ds);
            }
            return string.Empty;
        }

        public string CreaMacchina(string NumeroSerie, string Descrizione, decimal IdDitta, string Luogo, string Nota, string DataCostruzione, decimal IdPadre, string account)
        {
            NumeroSerie = correggiString(NumeroSerie, 20);
            Descrizione = correggiString(Descrizione, 45);
            Luogo = correggiString(Luogo, 45);
            Nota = correggiString(Nota, 100);

            using (ManutezioneBusiness bManutenzione = new ManutezioneBusiness())
            {
                bManutenzione.FillMacchine(_ds, false);

                if (_ds.MACCHINE.Any(x => x.SERIALE.Trim() == NumeroSerie && x.IDDITTA == IdDitta))
                    return "Macchina già inserita a sistema per questa ditta con questo numero di serie";

                ManutenzioneDS.MACCHINERow macchina = _ds.MACCHINE.NewMACCHINERow();

                macchina.CANCELLATO = SiNo.No;
                macchina.DATAMODIFICA = DateTime.Now;
                macchina.UTENTEMODIFICA = account;

                macchina.IDDITTA = IdDitta;
                if (IdPadre >= 0)
                    macchina.IDPADRE = IdPadre;
                macchina.SERIALE = NumeroSerie;
                macchina.DESCRIZIONE = Descrizione;
                macchina.NOTE = Nota;
                macchina.LUOGO = Luogo;
                macchina.DATACOSTRUZIONE = DataCostruzione.Length > 10 ? DataCostruzione.Substring(0, 10) : DataCostruzione;

                _ds.MACCHINE.AddMACCHINERow(macchina);

                bManutenzione.UpdateTable(_ds.MACCHINE.TableName, _ds);
            }
            return string.Empty;
        }

        public string CreaIntervento(string Descrizione, string Luogo, DateTime Data, decimal Durata, decimal IdMacchina, decimal IdManutentore, string Frequenza, string Nota, decimal IdSerie, string Stato, string account)
        {
            using (ManutezioneBusiness bManutenzione = new ManutezioneBusiness())
            {

                ManutenzioneDS.INTERVENTIRow intervento = _ds.INTERVENTI.NewINTERVENTIRow();

                intervento.CANCELLATO = SiNo.No;
                intervento.DATAMODIFICA = DateTime.Now;
                intervento.UTENTEMODIFICA = account;

                intervento.DESCRIZIONE = Descrizione;
                intervento.DURATA = Durata;
                if (IdMacchina > 0) intervento.IDMACCHINA = IdMacchina;
                if (IdManutentore > 0) intervento.IDMANUTENTORE = IdManutentore;
                if (IdSerie > 0) intervento.IDSERIE = IdSerie;
                intervento.FREQUENZA = correggiString(Frequenza, 20);
                intervento.NOTE = correggiString(Nota, 200);
                intervento.LUOGO = correggiString(Luogo, 50);
                intervento.DATAINTERVENTO = Data;
                intervento.STATO = correggiString(Stato, 25);

                _ds.INTERVENTI.AddINTERVENTIRow(intervento);

                bManutenzione.UpdateTable(_ds.INTERVENTI.TableName, _ds);
            }
            return string.Empty;
        }

        public void ModificaIntervento(decimal IdIntervento, DateTime Data, string Stato, decimal Durata, decimal IdManutentore, string Frequenza, string Nota, string account)
        {


            using (ManutezioneBusiness bManutenzione = new ManutezioneBusiness())
            {
                bManutenzione.FillInterventi(_ds, true);

                ManutenzioneDS.INTERVENTIRow intervento = _ds.INTERVENTI.Where(x => x.IDINTERVENTO == IdIntervento).FirstOrDefault();

                if (intervento == null) return;
                intervento.DATAMODIFICA = DateTime.Now;
                intervento.UTENTEMODIFICA = account;

                intervento.DURATA = Durata;
                if (IdManutentore > 0) intervento.IDMANUTENTORE = IdManutentore;
                if (IdManutentore == -1) intervento.SetIDMANUTENTORENull();

                intervento.FREQUENZA = correggiString(Frequenza, 20);
                intervento.NOTE = correggiString(Nota, 200);
                intervento.DATAINTERVENTO = Data;
                intervento.STATO = correggiString(Stato, 25);


                bManutenzione.UpdateTable(_ds.INTERVENTI.TableName, _ds);
            }
           
        }

        public List<DittaModel> CreaListaDittaModel()
        {
            List<DittaModel> lista = new List<DittaModel>();

            using (ManutezioneBusiness bManutenzione = new ManutezioneBusiness())
            {
                bManutenzione.FillDitte(_ds, true);
                bManutenzione.FillRiferimenti(_ds, true);

                foreach (ManutenzioneDS.DITTERow d in _ds.DITTE)
                    lista.Add(CreaDittaModel(d, _ds));
            }

            return lista;
        }

        public List<MacchinaModel> CreaListaMacchinaModel()
        {
            List<MacchinaModel> lista = new List<MacchinaModel>();

            using (ManutezioneBusiness bManutenzione = new ManutezioneBusiness())
            {
                bManutenzione.FillMacchine(_ds, true);
                bManutenzione.FillDitte(_ds, true);

                foreach (ManutenzioneDS.MACCHINERow d in _ds.MACCHINE)
                    lista.Add(CreaMacchinaModel(d, _ds));
            }

            return lista;
        }

        public List<InterventoModel> CreaListaInterventoModel()
        {
            List<InterventoModel> lista = new List<InterventoModel>();

            using (ManutezioneBusiness bManutenzione = new ManutezioneBusiness())
            {
                bManutenzione.FillMacchine(_ds, true);
                bManutenzione.FillManutentori(_ds, true);
                bManutenzione.FillInterventi(_ds, true);


                foreach (ManutenzioneDS.INTERVENTIRow d in _ds.INTERVENTI)
                    lista.Add(CreaInterventoModel(d, _ds));
            }

            return lista;
        }
        public List<ManutentoreModel> CreaListaManutentoreModel()
        {
            List<ManutentoreModel> lista = new List<ManutentoreModel>();

            using (ManutezioneBusiness bManutenzione = new ManutezioneBusiness())
            {
                bManutenzione.FillManutentori(_ds, true);
                bManutenzione.FillDitte(_ds, true);
                bManutenzione.FillRiferimenti(_ds, true);

                foreach (ManutenzioneDS.MANUTENTORIRow d in _ds.MANUTENTORI)
                    lista.Add(CreaManutentoreModel(d, _ds));
            }

            return lista;
        }

        private ManutentoreModel CreaManutentoreModel(ManutenzioneDS.MANUTENTORIRow manutentore, ManutenzioneDS ds)
        {
            ManutentoreModel dm = new ManutentoreModel();
            dm.IdManutentore = manutentore.IDMANUTENTORE;
            dm.NomeCognome = manutentore.NOMECOGNOME;
            dm.Account = manutentore.IsACCOUNTNull() ? string.Empty : manutentore.ACCOUNT;
            dm.Nota = manutentore.IsNOTANull() ? string.Empty : manutentore.NOTA;

            ManutenzioneDS.DITTERow ditta = _ds.DITTE.Where(x => x.IDDITTA == manutentore.IDDITTA).FirstOrDefault();
            dm.Ditta = CreaDittaModel(ditta, _ds);

            RiferimentoModelContainer rmc = new RiferimentoModelContainer();
            dm.Riferimenti = rmc;

            rmc.TabellaEsterna = TabelleEsterne.Manutentori;
            rmc.IdEsterna = manutentore.IDMANUTENTORE;
            rmc.Riferimenti = new List<RiferimentoModel>();

            foreach (ManutenzioneDS.RIFERIMENTIRow riferimento in ds.RIFERIMENTI.Where(x => x.IDESTERNA == manutentore.IDMANUTENTORE && x.TABELLAESTERNA == TabelleEsterne.Manutentori))
                rmc.Riferimenti.Add(CreaRiferimentoModel(riferimento));

            return dm;
        }

        private DittaModel CreaDittaModel(ManutenzioneDS.DITTERow ditta, ManutenzioneDS ds)
        {
            DittaModel dm = new DittaModel();
            dm.IdDitta = ditta.IDDITTA;
            dm.RagioneSociale = ditta.RAGIONESOCIALE;

            RiferimentoModelContainer rmc = new RiferimentoModelContainer();
            dm.Riferimenti = rmc;

            rmc.TabellaEsterna = TabelleEsterne.Ditte;
            rmc.IdEsterna = ditta.IDDITTA;
            rmc.Riferimenti = new List<RiferimentoModel>();

            foreach (ManutenzioneDS.RIFERIMENTIRow riferimento in ds.RIFERIMENTI.Where(x => x.IDESTERNA == ditta.IDDITTA && x.TABELLAESTERNA == TabelleEsterne.Ditte))
                rmc.Riferimenti.Add(CreaRiferimentoModel(riferimento));

            return dm;
        }

        private DittaModel CreaDittaModel(decimal IdDitta, ManutenzioneDS ds)
        {
            ManutenzioneDS.DITTERow ditta = ds.DITTE.Where(x => x.IDDITTA == IdDitta).FirstOrDefault();
            if (ditta == null) return null;

            return CreaDittaModel(ditta, ds);
        }
        private MacchinaModel CreaMacchinaModel(ManutenzioneDS.MACCHINERow macchina, ManutenzioneDS ds)
        {
            MacchinaModel dm = new MacchinaModel();
            dm.Ditta = CreaDittaModel(macchina.IDDITTA, ds);
            dm.DataCostruzione = macchina.IsDATACOSTRUZIONENull() ? string.Empty : macchina.DATACOSTRUZIONE;
            dm.Descrizione = macchina.DESCRIZIONE;
            dm.IdMacchina = macchina.IDMACCHINA;
            dm.Luogo = macchina.IsLUOGONull() ? string.Empty : macchina.LUOGO;
            dm.Nota = macchina.IsNOTENull() ? string.Empty : macchina.NOTE;
            dm.NumeroSerie = macchina.SERIALE;
            if (!macchina.IsIDPADRENull())
            {
                dm.Padre = CreaMacchinaModel(macchina.IDPADRE, ds);
            }

            Documenti documenti = new Documenti();
            dm.Documenti = documenti.CreaDocumentoModelContainer(macchina.IDMACCHINA, TabelleEsterne.Macchine);
            return dm;
        }

        private InterventoModel CreaInterventoModel(ManutenzioneDS.INTERVENTIRow intervento, ManutenzioneDS ds)
        {
            InterventoModel dm = new InterventoModel();
            dm.IdIntervento = intervento.IDINTERVENTO;
            dm.Descrizione = intervento.DESCRIZIONE;
            dm.Durata = intervento.IsDURATANull() ? 0 : intervento.DURATA;

            dm.Macchina = new MacchinaModel();
            if (!intervento.IsIDMACCHINANull())
                dm.Macchina = CreaMacchinaModel(intervento.IDMACCHINA, ds);

            dm.Manutentore = new ManutentoreModel();
            if (!intervento.IsIDMANUTENTORENull())
                dm.Manutentore = CreaManutentoreModel(intervento.IDMANUTENTORE, ds);

            dm.IdSerie = intervento.IsIDSERIENull() ? -1 : intervento.IDSERIE;
            dm.Frequenza = intervento.IsFREQUENZANull() ? string.Empty : intervento.FREQUENZA;
            dm.Nota = intervento.IsNOTENull() ? string.Empty : intervento.NOTE;
            dm.Luogo = intervento.IsLUOGONull() ? string.Empty : intervento.LUOGO;
            dm.Stato = intervento.IsSTATONull() ? string.Empty : intervento.STATO;
            dm.DataIntervento = intervento.DATAINTERVENTO;

            return dm;
        }
        private MacchinaModel CreaMacchinaModel(decimal idMacchina, ManutenzioneDS ds)
        {
            ManutenzioneDS.MACCHINERow macchina = ds.MACCHINE.Where(x => x.IDMACCHINA == idMacchina).FirstOrDefault();
            if (macchina == null) return null;

            return CreaMacchinaModel(macchina, ds);
        }
        private ManutentoreModel CreaManutentoreModel(decimal idManutentore, ManutenzioneDS ds)
        {
            ManutenzioneDS.MANUTENTORIRow manutentore = ds.MANUTENTORI.Where(x => x.IDMANUTENTORE == idManutentore).FirstOrDefault();
            if (manutentore == null) return null;

            return CreaManutentoreModel(manutentore, ds);
        }

        private RiferimentoModel CreaRiferimentoModel(ManutenzioneDS.RIFERIMENTIRow riferimento)
        {
            RiferimentoModel rm = new RiferimentoModel();
            rm.Etichetta = riferimento.ETICHETTA;
            rm.IdRiferimento = riferimento.IDRIFERIMENTO;
            rm.Riferimento = riferimento.RIFERIMENTO;
            rm.Tipologia = riferimento.TIPOLOGIA;

            return rm;
        }
        public void CancellaDitta(decimal idDitta, string account)
        {
            using (ManutezioneBusiness bManutenzione = new ManutezioneBusiness())
            {
                bManutenzione.FillDitte(_ds, true);
                ManutenzioneDS.DITTERow ditta = _ds.DITTE.Where(x => x.IDDITTA == idDitta).FirstOrDefault();
                if (ditta != null)
                {
                    ditta.CANCELLATO = SiNo.Si;
                    ditta.DATAMODIFICA = DateTime.Now;
                    ditta.UTENTEMODIFICA = account;

                    bManutenzione.UpdateTable(_ds.DITTE.TableName, _ds);
                }
            }
        }

        public void CancellaManutentore(decimal IdManutentore, string account)
        {
            using (ManutezioneBusiness bManutenzione = new ManutezioneBusiness())
            {
                bManutenzione.FillManutentori(_ds, true);
                ManutenzioneDS.MANUTENTORIRow manutentore = _ds.MANUTENTORI.Where(x => x.IDMANUTENTORE == IdManutentore).FirstOrDefault();
                if (manutentore != null)
                {
                    manutentore.CANCELLATO = SiNo.Si;
                    manutentore.DATAMODIFICA = DateTime.Now;
                    manutentore.UTENTEMODIFICA = account;

                    bManutenzione.UpdateTable(_ds.MANUTENTORI.TableName, _ds);
                }
            }
        }

        public void CancellaMacchina(decimal IdMacchina, string account)
        {
            using (ManutezioneBusiness bManutenzione = new ManutezioneBusiness())
            {
                bManutenzione.FillMacchine(_ds, true);
                ManutenzioneDS.MACCHINERow macchina = _ds.MACCHINE.Where(x => x.IDMACCHINA == IdMacchina).FirstOrDefault();
                if (macchina != null)
                {
                    macchina.CANCELLATO = SiNo.Si;
                    macchina.DATAMODIFICA = DateTime.Now;
                    macchina.UTENTEMODIFICA = account;

                    bManutenzione.UpdateTable(_ds.MACCHINE.TableName, _ds);
                }
            }
        }

        public void CancellaIntervento(decimal IdIntervento, string account)
        {
            using (ManutezioneBusiness bManutenzione = new ManutezioneBusiness())
            {
                bManutenzione.FillInterventi(_ds, true);
                ManutenzioneDS.INTERVENTIRow intervento = _ds.INTERVENTI.Where(x => x.IDINTERVENTO == IdIntervento).FirstOrDefault();
                if (intervento != null)
                {
                    intervento.CANCELLATO = SiNo.Si;
                    intervento.DATAMODIFICA = DateTime.Now;
                    intervento.UTENTEMODIFICA = account;

                    bManutenzione.UpdateTable(_ds.INTERVENTI.TableName, _ds);
                }
            }
        }
        public void ModificaDitta(decimal idDitta, string ragioneSociale, string account)
        {
            using (ManutezioneBusiness bManutenzione = new ManutezioneBusiness())
            {
                bManutenzione.FillDitte(_ds, true);
                ManutenzioneDS.DITTERow ditta = _ds.DITTE.Where(x => x.IDDITTA == idDitta).FirstOrDefault();
                if (ditta != null)
                {
                    ditta.RAGIONESOCIALE = correggiString(ragioneSociale, 45);

                    ditta.DATAMODIFICA = DateTime.Now;
                    ditta.UTENTEMODIFICA = account;

                    bManutenzione.UpdateTable(_ds.DITTE.TableName, _ds);
                }
            }
        }

        public void ModificaMacchina(decimal IdMacchina, string Luogo, string Nota, string account)
        {
            using (ManutezioneBusiness bManutenzione = new ManutezioneBusiness())
            {
                bManutenzione.FillMacchine(_ds, true);
                ManutenzioneDS.MACCHINERow macchina = _ds.MACCHINE.Where(x => x.IDMACCHINA == IdMacchina).FirstOrDefault();
                if (macchina != null)
                {
                    macchina.LUOGO = correggiString(Luogo, 45);
                    macchina.NOTE = correggiString(Nota, 100);

                    macchina.DATAMODIFICA = DateTime.Now;
                    macchina.UTENTEMODIFICA = account;

                    bManutenzione.UpdateTable(_ds.MACCHINE.TableName, _ds);
                }
            }
        }


        public void ModificaManutentore(decimal IdManutentore, string utente, string nota, string account)
        {
            using (ManutezioneBusiness bManutenzione = new ManutezioneBusiness())
            {
                bManutenzione.FillManutentori(_ds, true);
                ManutenzioneDS.MANUTENTORIRow manutentore = _ds.MANUTENTORI.Where(x => x.IDMANUTENTORE == IdManutentore).FirstOrDefault();
                if (manutentore != null)
                {
                    manutentore.ACCOUNT = correggiString(utente, 45); ;
                    manutentore.NOTA =correggiString( nota,100);

                    manutentore.DATAMODIFICA = DateTime.Now;
                    manutentore.UTENTEMODIFICA = account;

                    bManutenzione.UpdateTable(_ds.MANUTENTORI.TableName, _ds);
                }
            }
        }
        public string CreaRiferimento(decimal IdEsterna, string TabellaEsterna, string Tipologia, string Etichetta, string Riferimento, string account)
        {
            Riferimento =correggiString( Riferimento,45);
            Etichetta =correggiString( Etichetta,45);
            Tipologia =correggiString( Tipologia,45);
            TabellaEsterna = correggiString(TabellaEsterna,45);

            if (string.IsNullOrEmpty(Riferimento))
                return "Riferimento assente";
            if (string.IsNullOrEmpty(Etichetta))
                return "Etichetta assente";
            if (string.IsNullOrEmpty(Tipologia))
                return "Tipologia assente";
            if (string.IsNullOrEmpty(TabellaEsterna))
                return "Tabella esterna assente";

            using (ManutezioneBusiness bManutenzione = new ManutezioneBusiness())
            {
                bManutenzione.FillRiferimenti(_ds, false);

                if (_ds.RIFERIMENTI.Any(x => x.RIFERIMENTO.Trim() == Riferimento && x.IDESTERNA == IdEsterna && x.TABELLAESTERNA == TabellaEsterna))
                    return "Riferimento già inserito a sistema";

                ManutenzioneDS.RIFERIMENTIRow riferimento = _ds.RIFERIMENTI.NewRIFERIMENTIRow();
                riferimento.ETICHETTA = Etichetta;
                riferimento.CANCELLATO = SiNo.No;
                riferimento.DATAMODIFICA = DateTime.Now;
                riferimento.UTENTEMODIFICA = account;
                riferimento.RIFERIMENTO = Riferimento;
                riferimento.IDESTERNA = IdEsterna;
                riferimento.TABELLAESTERNA = TabellaEsterna;
                riferimento.TIPOLOGIA = Tipologia;
                _ds.RIFERIMENTI.AddRIFERIMENTIRow(riferimento);

                bManutenzione.UpdateTable(_ds.RIFERIMENTI.TableName, _ds);
            }

            return string.Empty;
        }

        public void CancellaRiferimento(decimal idRiferimento, string account)
        {
            using (ManutezioneBusiness bManutenzione = new ManutezioneBusiness())
            {
                bManutenzione.FillRiferimenti(_ds, true);
                ManutenzioneDS.RIFERIMENTIRow riferimento = _ds.RIFERIMENTI.Where(x => x.IDRIFERIMENTO == idRiferimento).FirstOrDefault();
                if (riferimento != null)
                {
                    riferimento.CANCELLATO = SiNo.Si;
                    riferimento.DATAMODIFICA = DateTime.Now;
                    riferimento.UTENTEMODIFICA = account;

                    bManutenzione.UpdateTable(_ds.RIFERIMENTI.TableName, _ds);
                }
            }
        }
        public void ModificaRiferimento(decimal idRiferimenti, string Etichetta, string Riferimento, string Tipologia, string account)
        {
            ManutenzioneDS.RIFERIMENTIRow riferimento = _ds.RIFERIMENTI.Where(x => x.IDRIFERIMENTO == idRiferimenti).FirstOrDefault();
            using (ManutezioneBusiness bManutenzione = new ManutezioneBusiness())
            {
                bManutenzione.FillRiferimenti(_ds, true);

                if (riferimento != null)
                {
                    riferimento.ETICHETTA =correggiString( Etichetta,45);
                    riferimento.RIFERIMENTO =correggiString( Riferimento,45);
                    riferimento.TIPOLOGIA =correggiString( Tipologia,45);

                    riferimento.DATAMODIFICA = DateTime.Now;
                    riferimento.UTENTEMODIFICA = account;

                    bManutenzione.UpdateTable(_ds.RIFERIMENTI.TableName, _ds);
                }
            }
        }
    }
}

