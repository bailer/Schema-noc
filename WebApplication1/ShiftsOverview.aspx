<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShiftsOverview.aspx.cs" Inherits="Schedule.ShiftsOverview" %>
<asp:Content ID="ShiftOverview" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DropDownList ID="DropDownSpan" runat="server">
        <asp:ListItem>Day</asp:ListItem>
        <asp:ListItem Selected="True">Week</asp:ListItem>
        <asp:ListItem>Month</asp:ListItem>
    </asp:DropDownList>
    <div class="calendarWrapper">
        <asp:Calendar ID="DatePicker" runat="server" DayNameFormat="FirstLetter" Font-Names="Tahoma" Font-Size="11px" 
            NextMonthText="." PrevMonthText="." SelectMonthText="»" SelectWeekText="›" CssClass="myCalendar" OnSelectionChanged="Calendar1_SelectionChanged" 
            OnDayRender="Calendar1_DayRender" CellPadding="0">
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
    <asp:GridView ID="Schedule" runat="server">
    </asp:GridView>
</asp:Content>
