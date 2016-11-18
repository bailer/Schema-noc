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
            //If it isnt a postback request show the new and change buttons as default
            if (!IsPostBack)
            {
                changeUser.Visible = true;
                newButton.Visible = true;
            }

        }
        #region Buttons
        // Buttons for different operations
        protected void deleteShiftsButton_Click(object sender, EventArgs e)
        {
            deleteShifts(workerDropdown.Text.ToLower());
        }
        //Creates a new worker
        protected void newButton_Click(object sender, EventArgs e)
        {
            addWorker();
            updateDropdown();

        }
        //Updates a current worker
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
        //Removes a worker
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

        //Removes shifts
        protected void deleteShifts(string name)
        {
            //Creates a new workcontext and a new worker
            WorkContext db = new WorkContext();
            Worker worker = new Worker();

            //Gets the worker with the name
            Worker.getWorker(name, db);

            //Calls the deleteShifts function and shows the "deleted" label
            ShiftWorker.deleteShiftWorkers(worker, db);
            deletedShiftsLabel.Visible = true;
            /* 
             * call this to delete all the shifts for a specific worker.
             * forexample to get  
             */
        }
        //same as above however only deletes from a certain date.
        protected void deleteShifts(string name, DateTime fromDate)
        {
            WorkContext db = new WorkContext();
            Worker worker = new Worker();
            Worker.getWorker(name, db);
            ShiftWorker.deleteShiftWorkers(worker, db, fromDate);
            deletedShiftsLabel.Visible = true;
            /* 
             * call this to delete all the shifts for a specific worker.
             * forexample to get  
             */
        }
        //Function collects information from the textboxes and creates a worker. It then calls the addWorker function in the Worker class to save it
        protected void addWorker()
        {
            //Create a workcontext and collect information if the textbox and group dropdown are not empty
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
                // if this worker does not exist save the worker by calling the addWorker function in the Worker class
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
        //Used to add a bulk of days at once to a worker.
        protected void addWorkerDays(DateTime fromDate, Worker worker, int week /*Workcontext dbContext, DateTime toDate*/)
        {
            int startDay = 99;
            deleteShifts(worker.workerName, fromDate);

            // schedule per day in numbers including free days
            int[] scheduleArr = new int[] { 1, 1, 1, 1, 1, 0, 0, 6, 6, 0, 0, 6, 4, 4, 2, 2, 0, 0, 0, 0, 0, 3, 3, 3, 3, 0, 0, 0, 0, 0, 0, 0, 3, 5, 5, 0, 0, 2, 2, 2, 0, 0 };

            //what week the person wants to start the counting
            switch (week)
            {
                case 1:
                    startDay = 0; 
                    break;
                case 2:
                    startDay = 7;
                    break;
                case 3:
                    startDay = 14;
                    break;
                case 4:
                    startDay = 21;
                    break;
                case 5:
                    startDay = 28;
                    break;
                case 6:
                    startDay = 35;
                    break;
            }
            // call addShifts in shiftWorker for adding and saving the shifts to the context if startDay is not at its default value
            if(startDay != 99)
            {
                ShiftWorker.addShifts(worker, fromDate, scheduleArr, week, startDay);
            }
            else
            {
                //Show startday not selected label
            }
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
                /*
     * specefikation för addering av shift för ny person alt ändring av schema för person från visst datum. 
     * Ska denna bara funka från måndagar?
     * Man bör kunna se hur de andra shiften ser ut i närheten av dessa (ta fram exempelschema? 
     * ta bort alla andra shift från ett visst datum/innan ändring.
     * 
     */
            }
        //Set the default buttons as visible and all others as invis
        protected void defaultButtons()
        {
            newButton.Visible = true;
            updateButton.Visible = false;
            deleteButton.Visible = false;
            deleteShiftsButton.Visible = false;
        }
        
        //When you have selected a worker from the dropdown set update and delete as visible and rest as invis.
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
     