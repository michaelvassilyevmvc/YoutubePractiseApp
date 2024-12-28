//const { signalR } = require("./signalr/dist/browser/signalr");

document.getElementById("messages").style.display = "none";
var connection = new signalR.HubConnectionBuilder()
    .withUrl("/chat")
    .build();

connection.start().catch(e => console.error(e.toString()));

document.getElementById("joinButton")
    .addEventListener("click", e => {
        const chatName = document.getElementById("inputChat").value;

        connection.invoke("JoinToChat", chatName).catch(e => console.errro(e.toString()));
        document.getElementById("join").style.display = "none";
        document.getElementById("messages").style.display = "block";
        e.preventDefault();
    });

document.getElementById("sendButton")
    .addEventListener("click", e => {
        const chatName = document.getElementById("inputChat").value;
        const user = document.getElementById("inputUser").value;
        const message = document.getElementById("inputMessage").value;

        connection.invoke("SendMessage", chatName, user, message).catch(e => console.errro(e.toString()));
        e.preventDefault();
    });

connection.on("ReceiveMessage", message => {
    var el = document.createElement("li");
    document.getElementById("messageList").appendChild(el);
    el.textContent = message;
})