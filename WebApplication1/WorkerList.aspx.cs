using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Schedule.Models;
using System.Web.ModelBinding;
using System.Data;
namespace Schedule
{
    public partial class WorkerList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IEnumerable<ShiftWorker> GetWorkers([QueryString("id")] string id)
        {
            int nr = 0;
            try
            {
                 nr = Int32.Parse(id);
            }
            catch
            {

            }
            var db = new Schedule.Models.WorkContext();


            var query = from o in db.shiftworkers.Include("shift").Include("worker")
                        where o.worker.workerNr == nr
                        select o;
            
            //query = query.Where(p => p.workerName == name);
            return query;
            
        }
    }
}
