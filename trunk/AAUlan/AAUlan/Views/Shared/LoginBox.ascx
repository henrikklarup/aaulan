<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<AAUlan.Models.User>" %>

<% AAUlan.Models.DatabaseReposity productRepo = new AAUlan.Models.DatabaseReposity();  %>
<fieldset>
    <%if (!Context.User.Identity.IsAuthenticated)
    { %>
    <%using (Html.BeginForm("Login", "Login", new { ReturnUrl = Request.QueryString["ReturnUrl"] }))
      { %>
    <%= Html.ValidationSummary("Login was unsuccessful. Please correct the errors and try again.")%>
      <%: Html.Label("Username:")%>
      <%: Html.TextBoxFor(model => Model.Username)%>
      <%: Html.ValidationMessage("Username", "*")%>
      <br />
      <%: Html.Label("Password: ")%>
      <%: Html.PasswordFor(model => Model.Password)%>   
      <%: Html.ValidationMessage("Password", "*")%>                 
      <input type="submit" name="SubmitButton1" id="submit" value="Login" />
      <%} %>
    <%} %>

    <%else
        { %>
            <%using (Html.BeginForm("Logout", "Login"))
            { %>
            <%: Html.Label("Username: ")%>
            <%: Html.Label(Context.User.Identity.Name)%>
            <br />
            <%: Html.Label("Role: ")%>
            <%: Html.Label(productRepo.GetUserRoleFromUsername(Context.User.Identity.Name))%>
            <input type="submit" name="submitbutton1" id="Submit1" value="Logout" />
            <%} %>
        <%} %>
</fieldset>

