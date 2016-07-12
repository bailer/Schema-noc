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
            SortedDictionary<string, List<ShiftWorker>> scheduleDict = new SortedDictionary<string, List<ShiftWorker>>();
            var shiftworkers = ShiftWorker.getAll();
            foreach (var s in shiftworkers)
            {
                if (scheduleDict.ContainsKey(s.date))
                {
                    scheduleDict[s.date].Add(s);
                } else
                {
                    scheduleDict[s.date] = new List<ShiftWorker>();
                    scheduleDict[s.date].Add(s);
                }
            }
            Schedule.DataSource = scheduleDict;
            Schedule.DataBind();
        }
    }
}