using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Schedule.Models
{
    public class Worker
    {
        /// <summary>
        /// namn telefonnummer och om dom är shiftledare eller ej
        /// </summary>
        /// y5re
        ///
        public string workerName { get; set; }
        [Key]
        public int workerNr { get; set; }
        public bool admin { get; set; }
        public string group { get; set; }
        public string ad { get; set; }

        static public IEnumerable<Worker> getAll()
        {
            var db = new WorkContext();
            // var query = from o in db.workers
            // orderby o.workerNr
            // select o;
            IEnumerable<Worker> query = db.workers.Where(s => s.workerNr != null);
            var sortedQuery = query.OrderBy(s => s.workerName);
            return sortedQuery;
        }
        static public Worker getWorker(string name, WorkContext db)
        {
            Worker match = new Worker();
            match = db.workers.Where(s => s.workerName == name).FirstOrDefault();
            return match;
        }
        /*
        static public Worker getWorker(string name)
        {
            WorkContext db = new WorkContext();
            Worker match = new Worker();
            match = db.workers.Where(s => s.workerName == name).FirstOrDefault();
            return match;
        }*/


        static public void updateWorker(Worker worker)
        {
            var db = new WorkContext();
            db.Entry(worker).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        static public void deleteWorker(string name)
        {
            var db = new WorkContext();
            Worker worker = Worker.getWorker(name, db);
            if (worker != null)
            {
                // Ta bort alla shiftworkers som har att göra med den
                ShiftWorker.deleteShiftWorkers(worker, db);
                db.workers.Remove(worker);
                db.SaveChanges();
            }
            else
            {
                //TODO Add exception
               //throw not found exception
            }
 
        }
        static public void addWorker(Worker worker, WorkContext db)
        {
            db.workers.Add(worker);
            db.SaveChanges();
        }
    }
}