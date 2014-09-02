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
		if (items.length > 3) {
		    post += "<i><small>" + FormatTime(items[3]) + "</small></i><br>";
		}
		post += "<i>" + items[1].replace(/\*/g, '') + "</i><br>";
		post += items[2] + "</li>";
		$('#stream').append(post);
		var sound;
		var extension;
		if ((new Audio()).canPlayType("audio/ogg; codecs=vorbis")) {
		    extension = "ogg";
		} else if ((new Audio()).canPlayType("audio/mp3; codecs=vorbis")) {
		    extension = "mp3";
		}
		if (extension) {
			sound = new Audio("/Content/chime." + extension);
			sound.play();
		}
	});
	$('html, body').scrollTop($(document).height());
}
function FormatTime(code) {
	var year = new Date().getFullYear();
	var month = code.substring(0, 2);
	var day = code.substring(2, 4);
	var hour = code.substring(4, 6);
	var minute = code.substring(6, 8);
	var second = code.substring(8, 10);
	if ((data === "") || (data === null)) {
		var second = Math.round(new Date().getTime() / 1000 % 60);
	}
	return "" + year + "/" + month + "/" + day + " " + hour + ":" + minute + ":" + second;
}
$(document).ready(function() {
	setInterval(function() {
		UpdateMessages();
	}, 5000);
});