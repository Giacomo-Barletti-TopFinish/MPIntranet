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
    public class Manutenzione
    {
        private ManutenzioneDS _ds = new ManutenzioneDS();

        public string CreaDitta(string ragioneSociale, string account)
        {
            string dittaStr = ragioneSociale.ToUpper().Trim();

            using (ManutezioneBusiness bManutenzione = new ManutezioneBusiness())
            {
                bManutenzione.FillDitte(_ds, false);

                if (_ds.DITTE.Any(x => x.RAGIONESOCIALE.Trim() == dittaStr))
                    return "Ditta già inserita a sistema";

                ManutenzioneDS.DITTERow ditta = _ds.DITTE.NewDITTERow();

                ditta.CANCELLATO = SiNo.No;
                ditta.DATAMODIFICA = DateTime.Now;
                ditta.UTENTEMODIFICA = account;
                ditta.RAGIONESOCIALE = dittaStr.Length > 45 ? dittaStr.Substring(0, 45) : dittaStr;
                _ds.DITTE.AddDITTERow(ditta);

                bManutenzione.UpdateTable(_ds.DITTE.TableName, _ds);
            }
            return string.Empty;
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
        public void ModificaDitta(decimal idDitta, string ragioneSociale, string account)
        {
            ragioneSociale = (ragioneSociale.Length > 45 ? ragioneSociale.Substring(0, 45) : ragioneSociale).ToUpper();


            using (ManutezioneBusiness bManutenzione = new ManutezioneBusiness())
            {
                bManutenzione.FillDitte(_ds, true);
                ManutenzioneDS.DITTERow ditta = _ds.DITTE.Where(x => x.IDDITTA == idDitta).FirstOrDefault();
                if (ditta != null)
                {
                    ditta.RAGIONESOCIALE = ragioneSociale.Length > 45 ? ragioneSociale.Substring(0, 45) : ragioneSociale;

                    ditta.DATAMODIFICA = DateTime.Now;
                    ditta.UTENTEMODIFICA = account;

                    bManutenzione.UpdateTable(_ds.DITTE.TableName, _ds);
                }
            }
        }

        public string CreaRiferimento(string Etichetta, string Riferimento, string Tipologia, string account)
        {
            string riferimentoStr = Riferimento.ToUpper().Trim();

            using (ManutezioneBusiness bManutenzione = new ManutezioneBusiness())
            {
                bManutenzione.FillRiferimenti(_ds, false);

                if (_ds.RIFERIMENTI.Any(x => x.RIFERIMENTO.Trim() == riferimentoStr))
                    return "Riferimento già inserito a sistema";

                ManutenzioneDS.RIFERIMENTIRow riferimento = _ds.RIFERIMENTI.NewRIFERIMENTIRow();
                riferimento.ETICHETTA = Etichetta.Length > 45 ? Etichetta.Substring(0, 45) : Etichetta;
                riferimento.CANCELLATO = SiNo.No;
                riferimento.DATAMODIFICA = DateTime.Now;
                riferimento.UTENTEMODIFICA = account;
                riferimento.RIFERIMENTO = riferimentoStr.Length > 45 ? riferimentoStr.Substring(0, 45) : riferimentoStr;
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

                    bManutenzione.UpdateTable(_ds.DITTE.TableName, _ds);
                }
            }
        }
        public void ModificaRiferimenti(decimal idRiferimenti, string Etichetta, string Riferimento, string Tipologia, string account)
        {
            Etichetta = (Etichetta.Length > 45 ? Etichetta.Substring(0, 45) : Etichetta).ToUpper();
            Riferimento = (Riferimento.Length > 45 ? Riferimento.Substring(0, 45) : Riferimento).ToUpper();
            Tipologia = (Tipologia.Length > 45 ? Tipologia.Substring(0, 45) : Tipologia).ToUpper();
            ManutenzioneDS.RIFERIMENTIRow riferimento = _ds.RIFERIMENTI.Where(x => x.IDRIFERIMENTO == idRiferimenti).FirstOrDefault();
            using (ManutezioneBusiness bManutenzione = new ManutezioneBusiness())
            {
                bManutenzione.FillRiferimenti(_ds, true);

                if (riferimento != null)
                {
                    riferimento.ETICHETTA = Etichetta;
                    riferimento.RIFERIMENTO = Riferimento;
                    riferimento.TIPOLOGIA = Tipologia;

                    riferimento.DATAMODIFICA = DateTime.Now;
                    riferimento.UTENTEMODIFICA = account;

                    bManutenzione.UpdateTable(_ds.RIFERIMENTI.TableName, _ds);
                }
            }
        }
    }
}

