using System;
using System.Collections;
using System.Collections.Generic;
using Schedule.Models;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

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
            /*
            try
            {
                switch (e.Row.RowType)
                {
                    case DataControlRowType.Header:
                        //...
                        break;
                    case DataControlRowType.DataRow:
                        e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#93A3B0'; this.style.color='White'; this.style.cursor='pointer'");
                        if (e.Row.RowState == DataControlRowState.Alternate)
                        {
                            e.Row.Attributes.Add("onmouseout", String.Format("this.style.color='Black';this.style.backgroundColor='{0}';", Schedule.AlternatingRowStyle.BackColor.ToKnownColor()));
                        }
                        else
                        {
                            e.Row.Attributes.Add("onmouseout", String.Format("this.style.color='Black';this.style.backgroundColor='{0}';", Schedule.RowStyle.BackColor.ToKnownColor()));
                        }
                        e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(Schedule, "Select$" + e.Row.RowIndex.ToString()));
                        break;
                }
            }
            catch
            {
                //...throw
            }*/

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
            int i = 0;
            //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'your_page.aspx', null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
        }

        protected void Schedule_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Schedule_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //TODO: koppla mot exception i shiftoworker.update om några errors hittades.
            ShiftWorker.update(sender, e);
            Schedule.EditIndex = -1;
            PopulateSchedule();
        }

        protected void Schedule_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Schedule.EditIndex = e.NewEditIndex;
            PopulateSchedule();
        }

        protected void Schedule_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            Schedule.EditIndex = -1;
            PopulateSchedule();
        }
    }
}
/*https://forums.asp.net/p/1537390/3740237.aspx#3740237.
 *     protected override void Render(HtmlTextWriter writer)
    {
        // Add the extras to each row.
        foreach (GridViewRow row in GridView1.Rows)
        {
            // Show hand like the mouseover of buttons. (Not very functional, but very cute.)
            row.Attributes["onmouseover"] = "this.style.cursor='pointer';";

            // Each Cell will need its own PostBack link, with the necessary information in it.
            foreach (TableCell cell in row.Cells)
            {
                // Although we already know this should be the case,
                // make safe code. Makes copying for reuse a lot easier.
                if (cell is DataControlFieldCell)
                {
                    // Put the link on the cell.
                    cell.Attributes["onclick"] =
                        Page.ClientScript.GetPostBackClientHyperlink(GridView1,
                        String.Format("CellSelect${0},{1}", row.RowIndex, row.Cells.GetCellIndex(cell)));

                    // Register for event validation: This will keep ASP from giving nasty errors from
                    // getting events from controls that shouldn't be sending any.
                    Page.ClientScript.RegisterForEventValidation(GridView1.UniqueID,
                        String.Format("CellSelect${0},{1}", row.RowIndex, row.Cells.GetCellIndex(cell)));
                }
            }
        }
        
        base.Render(writer);
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // Don't interfere with other commands.
        // We may not have any now, but this is another safe-code strategy.
        if (e.CommandName == "CellSelect")
        {
            // Unpack the arguments.
            String[] arguments = ((String)e.CommandArgument).Split(new char[] { ',' });

            // More safe coding: Don't assume there are at least 2 arguments.
            // (And ignore when there are more.)
            if (arguments.Length >= 2)
            {
                // And even more safe coding: Don't assume the arguments are proper int values.
                int rowIndex = -1, cellIndex = -1;
                int.TryParse(arguments[0], out rowIndex);
                int.TryParse(arguments[1], out cellIndex);

                // Use the rowIndex to select the Row, like Select would do.
                // ...with safety: Don't assume GridView1 even has the row.
                if (rowIndex > -1 && rowIndex < GridView1.Rows.Count)
                {
                    GridView1.SelectedIndex = rowIndex;
                }

                // Just for this demo: Put the selection in the TextBoxes.
                SelectedRowLabel.Text = rowIndex.ToString();
                SelectedColumnLabel.Text = cellIndex.ToString();
            }
        }
    }
}
 */
