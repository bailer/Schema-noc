<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShiftsOverview.aspx.cs" EnableEventValidation="false"  Inherits="Schedule.ShiftsOverview" %>
<asp:Content ID="ShiftOverview" ContentPlaceHolderID="MainContent" runat="server">

    
    <asp:DropDownList ID="DropDownSpan" runat="server" OnTextChanged="DropDownSpan_SelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem>Day</asp:ListItem>
        <asp:ListItem>Week</asp:ListItem>
        <asp:ListItem>Month</asp:ListItem>
    </asp:DropDownList>
    <asp:CheckBoxList ID="GroupCheckbox" runat="server" AutoPostBack="True" OnSelectedIndexChanged="GroupCheckbox_SelectedIndexChanged">
        <asp:ListItem Selected="True" Value="noc">NOC</asp:ListItem>
        <asp:ListItem Selected="True" Value="vikarie">Vikarier</asp:ListItem>
        <asp:ListItem Selected="True" Value="shiftleader">shiftleader</asp:ListItem>
        <asp:ListItem Selected="True" Value="annat">Annat</asp:ListItem>
    </asp:CheckBoxList>
    <div class="calendarWrapper">
        <asp:Calendar ID="DatePicker" runat="server" DayNameFormat="FirstLetter" Font-Names="Tahoma" Font-Size="11px" 
            NextMonthText="." PrevMonthText="." SelectMonthText="»" SelectWeekText="›" CssClass="myCalendar" CellPadding="0" SelectedDate="<%# DateTime.Today %>" OnSelectionChanged="DatePicker_SelectionChanged" >
            <OtherMonthDayStyle ForeColor="#b0b0b0" />
            <DayStyle CssClass="myCalendarDay" ForeColor="#2d3338" />
            <DayHeaderStyle CssClass="myCalendarDayHeader" ForeColor="#2d3338" />
            <SelectedDayStyle Font-Bold="True" Font-Size="12px" CssClass="myCalendarSelector" />
            <TodayDayStyle CssClass="myCalendarToday" />
            <SelectorStyle CssClass="myCalendarSelector" />
            <NextPrevStyle CssClass="myCalendarNextPrev" />
            <TitleStyle CssClass="myCalendarTitle" />
        </asp:Calendar>
    </div>
    <div style="overflow-x:auto;width:1080px">
        <asp:GridView ID="Schedule" runat="server" OnRowDataBound="Schedule_RowDataBound" Font-Bold="True" PageSize="700" OnRowUpdating="Schedule_RowUpdating" OnRowEditing="Schedule_RowEditing" OnRowCancelingEdit="Schedule_RowCancelingEdit">
            <Columns>
                <asp:TemplateField>  
                    <ItemTemplate>  
                        <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" />  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>  
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>  
                    </EditItemTemplate>  
                </asp:TemplateField>   
            </Columns>
    </asp:GridView>
        
    <asp:Button ID="Button1" runat="server" Text="Parse Excel Schedule" OnClick="Button1_Click" />
    </div>
</asp:Content>
