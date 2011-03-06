<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AAUlan.ViewModels.UserViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>RoleAssignment</h2>

        <%using (Html.BeginForm("SearchUsername","User"))
      { %>
        <%: Html.Label("Search username: ") %>
        <%: Html.TextBox("Username")%>
        <input type="submit" name="submitbox1" value="Search" />
    <%} %>

    <form id="form1" runat="server">
    <br />
        <table class="userManagement">
        <tr>
            <th>
                Username
            </th>
            <th>
                Role
            </th>
            <th></th>
        </tr>
        <% foreach (var user in Model.users)
           { %>
           <%using (Html.BeginForm("PromoteOrDemote","User")) { %>
           <tr>
            <td>
                <p><%: user.Username %></p>
                <%: Html.Hidden("Username",user.Username) %>
            </td>
            <td>
                <p><%: user.Role.Trim() %></p>
            </td>

            <td>
                <%if (user.Role.Trim() != "Administrator")
                  { %>
                <input value="Promote" type="submit" name="submitButton" />
                <%} %>
                <%if (user.Role.Trim() != "Bruger")
                  {%>
                <input value="Demote" type="submit" name="submitButton" />
                <%} %>
            </td>
            </tr>
            <%} %>
        <% } %>
    </table>

    </form>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
