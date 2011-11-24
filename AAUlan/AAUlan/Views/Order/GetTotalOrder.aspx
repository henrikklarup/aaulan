<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AAUlan.ViewModels.OrderViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>GetTotalOrder</h2>

    <table class="userManagement">
        <tr>
            <th>
                Number
            </th>
            <th>
                Note
            </th>
            <th>
                FOOD ID!
            </th>
            <th>
                Quantity
            </th>
        </tr>

    <% for (int i = 0; i < Model.Orders.Count; i++)
       { %>
        <tr>
            <td align=center>
                <%: Model.Orders[i].Number%>
            </td>
            <td align=center>
                <%: Model.Orders[i].Note%>
            </td>
            <td align=center>
                <%: Model.Orders[i].EVENTID%>
            </td>
            <td align=center>
                <%: Model.Orders[i].quantity %>
            </td>
        </tr>
    <% } %>

    </table>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
