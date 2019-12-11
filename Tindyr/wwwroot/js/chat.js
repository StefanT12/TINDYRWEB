//get connection
var connection = new signalR.HubConnectionBuilder().withUrl("/appchat").build();

////use this to retrieve conversations - they are sorted already by message timestamp
//connection.invoke('GetConversations', username).done(function (conversations) {
//    //iterate and display conversations and messages from within them
//});

//use this to get messages live from other users
connection.on("MessageReceived", function (user, message) {
    //fill it with your code
    var li = document.createElement("li");
    li.textContent = user + " says : " +message;
    document.getElementById("messagesList").appendChild(li);
});

//use this to render sent messages 
connection.on("MessageSent", function (message) {
    //fill it with your code
    var li = document.createElement("li");
    li.textContent = "You said : " + message;
    document.getElementById("messagesList").appendChild(li);
});

connection.start().then(function () {
    //document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

//use this to send messages

document.getElementById("sendButton").addEventListener("click", function (event) { // get some button
    var sender = document.getElementById("userValue").innerHTML;//get username of user sending;
    var receiver = document.getElementById("userInput").value;//get username of user your're supposed to send the message to
    var message = document.getElementById("messageInput").value;//get the message you're supposed to send
    //this invokes the c# method of our hub with the parameters needed to send the message to the other user
    connection.invoke("SendMessage", receiver, sender, message).catch(function (err) {
        return console.error(err.toString());
    });
    document.getElementById("messageInput").value = "";
    event.preventDefault();
});