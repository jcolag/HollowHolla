<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage" MasterPageFile="~/Views/Shared/HollowHolla.master" %>
<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="server">
	<title>Home Feed - Hollow Holla!</title>
	<script type="text/javascript" src="/Content/js/index.js"></script>
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" ID="MainContentContent" runat="server">
	<ul><%= ViewData["Message"] %></ul>
	<ul id="stream"></ul>
</asp:Content>