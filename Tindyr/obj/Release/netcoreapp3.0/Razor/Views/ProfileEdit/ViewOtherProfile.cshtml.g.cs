#pragma checksum "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\ProfileEdit\ViewOtherProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a873cc25c90553fc98932898265af99ad278268a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProfileEdit_ViewOtherProfile), @"mvc.1.0.view", @"/Views/ProfileEdit/ViewOtherProfile.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a873cc25c90553fc98932898265af99ad278268a", @"/Views/ProfileEdit/ViewOtherProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b534ad202c5fde8e056124080668e533fedad87", @"/Views/_ViewImports.cshtml")]
    public class Views_ProfileEdit_ViewOtherProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tindyr.Models.ProfileEdit.AllUserInformationModel>
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\ProfileEdit\ViewOtherProfile.cshtml"
  
    ViewData["Title"] = "ViewOtherProfile";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a873cc25c90553fc98932898265af99ad278268a4211", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a873cc25c90553fc98932898265af99ad278268a5250", async() => {
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
            WriteLiteral("\r\n\r\n<section class=\"content\">\r\n    <br />\r\n    <br />\r\n    <h1 class=\"view-h1\">");
#nullable restore
#line 14 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\ProfileEdit\ViewOtherProfile.cshtml"
                   Write(Model.AnimalModel.AnimalName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\'s Profile</h1>\r\n    <article class=\"view\">\r\n        <section class=\"gallery\">\r\n            <div class=\"image\">\r\n                <img");
            BeginWriteAttribute("src", " src=", 505, "", 578, 1);
#nullable restore
#line 18 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\ProfileEdit\ViewOtherProfile.cshtml"
WriteAttributeValue("", 510, Url.Content("~/userimages/"+@Model.AnimalModel.ForUser+"front.jpg"), 510, 68, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"placeholderpic\">\r\n            </div>\r\n\r\n\r\n");
#nullable restore
#line 22 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\ProfileEdit\ViewOtherProfile.cshtml"
             for (int i = 1; i < 4; i++)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"image\">\r\n                    <img");
            BeginWriteAttribute("src", " src=", 744, "", 831, 1);
#nullable restore
#line 25 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\ProfileEdit\ViewOtherProfile.cshtml"
WriteAttributeValue("", 749, Url.Content("~/userimages/"+User.Identity.Name+"gallery" + i.ToString() + ".jpg"), 749, 82, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"placeholderpic\">\r\n                </div>\r\n");
#nullable restore
#line 27 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\ProfileEdit\ViewOtherProfile.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        </section>\r\n\r\n        <section>\r\n            <h3></h3>\r\n            <p><span><i class=\"fas fa-paw\"></i></span> ");
#nullable restore
#line 34 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\ProfileEdit\ViewOtherProfile.cshtml"
                                                  Write(Model.AnimalModel.AnimalType);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 34 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\ProfileEdit\ViewOtherProfile.cshtml"
                                                                                 Write(Model.AnimalModel.AnimalBreed);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p><span><i class=\"fas fa-mars\"></i></span> ");
#nullable restore
#line 35 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\ProfileEdit\ViewOtherProfile.cshtml"
                                                   Write(Model.AnimalModel.AnimalGender);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p><span><i class=\"fas fa-birthday-cake\"></i></span> ");
#nullable restore
#line 36 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\ProfileEdit\ViewOtherProfile.cshtml"
                                                            Write(Model.AnimalModel.GetYear());

#line default
#line hidden
#nullable disable
            WriteLiteral(" years old</p>\r\n            <p><span><i class=\"fas fa-search\"></i></span> Looking for: ");
#nullable restore
#line 37 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\ProfileEdit\ViewOtherProfile.cshtml"
                                                                  Write(Model.AnimalModel.LookingFor);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n\r\n");
#nullable restore
#line 40 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\ProfileEdit\ViewOtherProfile.cshtml"
             if (Model.AsMatching)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h3>Owner</h3>\r\n                <p><span><i class=\"fas fa-user\"></i></span> ");
