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
        protected void Schedule_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int a = e.Row.Cells.Count;
                for(int b = 0; a>b; b++)
                {
                    
                    switch(e.Row.Cells[b].Text.ToLower())
                    {
                        case "1":
                            e.Row.Cells[b].BackColor = System.Drawing.Color.LightBlue;
                            break;
                        case "2":
                            e.Row.Cells[b].BackColor = System.Drawing.Color.Green;
                            break;
                        case "3":
                            e.Row.Cells[b].BackColor = System.Drawing.Color.Red;
                            break;
                        case "4":
                            e.Row.Cells[b].BackColor = System.Drawing.Color.Blue;
                            break;
                        case "5":
                            e.Row.Cells[b].BackColor = System.Drawing.Color.Yellow;
                            break;
                        case "6":
                            e.Row.Cells[b].BackColor = System.Drawing.Color.Pink;
                            break;
                        case "7":
                            e.Row.Cells[b].BackColor = System.Drawing.Color.Purple;
                            break;
                        case "8":
                            e.Row.Cells[b].BackColor = System.Drawing.Color.Coral;
                            break;
                        case "bl":
                            e.Row.Cells[b].BackColor = System.Drawing.Color.White;
                            break;

                    }
                    if (e.Row.Cells[b].Text.Contains("s") && e.Row.Cells[b].Text != "&nbsp;" && b != 0)
                    {
                        e.Row.Cells[b].BackColor = System.Drawing.Color.Orange;
                    }
                }
                /*
                else if (e.Row.Cells[0].Text == "close")
                {
                    e.Row.Cells[0].ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    e.Row.Cells[0].ForeColor = System.Drawing.Color.Green;
                }*/
            }
        }
    }
}