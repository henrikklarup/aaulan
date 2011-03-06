<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AAUlan.ViewModels.OrderViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>
    <%using (Html.BeginForm("Index", "Order"))
      { %>
    <p>
    <%: Html.Label("Navn: ") %>
    <%: Html.TextBoxFor(model => Model.pizza.Name)%>
    <br />
    <%: Html.Label("Note: ") %>
    <%: Html.TextBoxFor(model => Model.pizza.Note)%>
    <br />
    <%: Html.Label("Pizza nr: ") %>
    <%: Html.TextBoxFor(model => Model.pizza.Number)%>
    <br />
    <input value="Order pizza" type="submit" />
    </p>
    <%} %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
