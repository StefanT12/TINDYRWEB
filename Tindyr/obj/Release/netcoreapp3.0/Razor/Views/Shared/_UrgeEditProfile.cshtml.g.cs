#pragma checksum "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\Shared\_UrgeEditProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f3b99daa4116d53437da393f8db8578f4ea61da5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__UrgeEditProfile), @"mvc.1.0.view", @"/Views/Shared/_UrgeEditProfile.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f3b99daa4116d53437da393f8db8578f4ea61da5", @"/Views/Shared/_UrgeEditProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b534ad202c5fde8e056124080668e533fedad87", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__UrgeEditProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n    <article class=\"donate\">\r\n        <div>\r\n            <h1 class=\"premium-headline\">One last thing ");
#nullable restore
#line 8 "C:\Users\Intel\source\repos\TINDYRWEB\Tindyr\Views\Shared\_UrgeEditProfile.cshtml"
                                                   Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@",</h1>
            <p class=""donate-p"">
                Before you can fully utilize our services, make sure all information provided in Profile is correct :)
            </p>
            <button type=""button"" class=""premium-button"" title=""employs"" onclick=""GoEdit()"" return false>Edit your profile</button>
        </div>
    </article>
");
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
