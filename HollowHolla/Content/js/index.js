function UpdateMessages() {
    var url = "/Home/Next";
    var inner = "";
    $.get(url, function(data) {
        if ((data === "") || (data === null)) {
            return;
        }
        var post = "<li class='hh-post'>" + data.replace(/#/g, "<br>") + "</li>";
		$('#stream').append(post);
    });
}
$(document).ready(function() {
	setInterval(function() {
		UpdateMessages();
	}, 5000);
});