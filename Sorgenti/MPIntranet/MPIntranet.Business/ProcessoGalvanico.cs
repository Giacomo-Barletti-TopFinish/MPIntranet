using MPIntranet.Common;
using MPIntranet.DataAccess.Articolo;
using MPIntranet.DataAccess.Galvanica;
using MPIntranet.Entities;
using MPIntranet.Helpers;
using MPIntranet.Models;
using MPIntranet.Models.Anagrafica;
using MPIntranet.Models.Articolo;
using MPIntranet.Models.Galvanica;
using MPIntranet.Models.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class ProcessoGalvanico : BusinessBase
    {
        private ArticoloDS _ds = new ArticoloDS();
        private RVLDS _dsRVL = new RVLDS();
        private Galvanica _galvanica = new Galvanica();
        public List<ProcessoModel> CaricaProcessi(decimal idArticolo, decimal idImpianto)
        {

            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                bArticolo.FillProcessi(_ds, idArticolo, true);
                bArticolo.FillFasiProcesso(_ds, idArticolo, true);
            }

            List<TelaioModel> telai = _galvanica.CreaListaTelaioModel();
            List<decimal> idprocessi = _ds.PROCESSI.Where(x => x.IDIMPIANTO == idImpianto).Select(x => x.IDPROCESSO).ToList();

            List<ProcessoModel> processiModel = new List<ProcessoModel>();

            foreach (decimal idProcesso in idprocessi)
            {
                processiModel.Add(CreaProcessoModel(idProcesso, telai));
            }
            return processiModel;
        }

        public ProcessoModel EstraiProcesso(decimal idProcesso)
        {
            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                bArticolo.GetProcesso(_ds, idProcesso, true);
                bArticolo.GetFasiProcesso(_ds, idProcesso, true);
            }

            List<TelaioModel> telai = _galvanica.CreaListaTelaioModel();

            return CreaProcessoModel(idProcesso, telai);
        }

        public List<ProcessoModel> CaricaProcessiStandard()
        {

            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                bArticolo.FillProcessiStandard(_ds, true);
                bArticolo.FillFasiProcessoStandard(_ds, true);
            }

            List<TelaioModel> telai = _galvanica.CreaListaTelaioModel();
            List<decimal> idprocessi = _ds.PROCESSI.Select(x => x.IDPROCESSO).ToList();

            List<ProcessoModel> processiModel = new List<ProcessoModel>();

            foreach (decimal idProcesso in idprocessi)
            {
                processiModel.Add(CreaProcessoModel(idProcesso, telai));
            }
            return processiModel;
        }

        public List<ProcessoModel> CaricaProcessiStandard(Decimal idBrand)
        {
            List<ProcessoModel> processi = CaricaProcessiStandard();
            return processi.Where(x =>x.Colore!=null && x.Colore.IdBrand == idBrand).ToList();
        }

        public ProcessoModel CreaProcessoModel(decimal idProcesso, List<TelaioModel> telai)
        {

            ArticoloDS.PROCESSIRow processo = _ds.PROCESSI.Where(x => x.IDPROCESSO == idProcesso).FirstOrDefault();
            if (processo == null)
            {
                using (ArticoloBusiness bArticolo = new ArticoloBusiness())
                {
                    bArticolo.GetProcesso(_ds, idProcesso, false);
                    bArticolo.GetFasiProcesso(_ds, idProcesso, false);
                }
                processo = _ds.PROCESSI.Where(x => x.IDPROCESSO == idProcesso).FirstOrDefault();
                if (processo == null) return null;
            }

            ProcessoModel processoModel = new ProcessoModel();
            processoModel.Descrizione = processo.DESCRIZIONE;
            processoModel.IdArticolo = processo.IDARTICOLO;
            processoModel.IdProcesso = processo.IDPROCESSO;
            TelaioModel telaio = telai.Where(x => x.IdTelaio == ElementiVuoti.TelaioVuoto).FirstOrDefault();
            if (!processo.IsIDTELAIONull())
                telaio = telai.Where(x => x.IdTelaio == processo.IDTELAIO).FirstOrDefault();
            processoModel.Telaio = telaio;

            processoModel.Standard = processo.IsSTANDARDNull() ? false : processo.STANDARD == SiNo.Si;

            if (!processo.IsIDCOLORENull())
            {
                Anagrafica a = new Anagrafica();
                processoModel.Colore = a.EstraiColoreModel(processo.IDCOLORE);
            }
            else
                processoModel.Colore = new ColoreModel();

            List<ImpiantoModel> impianti = _galvanica.CreaListaImpiantoModel();
            processoModel.Impianto = impianti.Where(x => x.IdImpianto == processo.IDIMPIANTO).FirstOrDefault();

            List<VascaModel> vasche = _galvanica.CreaListaVascaModel();
            processoModel.Fasi = new List<FaseProcessoModel>();

            foreach (ArticoloDS.FASIPROCESSORow fase in _ds.FASIPROCESSO.Where(x => x.IDPROCESSO == idProcesso))
            {
                FaseProcessoModel faseProcessoModel = new FaseProcessoModel()
                {
                    Corrente = fase.CORRENTE,
                    Durata = fase.DURATA,
                    IdFaseProcesso = fase.IDFASEPROCESSO,
                    IdProcesso = fase.IDPROCESSO,
                    Sequenza = fase.SEQUENZA,
                    Vasca = vasche.Where(x => x.IdVasca == fase.IDVASCA).FirstOrDefault(),
                    SpessoreMassimo = fase.IsSPESSOREMASSIMONull() ? 0 : fase.SPESSOREMASSIMO,
                    SpessoreMinimo = fase.IsSPESSOREMINIMONull() ? 0 : fase.SPESSOREMINIMO,
                    SpessoreNominale = fase.IsSPESSORENOMINALENull() ? 0 : fase.SPESSORENOMINALE

                };
                processoModel.Fasi.Add(faseProcessoModel);
            }

            return processoModel;
        }

        public void CreaNuovoProcesso(decimal idArticolo, decimal idImpianto, decimal idColore, string descrizione, string utente)
        {
            ArticoloDS.PROCESSIRow processo;

            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                processo = _ds.PROCESSI.NewPROCESSIRow();
                processo.CANCELLATO = SiNo.No;
                processo.DATAMODIFICA = DateTime.Now;
                processo.DESCRIZIONE = descrizione;
                processo.IDARTICOLO = idArticolo;
                processo.IDIMPIANTO = idImpianto;
                processo.IDCOLORE = idColore;
                processo.STANDARD = idArticolo == -1 ? SiNo.Si : SiNo.No;
                processo.UTENTEMODIFICA = utente;
                _ds.PROCESSI.AddPROCESSIRow(processo);

                bArticolo.UpdateTable(_ds.PROCESSI.TableName, _ds);
            }
        }
        public string SalvaProcesso(decimal idArticolo, decimal idImpianto, decimal idProcesso, decimal idTelaio, string descrizione, string vascheJSON, string utente)
        {
            string messaggio = string.Empty;
            bool esito = true;
            SalvaProcessoJson[] vasche = JSonSerializer.Deserialize<SalvaProcessoJson[]>(vascheJSON);
            foreach (SalvaProcessoJson vasca in vasche)
            {
                decimal aux;
                if (string.IsNullOrEmpty(vasca.Durata)) esito = false;
            }

            if (!esito)
            {
                messaggio = "Valorizzare la durata delle vasche";
                return messaggio;
            }

            ArticoloDS.PROCESSIRow processo;

            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                bArticolo.FillProcessi(_ds, idArticolo, true);
                bArticolo.FillFasiProcesso(_ds, idArticolo, true);

                processo = _ds.PROCESSI.Where(x => x.IDPROCESSO == idProcesso).FirstOrDefault();
                if (processo != null)
                {
                    processo.DESCRIZIONE = descrizione;

                    processo.IDTELAIO = idTelaio;
                    if (idTelaio == ElementiVuoti.TelaioVuoto) processo.SetIDTELAIONull();

                    List<ArticoloDS.FASIPROCESSORow> fasi = _ds.FASIPROCESSO.Where(x => x.IDPROCESSO == idProcesso).ToList();
                    List<decimal> idFaseProcesso = vasche.Select(x => x.IdFaseProcesso).ToList();

                    foreach (ArticoloDS.FASIPROCESSORow faseDaCancellare in fasi.Where(x => !idFaseProcesso.Contains(x.IDFASEPROCESSO)))
                    {
                        faseDaCancellare.CANCELLATO = SiNo.Si;
                        faseDaCancellare.DATAMODIFICA = DateTime.Now;
                        faseDaCancellare.UTENTEMODIFICA = utente;
                    }

                    for (int i = 0; i < vasche.Length; i++)
                    {
                        SalvaProcessoJson vasca = vasche[i];
                        decimal corrente = decimal.Parse(vasca.Corrente.Replace(".", ","));
                        decimal spessoreMinimo = decimal.Parse(vasca.SpessoreMinimo.Replace(".", ","));
                        decimal spessoreMassimo = decimal.Parse(vasca.SpessoreMassimo.Replace(".", ","));
                        decimal spessoreNominale = decimal.Parse(vasca.SpessoreNominale.Replace(".", ","));

                        ArticoloDS.FASIPROCESSORow fase = fasi.Where(x => x.IDFASEPROCESSO == vasca.IdFaseProcesso).FirstOrDefault();
                        if (fase == null)
                        {
                            fase = _ds.FASIPROCESSO.NewFASIPROCESSORow();
                            fase.CANCELLATO = SiNo.No;
                            fase.CORRENTE = corrente;
                            fase.SPESSOREMASSIMO = spessoreMassimo;
                            fase.SPESSORENOMINALE = spessoreNominale;
                            fase.SPESSOREMINIMO = spessoreMinimo;
                            fase.DURATA = vasca.Durata;
                            fase.DATAMODIFICA = DateTime.Now;
                            fase.IDPROCESSO = idProcesso;
                            fase.IDVASCA = vasca.IdVasca;
                            fase.SEQUENZA = i;
                            fase.UTENTEMODIFICA = utente;
                            _ds.FASIPROCESSO.AddFASIPROCESSORow(fase);
                        }
                        else
                        {
                            fase.CORRENTE = corrente;
                            fase.DURATA = vasca.Durata;
                            fase.SPESSOREMASSIMO = spessoreMassimo;
                            fase.SPESSORENOMINALE = spessoreNominale;
                            fase.SPESSOREMINIMO = spessoreMinimo;
                            fase.DATAMODIFICA = DateTime.Now;
                            fase.SEQUENZA = i;
                            fase.UTENTEMODIFICA = utente;
                        }
                    }

                    bArticolo.UpdateTable(_ds.FASIPROCESSO.TableName, _ds);
                    bArticolo.UpdateTable(_ds.PROCESSI.TableName, _ds);
                    messaggio = "Salvataggio riuscito";
                }

            }

            return messaggio;
        }

        public string CancellaProcesso(decimal idArticolo, decimal idImpianto, decimal idProcesso, string utente)
        {
            string messaggio = string.Empty;

            ArticoloDS.PROCESSIRow processo;

            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                bArticolo.FillProcessi(_ds, idArticolo, true);
                bArticolo.FillFasiProcesso(_ds, idArticolo, true);

                processo = _ds.PROCESSI.Where(x => x.IDPROCESSO == idProcesso).FirstOrDefault();
                if (processo != null)
                {
                    processo.CANCELLATO = SiNo.Si;
                    processo.DATAMODIFICA = DateTime.Now;
                    processo.UTENTEMODIFICA = utente;

                    List<ArticoloDS.FASIPROCESSORow> fasi = _ds.FASIPROCESSO.Where(x => x.IDPROCESSO == idProcesso).ToList();

                    foreach (ArticoloDS.FASIPROCESSORow faseDaCancellare in fasi)
                    {
                        faseDaCancellare.CANCELLATO = SiNo.Si;
                        faseDaCancellare.DATAMODIFICA = DateTime.Now;
                        faseDaCancellare.UTENTEMODIFICA = utente;
                    }

                    bArticolo.UpdateTable(_ds.FASIPROCESSO.TableName, _ds);
                    bArticolo.UpdateTable(_ds.PROCESSI.TableName, _ds);
                    messaggio = "Cancellazione riuscita";
                }

            }

            return messaggio;
        }
        public string CopiaProcesso(decimal idProcessoStandard, decimal idArticolo, decimal idImpianto, string utente)
        {
            string descrizione = "€#@#[]";

            using (ArticoloBusiness bArticolo = new ArticoloBusiness())
            {
                bArticolo.FillProcessi(_ds, -1, true);
                bArticolo.FillFasiProcesso(_ds, -1, true);
                ArticoloDS.PROCESSIRow processoStandard = _ds.PROCESSI.Where(x => x.IDPROCESSO == idProcessoStandard).FirstOrDefault();
                decimal idcolore = ElementiVuoti.ColoreVuoto;

                if (!processoStandard.IsIDCOLORENull()) idcolore = processoStandard.IDCOLORE;

                if (processoStandard == null)
                {
                    return "Errore durante la copia. Processo standard non trovato.";
                }
                string nuovaDescrizione = processoStandard.DESCRIZIONE;

                CreaNuovoProcesso(idArticolo, idImpianto, idcolore, descrizione, utente);
                _ds.PROCESSI.Clear();

                bArticolo.FillProcessi(_ds, idArticolo, true);
                bArticolo.FillFasiProcesso(_ds, idArticolo, true);


                ArticoloDS.PROCESSIRow processo = _ds.PROCESSI.Where(x => x.DESCRIZIONE == descrizione).FirstOrDefault();
                if (processo != null)
                {
                    processo.DESCRIZIONE = nuovaDescrizione;

                    List<ArticoloDS.FASIPROCESSORow> fasiStandard = _ds.FASIPROCESSO.Where(x => x.IDPROCESSO == idProcessoStandard).ToList();
                    foreach (ArticoloDS.FASIPROCESSORow faseStandard in fasiStandard)
                    {
                        ArticoloDS.FASIPROCESSORow fase = _ds.FASIPROCESSO.NewFASIPROCESSORow();
                        fase.CANCELLATO = SiNo.No;
                        fase.CORRENTE = faseStandard.CORRENTE;
                        fase.DURATA = faseStandard.DURATA;
                        fase.DATAMODIFICA = DateTime.Now;
                        fase.IDPROCESSO = processo.IDPROCESSO;
                        fase.IDVASCA = faseStandard.IDVASCA;
                        fase.SEQUENZA = faseStandard.SEQUENZA;
                        fase.SPESSOREMASSIMO = faseStandard.SPESSOREMASSIMO;
                        fase.SPESSORENOMINALE = faseStandard.SPESSORENOMINALE;
                        fase.SPESSOREMINIMO = faseStandard.SPESSOREMINIMO;

                        fase.UTENTEMODIFICA = utente;
                        _ds.FASIPROCESSO.AddFASIPROCESSORow(fase);
                    }

                    bArticolo.UpdateTable(_ds.FASIPROCESSO.TableName, _ds);
                    bArticolo.UpdateTable(_ds.PROCESSI.TableName, _ds);
                    return "Salvataggio riuscito";
                }
                return "Errore durante la copia. Impossibile creare un nuovo processo.";
            }
        }

    }
}
