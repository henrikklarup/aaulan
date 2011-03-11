<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AAUlan.ViewModels.OrderViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>GetTotalOrder</h2>

    <table class="userManagement">
        <tr>
            <th>
                Name
            </th>
            <th>
                Note
            </th>
            <th>
                Number
            </th>
            <th>
                FOOD ID!
            </th>
            <th>
                Paid
            </th>
            <th>
                Quantity
            </th>
        </tr>

    <% for (int i = 0; i < Model.Orders.Count; i++)
       { %>
        <tr>
            <td>
                <%: Model.Orders[i].Name%>
                <%: Html.HiddenFor(model => Model.Orders[i].ID) %>
            </td>
            <td>
                <%: Model.Orders[i].Note%>
            </td>
            <td>
                <%: Model.Orders[i].Number%>
            </td>
            <td>
                <%: Model.Orders[i].EVENTID%>
            </td>
            <td>
                <%: Html.CheckBoxFor(model => Model.Orders[i].Paid)%>
            </td>
            <td>
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
