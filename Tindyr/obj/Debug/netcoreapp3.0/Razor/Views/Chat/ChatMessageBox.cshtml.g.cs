#pragma checksum "C:\TINDYRWEB\Tindyr\Views\Chat\ChatMessageBox.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "805b0d9edde4274ecaf45989f1eb74b54bb5a225"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Chat_ChatMessageBox), @"mvc.1.0.view", @"/Views/Chat/ChatMessageBox.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\TINDYRWEB\Tindyr\Views\_ViewImports.cshtml"
using Tindyr;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\TINDYRWEB\Tindyr\Views\_ViewImports.cshtml"
using Tindyr.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"805b0d9edde4274ecaf45989f1eb74b54bb5a225", @"/Views/Chat/ChatMessageBox.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ba0c2961087dd2a5e922c288a90429803c4a74c", @"/Views/_ViewImports.cshtml")]
    public class Views_Chat_ChatMessageBox : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\TINDYRWEB\Tindyr\Views\Chat\ChatMessageBox.cshtml"
  
    ViewData["Title"] = "ChatMessageBox";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"   //chat zone
    <div id=""chat_zone"">
        //open and close chat burger. have some kind of notification if you have messages
        <div id=""mySidebar"" class=""sidebar width0px"">
            <a href=""javascript:void(0)"" class=""closebtn"" onclick=""closeNav()""><img id=""secondaryMessangerButton"" class=""messangerIcon"" src=""https://cdn2.iconfinder.com/data/icons/social-media-2285/512/1_Messenger_colored_svg-512.png"" alt=""Messanger"" /></a>
            <a href=""#""><img class=""messangerIcon"" src=""https://img.favpng.com/11/4/14/computer-icons-user-symbol-light-png-favpng-SpjCsM9Bzipc7zF1JQG3gKjt9.jpg"" alt=""User2"" /> User2</a>
            <a href=""#""><img class=""messangerIcon"" src=""https://img.favpng.com/11/4/14/computer-icons-user-symbol-light-png-favpng-SpjCsM9Bzipc7zF1JQG3gKjt9.jpg"" alt=""User2"" /> User3</a>
            <a href=""#""><img class=""messangerIcon"" src=""https://img.favpng.com/11/4/14/computer-icons-user-symbol-light-png-favpng-SpjCsM9Bzipc7zF1JQG3gKjt9.jpg"" alt=""User2"" /> User4</a>
            <");
            WriteLiteral(@"a href=""#""><img class=""messangerIcon"" src=""https://img.favpng.com/11/4/14/computer-icons-user-symbol-light-png-favpng-SpjCsM9Bzipc7zF1JQG3gKjt9.jpg"" alt=""User2"" /> User5</a>
        </div>
        
        <div id=""main"">
            <button class=""openbtn"" onclick=""openNav()""><img id=""mainMessangerButton"" class=""messangerIcon"" src=""https://cdn2.iconfinder.com/data/icons/social-media-2285/512/1_Messenger_colored_svg-512.png"" alt=""Messanger"" /></button>
        </div>

        //list of users, reverse dropdown
        //for 1 to 6 show
        <div id=""chat-users"">
            //show name and picture
            // show new messages
            // open message box
        </div>
        // end for 1 to 6
    </div>

<script>
function openNav() {
document.getElementById(""mySidebar"").classList.add('width200px');
document.getElementById(""mySidebar"").classList.remove('width0px');
document.getElementById(""main"").classList.add('d-none');
  document.getElementById(""secondaryMessangerButton"").sty");
            WriteLiteral(@"le.display = ""block"";
  document.getElementById(""mainMessangerButton"").classList.add('d-none');
}

/* Set the width of the sidebar to 0 and the left margin of the page content to 0 */
function closeNav() {
document.getElementById(""mySidebar"").classList.add('width0px');
document.getElementById(""mySidebar"").classList.remove('width200px');
document.getElementById(""main"").classList.remove('d-none');
  document.getElementById(""secondaryMessangerButton"").style.display = ""none"";
  document.getElementById(""mainMessangerButton"").classList.remove('d-none');
}
</script>
<style>
    button img{
    }
.messangerIcon{      
    width: 45px;
    height: 45px;
}

.sidebar {
  position: fixed; /* Stay in place */
  z-index: 1; /* Stay on top */
  right: 0;
  background-color: #111; /* Black*/
  overflow-x: hidden; /* Disable horizontal scroll */
  padding-top: 60px; /* Place content 60px from the top */
  transition: 0.5s; /* 0.5 second transition effect to slide in the sidebar */
}
.width200px{
            WriteLiteral(@"
    width: 200px;
}
.width0px{
    width: 0px;
}
/* The sidebar links */
.sidebar a {
  padding: 8px 8px 8px 32px;
  text-decoration: none;
  font-size: 25px;
  color: #818181;
  display: block;
  transition: 0.3s;
}

/* When you mouse over the navigation links, change their color */
.sidebar a:hover {
  color: #f1f1f1;
}

/* Position and style the close button (top right corner) */
.sidebar .closebtn {
  position: absolute;
  top: 0;
  width:0;
  right: 25px;
  font-size: 36px;
  margin-left: 50px;
}

/* The button used to open the sidebar */
.openbtn {
  font-size: 20px;
  cursor: pointer;
  background-color: transparent;
  color: white;
  border: none;
}

.openbtn:hover {
}

/* Style page content - use this if you want to push the page content to the right when you open the side navigation */
#main {
    position: fixed; /* Stay in place */
    z-index: 1; /* Stay on top */
    right: 0;
}

/* On smaller screens, where height is less than 450px, change the ");
            WriteLiteral("style of the sidenav (less padding and a smaller font size) */\r\n\r\n</style>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591