﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AAUlan.ViewModels.OrderViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>
    <%using (Html.BeginForm("Index", "Order"))
      { %>
    <p><%: Html.Label("Navn: ") %></p>
    <%: Html.TextBoxFor(model => Model.mad.Name)%>
    <br />
    <p><%: Html.Label("Note: ") %></p>
    <%: Html.TextBoxFor(model => Model.mad.Note)%>
    <br />
    <p><%: Html.Label("nr: ") %></p>
    <%: Html.TextBoxFor(model => Model.mad.Number)%>
    <br />
    <input value="Order pizza" type="submit" />
    <%} %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
