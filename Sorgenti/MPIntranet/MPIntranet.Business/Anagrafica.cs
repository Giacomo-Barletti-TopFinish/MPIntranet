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

        public AnagraficaDS.REPARTIRow EstraiReparto(decimal idReparto)
        {
            if (_ds.REPARTI.Count == 0)
            {
                using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
                    bAnagrafica.FillReparti(_ds, true);
            }
            return _ds.REPARTI.Where(x => x.IDREPARTO == idReparto).FirstOrDefault();
        }

        public AnagraficaDS.MATERIALIRow EstraiMateriale(decimal idMateriale)
        {
            if (_ds.MATERIALI.Count == 0)
            {
                using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
                    bAnagrafica.FillMateriali(_ds, true);
            }
            return _ds.MATERIALI.Where(x => x.IDMATERIALE == idMateriale).FirstOrDefault();
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
                _ds.COLORI.Clear();
                _ds.BRAND.Clear();
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
        public List<TipoDocumentoModel> CreaListaTipoDocumentoModel()
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
                if (tipoDocumento != null && tipoDocumento.DESCRIZIONE != "IMMAGINE STANDARD")
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
                    lista.Add(creaMaterialeModel(materiale));
                }
            }
            return lista;
        }

        private MaterialeModel creaMaterialeModel(AnagraficaDS.MATERIALIRow materiale)
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
            return m;
        }

        private MaterialeModel creaMaterialeModel(decimal idMateriale)
        {
            AnagraficaDS.MATERIALIRow materiale = EstraiMateriale(idMateriale);
            return creaMaterialeModel(materiale);
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
            descrizione = (descrizione.Length > 25 ? descrizione.Substring(0, 25) : descrizione).ToUpper();
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
        public string CreaReparto(string codice, string descrizioneBreve, string descrizione, string account)
        {
            if (string.IsNullOrEmpty(codice)) return "Codice deve essere valorizzato";
            codice = codice.Trim().ToUpper();
            descrizioneBreve = descrizioneBreve.Trim().ToUpper();
            descrizione = descrizione.Trim().ToUpper();

            descrizione = (descrizione.Length > 30 ? descrizione.Substring(0, 30) : descrizione).ToUpper();
            descrizioneBreve = (descrizioneBreve.Length > 15 ? descrizioneBreve.Substring(0, 15) : descrizioneBreve).ToUpper();
            codice = (codice.Length > 10 ? codice.Substring(0, 10) : codice).ToUpper();

            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillReparti(_ds, false);
                AnagraficaDS.REPARTIRow b = _ds.REPARTI.Where(x => x.CODICE == codice).FirstOrDefault();
                if (b != null)
                {
                    if (b.CANCELLATO == SiNo.Si)
                        return "Un reparto con questo codice era presente ma è stato cancellato";
                    else
                        return "Un reparto con questo codice è già presente";
                }

                AnagraficaDS.REPARTIRow br = _ds.REPARTI.NewREPARTIRow();
                br.CODICE = codice;
                br.DESCRIZIONE = descrizione;
                br.DESCRIZIONEBREVE = descrizioneBreve;

                br.CANCELLATO = SiNo.No;
                br.DATAMODIFICA = DateTime.Now;
                br.UTENTEMODIFICA = account;

                _ds.REPARTI.AddREPARTIRow(br);
                bAnagrafica.UpdateTable(_ds, _ds.REPARTI.TableName);

                return string.Empty;
            }
        }

        public string ModificaReparto(decimal idReparto, string codice, string descrizioneBreve, string descrizione, string account)
        {
            codice = codice.Trim().ToUpper();
            descrizioneBreve = descrizioneBreve.Trim().ToUpper();
            descrizione = descrizione.Trim().ToUpper();

            descrizione = (descrizione.Length > 30 ? descrizione.Substring(0, 30) : descrizione).ToUpper();
            descrizioneBreve = (descrizioneBreve.Length > 15 ? descrizioneBreve.Substring(0, 15) : descrizioneBreve).ToUpper();
            codice = (codice.Length > 10 ? codice.Substring(0, 10) : codice).ToUpper();

            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillReparti(_ds, false);
                AnagraficaDS.REPARTIRow reparto = _ds.REPARTI.Where(x => x.IDREPARTO == idReparto).FirstOrDefault();
                if (reparto == null) return "Impossibile modificare il reparto";

                AnagraficaDS.REPARTIRow b = _ds.REPARTI.Where(x => x.CODICE == codice && x.IDREPARTO != idReparto).FirstOrDefault();
                if (b != null)
                {
                    if (b.CANCELLATO == SiNo.Si)
                        return "Un reparto con questo codice era presente ma è stato cancellato";
                    else
                        return "Un reparto con questo codice è già presente";
                }

                reparto.CODICE = codice;
                reparto.DESCRIZIONE = descrizione;
                reparto.DESCRIZIONEBREVE = descrizioneBreve;

                reparto.DATAMODIFICA = DateTime.Now;
                reparto.UTENTEMODIFICA = account;

                bAnagrafica.UpdateTable(_ds, _ds.REPARTI.TableName);

                return string.Empty;
            }
        }

        public void CancellaReparto(decimal idReparto, string account)
        {
            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillReparti(_ds, true);
                bAnagrafica.FillFasi(_ds, true);
                AnagraficaDS.REPARTIRow reparto = _ds.REPARTI.Where(x => x.IDREPARTO == idReparto).FirstOrDefault();
                if (reparto != null)
                {
                    reparto.CANCELLATO = SiNo.Si;
                    reparto.DATAMODIFICA = DateTime.Now;
                    reparto.UTENTEMODIFICA = account;

                    bAnagrafica.UpdateTable(_ds, _ds.REPARTI.TableName);
                }

                foreach (AnagraficaDS.FASIRow fase in _ds.FASI.Where(x => x.IDREPARTO == idReparto))
                {
                    fase.CANCELLATO = SiNo.Si;
                    fase.DATAMODIFICA = DateTime.Now;
                    fase.UTENTEMODIFICA = account;
                }
                bAnagrafica.UpdateTable(_ds, _ds.FASI.TableName);
            }
        }
        public List<RepartoModel> CreaListaRepartoModel()
        {
            List<RepartoModel> lista = new List<RepartoModel>();

            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillReparti(_ds, true);
                foreach (AnagraficaDS.REPARTIRow reparto in _ds.REPARTI)
                {
                    lista.Add(creaRepartoModel(reparto));
                }
            }
            return lista;
        }

        private RepartoModel creaRepartoModel(AnagraficaDS.REPARTIRow reparto)
        {
            if (reparto == null) return null;
            RepartoModel r = new RepartoModel()
            {
                IdReparto = reparto.IDREPARTO,
                Codice = reparto.CODICE,
                DescrizioneBreve = reparto.IsDESCRIZIONEBREVENull() ? string.Empty : reparto.DESCRIZIONEBREVE,
                Descrizione = reparto.IsDESCRIZIONENull() ? string.Empty : reparto.DESCRIZIONE,
            };
            return r;
        }

        public RepartoModel CreaRepartoModel(decimal idReparto)
        {
            AnagraficaDS.REPARTIRow reparto = EstraiReparto(idReparto);
            return creaRepartoModel(reparto);
        }
        public List<FaseModel> CreaListaFaseModel()
        {
            List<FaseModel> lista = new List<FaseModel>();

            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                if (_ds.FASI.Count == 0)
                    bAnagrafica.FillFasi(_ds, true);
                foreach (AnagraficaDS.FASIRow fase in _ds.FASI)
                {
                    lista.Add(creaFaseModel(fase));
                }
            }
            return lista;
        }

        public List<FaseModel> CreaListaFaseModel(decimal idReparto)
        {
            List<FaseModel> lista = CreaListaFaseModel();
            return lista.Where(x => x.Reparto.IdReparto == idReparto).ToList();
        }


        private FaseModel creaFaseModel(AnagraficaDS.FASIRow fase)
        {
            if (fase == null) return null;
            FaseModel r = new FaseModel()
            {
                IdFase = fase.IDFASE,
                Codice = fase.CODICE,
                Descrizione = fase.DESCRIZIONE,
                Reparto = CreaRepartoModel(fase.IDREPARTO),
                Ricarico = fase.IsRICARICONull() ? 0 : fase.RICARICO,
                Costo = fase.IsCOSTONull() ? 0 : fase.COSTO,
                IncludiPreventivo = fase.INCLUDIPREVENTIVO == SiNo.Si,
                IdEsterna = fase.IsIDESTERNANull() ? -1 : fase.IDESTERNA,
                TabellaEsterna = fase.IsTABELLAESTERNANull() ? string.Empty : fase.TABELLAESTERNA
            };
            return r;
        }

        public string CreaFase(string codice, string descrizione, decimal idReparto, decimal ricarico, decimal costo, bool includiPreventivo, decimal idEsterna, string tabellaEsterna, string account)
        {
            if (string.IsNullOrEmpty(codice)) return "Codice deve essere valorizzato";
            if (string.IsNullOrEmpty(descrizione)) return "Descrizione deve essere valorizzata";
            codice = codice.Trim().ToUpper();
            descrizione = descrizione.Trim().ToUpper();

            codice = (codice.Length > 10 ? codice.Substring(0, 10) : codice).ToUpper();
            descrizione = (descrizione.Length > 40 ? descrizione.Substring(0, 40) : descrizione).ToUpper();

            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillFasi(_ds, false);
                AnagraficaDS.FASIRow b = _ds.FASI.Where(x => x.CODICE == codice).FirstOrDefault();
                if (b != null)
                {
                    if (b.CANCELLATO == SiNo.Si)
                        return "Una fase con questo codice era presente ma è stato cancellato";
                    else
                        return "Una fase con questo codice è già presente";
                }

                AnagraficaDS.FASIRow br = _ds.FASI.NewFASIRow();
                br.CODICE = codice;
                br.DESCRIZIONE = descrizione;
                br.IDREPARTO = idReparto;
                br.RICARICO = ricarico;
                br.COSTO = costo;
                br.INCLUDIPREVENTIVO = includiPreventivo ? "S" : "N";
                if (idEsterna >= 0)
                    br.IDESTERNA = idEsterna;
                else
                    br.SetIDESTERNANull();
                if (string.IsNullOrEmpty(tabellaEsterna))
                    br.SetTABELLAESTERNANull();
                else
                    br.TABELLAESTERNA = tabellaEsterna;

                br.CANCELLATO = SiNo.No;
                br.DATAMODIFICA = DateTime.Now;
                br.UTENTEMODIFICA = account;

                _ds.FASI.AddFASIRow(br);
                bAnagrafica.UpdateTable(_ds, _ds.FASI.TableName);

                return string.Empty;
            }
        }

        public string ModificaFase(decimal idFase, string codice, string descrizione, decimal idReparto, decimal ricarico, decimal costo, bool includiPreventivo, decimal idEsterna, string tabellaEsterna, string account)
        {
            if (string.IsNullOrEmpty(codice)) return "Codice deve essere valorizzato";
            if (string.IsNullOrEmpty(descrizione)) return "Descrizione deve essere valorizzata";
            codice = codice.Trim().ToUpper();
            descrizione = descrizione.Trim().ToUpper();

            codice = (codice.Length > 10 ? codice.Substring(0, 10) : codice).ToUpper();
            descrizione = (descrizione.Length > 40 ? descrizione.Substring(0, 40) : descrizione).ToUpper();

            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillFasi(_ds, false);
                AnagraficaDS.FASIRow fase = _ds.FASI.Where(x => x.IDFASE == idFase).FirstOrDefault();
                if (fase == null) return "Impossibile modificare la fase";

                AnagraficaDS.FASIRow b = _ds.FASI.Where(x => x.CODICE == codice && x.IDFASE != idFase).FirstOrDefault();
                if (b != null)
                {
                    if (b.CANCELLATO == SiNo.Si)
                        return "Una fase con questo codice era presente ma è stato cancellato";
                    else
                        return "Una fase con questo codice è già presente";
                }

                fase.CODICE = codice;
                fase.DESCRIZIONE = descrizione;
                fase.IDREPARTO = idReparto;
                fase.RICARICO = ricarico;
                fase.COSTO = costo;
                fase.INCLUDIPREVENTIVO = includiPreventivo ? "S" : "N";
                if (idEsterna >= 0)
                    fase.IDESTERNA = idEsterna;
                else
                    fase.SetIDESTERNANull();
                if (string.IsNullOrEmpty(tabellaEsterna))
                    fase.SetTABELLAESTERNANull();
                else
                    fase.TABELLAESTERNA = tabellaEsterna;


                fase.DATAMODIFICA = DateTime.Now;
                fase.UTENTEMODIFICA = account;

                bAnagrafica.UpdateTable(_ds, _ds.FASI.TableName);

                return string.Empty;
            }
        }

        public void CancellaFase(decimal idFase, string account)
        {
            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillFasi(_ds, true);
                AnagraficaDS.FASIRow fase = _ds.FASI.Where(x => x.IDFASE == idFase).FirstOrDefault();
                if (fase != null)
                {
                    fase.CANCELLATO = SiNo.Si;
                    fase.DATAMODIFICA = DateTime.Now;
                    fase.UTENTEMODIFICA = account;

                    bAnagrafica.UpdateTable(_ds, _ds.FASI.TableName);
                }
            }
        }

        public List<TipoProdottoModel> CreaListaTipoProdottoModel()
        {
            List<TipoProdottoModel> lista = new List<TipoProdottoModel>();

            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillTipiProdotto(_ds, true);
                foreach (AnagraficaDS.TIPIPRODOTTORow tipoProdotto in _ds.TIPIPRODOTTO)
                {
                    lista.Add(creaTipoProdottoModel(tipoProdotto));
                }
            }
            return lista;
        }

        public TipoProdottoModel EstraiTipoProdottoModel(decimal idTipoProdotto)
        {
            AnagraficaDS.TIPIPRODOTTORow elemento = EstraiTipoProdotto(idTipoProdotto);
            if (elemento == null) return null;
            return creaTipoProdottoModel(elemento);
        }

        public AnagraficaDS.TIPIPRODOTTORow EstraiTipoProdotto(decimal idTipoProdotto)
        {
            if (_ds.TIPIPRODOTTO.Count == 0)
            {
                using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
                    bAnagrafica.FillTipiProdotto(_ds, true);
            }
            return _ds.TIPIPRODOTTO.Where(x => x.IDTIPOPRODOTTO == idTipoProdotto).FirstOrDefault();
        }

        private TipoProdottoModel creaTipoProdottoModel(AnagraficaDS.TIPIPRODOTTORow tipoProdotto)
        {
            if (tipoProdotto == null) return null;
            TipoProdottoModel r = new TipoProdottoModel()
            {
                IdTipoProdotto = tipoProdotto.IDTIPOPRODOTTO,
                Codice = tipoProdotto.CODICE,
                Descrizione = tipoProdotto.IsDESCRIZIONENull() ? string.Empty : tipoProdotto.DESCRIZIONE,
            };
            return r;
        }

        public string CreaTipoProdotto(string codice, string descrizione, string account)
        {
            if (string.IsNullOrEmpty(codice)) return "Codice deve essere valorizzato";

            codice = codice.Trim().ToUpper();
            descrizione = descrizione.Trim().ToUpper();

            codice = (codice.Length > 10 ? codice.Substring(0, 10) : codice).ToUpper();
            descrizione = (descrizione.Length > 30 ? descrizione.Substring(0, 30) : descrizione).ToUpper();

            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillTipiProdotto(_ds, false);
                AnagraficaDS.TIPIPRODOTTORow b = _ds.TIPIPRODOTTO.Where(x => x.CODICE == codice).FirstOrDefault();
                if (b != null)
                {
                    if (b.CANCELLATO == SiNo.Si)
                        return "Un tipo prodotto con questo codice era presente ma è stato cancellato";
                    else
                        return "Un tipo prodotto con questo codice è già presente";
                }

                AnagraficaDS.TIPIPRODOTTORow br = _ds.TIPIPRODOTTO.NewTIPIPRODOTTORow();
                br.CODICE = codice;
                br.DESCRIZIONE = descrizione;

                br.CANCELLATO = SiNo.No;
                br.DATAMODIFICA = DateTime.Now;
                br.UTENTEMODIFICA = account;

                _ds.TIPIPRODOTTO.AddTIPIPRODOTTORow(br);
                bAnagrafica.UpdateTable(_ds, _ds.TIPIPRODOTTO.TableName);

                return string.Empty;
            }
        }

        public string ModificaTipoProdotto(decimal idTipoProdotto, string codice, string descrizione, string account)
        {
            if (string.IsNullOrEmpty(codice)) return "Codice deve essere valorizzato";

            codice = codice.Trim().ToUpper();
            descrizione = descrizione.Trim().ToUpper();

            codice = (codice.Length > 10 ? codice.Substring(0, 10) : codice).ToUpper();
            descrizione = (descrizione.Length > 30 ? descrizione.Substring(0, 30) : descrizione).ToUpper();

            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillTipiProdotto(_ds, false);
                AnagraficaDS.TIPIPRODOTTORow tipoProdotto = _ds.TIPIPRODOTTO.Where(x => x.IDTIPOPRODOTTO == idTipoProdotto).FirstOrDefault();
                if (tipoProdotto == null) return "Impossibile modificare il tipo prodotto";

                AnagraficaDS.TIPIPRODOTTORow b = _ds.TIPIPRODOTTO.Where(x => x.CODICE == codice && x.IDTIPOPRODOTTO != idTipoProdotto).FirstOrDefault();
                if (b != null)
                {
                    if (b.CANCELLATO == SiNo.Si)
                        return "Un tipo prodotto con questo codice era presente ma è stato cancellato";
                    else
                        return "Un tipo prodotto con questo codice è già presente";
                }

                tipoProdotto.CODICE = codice;
                tipoProdotto.DESCRIZIONE = descrizione;

                tipoProdotto.DATAMODIFICA = DateTime.Now;
                tipoProdotto.UTENTEMODIFICA = account;

                bAnagrafica.UpdateTable(_ds, _ds.TIPIPRODOTTO.TableName);

                return string.Empty;
            }
        }

        public string ModificaTipoDocumento(decimal idTipoDocumento, string descrizione, string account)
        {
            if (string.IsNullOrEmpty(descrizione)) return "Descrizione deve essere valorizzata";

            descrizione = descrizione.Trim().ToUpper();

            descrizione = (descrizione.Length > 25 ? descrizione.Substring(0, 25) : descrizione).ToUpper();

            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillTipiDocumento(_ds, false);
                AnagraficaDS.TIPIDOCUMENTORow tipoDocumento = _ds.TIPIDOCUMENTO.Where(x => x.IDTIPODOCUMENTO == idTipoDocumento).FirstOrDefault();
                if (tipoDocumento == null) return "Impossibile modificare il tipo documento";
                if (tipoDocumento.DESCRIZIONE != "IMMAGINE STANDARD") return "IMMAGINE STANDARD non può essere modificata perchè di sistema";

                AnagraficaDS.TIPIDOCUMENTORow b = _ds.TIPIDOCUMENTO.Where(x => x.DESCRIZIONE == descrizione && x.IDTIPODOCUMENTO != idTipoDocumento).FirstOrDefault();
                if (b != null)
                {
                    if (b.CANCELLATO == SiNo.Si)
                        return "Un tipo documento con questo codice era presente ma è stato cancellato";
                    else
                        return "Un tipo documento con questo codice è già presente";
                }

                tipoDocumento.DESCRIZIONE = descrizione;

                tipoDocumento.DATAMODIFICA = DateTime.Now;
                tipoDocumento.UtenteModifica = account;

                bAnagrafica.UpdateTable(_ds, _ds.TIPIDOCUMENTO.TableName);

                return string.Empty;
            }
        }
        public void CancellaTipoProdotto(decimal idTipoProdotto, string account)
        {
            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillTipiProdotto(_ds, true);
                AnagraficaDS.TIPIPRODOTTORow tipoProdotto = _ds.TIPIPRODOTTO.Where(x => x.IDTIPOPRODOTTO == idTipoProdotto).FirstOrDefault();
                if (tipoProdotto != null)
                {
                    tipoProdotto.CANCELLATO = SiNo.Si;
                    tipoProdotto.DATAMODIFICA = DateTime.Now;
                    tipoProdotto.UTENTEMODIFICA = account;

                    bAnagrafica.UpdateTable(_ds, _ds.TIPIPRODOTTO.TableName);
                }
            }
        }

        public List<MateriaPrimaModel> CreaListaMateriaPrimaModel()
        {
            List<MateriaPrimaModel> lista = new List<MateriaPrimaModel>();

            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillMateriePrime(_ds, true);
                foreach (AnagraficaDS.MATERIEPRIMERow materiaPrima in _ds.MATERIEPRIME)
                {
                    lista.Add(creaMateriaPrimaModel(materiaPrima));
                }
            }
            return lista;
        }


        private MateriaPrimaModel creaMateriaPrimaModel(AnagraficaDS.MATERIEPRIMERow materiaPrima)
        {
            if (materiaPrima == null) return null;
            MateriaPrimaModel r = new MateriaPrimaModel()
            {
                IdMateriaPrima = materiaPrima.IDMATERIAPRIMA,
                Codice = materiaPrima.CODICE,
                Descrizione = materiaPrima.DESCRIZIONE,
                Materiale = creaMaterialeModel(materiaPrima.IDMATERIALE).ToString(),
                Ricarico = materiaPrima.IsRICARICONull() ? 0 : materiaPrima.RICARICO,
                Costo = materiaPrima.IsCOSTONull() ? 0 : materiaPrima.COSTO,
                IncludiPreventivo = materiaPrima.INCLUDIPREVENTIVO == SiNo.Si,
            };
            return r;
        }

        public string CreaMateriaPrima(string codice, string descrizione, decimal idMateriale, decimal ricarico, decimal costo, bool includiPreventivo, string account)
        {
            if (string.IsNullOrEmpty(codice)) return "Codice deve essere valorizzato";
            if (string.IsNullOrEmpty(descrizione)) return "Descrizione deve essere valorizzata";
            codice = codice.Trim().ToUpper();
            descrizione = descrizione.Trim().ToUpper();

            codice = (codice.Length > 10 ? codice.Substring(0, 10) : codice).ToUpper();
            descrizione = (descrizione.Length > 40 ? descrizione.Substring(0, 40) : descrizione).ToUpper();

            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillMateriePrime(_ds, false);
                AnagraficaDS.FASIRow b = _ds.FASI.Where(x => x.CODICE == codice).FirstOrDefault();
                if (b != null)
                {
                    if (b.CANCELLATO == SiNo.Si)
                        return "Una materia prima con questo codice era presente ma è stato cancellato";
                    else
                        return "Una materia prima con questo codice è già presente";
                }

                AnagraficaDS.MATERIEPRIMERow br = _ds.MATERIEPRIME.NewMATERIEPRIMERow();
                br.CODICE = codice;
                br.DESCRIZIONE = descrizione;
                br.IDMATERIALE = idMateriale;
                br.RICARICO = ricarico;
                br.COSTO = costo;
                br.INCLUDIPREVENTIVO = includiPreventivo ? "S" : "N";

                br.CANCELLATO = SiNo.No;
                br.DATAMODIFICA = DateTime.Now;
                br.UTENTEMODIFICA = account;

                _ds.MATERIEPRIME.AddMATERIEPRIMERow(br);
                bAnagrafica.UpdateTable(_ds, _ds.MATERIEPRIME.TableName);

                return string.Empty;
            }
        }

        public string ModificaMateriaPrima(decimal idMateriaPrima, string codice, string descrizione, decimal idMateriale, decimal ricarico, decimal costo, bool includiPreventivo, string account)
        {
            if (string.IsNullOrEmpty(codice)) return "Codice deve essere valorizzato";
            if (string.IsNullOrEmpty(descrizione)) return "Descrizione deve essere valorizzata";
            codice = codice.Trim().ToUpper();
            descrizione = descrizione.Trim().ToUpper();

            codice = (codice.Length > 10 ? codice.Substring(0, 10) : codice).ToUpper();
            descrizione = (descrizione.Length > 40 ? descrizione.Substring(0, 40) : descrizione).ToUpper();

            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillMateriePrime(_ds, false);
                AnagraficaDS.MATERIEPRIMERow materiaPrima = _ds.MATERIEPRIME.Where(x => x.IDMATERIAPRIMA == idMateriaPrima).FirstOrDefault();
                if (materiaPrima == null) return "Impossibile modificare la materia prima";

                AnagraficaDS.MATERIEPRIMERow b = _ds.MATERIEPRIME.Where(x => x.CODICE == codice && x.IDMATERIAPRIMA != idMateriaPrima).FirstOrDefault();
                if (b != null)
                {
                    if (b.CANCELLATO == SiNo.Si)
                        return "Una materia prima con questo codice era presente ma è stato cancellato";
                    else
                        return "Una materia prima con questo codice è già presente";
                }

                materiaPrima.CODICE = codice;
                materiaPrima.DESCRIZIONE = descrizione;
                materiaPrima.IDMATERIALE = idMateriale;
                materiaPrima.RICARICO = ricarico;
                materiaPrima.COSTO = costo;
                materiaPrima.INCLUDIPREVENTIVO = includiPreventivo ? "S" : "N";


                materiaPrima.DATAMODIFICA = DateTime.Now;
                materiaPrima.UTENTEMODIFICA = account;

                bAnagrafica.UpdateTable(_ds, _ds.MATERIEPRIME.TableName);

                return string.Empty;
            }
        }

        public void CancellaMateriaPrima(decimal idMateriaPrima, string account)
        {
            using (AnagraficaBusiness bAnagrafica = new AnagraficaBusiness())
            {
                bAnagrafica.FillMateriePrime(_ds, true);
                AnagraficaDS.MATERIEPRIMERow materiaPrima = _ds.MATERIEPRIME.Where(x => x.IDMATERIAPRIMA == idMateriaPrima).FirstOrDefault();
                if (materiaPrima != null)
                {
                    materiaPrima.CANCELLATO = SiNo.Si;
                    materiaPrima.DATAMODIFICA = DateTime.Now;
                    materiaPrima.UTENTEMODIFICA = account;

                    bAnagrafica.UpdateTable(_ds, _ds.MATERIEPRIME.TableName);
                }
            }
        }
    }
}
