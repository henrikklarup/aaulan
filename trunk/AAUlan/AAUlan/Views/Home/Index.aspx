<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AAUlan.ViewModels.EventViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <%if (Model.events == null)
      { %>
      <h1>Der er ingen data at vise</h1>
      <%}
      else
      {
          foreach (var i in Model.events)
          {%>
        <fieldset>
            <legend><%:i.Name%> </legend>
            <p><strong>Start Time: </strong></p><%: i.StartTime.ToString()%>
            <br />
            <p><strong>End time:</strong></p><%: i.EndTime.ToString()%>
            <br />
            <p><strong>Game: </strong></p><%: i.Games.Description.ToString()%>
            <br />
            <p><strong>Description: </strong></p><%: i.Description.ToString()%>
            <br />
            <p><strong>Rules: </strong></p><%: i.Rules.ToString()%>
        </fieldset>
        <%}
      } %>
    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
