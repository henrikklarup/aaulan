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
            <p>
            <%: Html.Label("Username: ")%>
            <%: Html.Label(Context.User.Identity.Name)%>
            <br />
            <%: Html.Label("Role: ")%>
            <%: Html.Label(productRepo.GetUserRoleFromUsername(Context.User.Identity.Name))%>
            <input type="submit" name="submitbutton1" id="Submit1" value="Logout" />
            </p>
            <%} %>
        <%} %>

