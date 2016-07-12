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
        public DateTime date { get; set; }
        static public IQueryable<ShiftWorker> get(DateTime fromDate, DateTime toDate/*, List<int> groups*/)
        {

            //groups = groups ?? new List<int> { 1, 2, 3, 4, 5 };
            var db = new WorkContext();
            
            var query = from o in db.shiftworkers.Include("shift").Include("worker")
                        orderby o.date
                        where o.date.CompareTo(fromDate) >= 0 && o.date.CompareTo(toDate) <= 0
                        select o;
            
            return query;
        }
    }
}