using MPIntranet.DataAccess.Articoli;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.Business
{
    public class Task
    {
        public string Codice { get; set; }
        public string Descrizione { get; set; }


        public static List<Task> EstraiListaTask()
        {
            ArticoliDS ds = new ArticoliDS();
            using (ArticoliBusiness bArticolo = new ArticoliBusiness())
            {
                bArticolo.FillTask(ds);
            }

            List<Task> tasks = new List<Task>();
            foreach (ArticoliDS.TaskRow riga in ds.Task)
            {
                Task task = CreaTask(riga);
                tasks.Add(task);
            }
            return tasks;
        }

        private static Task CreaTask(ArticoliDS.TaskRow riga)
        {
            if (riga == null) return null;
            Task task = new Task();
            task.Codice = riga.Code;
            task.Descrizione = riga.Description;
            return task;
        }

        public override string ToString()
        {
            return Codice;
        }
    }
}
