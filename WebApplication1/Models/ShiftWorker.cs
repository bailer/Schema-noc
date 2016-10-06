using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Collections;
using System.Web.UI.WebControls;
using System.Web.UI;
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
        static public IQueryable<ShiftWorker> get(DateTime fromDate, DateTime toDate, List<string> groupList)
        {

            //groups = groups ?? new List<int> { 1, 2, 3, 4, 5 };
            var db = new WorkContext();
            
            var query = from o in db.shiftworkers.Include("shift").Include("worker")
                        orderby o.date
                        where o.date.CompareTo(fromDate) >= 0 && o.date.CompareTo(toDate) <= 0 && groupList.Contains(o.worker.@group.ToLower())
                        select o;
            
            return query;
        }
        static public void deleteShiftWorkers(Worker worker, WorkContext db)
        {
            var matches = db.shiftworkers.Where(s => s.worker.workerNr == worker.workerNr);
            if(matches != null)
            {
                foreach (ShiftWorker shiftWorker in matches)
                {
                    db.shiftworkers.Remove(shiftWorker);

                }
                db.SaveChanges();
            }

        }
        static public ShiftWorker getShiftworker(Worker worker, DateTime date)
        {

            //groups = groups ?? new List<int> { 1, 2, 3, 4, 5 };
            var db = new WorkContext();
            ShiftWorker shiftWorker = db.shiftworkers.Where(s => s.worker.workerNr == worker.workerNr && s.date == date).Include("shift").Include("worker").FirstOrDefault();
            return shiftWorker;
        }
        static public ShiftWorker getShiftworker(Worker worker, DateTime date, WorkContext db)
        {

            //groups = groups ?? new List<int> { 1, 2, 3, 4, 5 };
            //var db = new WorkContext();
            ShiftWorker shiftWorker = db.shiftworkers.Where(s => s.worker.workerNr == worker.workerNr && s.date == date).Include("shift").Include("worker").FirstOrDefault();
            return shiftWorker;
        }

        public static void updateFromGridView(object sender, GridViewUpdateEventArgs e)
        {
            var ctx = new WorkContext();
            var values = e.NewValues;
            ShiftWorker shiftWorker;
            Shift newShift;
            Worker worker = null;
            bool changed;
            bool added;

            foreach (DictionaryEntry shift in values)
            {
                changed = false;
                added = false;


                var a = shift.Key;
                string b = null;
                if (shift.Value != null)
                {
                    b = shift.Value.ToString();
                }
                if (a.ToString() == "Name")
                {
                    //worker = Worker.getWorker(b.ToString(), ctx);
                    worker = ctx.workers.Where(s => s.workerName == b.ToString().ToLower()).FirstOrDefault();
                }
                
                else if(checkInputs(b, ctx))
                {

                    DateTime date = Convert.ToDateTime(a);

                    if (shift.Value != null)
                    {
                        //string match = b[0].ToString();
                        //newShift = ctx.shifts.Where(s => s.shiftId == match).FirstOrDefault<Shift>();
                        //shiftWorker = ctx.shiftworkers.Where(s => s.worker.workerNr == worker.workerNr && s.date == date).FirstOrDefault();

                        //newShift = Shift.getShift(b[0].ToString(), ctx);
                        string bString = b[0].ToString();
                        newShift = ctx.shifts.Where(s => s.shiftId == bString).FirstOrDefault();
                        //shiftWorker = getShiftworker(worker, date, ctx);
                        shiftWorker = ctx.shiftworkers.Where(s => s.worker.workerNr == worker.workerNr && s.date == date).Include("shift").Include("worker").FirstOrDefault();

                        if (shiftWorker == null && newShift != null && worker != null)
                        {
                            ShiftWorker newShiftWorker = new ShiftWorker();
                            newShiftWorker.shift = newShift;
                            newShiftWorker.worker = worker;
                            newShiftWorker.date = date;
                            if (b.ToLower().Contains("s"))
                            {
                                newShiftWorker.vacation = true;
                                newShiftWorker.vacationReason = "semester";
                            }
                            shiftWorker = newShiftWorker;

                            added = true;
                        }

                        else if (shiftWorker != null)
                        {
                            if (b.ToLower().Contains("s"))
                            {
                                shiftWorker.vacation = true;
                                shiftWorker.vacationReason = "semester";
                            }
                            else
                            {
                                shiftWorker.vacation = false;
                                shiftWorker.vacationReason = null;
                            }
                            shiftWorker.shift = newShift;
                            changed = true;
                        }

                        if (added == true)
                        {
                            ctx.shiftworkers.Add(shiftWorker);
                            ctx.SaveChanges();
                        }

                        else if (changed == true)
                        {
                            ctx.Entry(shiftWorker).State = System.Data.Entity.EntityState.Modified;
                            ctx.SaveChanges();
                        }

                        else
                        {
                            //Visar alerts omn något vart fel. 
                            //throw exception here
                            //string errortext = " Här vart något fel vänligen dubbelkolla parametrarna";
                            // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + a + " " + b + errortext + "');", true);
                            break;
                        }
                    }
                    else
                    {
                        newShift = null;
                        //TODO: Varför funkar ctx.shiftworkers och inte getshiftworker()...
                        //shiftWorker = getShiftworker(worker, date);
                        shiftWorker = ctx.shiftworkers.Where(s => s.worker.workerNr == worker.workerNr && s.date == date).FirstOrDefault();

                        if (shiftWorker != null)
                        {
                            ctx.shiftworkers.Remove(shiftWorker);
                            ctx.SaveChanges();
                        }
                    }




                }
                //http://www.entityframeworktutorial.net/EntityFramework5/create-dbcontext-in-entity-framework5.aspx

                //shiftWorker = ctx.shiftworkers.Where(s => s.worker == shift.value)
                //(s => s.StudentName == "New Student1").FirstOrDefault<Student>();
            }


        }
        private static bool checkInputs(string input, WorkContext db)
        {
            bool pass = false;
            if(input != null)
            {
                var compareShift = Shift.getShifts(db);
                input = input.ToLower();
                var a = compareShift.Where(s => s.shiftId == input[0].ToString());
                if (input.Count() == 1 && a.Count() != 0 || input[0].ToString().ToLower() == "s")
                {
                    pass = true;
                }
                else if (input.Count() == 2 && a.Count() != 0 && input[1].ToString() == "s" || input == "bl")
                {
                    pass = true;
                }
                else if (input.Count() == 3 && a.Count() != 0 && input[1].ToString() == "s" && (input[2].ToString() == "f" || input[1].ToString() == "r"))
                {
                    pass = true;

                }
            }
            else
            {
                pass = true;
            }

            return pass;
        }
    }
}