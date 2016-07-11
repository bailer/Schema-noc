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
                    shiftLeader = false

                },
                new Worker
                {
                    workerName = "peter",
                    workerSurName = "strandgren",
                    shiftLeader = false

                },
                new Worker
                {
                    workerName = "leo",
                    workerSurName = "bergström",
                    shiftLeader = false

                },
                new Worker
                {
                    workerName = "daniel",
                    workerSurName = "engh",
                    shiftLeader = false

                },
                new Worker
                {
                    workerName = "staffan",
                    workerSurName = "celind",
                    shiftLeader = false

                },
                new Worker
                {
                    workerName = "lars åke",
                    workerSurName = "sköld",
                    shiftLeader = false

                },
                new Worker
                {
                    workerName = "christian",
                    workerSurName = "de mander",
                    shiftLeader = false

                },
                new Worker
                {
                    workerName = "joakim",
                    workerSurName = "larsson",
                    shiftLeader = false

                },
                new Worker
                {
                    workerName = "daniel",
                    workerSurName = "santana",
                    shiftLeader = false

                },
                new Worker
                {
                    workerName = "alexander",
                    workerSurName = "jansson",
                    shiftLeader = false

                },
                new Worker
                {
                    workerName = "joakim",
                    workerSurName = "järvinen",
                    shiftLeader = false

                },
                new Worker
                {
                    workerName = "christoffer",
                    workerSurName = "nilsson",
                    shiftLeader = false

                },
                new Worker
                {
                    workerName = "säfström",
                    workerSurName = "säfström",
                    shiftLeader = false

                },
                new Worker
                {
                    workerName = "joakim",
                    workerSurName = "nilsson joakim",
                    shiftLeader = false

                },
                new Worker
                {
                    workerName = "peter",
                    workerSurName = "lundgren",
                    shiftLeader = false

                },
                new Worker
                {
                    workerName = "Arash",
                    workerSurName = "Sadeghi",
                    shiftLeader = false

                },
                new Worker
                {
                    workerName = "gunnar",
                    workerSurName = "petzäll",
                    shiftLeader = false

                },
                new Worker
                {
                    workerName = "markus",
                    workerSurName = "jonsson",
                    shiftLeader = false

                },
                new Worker
                {
                    workerName = "max",
                    workerSurName = "wijnblad",
                    shiftLeader = false

                },
                new Worker
                {
                    workerName = "robin",
                    workerSurName = "lindqvist",
                    shiftLeader = false

                },
                new Worker
                {
                    workerName = "max",
                    workerSurName = "wijnblad",
                    shiftLeader = false

                },
                new Worker
                {
                    workerName = "fredrik",
                    workerSurName = "puhakka",
                    shiftLeader = true

                },
                new Worker
                {
                    workerName = "daniel",
                    workerSurName = "nilsson daniel",
                    shiftLeader = true

                },
                new Worker
                {
                    workerName = "stefan",
                    workerSurName = "ericsson",
                    shiftLeader = true

                },
                new Worker
                {
                    workerName = "niklas",
                    workerSurName = "sundh",
                    shiftLeader = true

                },
                new Worker
                {
                    workerName = "jenny",
                    workerSurName = "malmgren",
                    shiftLeader = true

                },
                new Worker
                {
                    workerName = "ulrika",
                    workerSurName = "göth",
                    shiftLeader = false

                },
                new Worker
                {
                    workerName = "micke",
                    workerSurName = "forsberg",
                    shiftLeader = false

                },
                new Worker
                {
                    workerName = "marcus",
                    workerSurName = "sjöberg",
                    shiftLeader = false

                },
                new Worker
                {
                    workerName = "johan",
                    workerSurName = "ingevaldsson",
                    shiftLeader = true

                },
                new Worker
                {
                    workerName = "Ace",
                    workerSurName = "Maroney",
                    shiftLeader = true

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