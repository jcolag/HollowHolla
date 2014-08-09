<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage" MasterPageFile="~/Views/Shared/HollowHolla.master" %>
<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="server">
	<title>Home Feed - Hollow Holla!</title>
	<script type="text/javascript">
	    function UpdateMessages() {
	        var post = "<li class='hh-post'>";
	        post += "Next item"
	        post += "</li>";
			$('#stream').append(post);
		}
		$(document).ready(function() {
			setInterval(function() {
				UpdateMessages();
			}, 5000);
		});
	</script>
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" ID="MainContentContent" runat="server">
	<ul id="stream"></ul>
</asp:Content>