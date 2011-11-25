<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AAUlan.ViewModels.OrderViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Order Pizza</h2>
    <fieldset>
    <legend>Order Food</legend>
        <%using (Html.BeginForm("Index", "Order"))
          { %>
        <p><%: Html.Label("Name: ") %></p>
        <%: Html.TextBoxFor(model => Model.mad.Name)%>
        <br />
        <p><%: Html.Label("Note: ") %></p>
        <%: Html.TextBoxFor(model => Model.mad.Note)%>
        <br />
        <p><%: Html.Label("Number: ") %></p>
        <%: Html.TextBoxFor(model => Model.mad.Number)%>
        <br />
        <input value="Order pizza" type="submit" />
    </fieldset>
    <fieldset>
    <legend>Menu</legend>
    <a href="../../Content/pizza1.png" target="_blank"><img alt="Pizza Manu" src="../../Content/pizza1.png" border="0" width="800" /></a><br />
    <a href="../../Content/pizza2.png" target="_blank"><img alt="Pizza Menu" src="../../Content/pizza2.png" border="0" width="800" /></a>
    </fieldset>
    <%} %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
