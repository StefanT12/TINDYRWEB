//get connection
var connection = new signalR.HubConnectionBuilder().withUrl("/appchat").build();

//use this to retrieve conversations - they are sorted already by message timestamp
connection.invoke('GetConversations', username).done(function (conversations) {
    //iterate and display conversations and messages from within them
});

//use this to get messages live from other users
connection.on("MessageReceived", function (user, message) {
    //fill it with your code
});

//use this to render sent messages 
connection.on("MessageSent", function (message) {
    //fill it with your code
});

//use this to send messages

document.getElementById("sendButton").addEventListener("click", function (event) { // get some button
    var sender = '';//get username of user sending;
    var receiver = '';//get username of user your're supposed to send the message to
    var message = '';//get the message you're supposed to send
    //this invokes the c# method of our hub with the parameters needed to send the message to the other user
    connection.invoke("SendMessage", message, sender, receiver).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});