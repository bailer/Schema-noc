using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Schedule.Models;
using System.Web.ModelBinding;
using System.Data;
namespace Schedule
{
    public partial class WorkerList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IEnumerable<ShiftWorker> GetWorkers([QueryString("id")] string id)
        {
            //TODO display these in dropdown instead of list
            int nr = 0;
            try
            {
                 nr = Int32.Parse(id);
            }
            catch
            {

            }
            var db = new Schedule.Models.WorkContext();


            var query = from o in db.shiftworkers.Include("shift").Include("worker")
                        where o.worker.workerNr == nr
                        select o;

            //query = query.Where(p => p.workerName == name);
            return query;
            
        }
        public static void displayWorker()
        {
            /*
             when selected from dropdown
             populate workerboxes

             */

        }
        public static void changeWorker()
        {
            /*when button is pushed
             get worker from worker.cs with name
             workername from textbox
             workeradmin from checkbox
             workerad from textbox
             workergroup from radiobuttons
             context save

             */
        }
        public static void addWorker()
        {
            /*
             new workcontext
             workername from textbox
             workeradmin from checkbox
             workerad from textbox
             workergroup from radiobuttons
             context save
             ifworkerdays = yes addworkerdays()
             */
        }
        public static void addWorkerDays()
        {
            /*
            date startdag
            int a= 0
            new workcontext
            while dag < slutdag

            if börja dagskift a= 0
            if börja projektvecka a = 7
            if börja dag helg =12
            if börja kvällskift a = 14
            if börja natt a= 21
            if börja natt helg a= 32
            if börja kvällskift2 a= 37
            array =  111110066006442200000333300000003550022200
            if(array[a] == 0)
            {
            shiftid = array[a]
            }
            startdag.add(1)
            a++
            if(a==43)
            {
            a=0
            }

            create shiftworker (shiftid, worker, date)
            /while

            context save
            */
        }
    }
}
/*
 <asp:GridView ID="gvPerson" runat="server" AutoGenerateColumns="False" BackColor="White"  
                BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4"  
                    SelectMethod="GetWorkers"
                    ItemType="Schedule.Models.ShiftWorker"
                    > 
                <RowStyle BackColor="White" ForeColor="#003399" /> 
                    <Columns> 
                        <asp:TemplateField HeaderText="LastName" SortExpression="LastName"> 
                            <EditItemTemplate> 
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Item.shift.shiftId %>'></asp:TextBox> 
                            </EditItemTemplate> 
                            <ItemTemplate> 
                                <asp:Label ID="Label1" runat="server" Text='<%# Item.shift.typeOFShift %>'></asp:Label> 
                            </ItemTemplate> 
                        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Staff" > 
                            <EditItemTemplate> 
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Item.worker.workerSurName %>'></asp:TextBox> 
                            </EditItemTemplate> 
                            <ItemTemplate> 
                                <asp:Label ID="Label2" runat="server" Text='<%# Item.worker.workerName +" " + Item.worker.workerSurName %>'></asp:Label> 
                            </ItemTemplate> 
                        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Staff">
                                <EditItemTemplate> 
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Item.date %>'></asp:TextBox> 
                                </EditItemTemplate> 
                                <ItemTemplate> 
                                    <asp:Label ID="Label2" runat="server" Text='<%# Item.date %>'></asp:Label> 
                                </ItemTemplate> 
                        </asp:TemplateField> 
                    </Columns> 
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" /> 
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" /> 
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" /> 
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" /> 
                </asp:GridView> 
     
     */
