#pragma checksum "C:\Users\61415\source\repos\WebApplication2\WebApplication2\Views\First\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6a56576b01a5c631d115c1c1a1602d1ba8eaf508"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_First_Index), @"mvc.1.0.view", @"/Views/First/Index.cshtml")]
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
#line 1 "C:\Users\61415\source\repos\WebApplication2\WebApplication2\Views\_ViewImports.cshtml"
using WebApplication2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\61415\source\repos\WebApplication2\WebApplication2\Views\_ViewImports.cshtml"
using WebApplication2.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\61415\source\repos\WebApplication2\WebApplication2\Views\First\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a56576b01a5c631d115c1c1a1602d1ba8eaf508", @"/Views/First/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"caeba75ac74d12c21a39346605ceef72ce7744cc", @"/Views/_ViewImports.cshtml")]
    public class Views_First_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<object>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\61415\source\repos\WebApplication2\WebApplication2\Views\First\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome</h1>\r\n    <p>Learn about <a href=\"https://docs.microsoft.com/aspnet/core\">building Web apps with ASP.NET Core</a>.</p>\r\n</div>\r\n<h1>\r\n    ");
#nullable restore
#line 12 "C:\Users\61415\source\repos\WebApplication2\WebApplication2\Views\First\Index.cshtml"
Write(base.ViewBag.User1);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</h1>\r\n<h1>\r\n    ");
#nullable restore
#line 15 "C:\Users\61415\source\repos\WebApplication2\WebApplication2\Views\First\Index.cshtml"
Write(base.ViewBag.configInfo);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</h1>\r\n\r\n<h1>\r\n    ");
#nullable restore
#line 19 "C:\Users\61415\source\repos\WebApplication2\WebApplication2\Views\First\Index.cshtml"
Write(base.ViewData["User2"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</h1>\r\n<h1>\r\n    ");
#nullable restore
#line 22 "C:\Users\61415\source\repos\WebApplication2\WebApplication2\Views\First\Index.cshtml"
Write(base.TempData["User3"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</h1>\r\n\r\n\r\n\r\n<h1>\r\n    ");
#nullable restore
#line 28 "C:\Users\61415\source\repos\WebApplication2\WebApplication2\Views\First\Index.cshtml"
Write(Context.Session.GetString("User5"));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n</h1>\r\n\r\n<h1>\r\n    ");
#nullable restore
#line 32 "C:\Users\61415\source\repos\WebApplication2\WebApplication2\Views\First\Index.cshtml"
Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</h1>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<object> Html { get; private set; }
    }
}
#pragma warning restore 1591
