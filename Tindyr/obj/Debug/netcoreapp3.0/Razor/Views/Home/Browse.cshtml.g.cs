#pragma checksum "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\Home\Browse.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d209e4bcfc2ad92889bed281e9b3c4d56db27584"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Browse), @"mvc.1.0.view", @"/Views/Home/Browse.cshtml")]
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
#line 1 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\_ViewImports.cshtml"
using Tindyr;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\_ViewImports.cshtml"
using Tindyr.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d209e4bcfc2ad92889bed281e9b3c4d56db27584", @"/Views/Home/Browse.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b534ad202c5fde8e056124080668e533fedad87", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Browse : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tindyr.Models.Browse.BrowseAnimalsModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/js/signalr/dist/browser/signalr.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/match.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\Home\Browse.cshtml"
  
    ViewData["Title"] = "Browse";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\Home\Browse.cshtml"
 if (Model.UserIsValidated)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"browseflex\">\r\n\r\n");
#nullable restore
#line 11 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\Home\Browse.cshtml"
         foreach (var animal in Model.Animals)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <section");
            BeginWriteAttribute("id", " id=", 278, "", 297, 1);
#nullable restore
#line 13 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\Home\Browse.cshtml"
WriteAttributeValue("", 282, animal.ForUser, 282, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <img");
            BeginWriteAttribute("src", " src=", 316, "", 383, 1);
#nullable restore
#line 14 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\Home\Browse.cshtml"
WriteAttributeValue("", 321, Url.Content("~/userimages/"+animal.ForUser +"front" + ".jpg"), 321, 62, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Anim_Pict\" />\r\n            <p>");
#nullable restore
#line 15 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\Home\Browse.cshtml"
          Write(animal.AnimalName);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 15 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\Home\Browse.cshtml"
                              Write(animal.AnimalBreed);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <input type=\"button\" class=\"premium-button\"");
            BeginWriteAttribute("onclick", " onclick=\"", 519, "\"", 563, 3);
            WriteAttributeValue("", 529, "LikeThisUserASP(\'", 529, 17, true);
#nullable restore
#line 16 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\Home\Browse.cshtml"
WriteAttributeValue("", 546, animal.ForUser, 546, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 561, "\')", 561, 2, true);
            EndWriteAttribute();
            WriteLiteral(" value=\"Like\">*\r\n");
            WriteLiteral("        </section>\r\n");
#nullable restore
#line 19 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\Home\Browse.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </div>\r\n");
#nullable restore
#line 23 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\Home\Browse.cshtml"
}
else
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\Home\Browse.cshtml"
Write(await Html.PartialAsync("_UrgeEditProfile"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\Home\Browse.cshtml"
                                                ;
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d209e4bcfc2ad92889bed281e9b3c4d56db275847296", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d209e4bcfc2ad92889bed281e9b3c4d56db275848335", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n        function GoEdit()\r\n        {\r\n            window.location.href = \"");
#nullable restore
#line 37 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\Home\Browse.cshtml"
                               Write(Url.Action("ProfileEdit", "ProfileEdit"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\";\r\n        }\r\n      \r\n        function LikeThisUserASP(username)\r\n        {\r\n            window.location.href = (\"");
#nullable restore
#line 42 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\Home\Browse.cshtml"
                                Write(Url.Action("Browse", "Home", new { username = "usernamevalue" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""").replace(""usernamevalue"", username);
        }

        function LikeThisUser(fromUser, toUser) {
            console.log(fromUser + "" to "" + toUser);
            //this invokes the c# method of our hub with the parameters needed to send the message to the other user
            connection.invoke(""Like"", fromUser, toUser)
                .then(function (result) {
                    console.log(result)
                    if (result == ""Liked"") {
                        //put toUser in WhoYouLiked and remove him from browse
                        RemoveElement(toUser);
                    }
                    else if (result == ""Matched"") {
                        //put toUser in Matches
                        RemoveElement(toUser);
                    }
                    else {
                        //failed or liked already
                    }
                    console.log(result);
                }, function (err) {
                    return console.error(err.toString())");
                WriteLiteral(";//error handling\r\n                });\r\n        }\r\n\r\n        function RemoveElement(id) {\r\n            console.log(id);\r\n            var elem = document.getElementById(id);\r\n            elem.parentNode.removeChild(elem);\r\n        }\r\n    </script>\r\n");
            }
            );
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tindyr.Models.Browse.BrowseAnimalsModel> Html { get; private set; }
    }
}
#pragma warning restore 1591