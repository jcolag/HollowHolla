﻿function UpdateMessages() {
	var url = "/Home/Next";
    var inner = "";
	$.get(url, function(data) {
		if ((data === "") || (data === null)) {
			return;
		}
		var items = data.split('#');
		var post = "<li class='hh-post'>";
		post += "<h2>" + items[0] + "</h2>";
		if (items.length > 3) {
		    post += "<i><small>" + FormatTime(items[3]) + "</small></i><br>";
		}
		post += "<i>" + items[1].replace(/\*/g, '') + "</i><br>";
		post += items[2] + "</li>";
		$('#stream').append(post);
	});
}
function FormatTime(code) {
	var year = new Date().getFullYear();
	var month = code.substring(0, 2);
	var day = code.substring(2, 4);
	var hour = code.substring(4, 6);
	var minute = code.substring(6, 8);
	return "" + year + "/" + month + "/" + day + " " + hour + ":" + minute;
}
$(document).ready(function() {
	setInterval(function() {
		UpdateMessages();
	}, 5000);
});