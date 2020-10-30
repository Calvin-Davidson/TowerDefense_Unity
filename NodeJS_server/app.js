const WebSocket = require('ws');

var ws = new WebSocket("ws://localhost:9998/service");
ws.onopen = function () {
    ws.send("Hello World"); // I WANT TO SEND THIS MESSAGE TO THE SERVER!!!!!!!!
};

ws.onmessage = function (evt) {
    var received_msg = evt.data;
    alert("Message is received...");
};
ws.onclose = function () {
    // websocket is closed.
    alert("Connection is closed...");
};