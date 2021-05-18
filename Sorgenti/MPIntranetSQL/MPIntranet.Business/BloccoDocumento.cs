using MPIntranet.DataAccess.Documenti;
using MPIntranet.Entities;
using MPIntranet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public static class TipoBloccoDocumento
    {
        public static string Lettura = "Lettura";
        public static string Scrittura = "Scrittura";
    }

    public class BloccoDocumento
    {
        public int IdBlocco { get; set; }
        public int IdDocumento { get; set; }
        public string UtenteInizio { get; set; }
        public bool Attivo { get; set; }
        public string TipoBlocco { get; set; }
        public string UtenteFine { get; set; }
        public DateTime InizioBlocco { get; set; }
        public DateTime? FineBlocco { get; set; }



        public static List<BloccoDocumento> EstraiBlocchiDocumento(int idDocumento)
        {
            DocumentiDS ds = new DocumentiDS();
            using (DocumentiBusiness bDocumenti = new DocumentiBusiness())
            {
                bDocumenti.FillBlocchiDocumento(ds, idDocumento);
            }
            List<BloccoDocumento> blocchi = new List<BloccoDocumento>();
            foreach (DocumentiDS.BLOCCHIDOCUMENTORow riga in ds.BLOCCHIDOCUMENTO)
            {
                BloccoDocumento blocco = CreaBloccoDocumento(riga);
                blocchi.Add(blocco);
            }
            return blocchi;

        }

        private static BloccoDocumento CreaBloccoDocumento(DocumentiDS.BLOCCHIDOCUMENTORow riga)
        {
            if (riga == null) return null;
            BloccoDocumento blocco = new BloccoDocumento();
            blocco.IdBlocco = riga.IDBLOCCO;
            blocco.TipoBlocco = riga.IsTIPOBLOCCONull() ? string.Empty : riga.TIPOBLOCCO;
            blocco.IdDocumento = riga.IDDOCUMENTO;
            blocco.Attivo = riga.ATTIVO;
            blocco.UtenteInizio = riga.UTENTEINIZIO;
            blocco.UtenteFine = riga.UTENTEFINE;
            blocco.InizioBlocco = riga.INIZIOBLOCCO;
            blocco.FineBlocco = riga.FINEBLOCCO;

            return blocco;
        }
    }
}
