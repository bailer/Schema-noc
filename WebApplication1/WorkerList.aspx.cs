using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Schedule.Models;
using System.Web.ModelBinding;

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


            var query = from o in db.shiftworkers
                        where o.worker.workerNr == nr
                        select o;
            foreach(var t in query)
            {
                var query2 = from b in db.shiftworkers
                             where b.shiftWorkerId == t.shiftWorkerId
                             select b.worker;
                var query3 = from c in db.shiftworkers
                             where c.shiftWorkerId == t.shiftWorkerId
                             select c.shift;
                t.worker = query2.First();
                t.shift = query3.First();
            }


            return query;
        }
    }
}
//query = query.Where(p => p.workerName == name);
/*< asp:DropDownList ID = "workerList"
ItemType = "schedule.Models.Worker"
runat = "server"
SelectMethod = "getWorkers" DataTextField = "workerName" >


</ asp:DropDownList >*/
