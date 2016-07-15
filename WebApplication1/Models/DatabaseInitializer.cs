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
                    workerName = "peter",
                    workerSurName = "ejvergård",
                    admin = false,
                    group = "noc"
                },
                new Worker
                {
                    workerName = "peter",
                    workerSurName = "strandgren",
                    admin = true,
                    group = "shiftleader"

                },
                new Worker
                {
                    workerName = "leo",
                    workerSurName = "bergström",
                    admin = false,
                    group = "noc"

                },
                new Worker
                {
                    workerName = "daniel",
                    workerSurName = "engh",
                    admin = false,
                    group = "vikarie"
                },
                new Worker
                {
                    workerName = "staffan",
                    workerSurName = "celind",
                    admin = false,
                    group = "noc"
                },
                new Worker
                {
                    workerName = "lars åke",
                    workerSurName = "sköld",
                    admin = false,
                    group = "noc"
                },
                new Worker
                {
                    workerName = "christian",
                    workerSurName = "de mander",
                    admin = false,
                    group = "noc"
                },
                new Worker
                {
                    workerName = "joakim",
                    workerSurName = "larsson",
                    admin = false,
                    group = "noc"
                },
                new Worker
                {
                    workerName = "daniel",
                    workerSurName = "santana",
                    admin = false,
                    group = "noc"
                },
                new Worker
                {
                    workerName = "alexander",
                    workerSurName = "jansson",
                    admin = false,
                    group = "noc"
                },
                new Worker
                {
                    workerName = "joakim",
                    workerSurName = "järvinen",
                    admin = true,
                    group = "vikarie"

                },
                new Worker
                {
                    workerName = "christoffer",
                    workerSurName = "cnilsson",
                    admin = false,
                    group = "noc"
                },
                new Worker
                {
                    workerName = "joakim",
                    workerSurName = "säfström",
                    admin = false,
                    group = "vikarie"

                },
                new Worker
                {
                    workerName = "joakim",
                    workerSurName = "jnilsson",
                    admin = false,
                    group = "vikarie"

                },
                new Worker
                {
                    workerName = "peter",
                    workerSurName = "lundgren",
                    admin = false,
                    group = "vikarie"
                },
                new Worker
                {
                    workerName = "Arash",
                    workerSurName = "Sadeghi",
                    admin = false,
                    group = "vikarie"
                },
                new Worker
                {
                    workerName = "gunnar",
                    workerSurName = "petzäll",
                    admin = false,
                    group = "noc"
                },
                new Worker
                {
                    workerName = "markus",
                    workerSurName = "jonsson",
                    admin = false,
                    group = "noc"
                },
                new Worker
                {
                    workerName = "max",
                    workerSurName = "wijnblad",
                    admin = false,
                    group = "vikarie"
                },
                new Worker
                {
                    workerName = "robin",
                    workerSurName = "lindqvist",
                    admin = false,
                    group = "vikarie"
                },
                new Worker
                {
                    workerName = "fredrik",
                    workerSurName = "puhakka",
                    admin = true,
                    group = "shiftleader"
                },
                new Worker
                {
                    workerName = "daniel",
                    workerSurName = "dnilsson",
                    admin = true,
                    group = "shiftleader"
                },
                new Worker
                {
                    workerName = "stefan",
                    workerSurName = "ericsson",
                    admin = true,
                    group = "shiftleader"

                },
                new Worker
                {
                    workerName = "niklas",
                    workerSurName = "sundh",
                    admin = true,
                    group = "shiftleader"

                },
                new Worker
                {
                    workerName = "jenny",
                    workerSurName = "malmgren",
                    admin = true,
                    group = "shiftleader"

                },
                new Worker
                {
                    workerName = "ulrika",
                    workerSurName = "göth",
                    admin = false,
                    group = "annat"

                },
                new Worker
                {
                    workerName = "micke",
                    workerSurName = "forsberg",
                    admin = false,
                    group = "annat"

                },
                new Worker
                {
                    workerName = "marcus",
                    workerSurName = "sjöberg",
                    admin = false,
                    group = "annat"

                },
                new Worker
                {
                    workerName = "johan",
                    workerSurName = "ingevaldsson",
                    admin = true,
                    group = "shiftleader"

                },
                new Worker
                {
                    workerName = "ace",
                    workerSurName = "Maroney",
                    admin = true,
                    group = "shiftleader"

                },
                new Worker
                {
                    workerName = "jakob",
                    workerSurName = "sennerby",
                    admin = false,
                    group = "vikarie"

                },
                new Worker
                {
                    workerName = "Marcus",
                    workerSurName = "Wijnblad",
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