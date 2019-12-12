// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//HEADER

/* Toggle between adding and removing the "responsive" class to nav-container when the user clicks on the icon */
function myFunction() {
    const x = document.getElementById("nav");
    if (x.className === "nav-container") {
        x.className += " responsive";
    } else {
        x.className = "nav-container";
    }
}