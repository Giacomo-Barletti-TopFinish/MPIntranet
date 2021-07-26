using MPIntranet.DataAccess.Articoli;
using MPIntranet.Entities;
using MPIntranet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class TaskArea : BaseModel
    {
        public int IdTaskArea { get; set; }
        public string AreaProduzione { get; set; }
        public string Task { get; set; }
        public double PezziPeriodo { get; set; }
        public double Periodo { get; set; }


        public static TaskArea EstraiTaskArea(int idTaskArea)
        {
            List<TaskArea> lista = EstraiListaTaskArea(false);
            return lista.Where(x => x.IdTaskArea == idTaskArea).FirstOrDefault();
        }

        public static List<TaskArea> EstraiListaTaskArea(bool soloNonCancellati)
        {
            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                bArticolo.FillTaskArea(ds, soloNonCancellati);
            }

            List<TaskArea> taskAreas = new List<TaskArea>();
            foreach (ArticoliDS.TASKAREARow riga in ds.TASKAREA)
            {
                TaskArea taskArea = CreaTaskArea(riga);
                taskAreas.Add(taskArea);
            }
            return taskAreas;
        }

        private static TaskArea CreaTaskArea(ArticoliDS.TASKAREARow riga)
        {
            if (riga == null) return null;
            TaskArea taskArea = new TaskArea();
            taskArea.IdTaskArea = riga.IDTASKAREA;
            taskArea.AreaProduzione = riga.AREAPRODUZIONE;
            taskArea.Task = riga.TASK;
            taskArea.PezziPeriodo = riga.PEZZIPERIODO;
            taskArea.Periodo = riga.PERIODO;

            taskArea.Cancellato = riga.CANCELLATO;
            taskArea.DataModifica = riga.DATAMODIFICA;
            taskArea.UtenteModifica = riga.UTENTEMODIFICA;
            return taskArea;
        }

        public static bool Salva(List<TaskArea> tasks, string utente)
        {
            bool esito = true;
            foreach (TaskArea t in tasks)
            {
                if (string.IsNullOrEmpty(t.Task))
                    esito = false;
                if (string.IsNullOrEmpty(t.AreaProduzione))
                    esito = false;
                if (t.Periodo <= 0)
                    esito = false;
                if (t.PezziPeriodo <= 0)
                    esito = false;
            }
            if (!esito)
                return false;

            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                bArticolo.FillTaskArea(ds, true);


                List<int> ids = tasks.Select(x => x.IdTaskArea).ToList();
                foreach (ArticoliDS.TASKAREARow rigaDaCancellare in ds.TASKAREA.Where(x => !ids.Contains(x.IDTASKAREA)))
                {
                    rigaDaCancellare.CANCELLATO = true;
                    rigaDaCancellare.DATAMODIFICA = DateTime.Now; 
                    rigaDaCancellare.UTENTEMODIFICA = utente;
                }

                List<int> idBC = ds.TASKAREA.Select(x => x.IDTASKAREA).ToList();
                foreach (TaskArea t in tasks)
                {
                    ArticoliDS.TASKAREARow riga = ds.TASKAREA.Where(x => x.IDTASKAREA == t.IdTaskArea).FirstOrDefault();
                    if (riga == null)
                    {
                        riga = ds.TASKAREA.NewTASKAREARow();
                    //    riga.IDTASKAREA = t.IdTaskArea;
                        riga.AREAPRODUZIONE = t.AreaProduzione;
                        riga.TASK = t.Task;
                        riga.PEZZIPERIODO = t.PezziPeriodo;
                        riga.PERIODO = t.Periodo;

                        riga.DATAMODIFICA = DateTime.Now;
                        riga.UTENTEMODIFICA = utente;
                        riga.CANCELLATO = false;

                        ds.TASKAREA.AddTASKAREARow(riga);
                    }
                    else
                    {
                        if (riga.AREAPRODUZIONE == t.AreaProduzione &&
                        riga.TASK == t.Task &&
                        riga.PEZZIPERIODO == t.PezziPeriodo &&
                        riga.PERIODO == t.Periodo) continue;

                        riga.AREAPRODUZIONE = t.AreaProduzione;
                        riga.TASK = t.Task;
                        riga.PEZZIPERIODO = t.PezziPeriodo;
                        riga.PERIODO = t.Periodo;

                        riga.DATAMODIFICA = DateTime.Now;
                        riga.UTENTEMODIFICA = utente; 

                    }

                }
                bArticolo.UpdateTable(ds.TASKAREA.TableName, ds);
            }
            return true;
        }

    }
}
