<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WorkerList.aspx.cs" Inherits="Schedule.WorkerList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            <hgroup>
                <h2><%: Page.Title %>
            </h2>
            </hgroup>
            
            <div id="Workerlist2">          
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
        </div>
            
        </div>
    </section>
</asp:Content>

    
 