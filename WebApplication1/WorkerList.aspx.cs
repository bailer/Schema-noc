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
        public IQueryable<Worker> GetWorkers([QueryString("id")] string name)
        {
            var db = new Schedule.Models.WorkContext();
            IQueryable<Worker> query = db.workers;
            
            if (name != null)
            {
                query = query.Where(p => p.workerName == name);
            };
            return query;
        }
    }
}