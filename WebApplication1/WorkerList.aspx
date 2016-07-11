<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WorkerList.aspx.cs" Inherits="Schedule.WorkerList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            <hgroup>
                <h2><%: Page.Title %>
            </h2>
            </hgroup>
            
            <div id="Workerlist2" style="text-align: center">
            <asp:ListView ID="shiftWorkerList" ItemType="Schedule.Models.ShiftWorker" runat="server" SelectMethod="GetWorkers">
                
                <ItemTemplate>
                        <td runat="server">
                            <table>
                                <tr>
                                    <td>
                                        <a href="/WorkerDetails.aspx?id=<%#:Item.worker.workerName  %>"> <%#:Item.shift.shiftId  %></a>
                                    </td>
                                </tr>
                                <td>&nbsp;</td>
                            </table>
                        </td>
                </ItemTemplate>
            </asp:ListView>
        </div>
            
        </div>
    </section>
</asp:Content>
