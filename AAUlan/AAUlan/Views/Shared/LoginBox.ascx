﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<AAUlan.Models.User>" %>

<% AAUlan.Models.DatabaseReposity productRepo = new AAUlan.Models.DatabaseReposity();  %>
    <%if (!Context.User.Identity.IsAuthenticated)
    { %>
            <%: Html.ActionLink("[ Login ]", "../Login/Login" ,new { ReturnUrl = Request.QueryString["ReturnUrl"] }) %>
    <%} %>

    <%else
        { %>
            <%using (Html.BeginForm("Logout", "Login"))
            { %>
            <div class="loginbox">
                <div>
                <%: Html.Label("Username: ")%>
                <%: Html.Label(Context.User.Identity.Name)%>
                </div>
                <div>
                <%: Html.Label("Role: ")%>
                <%: Html.Label(productRepo.GetUserRoleFromUsername(Context.User.Identity.Name))%>
                </div>
                <div>
                <input type="submit" name="submitbutton1" id="Submit1" value="Logout" />
                </div>
            </div>
            <%} %>
        <%} %>