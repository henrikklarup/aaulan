<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AAUlan.ViewModels.LanViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>CreateLan</h2>
    <% using(Html.BeginForm("CreateLan","Admin")) { %>

    <%: Html.Label(@"Start Time (ie 1999-09-01 21:34 PM): ") %>
    <br />
    <%: Html.TextBoxFor(model => Model.lan.StartTime) %>
    <br />
    <%: Html.Label("End Time: ") %>
    <br />
    <%: Html.TextBoxFor(model => Model.lan.EndTime) %>
    <br />
    <%: Html.Label("Description: ") %>
    <br />
    <%: Html.TextAreaFor(model => Model.lan.Description) %>
    <br />
    <%: Html.Label("Location: ") %>
    <br />
    <%: Html.TextBoxFor(model => Model.lan.Location) %>
    <br />
    <br />

    <input type="submit" value="Create Lan" />

    <%} %>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
