#pragma checksum "c:\Users\alexe\Documents\CodingDojo\CSharp\MVC\WeddingPlanner\Views\Home\ShowWedding.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "325186e15e9acef78ec261472bccad88a4d90e88"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ShowWedding), @"mvc.1.0.view", @"/Views/Home/ShowWedding.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/ShowWedding.cshtml", typeof(AspNetCore.Views_Home_ShowWedding))]
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
#line 1 "c:\Users\alexe\Documents\CodingDojo\CSharp\MVC\WeddingPlanner\Views\_ViewImports.cshtml"
using WeddingPlanner;

#line default
#line hidden
#line 2 "c:\Users\alexe\Documents\CodingDojo\CSharp\MVC\WeddingPlanner\Views\_ViewImports.cshtml"
using WeddingPlanner.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"325186e15e9acef78ec261472bccad88a4d90e88", @"/Views/Home/ShowWedding.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e9e38482b8beecdb199b7be73dfa5c3d6a2f574", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ShowWedding : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Wedding>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(16, 21, true);
            WriteLiteral("\r\n<h1>Welcome to the ");
            EndContext();
            BeginContext(38, 11, false);
#line 3 "c:\Users\alexe\Documents\CodingDojo\CSharp\MVC\WeddingPlanner\Views\Home\ShowWedding.cshtml"
              Write(Model.Bride);

#line default
#line hidden
            EndContext();
            BeginContext(49, 3, true);
            WriteLiteral(" & ");
            EndContext();
            BeginContext(53, 11, false);
#line 3 "c:\Users\alexe\Documents\CodingDojo\CSharp\MVC\WeddingPlanner\Views\Home\ShowWedding.cshtml"
                             Write(Model.Groom);

#line default
#line hidden
            EndContext();
            BeginContext(64, 14, true);
            WriteLiteral(" Wedding!</h1>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Wedding> Html { get; private set; }
    }
}
#pragma warning restore 1591
