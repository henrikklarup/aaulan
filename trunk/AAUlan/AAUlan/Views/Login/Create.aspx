<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AAUlan.Models.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>
        <% using (Html.BeginForm())
       { %>

       <p><%: Html.Label("Username: ") %> </p>
       <%: Html.TextBoxFor(model => Model.Username) %>
       <br />
       <p><%: Html.Label("Password: ") %></p>
       <%: Html.TextBoxFor(model => Model.Password) %>
       <br />
       <input id="submitButton1" name="Submitbutton1" type="submit" />
    <%} %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
