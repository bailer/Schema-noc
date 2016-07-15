using System;
using System.Collections.Generic;
using Schedule.Models;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Need varför blir alla cells större när man väljer månad som selection?
//need 2 ordna så att man använder hela skärmen till vänster och flytta table kontrollerna (kalender, dropdown etc) till en kolumn längst till höger.
//need 3 försök fixa så att kolumnerna längst till vänster fastnar när man scrollar. försökt med 
/*td.locked{
position: relative;
top: expression(this.offsetParent.scrollTop);
background-color: White;        
}*/ //samt class.css locked i TableGenerator.addDetails(sender, e, Schedule);
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

        //need fixa så att detta öppnar popup från table
        public static void clickTable()
        {
            //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'your_page.aspx', null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
        }
    }
}
 