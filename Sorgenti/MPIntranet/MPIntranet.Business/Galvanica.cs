﻿using MPIntranet.Common;
using MPIntranet.DataAccess.Galvanica;
using MPIntranet.Entities;
using MPIntranet.Models;
using MPIntranet.Models.Anagrafica;
using MPIntranet.Models.Galvanica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class Galvanica : BusinessBase
    {
        private GalvanicaDS _ds = new GalvanicaDS();
        private Anagrafica _anagrafica = new Anagrafica();

        public bool ImpiantoEsiste(decimal idImpianto)
        {
            using (GalvanicaBusiness bAnagrafica = new GalvanicaBusiness())
            {
                bAnagrafica.FillImpianti(_ds, true);
                return _ds.IMPIANTI.Any(x => x.IDIMPIANTO == idImpianto);
            }
        }

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
                    };
                    lista.Add(m);
                }
            }
            return lista;
        }
        public List<TelaioModel> CreaListaTelaioModel()
        {
            List<TelaioModel> lista = new List<TelaioModel>();

            using (GalvanicaBusiness bGalvanica = new GalvanicaBusiness())
            {
                bGalvanica.FillTelai(_ds, true);
                foreach (GalvanicaDS.TELAIRow telaio in _ds.TELAI)
                    lista.Add(CreaTelaioModel(telaio));
            }
            return lista;
        }

        private TelaioModel CreaTelaioModel(GalvanicaDS.TELAIRow telaio)
        {
            TelaioModel m = new TelaioModel();
            m.Codice = telaio.CODICE;
            m.CostoStandard = telaio.IsCOSTOSTANDARDNull() ? 0 : telaio.COSTOSTANDARD;
            m.IdTelaio = telaio.IDTELAIO;
            m.Pezzi = telaio.IsPEZZINull() ? 0 : telaio.PEZZI;
            m.TipoMontaggio = telaio.IsTIPOMONTAGGIONull() ? string.Empty : telaio.TIPOMONTAGGIO;
            return m;
        }

        public void CancellaImpianto(decimal idImpianto, string account)
        {
            using (GalvanicaBusiness bGalvanica = new GalvanicaBusiness())
            {
                bGalvanica.FillImpianti(_ds, true);
                GalvanicaDS.IMPIANTIRow impianto = _ds.IMPIANTI.Where(x => x.IDIMPIANTO == idImpianto).FirstOrDefault();
                if (impianto != null)
                {
                    impianto.CANCELLATO = SiNo.Si;
                    impianto.DATAMODIFICA = DateTime.Now;
                    impianto.UTENTEMODIFICA = account;

                    bGalvanica.UpdateTable(_ds, _ds.IMPIANTI.TableName);
                }
            }
        }

        public void CancellaTelaio(decimal idTelaio, string account)
        {
            using (GalvanicaBusiness bGalvanica = new GalvanicaBusiness())
            {
                bGalvanica.FillTelai(_ds, true);
                GalvanicaDS.TELAIRow telaio = _ds.TELAI.Where(x => x.IDTELAIO == idTelaio).FirstOrDefault();
                if (telaio != null)
                {
                    telaio.CANCELLATO = SiNo.Si;
                    telaio.DATAMODIFICA = DateTime.Now;
                    telaio.UTENTEMODIFICA = account;

                    bGalvanica.UpdateTable(_ds, _ds.TELAI.TableName);
                }
            }
        }
        public void ModificaImpianto(decimal idImpianto, string descrizione, string account)
        {
            using (GalvanicaBusiness bGalvanica = new GalvanicaBusiness())
            {
                bGalvanica.FillImpianti(_ds, true);
                GalvanicaDS.IMPIANTIRow br = _ds.IMPIANTI.Where(x => x.IDIMPIANTO == idImpianto).FirstOrDefault();
                if (br != null)
                {
                    br.DESCRIZIONE = correggiString(descrizione, 50);
                    br.DATAMODIFICA = DateTime.Now;
                    br.UTENTEMODIFICA = account;

                    bGalvanica.UpdateTable(_ds, _ds.IMPIANTI.TableName);
                }
            }
        }

        public void ModificaTelaio(decimal IdTelaio, decimal Costo, string account)
        {

            using (GalvanicaBusiness bGalvanica = new GalvanicaBusiness())
            {
                bGalvanica.FillTelai(_ds, true);
                GalvanicaDS.TELAIRow br = _ds.TELAI.Where(x => x.IDTELAIO == IdTelaio).FirstOrDefault();
                if (br != null)
                {
                    br.COSTOSTANDARD = Costo;
                    br.DATAMODIFICA = DateTime.Now;
                    br.UTENTEMODIFICA = account;

                    bGalvanica.UpdateTable(_ds, _ds.TELAI.TableName);
                }
            }
        }

        public string CreaImpianto(string descrizione, string account)
        {
            descrizione = correggiString(descrizione, 50);

            using (GalvanicaBusiness bGalvanica = new GalvanicaBusiness())
            {
                bGalvanica.FillImpianti(_ds, false);
                GalvanicaDS.IMPIANTIRow b = _ds.IMPIANTI.Where(x => x.DESCRIZIONE == descrizione).FirstOrDefault();
                if (b != null)
                {
                    if (b.CANCELLATO == SiNo.Si)
                        return "Un impianto con questa descrizione era presente ma è stato cancellato";
                    else
                        return "Un impianto con questa descrizione è già presente";
                }

                GalvanicaDS.IMPIANTIRow br = _ds.IMPIANTI.NewIMPIANTIRow();
                br.DESCRIZIONE = descrizione;

                br.CANCELLATO = SiNo.No;
                br.DATAMODIFICA = DateTime.Now;
                br.UTENTEMODIFICA = account;

                _ds.IMPIANTI.AddIMPIANTIRow(br);
                bGalvanica.UpdateTable(_ds, _ds.IMPIANTI.TableName);

                return string.Empty;
            }
        }

        public string CreaTelaio(string Codice, decimal Pezzi, string TipoMontaggio, decimal Costo, string account)
        {
            Codice = correggiString(Codice, 10);
            TipoMontaggio = correggiString(TipoMontaggio, 25);

            using (GalvanicaBusiness bGalvanica = new GalvanicaBusiness())
            {
                bGalvanica.FillTelai(_ds, false);
                if (_ds.TELAI.Any(x => x.CODICE == Codice && x.PEZZI == Pezzi))
                    return "Esiste già un telaio con questo codice e questo numero di pezzi";

                GalvanicaDS.TELAIRow br = _ds.TELAI.NewTELAIRow();
                br.CODICE = Codice;
                br.TIPOMONTAGGIO = TipoMontaggio;
                br.PEZZI = Pezzi;
                br.COSTOSTANDARD = Costo;

                br.CANCELLATO = SiNo.No;
                br.DATAMODIFICA = DateTime.Now;
                br.UTENTEMODIFICA = account;

                _ds.TELAI.AddTELAIRow(br);
                bGalvanica.UpdateTable(_ds, _ds.TELAI.TableName);

                return string.Empty;
            }
        }

        public List<VascaModel> CreaListaVascaModel(decimal idImpianto)
        {
            List<VascaModel> lista = new List<VascaModel>();

            using (GalvanicaBusiness bGalvanica = new GalvanicaBusiness())
            {
                bGalvanica.FillVasche(_ds, true);
                bGalvanica.FillImpianti(_ds, true);
                List<MaterialeModel> materiali = _anagrafica.CreaListaMaterialeModel();
                foreach (GalvanicaDS.VASCHERow vasca in _ds.VASCHE.Where(x => x.IDIMPIANTO == idImpianto))
                {
                    GalvanicaDS.IMPIANTIRow impianto = _ds.IMPIANTI.Where(x => x.IDIMPIANTO == vasca.IDIMPIANTO).FirstOrDefault();
                    string materiale = string.Empty;
                    MaterialeModel materialeModel = materiali.Where(x => x.IdMateriale == vasca.IDMATERIALE).FirstOrDefault();

                    VascaModel m = new VascaModel()
                    {
                        IdVasca = vasca.IDVASCA,
                        AbilitaStrato = vasca.ABILITASTRATO == SiNo.Si,
                        DescrizioneBreve = vasca.DESCRIZIONEBREVE,
                        IdImpianto = vasca.IDIMPIANTO,
                        Descrizione = vasca.DESCRIZIONE,
                        Impianto = (impianto == null) ? string.Empty : impianto.DESCRIZIONE,
                        Materiale = materialeModel,
                        DataModifica = vasca.DATAMODIFICA,
                        UtenteModifica = vasca.UTENTEMODIFICA
                    };
                    lista.Add(m);
                }
            }
            return lista;
        }

        public List<VascaModel> CreaListaVascaModel()
        {
            List<VascaModel> lista = new List<VascaModel>();

            using (GalvanicaBusiness bGalvanica = new GalvanicaBusiness())
            {
                bGalvanica.FillVasche(_ds, true);
                bGalvanica.FillImpianti(_ds, true);
                List<MaterialeModel> materiali = _anagrafica.CreaListaMaterialeModel();
                foreach (GalvanicaDS.VASCHERow vasca in _ds.VASCHE)
                {
                    GalvanicaDS.IMPIANTIRow impianto = _ds.IMPIANTI.Where(x => x.IDIMPIANTO == vasca.IDIMPIANTO).FirstOrDefault();
                    string materiale = string.Empty;
                    MaterialeModel materialeModel = materiali.Where(x => x.IdMateriale == vasca.IDMATERIALE).FirstOrDefault();

                    VascaModel m = new VascaModel()
                    {
                        IdVasca = vasca.IDVASCA,
                        AbilitaStrato = vasca.ABILITASTRATO == SiNo.Si,
                        DescrizioneBreve = vasca.DESCRIZIONEBREVE,
                        IdImpianto = vasca.IDIMPIANTO,
                        Descrizione = vasca.DESCRIZIONE,
                        Impianto = (impianto == null) ? string.Empty : impianto.DESCRIZIONE,
                        Materiale = materialeModel,
                        DataModifica = vasca.DATAMODIFICA,
                        UtenteModifica = vasca.UTENTEMODIFICA
                    };
                    lista.Add(m);
                }
            }
            return lista;
        }
        public void CancellaVasca(decimal idVasca, string account)
        {
            using (GalvanicaBusiness bGalvanica = new GalvanicaBusiness())
            {
                bGalvanica.FillVasche(_ds, true);
                GalvanicaDS.VASCHERow vasca = _ds.VASCHE.Where(x => x.IDVASCA == idVasca).FirstOrDefault();
                if (vasca != null)
                {
                    vasca.CANCELLATO = SiNo.Si;
                    vasca.DATAMODIFICA = DateTime.Now;
                    vasca.UTENTEMODIFICA = account;

                    bGalvanica.UpdateTable(_ds, _ds.VASCHE.TableName);
                }
            }
        }
        public void ModificaVasca(decimal idVasca, string descrizioneBreve, string descrizione, bool abilitaStrato, string account)
        {
            descrizioneBreve = (descrizioneBreve.Length > 30 ? descrizioneBreve.Substring(0, 30) : descrizioneBreve).ToUpper();
            descrizione = (descrizione.Length > 80 ? descrizione.Substring(0, 80) : descrizione).ToUpper();
            
            using (GalvanicaBusiness bGalvanica = new GalvanicaBusiness())
            {
                bGalvanica.FillVasche(_ds, true);
                GalvanicaDS.VASCHERow br = _ds.VASCHE.Where(x => x.IDVASCA == idVasca).FirstOrDefault();
                if (br != null)
                {
                    br.DESCRIZIONEBREVE = descrizioneBreve;
                    br.DESCRIZIONE = descrizione;
                    br.ABILITASTRATO = abilitaStrato ? SiNo.Si : SiNo.No;
                    br.DATAMODIFICA = DateTime.Now;
                    br.UTENTEMODIFICA = account;

                    bGalvanica.UpdateTable(_ds, _ds.VASCHE.TableName);
                }
            }
        }

        public string CreaVasca(string descrizioneBreve, string descrizione, bool abilitaStrato, decimal idImpianto, decimal idMateriale, string account)
        {
            descrizione = correggiString(descrizione, 50);
            descrizioneBreve = correggiString(descrizioneBreve, 30);

            if (!ImpiantoEsiste(idImpianto))
                return "Impianto non presente in archivio";

            if (!_anagrafica.MaterialeEsiste(idMateriale))
                return "Materiale non presente in archivio";

            using (GalvanicaBusiness bGalvanica = new GalvanicaBusiness())
            {
                bGalvanica.FillVasche(_ds, false);

                GalvanicaDS.VASCHERow vasca = _ds.VASCHE.NewVASCHERow();
                vasca.DESCRIZIONEBREVE = descrizioneBreve;
                vasca.DESCRIZIONE = descrizione;
                vasca.ABILITASTRATO = abilitaStrato ? SiNo.Si : SiNo.No;
                vasca.IDIMPIANTO = idImpianto;
                //         if (idMateriale > 0)
                vasca.IDMATERIALE = idMateriale;

                vasca.CANCELLATO = SiNo.No;
                vasca.DATAMODIFICA = DateTime.Now;
                vasca.UTENTEMODIFICA = account;

                _ds.VASCHE.AddVASCHERow(vasca);
                bGalvanica.UpdateTable(_ds, _ds.VASCHE.TableName);

                return string.Empty;
            }
        }
    }
}

