#pragma checksum "H:\Robert\Nackademin\ASPNET MVC1\Inlämningar\Inlämning 2 - Webshop\Views\Shared\_Cart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ab3176f1decf7999a22f96591e04fa6f4aa3282e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Cart), @"mvc.1.0.view", @"/Views/Shared/_Cart.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_Cart.cshtml", typeof(AspNetCore.Views_Shared__Cart))]
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
#line 1 "H:\Robert\Nackademin\ASPNET MVC1\Inlämningar\Inlämning 2 - Webshop\Views\_ViewImports.cshtml"
using Inlämning_2___Webshop;

#line default
#line hidden
#line 2 "H:\Robert\Nackademin\ASPNET MVC1\Inlämningar\Inlämning 2 - Webshop\Views\_ViewImports.cshtml"
using Inlämning_2___Webshop.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab3176f1decf7999a22f96591e04fa6f4aa3282e", @"/Views/Shared/_Cart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ddc536a28b20e83e882abe5dbff60c8b19d371a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Cart : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Inlämning_2___Webshop.Models.Matratt>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Store", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RemoveFromCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax", new global::Microsoft.AspNetCore.Html.HtmlString("true"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-method", new global::Microsoft.AspNetCore.Html.HtmlString("GET"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-mode", new global::Microsoft.AspNetCore.Html.HtmlString("replace"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-update", new global::Microsoft.AspNetCore.Html.HtmlString("#cart"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ConfirmOrder", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(51, 34, true);
            WriteLiteral("\r\n<h3>Du har beställt: </h3>\r\n<h4>");
            EndContext();
            BeginContext(86, 24, false);
#line 4 "H:\Robert\Nackademin\ASPNET MVC1\Inlämningar\Inlämning 2 - Webshop\Views\Shared\_Cart.cshtml"
Write(User.IsInRole("premium"));

#line default
#line hidden
            EndContext();
            BeginContext(110, 18, true);
            WriteLiteral("</h4>\r\n\r\n<table>\r\n");
            EndContext();
#line 7 "H:\Robert\Nackademin\ASPNET MVC1\Inlämningar\Inlämning 2 - Webshop\Views\Shared\_Cart.cshtml"
     foreach (var matratt in Model)
    {

#line default
#line hidden
            BeginContext(172, 30, true);
            WriteLiteral("        <tr>\r\n            <td>");
            EndContext();
            BeginContext(203, 19, false);
#line 10 "H:\Robert\Nackademin\ASPNET MVC1\Inlämningar\Inlämning 2 - Webshop\Views\Shared\_Cart.cshtml"
           Write(matratt.MatrattNamn);

#line default
#line hidden
            EndContext();
            BeginContext(222, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(246, 12, false);
#line 11 "H:\Robert\Nackademin\ASPNET MVC1\Inlämningar\Inlämning 2 - Webshop\Views\Shared\_Cart.cshtml"
           Write(matratt.Pris);

#line default
#line hidden
            EndContext();
            BeginContext(258, 27, true);
            WriteLiteral(" SEK</td>\r\n            <td>");
            EndContext();
            BeginContext(285, 188, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ab3176f1decf7999a22f96591e04fa6f4aa3282e7414", async() => {
                BeginContext(463, 6, true);
                WriteLiteral("Remove");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 12 "H:\Robert\Nackademin\ASPNET MVC1\Inlämningar\Inlämning 2 - Webshop\Views\Shared\_Cart.cshtml"
                                                                        WriteLiteral(matratt.MatrattId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(473, 22, true);
            WriteLiteral("</td>\r\n        </tr>\r\n");
            EndContext();
#line 14 "H:\Robert\Nackademin\ASPNET MVC1\Inlämningar\Inlämning 2 - Webshop\Views\Shared\_Cart.cshtml"
    }

#line default
#line hidden
            BeginContext(502, 35, true);
            WriteLiteral("\r\n<tr>\r\n    <td>Totalsumma: </td>\r\n");
            EndContext();
#line 18 "H:\Robert\Nackademin\ASPNET MVC1\Inlämningar\Inlämning 2 - Webshop\Views\Shared\_Cart.cshtml"
     if (User.IsInRole("premium"))
    {
        

#line default
#line hidden
#line 20 "H:\Robert\Nackademin\ASPNET MVC1\Inlämningar\Inlämning 2 - Webshop\Views\Shared\_Cart.cshtml"
         if (Model.Count >= 3)
        {

#line default
#line hidden
            BeginContext(623, 19, true);
            WriteLiteral("            <td><s>");
            EndContext();
            BeginContext(643, 39, false);
#line 22 "H:\Robert\Nackademin\ASPNET MVC1\Inlämningar\Inlämning 2 - Webshop\Views\Shared\_Cart.cshtml"
              Write(Convert.ToInt32(Model.Sum(p => p.Pris)));

#line default
#line hidden
            EndContext();
            BeginContext(682, 55, true);
            WriteLiteral("</s> <span style=\"font-weight:bold; color:forestgreen\">");
            EndContext();
            BeginContext(738, 44, false);
#line 22 "H:\Robert\Nackademin\ASPNET MVC1\Inlämningar\Inlämning 2 - Webshop\Views\Shared\_Cart.cshtml"
                                                                                                             Write(Convert.ToInt32(Model.Sum(p => p.Pris) * .8));

#line default
#line hidden
            EndContext();
            BeginContext(782, 18, true);
            WriteLiteral(" SEK</span></td>\r\n");
            EndContext();
#line 23 "H:\Robert\Nackademin\ASPNET MVC1\Inlämningar\Inlämning 2 - Webshop\Views\Shared\_Cart.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(836, 16, true);
            WriteLiteral("            <td>");
            EndContext();
            BeginContext(853, 39, false);
#line 26 "H:\Robert\Nackademin\ASPNET MVC1\Inlämningar\Inlämning 2 - Webshop\Views\Shared\_Cart.cshtml"
           Write(Convert.ToInt32(Model.Sum(p => p.Pris)));

#line default
#line hidden
            EndContext();
            BeginContext(892, 11, true);
            WriteLiteral(" SEK</td>\r\n");
            EndContext();
#line 27 "H:\Robert\Nackademin\ASPNET MVC1\Inlämningar\Inlämning 2 - Webshop\Views\Shared\_Cart.cshtml"
        }

#line default
#line hidden
#line 27 "H:\Robert\Nackademin\ASPNET MVC1\Inlämningar\Inlämning 2 - Webshop\Views\Shared\_Cart.cshtml"
         
    }
    else
    {

#line default
#line hidden
            BeginContext(938, 12, true);
            WriteLiteral("        <td>");
            EndContext();
            BeginContext(951, 39, false);
#line 31 "H:\Robert\Nackademin\ASPNET MVC1\Inlämningar\Inlämning 2 - Webshop\Views\Shared\_Cart.cshtml"
       Write(Convert.ToInt32(Model.Sum(p => p.Pris)));

#line default
#line hidden
            EndContext();
            BeginContext(990, 11, true);
            WriteLiteral(" SEK</td>\r\n");
            EndContext();
#line 32 "H:\Robert\Nackademin\ASPNET MVC1\Inlämningar\Inlämning 2 - Webshop\Views\Shared\_Cart.cshtml"
    }

#line default
#line hidden
            BeginContext(1008, 19, true);
            WriteLiteral("</tr>\r\n</table>\r\n\r\n");
            EndContext();
            BeginContext(1027, 94, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ab3176f1decf7999a22f96591e04fa6f4aa3282e13784", async() => {
                BeginContext(1103, 14, true);
                WriteLiteral("Complete order");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1121, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Inlämning_2___Webshop.Models.Matratt>> Html { get; private set; }
    }
}
#pragma warning restore 1591
