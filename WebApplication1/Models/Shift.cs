using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
namespace Schedule.Models
{
    public class Shift
    {
        [Key]
        public string shiftId { get; set; }
        public string typeOFShift { get; set; }
        public string shiftStart { get; set;}
        public string shiftEnd { get; set; }

        public static Shift getShift(string id)
        {
            var db = new WorkContext();
            Shift shift;
            shift = db.shifts.Where(s => s.shiftId == id).FirstOrDefault<Shift>();
            return shift;
        }
        public static IEnumerable<Shift> getShifts(WorkContext db)
        {
            
            var shifts = db.shifts.Where(s => s.shiftId != null);
            return shifts;
        }
            
    }

}