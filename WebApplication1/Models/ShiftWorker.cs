using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
namespace Schedule.Models
{
    public class ShiftWorker
    {
        
        [Key]
        public int shiftWorkerId { get; set;}

        public Worker worker { get; set; }
        public Shift shift { get; set; } 
        public bool vacation { get; set; }
        public bool vacationGranted { get; set; }
        public string vacationReason { get; set; }
        public bool sickLeave { get; set; }        
        public string date { get; set; }
        static public IQueryable<ShiftWorker> getAll()
        {
            var db = new WorkContext();
            var query = from o in db.shiftworkers.Include("shift").Include("worker")
                        orderby o.date
                        select o;
            return query;
        }
    }
}