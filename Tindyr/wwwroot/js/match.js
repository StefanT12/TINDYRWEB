"use strict";
//start connection with hub
var connection = new signalR.HubConnectionBuilder().withUrl("/livematch").build();
connection.start().then(function () {
    //document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});
/////SEND TO OTHER USERS
//LIKE
document.getElementById("likeButton").addEventListener("click", function (event) { // get some button
    var fromUser = '';
    var toUser = '';
    //this invokes the c# method of our hub with the parameters needed to send the message to the other user
    connection.invoke("Like", fromUser, toUser)
        .then(function (result) {
            if (result == "Liked") {
                //put toUser in WhoYouLiked
            }
            else if (result == "Matched") {
                //put toUser in Matches
            }
            else {
                //failed or liked already
            }
        }, function (err) {
            return console.error(err.toString());//error handling
        });
    event.preventDefault();
});
//UNLIKE
document.getElementById("likeButton").addEventListener("click", function (event) { // get some button
    var fromUser = '';
    var toUser = '';
    //this invokes the c# method of our hub with the parameters needed to send the message to the other user
    connection.invoke("Unlike", fromUser, toUser)
        .then(function (result) {
            if (result == "Unliked") {
                //unlike the bastard, take him out from Matches, WhoYouLiked or WhoLikesYou
            }
            else {
                //failed or unliked already
            }
        }, function (err) {
            return console.error(err.toString());//error handling
        });
    event.preventDefault();
});
////RECEIVE FROM OTHER USERS
//Receive like
connection.on("LikeReceived", function (from) {
    //put user on WhoLikesYou list
});

connection.on("Match", function (from) {
    //put user on Matches list
    //take user out from WhoLikesYou or from WhoYouLiked
});

connection.on("UnlikeReceived", function (from) {
    //take user out from WhoLikesYou or from WhoYouLiked or from Matches
});