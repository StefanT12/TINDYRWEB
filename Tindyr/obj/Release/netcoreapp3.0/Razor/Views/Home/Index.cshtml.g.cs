#pragma checksum "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "009b250eb62dc910c2d8c74d229375b26c657223"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"009b250eb62dc910c2d8c74d229375b26c657223", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b534ad202c5fde8e056124080668e533fedad87", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tindyr.Models.ProfileEdit.UserInfoStatusModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\Home\Index.cshtml"
 if (!User.Identity.IsAuthenticated)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\Home\Index.cshtml"
Write(await Html.PartialAsync("_LandingPageNewUser"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\Home\Index.cshtml"
                                                   

}
else
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\Home\Index.cshtml"
     if (!Model.Validated)//tells user he should edit his profile
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\Home\Index.cshtml"
   Write(await Html.PartialAsync("_UrgeEditProfile"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\Home\Index.cshtml"
                                                    ;
    }
    else
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\Home\Index.cshtml"
   Write(await Html.PartialAsync("_LandingPageExistingUser"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\Home\Index.cshtml"
                                                            
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\Home\Index.cshtml"
     

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n        function DoComfirm()\r\n        {\r\n            window.location.href = \"");
#nullable restore
#line 31 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\Home\Index.cshtml"
                               Write(Url.Action("Register", "Auth"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\";\r\n        }\r\n\r\n        function GoEdit()\r\n        {\r\n            console.log(\"heyhey\");\r\n            window.location.href = \"");
#nullable restore
#line 37 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\Home\Index.cshtml"
                               Write(Url.Action("ProfileEdit", "ProfileEdit"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\";\r\n        }\r\n\r\n        function GoTip()\r\n        {\r\n            console.log(\"heyhey\");\r\n            window.location.href = \"");
#nullable restore
#line 43 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\Home\Index.cshtml"
                               Write(Url.Action("Donate", "Home"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\";\r\n        }\r\n\r\n    </script>\r\n");
            }
            );
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tindyr.Models.ProfileEdit.UserInfoStatusModel> Html { get; private set; }
    }
}
#pragma warning restore 1591