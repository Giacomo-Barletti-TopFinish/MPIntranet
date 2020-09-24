using MPIntranet.Common;
using MPIntranet.DataAccess.Finiture_Burattovarie;
using MPIntranet.Entities;
using MPIntranet.Models.Finiture_Burattovarie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class FinitureBurattovarie : BusinessBase
    {
        private  FBVDS _ds = new FBVDS();
        private Anagrafica _anagrafica = new Anagrafica();

        public List<AttributiModel> CreaListaAttributiModel()
        {
            List<AttributiModel> lista = new List<AttributiModel>();

            using (FbvBusiness bFbv = new FbvBusiness())
            {
                bFbv.FillAttributi(_ds, true);
                foreach (FBVDS.FBVATTRIBUTIRow attributo in _ds.FBVATTRIBUTI)
                {
                    AttributiModel m = new AttributiModel()
                    {
                        IdFbvAttributi = attributo.IDFBVATTRIBUTI,
                        IdFbvProprieta = attributo.IDFBVPROPRIETA,
                        Codice = attributo.CODICE,
                        Descrizione = attributo.DESCRIZIONE,
                    };
                    lista.Add(m);
                }
            }
            return lista;
        }

        public List<FasiModel> CreaListaFasiModel()
        {
            List<FasiModel> lista = new List<FasiModel>();

            using (FbvBusiness bFbv = new FbvBusiness())
            {
                bFbv.FillFasi(_ds, true);
                foreach (FBVDS.FBVFASIRow fase in _ds.FBVFASI)
                {
                    FasiModel m = new FasiModel()
                    {
                        IdFbvFase = fase.IDFBVFASE,
                        Codice = fase.CODICE,
                        Descrizione = fase.DESCRIZIONE,
                        Ricarico = fase.RICARICO,
                        CostoOrario = fase.COSTOORARIO
                    };
                    lista.Add(m);
                }
            }
            return lista;
        }

        public List<GruppiModel> CreaListaGruppiModel()
        {
            List<GruppiModel> lista = new List<GruppiModel>();

            using (FbvBusiness bFbv = new FbvBusiness())
            {
                bFbv.FillGruppi(_ds, true);
                foreach (FBVDS.FBVGRUPPIPROPRIETARow gruppo in _ds.FBVGRUPPIPROPRIETA)
                {
                    GruppiModel m = new GruppiModel()
                    {
                        IdFbvGruppo = gruppo.IDFBVGRUPPO,
                        Codice = gruppo.CODICE,
                        Descrizione = gruppo.DESCRIZIONE,
                       
                    };
                    lista.Add(m);
                }
            }
            return lista;
        }

        public List<ProcessiModel> CreaListaProcessiModel()
        {
            List<ProcessiModel> lista = new List<ProcessiModel>();

            using (FbvBusiness bFbv = new FbvBusiness())
            {
                bFbv.FillProcessi(_ds, true);
                foreach (FBVDS.FBVPROCESSIRow processo in _ds.FBVPROCESSI)
                {
                    ProcessiModel m = new ProcessiModel()
                    {
                        IdFbvProcesso = processo.IDFBVPROCESSO,
                        IdArticolo = processo.IDARTICOLO,
                        IdColore = processo.IDCOLORE,
                        Descrizione = processo.DESCRIZIONE,
                        Standard = processo.STANDARD,
                    };
                    lista.Add(m);
                }
            }
            return lista;
        }

        public List<ProprietaModel> CreaListaProprietaModel()
        {
            List<ProprietaModel> lista = new List<ProprietaModel>();

            using (FbvBusiness bFbv = new FbvBusiness())
            {
                bFbv.FillProprieta(_ds, true);
                foreach (FBVDS.FBVPROPRIETARow proprieta in _ds.FBVPROPRIETA)
                {
                    ProprietaModel m = new ProprietaModel()
                    {
                        IdFbvProprieta = proprieta.IDFBVPROPRIETA,
                        Codice = proprieta.CODICE,
                        Descrizione = proprieta.DESCRIZIONE,

                    };
                    lista.Add(m);
                }
            }
            return lista;
        }

        public string CreaProprieta(string codice, string descrizione, string account)
        {
            descrizione = correggiString(descrizione, 45);
            codice = correggiString(codice, 45);

            

            using (FbvBusiness bFbv = new FbvBusiness())
            {
                bFbv.FillProprieta(_ds, false);

                if (_ds.FBVPROPRIETA.Any(x => x.CODICE == codice))
                    return "Proprieta' gia' inserita a sistema";

                FBVDS.FBVPROPRIETARow proprieta = _ds.FBVPROPRIETA.NewFBVPROPRIETARow();
                proprieta.CODICE = codice;
                proprieta.DESCRIZIONE = descrizione;

                proprieta.CANCELLATO = SiNo.No;
                proprieta.DATAMODIFICA = DateTime.Now;
                proprieta.UTENTEMODIFICA = account;

                _ds.FBVPROPRIETA.AddFBVPROPRIETARow(proprieta);
                bFbv.UpdateTable(_ds, _ds.FBVPROPRIETA.TableName);

                return string.Empty;
            }
        }

        public void ModificaProprieta(decimal idfbvproprieta, string codice, string descrizione, string account)
        {
            codice = (codice.Length > 45 ? codice.Substring(0, 45) : codice).ToUpper();
            descrizione = (descrizione.Length > 45 ? descrizione.Substring(0, 45) : descrizione).ToUpper();

            using (FbvBusiness bFbv = new FbvBusiness())
            {
                bFbv.FillProprieta(_ds, true);
                FBVDS.FBVPROPRIETARow br = _ds.FBVPROPRIETA.Where(x => x.IDFBVPROPRIETA == idfbvproprieta ).FirstOrDefault();
                if (br != null)
                {
                    br.CODICE = codice;
                    br.DESCRIZIONE = descrizione;
                    br.CANCELLATO = SiNo.No;
                    br.DATAMODIFICA = DateTime.Now;
                    br.UTENTEMODIFICA = account;

                    bFbv.UpdateTable(_ds, _ds.FBVPROPRIETA.TableName);
                }
            }
        }
        public void CancellaProprieta(decimal idFbvProprieta, string account)
        {
            using (FbvBusiness bFbv = new FbvBusiness())
            {
                bFbv.FillProprieta(_ds, true);
                FBVDS.FBVPROPRIETARow proprieta = _ds.FBVPROPRIETA.Where(x => x.IDFBVPROPRIETA == idFbvProprieta).FirstOrDefault();
                if (proprieta != null)
                {
                    proprieta.CANCELLATO = SiNo.Si;
                    proprieta.DATAMODIFICA = DateTime.Now;
                    proprieta.UTENTEMODIFICA = account;

                    bFbv.UpdateTable(_ds, _ds.FBVPROPRIETA.TableName);
                }
            }
        }
    }
}
