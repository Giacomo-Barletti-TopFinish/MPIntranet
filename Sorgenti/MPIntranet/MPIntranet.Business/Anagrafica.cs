using MPIntranet.Common;
using MPIntranet.DataAccess.Anagrafica;
using MPIntranet.Entities;
using MPIntranet.Models;
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

        public bool MaterialeEsiste(decimal idMateriale)
        {
            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillMateriali(_ds, true);
                return _ds.MATERIALI.Any(x => x.IDMATERIALE == idMateriale);
            }
        }

        public List<BrandModel> CreaListaBrandModel()
        {
            List<BrandModel> lista = new List<BrandModel>();

            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillBrand(_ds, true);
                foreach (AnagraficaDS.BRANDRow brand in _ds.BRAND)
                {
                    lista.Add(creaBrandModel(brand));
                }
            }
            return lista;
        }

        public AnagraficaDS.BRANDRow EstraiBrand(decimal idBrand)
        {
            if (_ds.BRAND.Count == 0)
            {
                using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
                    bAnagrafica.FillBrand(_ds, true);
            }
            return _ds.BRAND.Where(x => x.IDBRAND == idBrand).FirstOrDefault();
        }


        public AnagraficaDS.TIPIDOCUMENTORow EstraiTipoDocumento(decimal idTipoDocumento)
        {
            if (_ds.TIPIDOCUMENTO.Count == 0)
            {
                using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
                    bAnagrafica.FillTipiDocumento(_ds, true);
            }
            return _ds.TIPIDOCUMENTO.Where(x => x.IDTIPODOCUMENTO == idTipoDocumento).FirstOrDefault();
        }

        public TipoDocumentoModel EstraiTipoDocumentoModel(decimal idTipoDocumento)
        {
            if (_ds.TIPIDOCUMENTO.Count == 0)
            {
                using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
                    bAnagrafica.FillTipiDocumento(_ds, true);
            }
            AnagraficaDS.TIPIDOCUMENTORow td = _ds.TIPIDOCUMENTO.Where(x => x.IDTIPODOCUMENTO == idTipoDocumento).FirstOrDefault();
            if (td == null) return null;

            return CreaTipoDocumentoModel(idTipoDocumento, _ds);
        }
        private BrandModel creaBrandModel(AnagraficaDS.BRANDRow brand)
        {
            BrandModel bm = new BrandModel()
            {
                Brand = brand.BRAND,
                CodiceGestionale = brand.IsCODICEGESTIONALENull() ? string.Empty : brand.CODICEGESTIONALE,
                DataModifica = brand.DATAMODIFICA,
                IdBrand = brand.IDBRAND,
                PrefissoColore = brand.PREFISSOCOLORE,
                UtenteModifica = brand.UTENTEMODIFICA
            };
            return bm;
        }
        public BrandModel EstraiBrandModel(decimal idBrand)
        {
            AnagraficaDS.BRANDRow elemento = EstraiBrand(idBrand);
            if (elemento == null) return null;
            return creaBrandModel(elemento);
        }

        public AnagraficaDS.COLORIRow EstraiColore(decimal idColore)
        {
            if (_ds.COLORI.Count == 0)
            {
                using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
                    bAnagrafica.FillColori(_ds, true);
            }
            return _ds.COLORI.Where(x => x.IDCOLORE == idColore).FirstOrDefault();
        }

        public AnagraficaDS.COLORIRow EstraiColore(string codiceColore)
        {
            if (_ds.COLORI.Count == 0)
            {
                using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
                    bAnagrafica.FillColori(_ds, true);
            }
            return _ds.COLORI.Where(x => x.CODICE == codiceColore.ToUpper().Trim()).FirstOrDefault();
        }

        public AnagraficaDS.COLORIRow EstraiColorePerCodiceFigurativo(string codiceFigurativoColore)
        {
            if (_ds.COLORI.Count == 0)
            {
                using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
                    bAnagrafica.FillColori(_ds, true);
            }
            return _ds.COLORI.Where(x => x.CODICEFIGURATIVO == codiceFigurativoColore.ToUpper().Trim()).FirstOrDefault();
        }
        public ColoreModel EstraiColoreModel(decimal idColore)
        {
            AnagraficaDS.COLORIRow elemento = EstraiColore(idColore);
            if (elemento == null) return null;
            return creaColoreModel(elemento);
        }

        public ColoreModel EstraiColoreModel(string codiceColore)
        {
            AnagraficaDS.COLORIRow elemento = EstraiColore(codiceColore);
            if (elemento == null) return null;
            return creaColoreModel(elemento);
        }

        public ColoreModel EstraiColoreModelPerCodiceFigurativo(string codiceFigurativoColore)
        {
            AnagraficaDS.COLORIRow elemento = EstraiColorePerCodiceFigurativo(codiceFigurativoColore);
            if (elemento == null) return null;
            return creaColoreModel(elemento);
        }

        public void CancellaBrand(decimal idBrand, string account)
        {
            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillBrand(_ds, true);
                AnagraficaDS.BRANDRow brand = _ds.BRAND.Where(x => x.IDBRAND == idBrand).FirstOrDefault();
                if (brand != null)
                {
                    brand.CANCELLATO = SiNo.Si;
                    brand.DATAMODIFICA = DateTime.Now;
                    brand.UTENTEMODIFICA = account;

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
                    br.UTENTEMODIFICA = account;

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
                    if (b.CANCELLATO == SiNo.Si)
                        return "Un brand con questa descrizione era presente ma è stato cancellato";
                    else
                        return "Un brand con questa descrizione è già presente";
                }

                if (!string.IsNullOrWhiteSpace(codiceGestionale))
                {
                    b = _ds.BRAND.Where(x => !x.IsCODICEGESTIONALENull() && x.CODICEGESTIONALE == codiceGestionale).FirstOrDefault();
                    if (b != null)
                    {
                        if (b.CANCELLATO == SiNo.Si)
                            return "Un brand con questo codice gestionale era presente ma è stato cancellato";
                        else
                            return "Un brand con questo codice gestionale è già presente";
                    }
                }

                AnagraficaDS.BRANDRow br = _ds.BRAND.NewBRANDRow();
                br.BRAND = brand;
                br.CODICEGESTIONALE = codiceGestionale;
                br.PREFISSOCOLORE = prefissoColore;

                br.CANCELLATO = SiNo.No;
                br.DATAMODIFICA = DateTime.Now;
                br.UTENTEMODIFICA = account;

                _ds.BRAND.AddBRANDRow(br);
                bAnagrafica.UpdateTable(_ds, _ds.BRAND.TableName);

                return string.Empty;
            }
        }
        public List<ColoreModel> CreaListaColoreModel(string codice, string descrizione, string codiceFigurativo, string codiceCliente, decimal idBrand)
        {
            List<ColoreModel> lista = new List<ColoreModel>();

            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillColori(_ds, true);
                bAnagrafica.FillBrand(_ds, true);

                List<AnagraficaDS.COLORIRow> colori = _ds.COLORI.ToList();
                if (idBrand >= 0)
                    colori = colori.Where(x => !x.IsIDBRANDNull() && x.IDBRAND == idBrand).ToList();

                if (!string.IsNullOrWhiteSpace(codice))
                    colori = colori.Where(x => x.CODICE.Contains(codice.ToUpper())).ToList();

                if (!string.IsNullOrWhiteSpace(descrizione))
                    colori = colori.Where(x => x.DESCRIZIONE.Contains(descrizione.ToUpper())).ToList();

                if (!string.IsNullOrWhiteSpace(codiceFigurativo))
                    colori = colori.Where(x => x.CODICEFIGURATIVO.Contains(codiceFigurativo.ToUpper())).ToList();

                if (!string.IsNullOrWhiteSpace(codiceCliente))
                    colori = colori.Where(x => x.CODICEFIGURATIVO.Contains(codiceCliente.ToUpper())).ToList();

                foreach (AnagraficaDS.COLORIRow colore in colori)
                {
                    lista.Add(creaColoreModel(colore));
                }
            }
            return lista;
        }

        private ColoreModel creaColoreModel(AnagraficaDS.COLORIRow colore)
        {
            string brand = string.Empty;
            if (!colore.IsIDBRANDNull())
            {
                AnagraficaDS.BRANDRow b = EstraiBrand(colore.IDBRAND);
                if (b != null) brand = b.BRAND;
            }
            ColoreModel c = new ColoreModel()
            {
                Codice = colore.CODICE,
                Brand = brand,
                CodiceCliente = colore.CODICECLIENTE,
                CodiceFigurativo = colore.CODICEFIGURATIVO,
                Descrizione = colore.DESCRIZIONE,
                IdBrand = colore.IsIDBRANDNull() ? -1 : colore.IDBRAND,
                IdColore = colore.IDCOLORE,
                DataModifica = colore.DATAMODIFICA,
                UtenteModifica = colore.UTENTEMODIFICA
            };
            return c;
        }
        public void CancellaColore(decimal idColore, string account)
        {
            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillColori(_ds, true);
                AnagraficaDS.COLORIRow colore = _ds.COLORI.Where(x => x.IDCOLORE == idColore).FirstOrDefault();
                if (colore != null)
                {
                    colore.CANCELLATO = SiNo.Si;
                    colore.DATAMODIFICA = DateTime.Now;
                    colore.UTENTEMODIFICA = account;

                    bAnagrafica.UpdateTable(_ds, _ds.COLORI.TableName);
                }
            }
        }

        public string CreaColore(string descrizione, string codiceCliente, decimal idBrand, string account)
        {
            descrizione = (descrizione.Length > 40 ? descrizione.Substring(0, 40) : descrizione).ToUpper();
            codiceCliente = (codiceCliente.Length > 8 ? codiceCliente.Substring(0, 8) : codiceCliente).ToUpper();

            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillColori(_ds, false);
                bAnagrafica.FillBrand(_ds, false);

                AnagraficaDS.BRANDRow brandRow = _ds.BRAND.Where(x => x.IDBRAND == idBrand).FirstOrDefault();
                if (brandRow == null)
                {
                    return "Nessun brand con questo codice id";
                }
                else if (brandRow.CANCELLATO == SiNo.Si)
                    return "Il brand con questo codice id è stao cancellato";

                string codiceFigurativo = string.Format("{0}{1}", brandRow.PREFISSOCOLORE, codiceCliente);
                codiceFigurativo = (codiceFigurativo.Length > 10 ? codiceFigurativo.Substring(0, 10) : codiceFigurativo).ToUpper();

                AnagraficaDS.COLORIRow col = _ds.COLORI.Where(x => x.CODICEFIGURATIVO == codiceFigurativo).FirstOrDefault();
                if (col != null)
                {
                    if (col.CANCELLATO == SiNo.Si)
                        return "Un brand con questo codice figurativo era presente ma è stato cancellato";
                    else
                        return "Un brand con questo codice figurativo è già presente";
                }

                col = _ds.COLORI.Where(x => x.CODICECLIENTE == codiceCliente && !x.IsIDBRANDNull() && x.IDBRAND == idBrand).FirstOrDefault();
                if (col != null)
                {
                    if (col.CANCELLATO == SiNo.Si)
                        return "Un brand con questo codice cliente per questo brand era presente ma è stato cancellato";
                    else
                        return "Un brand con questo codice cliente per questo brand è già presente";
                }

                string prefisso = codiceFigurativo.Substring(0, 2).ToUpper();
                if (prefisso != brandRow.PREFISSOCOLORE)
                    return "Il prefisso del codice figurativo non è coerente con il prefisso del brand";

                string codice = (string)_ds.COLORI.Rows[_ds.COLORI.Rows.Count - 1]["CODICE"];
                codice = CreaCodiceColore(codice);

                AnagraficaDS.COLORIRow colore = _ds.COLORI.NewCOLORIRow();
                colore.CODICE = codice;
                colore.DESCRIZIONE = descrizione;
                colore.IDBRAND = idBrand;
                colore.CODICEFIGURATIVO = codiceFigurativo;
                colore.CODICECLIENTE = codiceCliente;

                colore.CANCELLATO = SiNo.No;
                colore.DATAMODIFICA = DateTime.Now;
                colore.UTENTEMODIFICA = account;

                _ds.COLORI.AddCOLORIRow(colore);
                bAnagrafica.UpdateTable(_ds, _ds.COLORI.TableName);

                return string.Empty;
            }
        }

        private string CreaCodiceColore(string ultimoCodice)
        {
            // 48 - 57 numeri
            // 65 - 90 lettere    
            // sequenza corretta 65 - 90  48 - 57
            byte[] bytes = Encoding.ASCII.GetBytes(ultimoCodice);

            bytes[2]++;
            if (bytes[2] == 91)
            {
                bytes[2] = 48;
            }
            if (bytes[2] == 58)
            {
                bytes[2] = 65;
                bytes[1]++;
                if (bytes[1] == 91)
                    bytes[1] = 48;
                if (bytes[1] == 58)
                {
                    bytes[1] = 65;
                    bytes[0]++;
                    if (bytes[0] == 91)
                        bytes[0] = 48;
                    if (bytes[0] == 58) throw new ArgumentOutOfRangeException("Codice colore oltre il valore 'ZZZ'");
                }
            }
            return Encoding.ASCII.GetString(bytes);


        }
        public string ModificaColore(decimal idColore, string descrizione, string account)
        {
            descrizione = (descrizione.Length > 40 ? descrizione.Substring(0, 40) : descrizione).ToUpper();

            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillColori(_ds, false);

                AnagraficaDS.COLORIRow colore = _ds.COLORI.Where(x => x.IDCOLORE == idColore).FirstOrDefault();

                colore.DESCRIZIONE = descrizione;

                colore.DATAMODIFICA = DateTime.Now;
                colore.UTENTEMODIFICA = account;

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
                    lista.Add(CreaTipoDocumentoModel(tipoDocumento));
            }
            return lista;
        }
        private TipoDocumentoModel CreaTipoDocumentoModel(AnagraficaDS.TIPIDOCUMENTORow tipoDocumento)
        {
            TipoDocumentoModel td = new TipoDocumentoModel()
            {
                IdTipoDocumento = tipoDocumento.IDTIPODOCUMENTO,
                Descrizione = tipoDocumento.DESCRIZIONE,
                DataModifica = tipoDocumento.DATAMODIFICA,
                UtenteModifica = tipoDocumento.UtenteModifica
            };
            return td;
        }
        public TipoDocumentoModel CreaTipoDocumentoModel(decimal idTipoDocumento, AnagraficaDS ds)
        {
            AnagraficaDS.TIPIDOCUMENTORow tipoDocumento = this.EstraiTipoDocumento(idTipoDocumento);
            if (tipoDocumento == null) return null;
            return CreaTipoDocumentoModel(tipoDocumento);

        }
        public void CancellaTipoDocumento(decimal idTipoDocumento, string account)
        {
            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillTipiDocumento(_ds, true);
                AnagraficaDS.TIPIDOCUMENTORow tipoDocumento = _ds.TIPIDOCUMENTO.Where(x => x.IDTIPODOCUMENTO == idTipoDocumento).FirstOrDefault();
                if (tipoDocumento != null)
                {
                    tipoDocumento.CANCELLATO = SiNo.Si;
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
                    if (tipoDocumento.CANCELLATO == SiNo.Si)
                        return "Un tipo documento con questa descrizione era presente ma è stato cancellato";
                    else
                        return "Un tipo documento con questa descrizione è già presente";
                }

                AnagraficaDS.TIPIDOCUMENTORow td = _ds.TIPIDOCUMENTO.NewTIPIDOCUMENTORow();
                td.CANCELLATO = SiNo.No;
                td.DESCRIZIONE = descrizione;
                td.DATAMODIFICA = DateTime.Now;
                td.UtenteModifica = account;

                _ds.TIPIDOCUMENTO.AddTIPIDOCUMENTORow(td);
                bAnagrafica.UpdateTable(_ds, _ds.TIPIDOCUMENTO.TableName);

                return string.Empty;
            }
        }

        public List<MaterialeModel> CreaListaMaterialeModel()
        {
            List<MaterialeModel> lista = new List<MaterialeModel>();

            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillMateriali(_ds, true);
                foreach (AnagraficaDS.MATERIALIRow materiale in _ds.MATERIALI)
                {
                    MaterialeModel m = new MaterialeModel()
                    {
                        IdMateriale = materiale.IDMATERIALE,
                        Codice = materiale.CODICE,
                        Descrizione = materiale.IsDESCRIZIONENull() ? string.Empty : materiale.DESCRIZIONE,
                        Prezioso = materiale.PREZIOSO,
                        PesoSpecifico = materiale.IsPESOSPECIFICONull() ? 0 : materiale.PESOSPECIFICO,
                        DataModifica = materiale.DATAMODIFICA,
                        UtenteModifica = materiale.UTENTEMODIFICA
                    };
                    lista.Add(m);
                }
            }
            return lista;
        }


        public void CancellaMateriale(decimal idMateriale, string account)
        {
            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillMateriali(_ds, true);
                AnagraficaDS.MATERIALIRow materiale = _ds.MATERIALI.Where(x => x.IDMATERIALE == idMateriale).FirstOrDefault();
                if (materiale != null)
                {
                    materiale.CANCELLATO = SiNo.Si;
                    materiale.DATAMODIFICA = DateTime.Now;
                    materiale.UTENTEMODIFICA = account;

                    bAnagrafica.UpdateTable(_ds, _ds.MATERIALI.TableName);
                }
            }
        }
        public void ModificaMateriale(decimal idMateriale, string codice, string descrizione, bool prezioso, decimal pesoSpecifico, string account)
        {
            descrizione = (descrizione.Length > 25 ? descrizione.Substring(0, 20) : descrizione).ToUpper();
            codice = (codice.Length > 8 ? codice.Substring(0, 8) : codice).ToUpper();

            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillMateriali(_ds, true);
                AnagraficaDS.MATERIALIRow br = _ds.MATERIALI.Where(x => x.IDMATERIALE == idMateriale).FirstOrDefault();
                if (br != null)
                {
                    br.CODICE = codice;
                    br.DESCRIZIONE = descrizione;
                    br.PREZIOSO = prezioso ? "S" : "N";
                    br.DATAMODIFICA = DateTime.Now;
                    br.UTENTEMODIFICA = account;
                    br.PESOSPECIFICO = pesoSpecifico;

                    bAnagrafica.UpdateTable(_ds, _ds.MATERIALI.TableName);
                }
            }
        }

        public string CreaMateriale(string codice, string descrizione, bool prezioso, decimal pesoSpecifico, string account)
        {
            descrizione = (descrizione.Length > 25 ? descrizione.Substring(0, 20) : descrizione).ToUpper();
            codice = (codice.Length > 8 ? codice.Substring(0, 8) : codice).ToUpper();

            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillMateriali(_ds, false);
                AnagraficaDS.MATERIALIRow b = _ds.MATERIALI.Where(x => x.CODICE == codice).FirstOrDefault();
                if (b != null)
                {
                    if (b.CANCELLATO == SiNo.Si)
                        return "Un materiale con questo codice era presente ma è stato cancellato";
                    else
                        return "Un materiale con questo codice è già presente";
                }

                AnagraficaDS.MATERIALIRow br = _ds.MATERIALI.NewMATERIALIRow();
                br.CODICE = codice;
                br.DESCRIZIONE = descrizione;
                br.PREZIOSO = prezioso ? "S" : "N";
                br.PESOSPECIFICO = pesoSpecifico;

                br.CANCELLATO = SiNo.No;
                br.DATAMODIFICA = DateTime.Now;
                br.UTENTEMODIFICA = account;

                _ds.MATERIALI.AddMATERIALIRow(br);
                bAnagrafica.UpdateTable(_ds, _ds.MATERIALI.TableName);

                return string.Empty;
            }
        }
    }
}
