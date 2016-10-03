using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Schedule.Models
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<WorkContext>
    {
        protected override void Seed(WorkContext context)
        {
            var workers = GetWorkers();
            int i = 1;
            foreach(Worker w in workers)
            {
                w.workerNr = i;
                i++;
            }
            
                workers.ForEach(c => context.workers.Add(c));
            var shifts = GetShifts();
                shifts.ForEach(p => context.shifts.Add(p));
           // var shiftWorkers = GetShiftWorkers(context);
              //  shiftWorkers.ForEach(b => context.shiftworkers.Add(b));
        }
        private static List<Worker> GetWorkers()
        {

            var workers = new List<Worker>
            {
                new Worker
                {
                    workerName = "peter ejvergård",
                    admin = false,
                    group = "noc"
                },
                new Worker
                {
                    workerName = "peter strandgren",
                    admin = true,
                    group = "shiftleader"

                },
                new Worker
                {
                    workerName = "leo bergström",
                    admin = false,
                    group = "noc"

                },
                new Worker
                {
                    workerName = "daniel engh",
                    admin = false,
                    group = "vikarie"
                },
                new Worker
                {
                    workerName = "staffan celind",
                    admin = false,
                    group = "noc"
                },
                new Worker
                {
                    workerName = "lars åke sköld",
                    admin = false,
                    group = "noc"
                },
                new Worker
                {
                    workerName = "christian de mander",
                    admin = false,
                    group = "noc"
                },
                new Worker
                {
                    workerName = "joakim larsson",
                    admin = false,
                    group = "noc"
                },
                new Worker
                {
                    workerName = "daniel santana",
                    admin = false,
                    group = "noc"
                },
                new Worker
                {
                    workerName = "alexander jansson",
                    admin = false,
                    group = "noc"
                },
                new Worker
                {
                    workerName = "joakim järvinen",
                    admin = true,
                    group = "vikarie"

                },
                new Worker
                {
                    workerName = "christoffer nilsson",
                    admin = false,
                    group = "noc"
                },
                new Worker
                {
                    workerName = "joakim säfström",
                    admin = false,
                    group = "vikarie"

                },
                new Worker
                {
                    workerName = "joakim nilsson",
                    admin = false,
                    group = "vikarie"

                },
                new Worker
                {
                    workerName = "peter lundgren",
                    admin = false,
                    group = "vikarie"
                },
                new Worker
                {
                    workerName = "Arash Sadeghi",
                    admin = false,
                    group = "vikarie"
                },
                new Worker
                {
                    workerName = "gunnar petzäll",
                    admin = false,
                    group = "noc"
                },
                new Worker
                {
                    workerName = "markus jonsson",
                    admin = false,
                    group = "noc"
                },
                new Worker
                {
                    workerName = "max wijnblad",
                    admin = false,
                    group = "vikarie"
                },
                new Worker
                {
                    workerName = "robin lindqvist",
                    admin = false,
                    group = "vikarie"
                },
                new Worker
                {
                    workerName = "fredrik puhakka",
                    admin = true,
                    group = "shiftleader"
                },
                new Worker
                {
                    workerName = "daniel nilsson",
                    admin = true,
                    group = "shiftleader"
                },
                new Worker
                {
                    workerName = "stefan ericsson",
                    admin = true,
                    group = "shiftleader"

                },
                new Worker
                {
                    workerName = "niklas sundh",
                    admin = true,
                    group = "shiftleader"

                },
                new Worker
                {
                    workerName = "jenny malmgren",
                    admin = true,
                    group = "shiftleader"

                },
                new Worker
                {
                    workerName = "ulrika göth",
                    admin = false,
                    group = "annat"

                },
                new Worker
                {
                    workerName = "micke forsberg",
                    admin = false,
                    group = "annat"

                },
                new Worker
                {
                    workerName = "marcus sjöberg",
                    admin = false,
                    group = "annat"

                },
                new Worker
                {
                    workerName = "johan ingevaldsson",
                    admin = true,
                    group = "shiftleader"

                },
                new Worker
                {
                    workerName = "ace Maroney",
                    admin = true,
                    group = "shiftleader"

                },
                new Worker
                {
                    workerName = "jakob sennerby",
                    admin = false,
                    group = "vikarie"

                },
                new Worker
                {
                    workerName = "Marcus Wijnblad",
                    admin = false,
                    group = "vikarie"

                },
            };
            return workers;
        }
        private static List<Shift> GetShifts()
        {

            var shifts = new List<Shift>
            {
                new Shift
                {
                    shiftId = "1",
                    typeOFShift = "morgon",
                    shiftStart = "07:00",
                    shiftEnd = "16:00",
                },

                new Shift
                {
                    shiftId = "2",
                    typeOFShift = "kväll",
                    shiftStart = "13:00",
                    shiftEnd = "22:00",
                },

                new Shift
                {
                    shiftId = "3",
                    typeOFShift = "natt vardag",
                    shiftStart = "21:45",
                    shiftEnd = "07:15",
                },

                new Shift
                {
                    shiftId = "4",
                    typeOFShift = "dag helg",
                    shiftStart = "07:15",
                    shiftEnd = "19:15",
                },

                new Shift
                {
                    shiftId = "5",
                    typeOFShift = "natt helg",
                    shiftStart = "19:15",
                    shiftEnd = "07:15",
                },


                new Shift
                {
                    shiftId = "6",
                    typeOFShift = "dag",
                    shiftStart = "08:00",
                    shiftEnd = "17:00",
                },

                new Shift
                {
                    shiftId = "7",
                    typeOFShift = "dag/kväll",
                    shiftStart = "10:00",
                    shiftEnd = "19:00",
                },
                new Shift
                {
                    shiftId = "8",
                    typeOFShift = "shiftledare B2",
                    shiftStart = "08:00",
                    shiftEnd = "17:00",
                },
                new Shift
                {
                    shiftId = "bl",
                    typeOFShift = "Beredskaps Ledig",
                    shiftStart = "",
                    shiftEnd = "",
                },
                new Shift
                {
                    shiftId = "S",
                    typeOFShift = "Semester",
                    shiftStart = "",
                    shiftEnd = "",
                },
                new Shift
                {
                    shiftId = "0",
                    typeOFShift = "Ej schemalagd",
                    shiftStart = "",
                    shiftEnd = "",
                }
            };
            return shifts;
        }

        private static List<ShiftWorker> GetShiftWorkers(WorkContext _db)
        {
            //WorkContext _db = new WorkContext();
            //Excelparser parser = new Excelparser();
            //var shiftWorkers = parser.excelParser(_db);
            //int i = 0;
            return null;
        } 

    }
}