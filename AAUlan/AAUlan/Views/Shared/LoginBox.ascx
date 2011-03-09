<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<AAUlan.Models.User>" %>

<% AAUlan.Models.DatabaseReposity productRepo = new AAUlan.Models.DatabaseReposity();  %>
    <%if (!Context.User.Identity.IsAuthenticated)
    { %>
            <%: Html.ActionLink("Login", "../Login/Login" ,new { ReturnUrl = Request.QueryString["ReturnUrl"] }) %>
    <%} %>

    <%else
        { %>
            <%using (Html.BeginForm("Logout", "Login"))
            { %>
            <p><%: Html.Label("Username: ")%></p>
            <p><%: Html.Label(Context.User.Identity.Name)%></p>
            <br />
            <p><%: Html.Label("Role: ")%></p>
            <p><%: Html.Label(productRepo.GetUserRoleFromUsername(Context.User.Identity.Name))%></p>
            <input type="submit" name="submitbutton1" id="Submit1" value="Logout" />
            <%} %>
        <%} %>