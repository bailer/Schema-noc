<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WorkerList.aspx.cs" Inherits="Schedule.WorkerList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            <hgroup>
                <h2><%: Page.Title %>
            </h2>
            </hgroup>
            <div id="Workerlist2" style="text-align: center">
            <asp:ListView ID="workerList" ItemType="Schedule.Models.Worker" runat="server" SelectMethod="GetWorkers" DataKeyNames="workerName">
                <EmptyDataTemplate>
                    <Table>
                        <tr>
                            <td>No data was returned</td>
                        </tr>
                    </Table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td />
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                        <td runat="server">
                            <table>
                                <tr>
                                    <td>
                                        <a href="/WorkerDetails.aspx?id=<%#: Item.workerNr %>"> <%#: Item.workerName %></a>
                                    </td>
                                </tr>
                                <td>&nbsp;</td>
                            </table>
                        </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table style="width:100%">
                        <tbody>
                            <tr>
                                <td>
                                    <table id="groupPlaceholderContainer" runat="server" style="width:100%">
                                        <tr id="groupPlaceholder"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>

                                </td>
                            </tr>
                            <tr>

                            </tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
            
        </div>
    </section>
</asp:Content>
