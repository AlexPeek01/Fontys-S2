#pragma checksum "C:\Users\Alex\Desktop\FHICT\Fontys-S2\Projecten\TestASP2\TestASP2\Views\User\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "091a9e9bc1bb35b9f6c3cf57b507a29853210d15"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Index), @"mvc.1.0.view", @"/Views/User/Index.cshtml")]
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
#line 1 "C:\Users\Alex\Desktop\FHICT\Fontys-S2\Projecten\TestASP2\TestASP2\Views\_ViewImports.cshtml"
using TestASP2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Alex\Desktop\FHICT\Fontys-S2\Projecten\TestASP2\TestASP2\Views\_ViewImports.cshtml"
using TestASP2.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"091a9e9bc1bb35b9f6c3cf57b507a29853210d15", @"/Views/User/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"efc6db690d0587cf009a78672e19a65303fe6966", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TestASP2.Models.UserModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Alex\Desktop\FHICT\Fontys-S2\Projecten\TestASP2\TestASP2\Views\User\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>");
#nullable restore
#line 6 "C:\Users\Alex\Desktop\FHICT\Fontys-S2\Projecten\TestASP2\TestASP2\Views\User\Index.cshtml"
Write(Model.userId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<img");
            BeginWriteAttribute("src", " src=\"", 105, "\"", 129, 1);
#nullable restore
#line 7 "C:\Users\Alex\Desktop\FHICT\Fontys-S2\Projecten\TestASP2\TestASP2\Views\User\Index.cshtml"
WriteAttributeValue("", 111, Model.profielFoto, 111, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TestASP2.Models.UserModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
