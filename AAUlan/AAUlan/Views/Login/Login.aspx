<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AAUlan.Models.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Login</h2>

    <%using (Html.BeginForm("Login", "Login", new { ReturnUrl = Request.QueryString["ReturnUrl"] }))
      { %>
      <%= Html.ValidationSummary("Login was unsuccessful. Please correct the errors and try again.")%>
      <p><%: Html.Label("Username:")%></p>
      <%: Html.TextBoxFor(model => Model.Username)%>
      <%: Html.ValidationMessage("Username", "*")%>
      <br />
      <p><%: Html.Label("Password: ")%></p>
      <%: Html.PasswordFor(model => Model.Password)%>   
      <%: Html.ValidationMessage("Password", "*")%>                 
      <input type="submit" name="SubmitButton1" id="submit" value="Login" />
    <%} %>
    <%: Html.ActionLink("Create User", "Create", "Login")%>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
