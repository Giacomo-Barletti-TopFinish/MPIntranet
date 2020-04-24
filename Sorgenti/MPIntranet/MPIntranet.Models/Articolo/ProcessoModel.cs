using MPIntranet.Entities;
using MPIntranet.Models.Anagrafica;
using MPIntranet.Models.Galvanica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Models.Articolo
{
    public class ProcessoModel
    {
        public decimal IdProcesso { get; set; }
        public decimal IdArticolo { get; set; }
        public string Descrizione { get; set; }
        public ImpiantoModel Impianto { get; set; }
        public List<FaseProcessoModel> Fasi { get; set; }
        public TelaioModel Telaio { get; set; }
        public bool Standard { get; set; }
        public ColoreModel Colore{ get; set; }

        public override string ToString()
        {
            return Descrizione;
        }

        public static ProcessoModel ProcessoVuoto()
        {
            ProcessoModel processo = new ProcessoModel();
            processo.IdProcesso = ElementiVuoti.ProcessoGalvanicoVuoto;
            processo.IdArticolo = ElementiVuoti.ArticoloStandard;
            processo.Impianto = ImpiantoModel.ImpiantoVuoto();
            processo.Fasi = new List<FaseProcessoModel>();
            processo.Telaio = new TelaioModel();
            processo.Standard = false;
            processo.Colore = ColoreModel.ColoreNullo();
            return processo;
        }
    }

    public class FaseProcessoModel
    {
        public decimal IdFaseProcesso { get; set; }
        public decimal IdProcesso { get; set; }
        public VascaModel Vasca { get; set; }
        public string Durata { get; set; }
        public decimal Corrente { get; set; }
        public decimal Sequenza { get; set; }
        public decimal SpessoreMinimo { get; set; }
        public decimal SpessoreNominale { get; set; }
        public decimal SpessoreMassimo { get; set; }
    }
}
