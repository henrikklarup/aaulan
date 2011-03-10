﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AAUlan.ViewModels.EventViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <%foreach (var i in Model.events)
      {%>
    <fieldset>
        <legend><%:i.Name %> Starts in<script type="text/javascript" language="javascript">javascript_countdown.init(<%: i.timeToStart() %>);</script></legend>
        <%: "Start Time: " + i.StartTime.ToString() %>
        <br />
        <%: "End Time: " + i.EndTime.ToString() %>
        <br />
        <%: "Game: " + i.Games.Description.ToString() %>
        <br />
        <%: "Description: " + i.Description.ToString() %>
        <br />
        <%: "Rules: " + i.Rules.ToString() %>
    </fieldset>
    <%} %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
