function UpdateMessages() {
	var url = "/Home/Next";
    var inner = "";
	$.get(url, function(data) {
		if ((data === "") || (data === null)) {
			return;
		}
		var items = data.split('#');
		var post = "<li class='hh-post'>";
		post += "<h2>" + items[0] + "</h2>";
		post += "<i>" + items[1].replace(/\*/g, '') + "</i><br>";
		post += items[2] + "</li>";
		$('#stream').append(post);
	});
}
$(document).ready(function() {
	setInterval(function() {
		UpdateMessages();
	}, 5000);
});