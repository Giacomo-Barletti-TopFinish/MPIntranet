using MPIntranet.Common;
using MPIntranet.DataAccess.Finiture_Burattovarie;
using MPIntranet.Entities;
using MPIntranet.Models.Finiture_Burattovarie;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MPIntranet.Business
{
    public class FinitureBurattovarie : BusinessBase
    {
        private FBVDS _ds = new FBVDS();




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
                        IdFbvFasi = fase.IDFBVFASE,
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

        public string CreaFasi(string Codice, string Descrizione, decimal Ricarico, decimal CostoOrario, string account)
        {
            Descrizione = correggiString(Descrizione, 30);
            Codice = correggiString(Codice, 10);
            


            using (FbvBusiness bFbv = new FbvBusiness())
            {
                bFbv.FillFasi(_ds, false);

                FBVDS.FBVFASIRow fasi = _ds.FBVFASI.NewFBVFASIRow();
                fasi.CODICE = Codice;
                fasi.DESCRIZIONE = Descrizione;
                fasi.RICARICO = Ricarico;
                fasi.COSTOORARIO = CostoOrario;


                fasi.CANCELLATO = SiNo.No;
                fasi.DATAMODIFICA = DateTime.Now;
                fasi.UTENTEMODIFICA = account;

                _ds.FBVFASI.AddFBVFASIRow(fasi);
                bFbv.UpdateTable(_ds, _ds.FBVFASI.TableName);

                return string.Empty;
            }
        }

        public void ModificaFasi(decimal IdFbvFasi, string Codice, string Descrizione, decimal Ricarico, decimal CostoOrario, string account)
        {
            Codice = (Codice.Length > 10 ? Codice.Substring(0, 10) : Codice).ToUpper();
            Descrizione = (Descrizione.Length > 30 ? Descrizione.Substring(0, 30) : Descrizione).ToUpper();

            using (FbvBusiness bFbv = new FbvBusiness())
            {
                bFbv.FillFasi(_ds, true);
                FBVDS.FBVFASIRow br = _ds.FBVFASI.Where(x => x.IDFBVFASE == IdFbvFasi).FirstOrDefault();
                if (br != null)
                {
                    br.CODICE = Codice;
                    br.DESCRIZIONE = Descrizione;
                    br.RICARICO = Ricarico;
                    br.COSTOORARIO = CostoOrario;
                    br.CANCELLATO = SiNo.No;
                    br.DATAMODIFICA = DateTime.Now;
                    br.UTENTEMODIFICA = account;

                    bFbv.UpdateTable(_ds, _ds.FBVFASI.TableName);
                }
            }
        }

        public void CancellaFasi(decimal IdFbvFasi, string account)
        {
            using (FbvBusiness bFbv = new FbvBusiness())
            {
                bFbv.FillFasi(_ds, true);
                FBVDS.FBVFASIRow fasi = _ds.FBVFASI.Where(x => x.IDFBVFASE == IdFbvFasi).FirstOrDefault();
                if (fasi != null)
                {
                    fasi.CANCELLATO = SiNo.Si;
                    fasi.DATAMODIFICA = DateTime.Now;
                    fasi.UTENTEMODIFICA = account;

                    bFbv.UpdateTable(_ds, _ds.FBVFASI.TableName);
                }
            }
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
                FBVDS.FBVPROPRIETARow br = _ds.FBVPROPRIETA.Where(x => x.IDFBVPROPRIETA == idfbvproprieta).FirstOrDefault();
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

        public List<AttributiModel> CreaListaAttributiModel()
        {
            List<AttributiModel> lista = new List<AttributiModel>();

            using (FbvBusiness bFbv = new FbvBusiness())
            {
                bFbv.FillAttributi(_ds, true);
                bFbv.FillProprieta(_ds, true);

                foreach (FBVDS.FBVATTRIBUTIRow attributi in _ds.FBVATTRIBUTI)
                {
                    FBVDS.FBVPROPRIETARow proprieta = _ds.FBVPROPRIETA.Where(x => x.IDFBVPROPRIETA == attributi.IDFBVPROPRIETA).FirstOrDefault();
                    string materiale = string.Empty;

                    AttributiModel m = new AttributiModel()
                    {
                        IdFbvAttributi = attributi.IDFBVATTRIBUTI,
                        Codice = attributi.CODICE,
                        Descrizione = attributi.DESCRIZIONE,
                        IdFbvProprieta = attributi.IDFBVPROPRIETA,

                    };
                    lista.Add(m);
                }
            }
            return lista;
        }



        public string CreaAttributi(string codice, string descrizione, decimal IdFbvProprieta, string account)
        {
            descrizione = correggiString(descrizione, 30);
            codice = correggiString(codice, 10);

            using (FbvBusiness bFbv = new FbvBusiness())
            {
                bFbv.FillAttributi(_ds, false);

                FBVDS.FBVATTRIBUTIRow attributi = _ds.FBVATTRIBUTI.NewFBVATTRIBUTIRow();
                attributi.CODICE = codice;
                attributi.DESCRIZIONE = descrizione;
                attributi.IDFBVPROPRIETA = IdFbvProprieta;
                attributi.CANCELLATO = SiNo.No;
                attributi.DATAMODIFICA = DateTime.Now;
                attributi.UTENTEMODIFICA = account;

                _ds.FBVATTRIBUTI.AddFBVATTRIBUTIRow(attributi);
                bFbv.UpdateTable(_ds, _ds.FBVATTRIBUTI.TableName);

                return string.Empty;
            }
        }

        public void CancellaAttributi(decimal IdFbvAttributi, string account)
        {
            using (FbvBusiness bFbv = new FbvBusiness())
            {
                bFbv.FillAttributi(_ds, true);
                FBVDS.FBVATTRIBUTIRow attributi = _ds.FBVATTRIBUTI.Where(x => x.IDFBVATTRIBUTI == IdFbvAttributi).FirstOrDefault();
                if (attributi != null)
                {
                    attributi.CANCELLATO = SiNo.Si;
                    attributi.DATAMODIFICA = DateTime.Now;
                    attributi.UTENTEMODIFICA = account;

                    bFbv.UpdateTable(_ds, _ds.FBVATTRIBUTI.TableName);
                }
            }
        }

        public void ModificaAttributi(decimal IdFbvAttributi, string codice, string descrizione, string account)
        {
            codice = (codice.Length > 10 ? codice.Substring(0, 10) : codice).ToUpper();
            descrizione = (descrizione.Length > 30 ? descrizione.Substring(0, 30) : descrizione).ToUpper();


            using (FbvBusiness bFbv = new FbvBusiness())
            {
                bFbv.FillAttributi(_ds, true);
                FBVDS.FBVATTRIBUTIRow attributi = _ds.FBVATTRIBUTI.Where(x => x.IDFBVATTRIBUTI == IdFbvAttributi).FirstOrDefault();
                if (attributi != null)
                {
                    attributi.CODICE = codice;
                    attributi.DESCRIZIONE = descrizione;
                    attributi.DATAMODIFICA = DateTime.Now;
                    attributi.UTENTEMODIFICA = account;

                    bFbv.UpdateTable(_ds, _ds.FBVATTRIBUTI.TableName);
                }
            }
        }

    }
}

