using System;
using System.Collections.Generic;
using Schedule.Models;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Schedule
{
    public partial class ShiftsOverview : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateSchedule();
            }

        }
        public void PopulateSchedule()
        {
            DataTable dt = new DataTable();
            var shiftworkers = ShiftWorker.getAll();
            Dictionary<string, int> addedWorkers = new Dictionary<string, int>();
            int counter = 0;
            dt.Columns.Add(new DataColumn("Name"));
            foreach (var s in shiftworkers)
            {
                if (!dt.Columns.Contains(s.date))
                {
                    dt.Columns.Add(new DataColumn(s.date));
                }
                string shiftId = s.shift.shiftId;
                if (s.vacation)
                {
                    shiftId = shiftId + "s";
                }
                if (!addedWorkers.Keys.Contains(s.worker.workerName + " " + s.worker.workerSurName))
                {
                    DataRow row = dt.NewRow();
                    row["Name"] = s.worker.workerName + " " + s.worker.workerSurName;
                    row[s.date] = shiftId;
                    dt.Rows.Add(row);
                    addedWorkers[s.worker.workerName + " " + s.worker.workerSurName] = counter;
                    counter++;

                }
                else
                {
                    dt.Rows[addedWorkers[s.worker.workerName + " " + s.worker.workerSurName]][s.date] = shiftId;
                }
            }
            Schedule.DataSource = dt;
            Schedule.DataBind();
        }
    }
}