<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<AAUlan.Models.LAN>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Lans</h2>

    <table class="userManagement">
        <tr>
            <th>
                ID
            </th>
            <th>
                StartTime
            </th>
            <th>
                EndTime
            </th>
            <th>
                Description
            </th>
            <th>
                Location
            </th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: item.ID %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.StartTime) %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.EndTime) %>
            </td>
            <td>
                <%: item.Description %>
            </td>
            <td>
                <%: item.Location %>
            </td>
            <td>
                <%if (item.Event == null)
                  { %>
                <%: Html.ActionLink("Delete", "DeleteLan", "Admin", new { id = item.ID }, null)%>
                <%} %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create Lan", "CreateLan", "Admin")%>
    </p>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Title" runat="server">
</asp:Content>

