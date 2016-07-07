using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Schedule.Models
{
    public class WorkContext : DbContext
    {
        public WorkContext() : base("Schedule")
        {

        }
        public DbSet<Shift> shifts { get; set; }
        public DbSet<Worker> workers { get; set; }
        public DbSet<ShiftWorker> shiftworkers { get; set; }

    }

}