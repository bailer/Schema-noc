<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WorkerList.aspx.cs" Inherits="Schedule.WorkerList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div ID="pageControlls">

        </div>

        <div ID="changeUser" runat="server" >
            <div>
                <asp:Label ID="updatedLabel" Text="Entry Updated" Visible="false" runat="server"></asp:Label>
                <asp:Label ID="deletedLabel" Text="Entry Deleted" Visible="false" runat="server"></asp:Label>
            </div>
            <div class="Dropdown">
                <asp:Label Text="Workers" runat="server"/>
                <asp:DropDownList ID="workerDropdown" runat="server" onload="workerDropdown_Load" OnSelectedIndexChanged="workerDropdown_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
                <br />
            </div>
            <div class="workerBoxes">
                <div>
                    <br />
                    <asp:Label Text="Name" runat="server"/>
                    <asp:TextBox ID="workerName" runat="server"></asp:TextBox>
                </div>
                <div>
                    
                    <asp:Label Text="AD" runat="server" />
                    <asp:TextBox ID="workerAD" runat="server"></asp:TextBox>
                    <br />
                </div>
                <div>
                    <asp:Label Text="Group:" runat="server" />
                    <asp:RadioButtonList ID="workerGroup" runat="server">
                        <asp:ListItem Text="noc"></asp:ListItem>
                        <asp:ListItem Text="vikarie"></asp:ListItem>
                        <asp:ListItem Text="shiftleader"></asp:ListItem>
                        <asp:ListItem Text="annat"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>

                <div>
                    <asp:CheckBox ID="Admin" runat="server"/>
                    <asp:Label Text="Admin?" runat="server"/>       
                </div>
                <div>
                    <br />
                    <asp:Button ID="updateButton" Text="Update Worker" OnClick="updateButton_Click" runat="server" Visible="False"/>
                    <asp:Button ID="deleteButton" Text="Delete Worker" OnClick="deleteButton_Click" runat="server" Visible="False"/>
                </div>
            </div>
            
        </div>
    </section>
</asp:Content>

    
 