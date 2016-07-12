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
            
            Schedule.DataSource = TableGenerator.generate(/*DatePicker.SelectedDate.ToShortDateString() ,DropDownSpan.SelectedValue, new List<int>() { 1, 2, 3, 4, 5 }*/);
            Schedule.DataBind();
            
        }
    }
}