#nullable restore
#line 43 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\ProfileEdit\ViewOtherProfile.cshtml"
                                                       Write(Model.UserProfileModel.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 43 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\ProfileEdit\ViewOtherProfile.cshtml"
                                                                                         Write(Model.UserProfileModel.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p><span><i class=\"fas fa-phone-alt\"></i></span> ");
#nullable restore
#line 44 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\ProfileEdit\ViewOtherProfile.cshtml"
                                                            Write(Model.UserProfileModel.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
            WriteLiteral("                <button type=\"button\" class=\"premium-button\" title=\"Unmatch\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1975, "\"", 2028, 4);
            WriteAttributeValue("", 1985, "UnmatchASP(\'", 1985, 12, true);
#nullable restore
#line 46 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\ProfileEdit\ViewOtherProfile.cshtml"
WriteAttributeValue("", 1997, Model.AnimalModel.ForUser, 1997, 26, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2023, "\',", 2023, 2, true);
            WriteAttributeValue(" ", 2025, "0)", 2026, 3, true);
            EndWriteAttribute();
            WriteLiteral(" return false>Unmatch</button>\r\n");
#nullable restore
#line 47 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\ProfileEdit\ViewOtherProfile.cshtml"
            }
            else
            {
                

#line default
#line hidden
#nullable disable
            WriteLiteral("                <button type=\"button\" class=\"premium-button\" title=\"like back\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2374, "\"", 2428, 4);
            WriteAttributeValue("", 2384, "LikeBackASP(\'", 2384, 13, true);
#nullable restore
#line 51 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\ProfileEdit\ViewOtherProfile.cshtml"
WriteAttributeValue("", 2397, Model.AnimalModel.ForUser, 2397, 26, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2423, "\',", 2423, 2, true);
            WriteAttributeValue(" ", 2425, "1)", 2426, 3, true);
            EndWriteAttribute();
            WriteLiteral(" return false>Like Back</button>\r\n");
#nullable restore
#line 52 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\ProfileEdit\ViewOtherProfile.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
                <script type=""text/javascript"">
                      function LikeBack(fromUser, toUser) {
                            console.log(fromUser + "" to "" + toUser);
                            //this invokes the c# method of our hub with the parameters needed to send the message to the other user
                            connection.invoke(""Like"", fromUser, toUser)
                                .then(function (result) {
                                    console.log(result)
                                    if (result == ""Matched"") {
                                        //put toUser in Matches
                                        window.location.href = """);
#nullable restore
#line 65 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\ProfileEdit\ViewOtherProfile.cshtml"
                                                           Write(Url.Action("MyMatches", "Home"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""";//go back to browse
                                    }
                                    else {
                                        //failed or liked already
                                    }
                                    console.log(result);
                                }, function (err) {
                                    return console.error(err.toString());//error handling
                                });
                    }

                    function Unmatch(fromUser, toUser) {
                         console.log(fromUser + "" to "" + toUser);
                         connection.invoke(""Unlike"", fromUser, toUser)
                                .then(function (result) {
                                    console.log(result)
                                    window.location.href = """);
#nullable restore
#line 81 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\ProfileEdit\ViewOtherProfile.cshtml"
                                                       Write(Url.Action("MyMatches", "Home"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""";//go back to browse
                                }, function (err) {
                                    return console.error(err.toString());//error handling
                                });


                    }

                    function LikeBackASP(toUser, t) {
                        window.location.href = (""");
#nullable restore
#line 90 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\ProfileEdit\ViewOtherProfile.cshtml"
                                            Write(Url.Action("MyMatches", "Home", new { username = "usernamevalue",  type = "1"}));

#line default
#line hidden
#nullable disable
                WriteLiteral("\").replace(\"usernamevalue\", t + \";\" + toUser);\r\n                        //console.log(toUser +\" \"+ type)\r\n                    }\r\n\r\n                    function UnmatchASP(toUser, t) {\r\n                        window.location.href = (\"");
#nullable restore
#line 95 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\ProfileEdit\ViewOtherProfile.cshtml"
                                            Write(Url.Action("MyMatches", "Home", new { username = "usernamevalue", type = "0"}));

#line default
#line hidden
#nullable disable
                WriteLiteral("\").replace(\"usernamevalue\",  t + \";\" + toUser);\r\n                         console.log(toUser +\" \"+ type)\r\n                    }\r\n                </script>\r\n            ");
            }
            );
            WriteLiteral("        </section>\r\n    </article>\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tindyr.Models.ProfileEdit.AllUserInformationModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
