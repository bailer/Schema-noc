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
        public string workerSurName { get; set; }
        [Key]
        public int workerNr { get; set; }
        public bool shiftLeader { get; set; }
        static public IQueryable getAll()
        {
            var db = new WorkContext();
            var query = from o in db.workers
                        orderby o.workerNr
                        select o;
            return query;
        }
    }
}