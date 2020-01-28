using MPIntranet.DataAccess.Articolo;
using MPIntranet.Entities;
using MPIntranet.Models.Articolo;
using MPIntranet.Models.Galvanica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class ProcessoGalvanico
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

            List<decimal> idprocessi = _ds.PROCESSI.Where(x => x.IDIMPIANTO == idImpianto).Select(x => x.IDPROCESSO).ToList();

            List<ProcessoModel> processiModel = new List<ProcessoModel>();

            foreach (decimal idProcesso in idprocessi)
            {
                processiModel.Add(CreaProcessoModel(idProcesso));
            }
            return processiModel;
        }

        public ProcessoModel CreaProcessoModel(decimal idProcesso)
        {           
            ArticoloDS.PROCESSIRow processo = _ds.PROCESSI.Where(x => x.IDPROCESSO == idProcesso).FirstOrDefault();
            if (processo == null) return null;

            ProcessoModel processoModel = new ProcessoModel();
            processoModel.Descrizione = processo.DESCRIZIONE;
            processoModel.IdArticolo = processo.IDARTICOLO;
            processoModel.IdProcesso = processo.IDPROCESSO;
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
                    idFaseProcesso = fase.IDFASEPROCESSO,
                    IdProcesso = fase.IDPROCESSO,
                    Sequenza = fase.SEQUENZA,
                    Vasca = vasche.Where(x => x.IdVasca == fase.IDVASCA).FirstOrDefault()
                };
                processoModel.Fasi.Add(faseProcessoModel);
            }

            return processoModel;
        }

    }
}
