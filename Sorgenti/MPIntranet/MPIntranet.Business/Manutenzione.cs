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
                bManutenzione.FillDitte(_ds);

                if (_ds.DITTE.Any(x => x.RAGIONESOCIALE.Trim() == dittaStr))
                    return "Ditta già inserita a sistema";

                ManutenzioneDS.DITTERow ditta = _ds.DITTE.NewDITTERow();

                ditta.CANCELLATO = SiNo.Si;
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
                bManutenzione.FillDitte(_ds);

                foreach(ManutenzioneDS.DITTERow d in _ds.DITTE)
                    lista.Add(CreaDittaModel(d));
            }

            return lista;
        }

        private DittaModel CreaDittaModel(ManutenzioneDS.DITTERow ditta)
        {
            DittaModel dm = new DittaModel();
            dm.IdDitta = ditta.IDDITTA;
            dm.RagioneSociale = ditta.RAGIONESOCIALE;

            return dm;
        }
    }
}
