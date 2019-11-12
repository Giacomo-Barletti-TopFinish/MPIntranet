using MPIntranet.DataAccess.Anagrafica;
using MPIntranet.Entities;
using MPIntranet.Models.Anagrafica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class Anagrafica
    {
        private AnagraficaDS _ds = new AnagraficaDS();

        public List<BrandModel> CreaListaBrandModel()
        {
            List<BrandModel> lista = new List<BrandModel>();

            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillBrand(_ds,true);
                foreach (AnagraficaDS.BRANDRow brand in _ds.BRAND)
                {
                    BrandModel bm = new BrandModel()
                    {
                        Brand = brand.BRAND,
                        CodiceGestionale = brand.IsCODICEGESTIONALENull() ? string.Empty : brand.CODICEGESTIONALE,
                        DataModifica = brand.DATAMODIFICA,
                        IdBrand = brand.IDBRAND,
                        PrefissoColore = brand.PREFISSOCOLORE,
                        UtenteModifica = brand.UtenteModifica
                    };
                    lista.Add(bm);
                }
            }
            return lista;
        }
        public List<ColoreModel> CreaListaColoreModel()
        {
            List<ColoreModel> lista = new List<ColoreModel>();

            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillColori(_ds,true);
                bAnagrafica.FillBrand(_ds,true);
                foreach (AnagraficaDS.COLORIRow colore in _ds.COLORI)
                {
                    string brand = string.Empty;
                    AnagraficaDS.BRANDRow b = _ds.BRAND.Where(x => x.IDBRAND == colore.IDBRAND).FirstOrDefault();
                    if (b != null) brand = b.BRAND;

                    ColoreModel c = new ColoreModel()
                    {
                        Codice = colore.CODICE,
                        Brand = brand,
                        CodiceCliente = colore.CODICECLIENTE,
                        CodiceFigurativo = colore.CODICEFIGURATIVO,
                        Descrizione = colore.DESCRIZIONE,
                        IdBrand = colore.IDBRAND,
                        IdColore = colore.IDCOLORE,
                        DataModifica = colore.DATAMODIFICA,
                        UtenteModifica = colore.UtenteModifica
                    };
                    lista.Add(c);
                }
            }
            return lista;
        }

        public List<TipoDocumentoModel> CreaListaTipoDocumento()
        {
            List<TipoDocumentoModel> lista = new List<TipoDocumentoModel>();

            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillTipiDocumento(_ds,true);
                foreach (AnagraficaDS.TIPIDOCUMENTORow tipoDocumento in _ds.TIPIDOCUMENTO)
                {
                    TipoDocumentoModel td = new TipoDocumentoModel()
                    {
                        IdTipoDocumento = tipoDocumento.IDTIPODOCUMENTO,
                        Descrizione = tipoDocumento.DESCRIZIONE,
                        DataModifica = tipoDocumento.DATAMODIFICA,
                        UtenteModifica = tipoDocumento.UtenteModifica
                    };
                    lista.Add(td);
                }
            }
            return lista;
        }

        public void CancellatipoDocumento(decimal idTipoDocumento)
        {
            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillTipiDocumento(_ds,true);
                AnagraficaDS.TIPIDOCUMENTORow tipoDocumento = _ds.TIPIDOCUMENTO.Where(x => x.IDTIPODOCUMENTO == idTipoDocumento).FirstOrDefault();
                if (tipoDocumento != null)
                {
                    tipoDocumento.CANCELLATO = "S";
                    bAnagrafica.UpdateTable(_ds, _ds.TIPIDOCUMENTO.TableName);
                }
            }
        }

        public string CreaTipoDocumento(string descrizione, string account)
        {
            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillTipiDocumento(_ds,false);
                AnagraficaDS.TIPIDOCUMENTORow tipoDocumento = _ds.TIPIDOCUMENTO.Where(x => x.DESCRIZIONE == descrizione).FirstOrDefault();
                if (tipoDocumento != null)
                {
                    if (tipoDocumento.CANCELLATO == "S")
                        return "Un tipo documento con questa descrizione era presente ma è stato cancellato";
                    else
                        return "Un tipo documento con questa descrizione era già presente";
                }

                AnagraficaDS.TIPIDOCUMENTORow td = _ds.TIPIDOCUMENTO.NewTIPIDOCUMENTORow();
                td.CANCELLATO = "N";
                td.DESCRIZIONE = descrizione.Length > 25 ? descrizione.Substring(0, 25) : descrizione;
                td.DATAMODIFICA = DateTime.Now;
                td.UtenteModifica = account;

                _ds.TIPIDOCUMENTO.AddTIPIDOCUMENTORow(td);
                bAnagrafica.UpdateTable(_ds, _ds.TIPIDOCUMENTO.TableName);

                return string.Empty;
            }
        }
    }
}
