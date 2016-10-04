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
        static public IQueryable getAll()
        {
            var db = new WorkContext();
            var query = from o in db.workers
                        orderby o.workerNr
                        select o;
            return query;
        }
        static public Worker getWorker(string name)
        {
            var db = new WorkContext();
            Worker match = new Worker();
            match = db.workers.Where(s => s.workerName == name).FirstOrDefault();
            return match;
        }
    }
}