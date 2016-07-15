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
            DateTime date = DateTime.Today;
            try
            {
                span = DropDownSpan.SelectedValue.ToString().ToLower();
                date = DatePicker.SelectedDate;
            }
            catch
            { }
            
            Schedule.DataSource = TableGenerator.generate(date, span /*new List<int>() { 1, 2, 3, 4, 5 }*/);
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
    }
}