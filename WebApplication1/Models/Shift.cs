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


    }
}