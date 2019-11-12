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
                bAnagrafica.FillBrand(_ds, true);
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


        public void CancellaBrand(decimal idBrand, string account)
        {
            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillBrand(_ds, true);
                AnagraficaDS.BRANDRow brand = _ds.BRAND.Where(x => x.IDBRAND == idBrand).FirstOrDefault();
                if (brand != null)
                {
                    brand.CANCELLATO = "S";
                    brand.DATAMODIFICA = DateTime.Now;
                    brand.UtenteModifica = account;

                    bAnagrafica.UpdateTable(_ds, _ds.BRAND.TableName);
                }
            }
        }
        public void ModificaBrand(decimal idBrand, string brand, string codiceGestionale, string prefissoColore, string account)
        {
            brand = (brand.Length > 20 ? brand.Substring(0, 20) : brand).ToUpper();
            codiceGestionale = (codiceGestionale.Length > 8 ? codiceGestionale.Substring(0, 8) : codiceGestionale).ToUpper();
            prefissoColore = (prefissoColore.Length > 2 ? prefissoColore.Substring(0, 2) : prefissoColore).ToUpper();

            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillBrand(_ds, true);
                AnagraficaDS.BRANDRow br = _ds.BRAND.Where(x => x.IDBRAND == idBrand).FirstOrDefault();
                if (br != null)
                {
                    br.BRAND = brand;
                    br.CODICEGESTIONALE = codiceGestionale;
                    br.PREFISSOCOLORE = prefissoColore;
                    br.DATAMODIFICA = DateTime.Now;
                    br.UtenteModifica = account;

                    bAnagrafica.UpdateTable(_ds, _ds.BRAND.TableName);
                }
            }
        }

        public string CreaBrand(string brand, string codiceGestionale, string prefissoColore, string account)
        {
            brand = (brand.Length > 20 ? brand.Substring(0, 20) : brand).ToUpper();
            codiceGestionale = (codiceGestionale.Length > 8 ? codiceGestionale.Substring(0, 8) : codiceGestionale).ToUpper();
            prefissoColore = (prefissoColore.Length > 2 ? prefissoColore.Substring(0, 2) : prefissoColore).ToUpper();

            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillBrand(_ds, false);
                AnagraficaDS.BRANDRow b = _ds.BRAND.Where(x => x.BRAND == brand).FirstOrDefault();
                if (b != null)
                {
                    if (b.CANCELLATO == "S")
                        return "Un brand con questa descrizione era presente ma è stato cancellato";
                    else
                        return "Un brand con questa descrizione è già presente";
                }

                if (!string.IsNullOrWhiteSpace(codiceGestionale))
                {
                    b = _ds.BRAND.Where(x =>!x.IsCODICEGESTIONALENull() &&  x.CODICEGESTIONALE == codiceGestionale).FirstOrDefault();
                    if (b != null)
                    {
                        if (b.CANCELLATO == "S")
                            return "Un brand con questo codice gestionale era presente ma è stato cancellato";
                        else
                            return "Un brand con questo codice gestionale è già presente";
                    }
                }

                AnagraficaDS.BRANDRow br = _ds.BRAND.NewBRANDRow();
                br.BRAND = brand;
                br.CODICEGESTIONALE = codiceGestionale;
                br.PREFISSOCOLORE = prefissoColore;

                br.CANCELLATO = "N";
                br.DATAMODIFICA = DateTime.Now;
                br.UtenteModifica = account;

                _ds.BRAND.AddBRANDRow(br);
                bAnagrafica.UpdateTable(_ds, _ds.BRAND.TableName);

                return string.Empty;
            }
        }
        public List<ColoreModel> CreaListaColoreModel()
        {
            List<ColoreModel> lista = new List<ColoreModel>();

            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillColori(_ds, true);
                bAnagrafica.FillBrand(_ds, true);
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
        public void CancellaColore(decimal idColore, string account)
        {
            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillColori(_ds, true);
                AnagraficaDS.COLORIRow colore = _ds.COLORI.Where(x => x.IDCOLORE == idColore).FirstOrDefault();
                if (colore != null)
                {
                    colore.CANCELLATO = "S";
                    colore.DATAMODIFICA = DateTime.Now;
                    colore.UtenteModifica = account;

                    bAnagrafica.UpdateTable(_ds, _ds.COLORI.TableName);
                }
            }
        }

        public string CreaColore(string codice, string descrizione, string codiceFigurativo, string codiceCliente, decimal idBrand, string account)
        {
            codice = (codice.Length > 3 ? codice.Substring(0, 3) : codice).ToUpper();
            descrizione = (descrizione.Length > 40 ? descrizione.Substring(0, 40) : descrizione).ToUpper();
            codiceFigurativo = (codiceFigurativo.Length > 10 ? codiceFigurativo.Substring(0, 10) : codiceFigurativo).ToUpper();
            codiceCliente = (codiceCliente.Length > 8 ? codiceCliente.Substring(0, 8) : codiceCliente).ToUpper();

            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillColori(_ds, false);
                AnagraficaDS.COLORIRow col = _ds.COLORI.Where(x => x.CODICE == codice).FirstOrDefault();
                if (col != null)
                {
                    if (col.CANCELLATO == "S")
                        return "Un colore con questo codice era presente ma è stato cancellato";
                    else
                        return "Un brand con questo codice è già presente";
                }

                col = _ds.COLORI.Where(x => x.DESCRIZIONE == descrizione).FirstOrDefault();
                if (col != null)
                {
                    if (col.CANCELLATO == "S")
                        return "Un brand con questa descrizione era presente ma è stato cancellato";
                    else
                        return "Un brand con questa descrizione è già presente";
                }

                col = _ds.COLORI.Where(x => x.CODICEFIGURATIVO == codiceFigurativo).FirstOrDefault();
                if (col != null)
                {
                    if (col.CANCELLATO == "S")
                        return "Un brand con questo codice figurativo era presente ma è stato cancellato";
                    else
                        return "Un brand con questo codice figurativo è già presente";
                }

                col = _ds.COLORI.Where(x => x.CODICECLIENTE == codiceCliente && x.IDBRAND == idBrand).FirstOrDefault();
                if (col != null)
                {
                    if (col.CANCELLATO == "S")
                        return "Un brand con questo codice cliente per questo brand era presente ma è stato cancellato";
                    else
                        return "Un brand con questo codice cliente per questo brand è già presente";
                }
                AnagraficaDS.COLORIRow colore = _ds.COLORI.NewCOLORIRow();
                colore.CODICE = codice;
                colore.DESCRIZIONE = descrizione;
                colore.IDBRAND = idBrand;
                colore.CODICEFIGURATIVO = codiceFigurativo;
                colore.CODICECLIENTE = codiceCliente;

                colore.CANCELLATO = "N";
                colore.DATAMODIFICA = DateTime.Now;
                colore.UtenteModifica = account;

                _ds.COLORI.AddCOLORIRow(colore);
                bAnagrafica.UpdateTable(_ds, _ds.COLORI.TableName);

                return string.Empty;
            }
        }
        public List<TipoDocumentoModel> CreaListaTipoDocumento()
        {
            List<TipoDocumentoModel> lista = new List<TipoDocumentoModel>();

            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillTipiDocumento(_ds, true);
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

        public void CancellaTipoDocumento(decimal idTipoDocumento, string account)
        {
            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillTipiDocumento(_ds, true);
                AnagraficaDS.TIPIDOCUMENTORow tipoDocumento = _ds.TIPIDOCUMENTO.Where(x => x.IDTIPODOCUMENTO == idTipoDocumento).FirstOrDefault();
                if (tipoDocumento != null)
                {
                    tipoDocumento.CANCELLATO = "S";
                    tipoDocumento.DATAMODIFICA = DateTime.Now;
                    tipoDocumento.UtenteModifica = account;

                    bAnagrafica.UpdateTable(_ds, _ds.TIPIDOCUMENTO.TableName);
                }
            }
        }

        public string CreaTipoDocumento(string descrizione, string account)
        {
            descrizione = (descrizione.Length > 25 ? descrizione.Substring(0, 25) : descrizione).ToUpper();
            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillTipiDocumento(_ds, false);
                AnagraficaDS.TIPIDOCUMENTORow tipoDocumento = _ds.TIPIDOCUMENTO.Where(x => x.DESCRIZIONE == descrizione).FirstOrDefault();
                if (tipoDocumento != null)
                {
                    if (tipoDocumento.CANCELLATO == "S")
                        return "Un tipo documento con questa descrizione era presente ma è stato cancellato";
                    else
                        return "Un tipo documento con questa descrizione è già presente";
                }

                AnagraficaDS.TIPIDOCUMENTORow td = _ds.TIPIDOCUMENTO.NewTIPIDOCUMENTORow();
                td.CANCELLATO = "N";
                td.DESCRIZIONE = descrizione;
                td.DATAMODIFICA = DateTime.Now;
                td.UtenteModifica = account;

                _ds.TIPIDOCUMENTO.AddTIPIDOCUMENTORow(td);
                bAnagrafica.UpdateTable(_ds, _ds.TIPIDOCUMENTO.TableName);

                return string.Empty;
            }
        }
    }
}
