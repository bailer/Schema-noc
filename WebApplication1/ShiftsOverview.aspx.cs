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
                Page.DataBind();
                string span = "week";
                PopulateSchedule();
            }

        }
        //Need varför blir alla cells större när man väljer månad som selection?
        public void PopulateSchedule()
        {
            string span = "";
            List<string> groupList = new List<string>();
            DateTime date = DateTime.Today;
            try
            {
                groupList = GroupCheckbox.Items.Cast<ListItem>()
                    .Where(li => li.Selected)
                    .Select(li => li.Value.ToLower())
                    .ToList();
                span = DropDownSpan.SelectedValue.ToString().ToLower();
                date = DatePicker.SelectedDate;
            }
            catch
            { }
            
            Schedule.DataSource = TableGenerator.generate(date, span, groupList );
            Schedule.DataBind();     
        }
        protected void Schedule_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            TableGenerator.addDetails(sender, e, Schedule);
            
        }

        protected void DatePicker_SelectionChanged(object sender, EventArgs e)
        {
            PopulateSchedule();
        }

        protected void DropDownSpan_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateSchedule();
        }

        protected void GroupCheckbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateSchedule();
        }
    }
}