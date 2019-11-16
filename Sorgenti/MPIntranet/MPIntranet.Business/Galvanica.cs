using MPIntranet.DataAccess.Galvanica;
using MPIntranet.Entities;
using MPIntranet.Models.Galvanica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class Galvanica
    {
        private GalvanicaDS _ds = new GalvanicaDS();
        private Anagrafica _anagrafica = new Anagrafica();

        public List<ImpiantoModel> CreaListaImpiantoModel()
        {
            List<ImpiantoModel> lista = new List<ImpiantoModel>();

            using (GalvanicaBusiness bGalvanica = new GalvanicaBusiness())
            {
                bGalvanica.FillImpianti(_ds, true);
                foreach (GalvanicaDS.IMPIANTIRow impianto in _ds.IMPIANTI)
                {
                    ImpiantoModel m = new ImpiantoModel()
                    {
                        IdImpianto = impianto.IDIMPIANTO,
                        Descrizione = impianto.DESCRIZIONE,
                        DataModifica = impianto.DATAMODIFICA,
                        UtenteModifica = impianto.UTENTEMODIFICA
                    };
                    lista.Add(m);
                }
            }
            return lista;
        }

        public void CancellaImpianto(decimal idImpianto, string account)
        {
            using (GalvanicaBusiness bGalvanica = new GalvanicaBusiness())
            {
                bGalvanica.FillImpianti(_ds, true);
                GalvanicaDS.IMPIANTIRow impianto = _ds.IMPIANTI.Where(x => x.IDIMPIANTO == idImpianto).FirstOrDefault();
                if (impianto != null)
                {
                    impianto.CANCELLATO = "S";
                    impianto.DATAMODIFICA = DateTime.Now;
                    impianto.UTENTEMODIFICA = account;

                    bGalvanica.UpdateTable(_ds, _ds.IMPIANTI.TableName);
                }
            }
        }
        public void ModificaImpianto(decimal idImpianto, string descrizione, string account)
        {
            descrizione = (descrizione.Length > 50 ? descrizione.Substring(0, 50) : descrizione).ToUpper();

            using (GalvanicaBusiness bGalvanica = new GalvanicaBusiness())
            {
                bGalvanica.FillImpianti(_ds, true);
                GalvanicaDS.IMPIANTIRow br = _ds.IMPIANTI.Where(x => x.IDIMPIANTO == idImpianto).FirstOrDefault();
                if (br != null)
                {
                    br.DESCRIZIONE = descrizione;
                    br.DATAMODIFICA = DateTime.Now;
                    br.UTENTEMODIFICA = account;

                    bGalvanica.UpdateTable(_ds, _ds.IMPIANTI.TableName);
                }
            }
        }

        public string CreaImpianto(string descrizione, string account)
        {
            descrizione = (descrizione.Length > 50 ? descrizione.Substring(0, 50) : descrizione).ToUpper();

            using (GalvanicaBusiness bGalvanica = new GalvanicaBusiness())
            {
                bGalvanica.FillImpianti(_ds, false);
                GalvanicaDS.IMPIANTIRow b = _ds.IMPIANTI.Where(x => x.DESCRIZIONE == descrizione).FirstOrDefault();
                if (b != null)
                {
                    if (b.CANCELLATO == "S")
                        return "Un impianto con questa descrizione era presente ma è stato cancellato";
                    else
                        return "Un impianto con questa descrizione è già presente";
                }

                GalvanicaDS.IMPIANTIRow br = _ds.IMPIANTI.NewIMPIANTIRow();
                br.DESCRIZIONE = descrizione;

                br.CANCELLATO = "N";
                br.DATAMODIFICA = DateTime.Now;
                br.UTENTEMODIFICA = account;

                _ds.IMPIANTI.AddIMPIANTIRow(br);
                bGalvanica.UpdateTable(_ds, _ds.IMPIANTI.TableName);

                return string.Empty;
            }
        }
    }
}

