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
    //TODO gör så folk kan editera shift
    public partial class WorkerList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                changeUser.Visible = true;
                newButton.Visible = true;
            }

        }
        #region Buttons

        protected void deleteShiftsButton_Click(object sender, EventArgs e)
        {
            deleteShifts(workerDropdown.Text.ToLower());
        }
        protected void newButton_Click(object sender, EventArgs e)
        {
            addWorker();
            updateDropdown();

        }
        protected void updateButton_Click(object sender, EventArgs e)
        {
            string name = workerDropdown.SelectedItem.ToString().ToLower();
            if (name != null && workerDropdown.SelectedItem.ToString().ToLower() != "select a name" && workerName.Text != "")
            {
                changeWorker(name);
            }
            else
            {
                //TODO släng upp popup ifall namn inte är ifyllt.
            }
        }
        protected void deleteButton_Click(object sender, EventArgs e)
        {
            string name = workerDropdown.SelectedItem.ToString().ToLower();
            if (name != null && workerDropdown.SelectedItem.ToString().ToLower() != "select a name")
            {
                deleteWorker(name);
            }
            else
            {
                //TODO släng upp popup ifall namn inte är ifyllt.
            }
        }
        #endregion

        #region Update
        protected void workerDropdown_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                updateDropdown();
            }


        }
        protected void workerDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatedLabel.Visible = false;
            deletedLabel.Visible = false;
            deletedShiftsLabel.Visible = false;
            string name = workerDropdown.SelectedItem.ToString();
            if (name != "Select a name")
            {
                populateWorker(name);
            }
            /*
             when selected from dropdown
             populate workerboxes

             */
        }


        protected void updateDropdown()
        {
            workerDropdown.Items.Clear();
            IEnumerable<Worker> query = Worker.getAll();
            workerDropdown.Items.Add("Select a name");
            foreach (Worker worker in query)
            {
                workerDropdown.Items.Add(worker.workerName.ToLower());
            }
            workerName.Text = "";
            workerAD.Text = "";
            Admin.Checked = false;
            workerGroup.ClearSelection();
            defaultButtons();
        }

        protected void populateWorker(string name)
        {
            var db = new WorkContext();
            Worker worker = Worker.getWorker(name, db);
            workerName.Text = worker.workerName;
            workerAD.Text = worker.ad;
            if (worker.group != null)
            {
                workerGroup.SelectedValue = worker.group.ToLower();
            }

            if (worker.admin == true)
            {
                Admin.Checked = true;
            }
            else
            {
                Admin.Checked = false;
            }
            workerButtons();
        }

        protected void deleteWorker(string name)
        {

            if (name != null)
            {
                Worker.deleteWorker(name);
            }
            updateDropdown();
            deletedLabel.Visible = true;
        }
        protected void changeWorker(string name)
        {
            var db = new WorkContext();
            Worker worker = Worker.getWorker(name, db);
            worker.workerName = workerName.Text.ToLower();
            worker.ad = workerAD.Text.ToLower();
            worker.group = workerGroup.Text.ToLower();

            if (Admin.Checked == true)
            {
                worker.admin = true;
            }
            else
            {
                worker.admin = false;
            }
            Worker.updateWorker(worker);
            updateDropdown();
            updatedLabel.Visible = true;
            //TODO: Skicka popup om att det är uppdaterat alt lägg en label som skriver "Entry updated"
            /*when button is pushed
             get worker from worker.cs with name
             workername from textbox
             workeradmin from checkbox
             workerad from textbox
             workergroup from radiobuttons
             context save

             */
        }
        #endregion
        #region Addworker/days /remove days

        protected void deleteShifts(string name)
        {
            WorkContext db = new WorkContext();
            var selected = workerDropdown.SelectedItem;
            Worker worker = new Worker();
            Worker.getWorker(name, db);
            ShiftWorker.deleteShiftWorkers(worker, db);
            deletedShiftsLabel.Visible = true;
            /* 
             * call this to delete all the shifts for a specific worker.
             * forexample to get  
             */
        }

        protected void addWorker()
        {
            var db = new WorkContext();
            if(workerName.Text != "" && workerGroup.SelectedValue != "")
            {
                Worker worker = new Worker();
                worker.workerName = workerName.Text.ToLower();
                worker.ad = workerAD.Text.ToLower();
                worker.group = workerGroup.SelectedValue.ToString();
                if (Admin.Checked == true)
                {
                    worker.admin = true;
                }
                else if (Admin.Checked == false)
                {
                    worker.admin = false;
                }

                if (Worker.getWorker(worker.workerName, db) == null)
                {
                    Worker.addWorker(worker, db);
                }
                else
                {
                    //TODO
                    //Name already exists error
                }
            }
            


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
        protected void addWorkerDays()
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
        protected void defaultButtons()
        {
            newButton.Visible = true;
            updateButton.Visible = false;
            deleteButton.Visible = false;
            deleteShiftsButton.Visible = false;
        }
        protected void workerButtons()
        {
            updateButton.Visible = true;
            deleteButton.Visible = true;
            deleteShiftsButton.Visible = true;
            newButton.Visible = false;

        }

        #endregion

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
