#pragma checksum "H:\Robert\Nackademin\ASPNET MVC1\Inlämningar\Inlämning 2 - Webshop\Views\User\Orders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9ef3e4069acdc68db2837d35eab8147005ce5f96"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Orders), @"mvc.1.0.view", @"/Views/User/Orders.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/User/Orders.cshtml", typeof(AspNetCore.Views_User_Orders))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9ef3e4069acdc68db2837d35eab8147005ce5f96", @"/Views/User/Orders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ddc536a28b20e83e882abe5dbff60c8b19d371a3", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Orders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Inlämning_2___Webshop.ViewModels.OrdersMatrattViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RemoveOrder", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(64, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "H:\Robert\Nackademin\ASPNET MVC1\Inlämningar\Inlämning 2 - Webshop\Views\User\Orders.cshtml"
  
    ViewData["Title"] = "Orders";

#line default
#line hidden
            BeginContext(108, 30, true);
            WriteLiteral("\r\n<h1>Orders</h1>\r\n\r\n<table>\r\n");
            EndContext();
#line 10 "H:\Robert\Nackademin\ASPNET MVC1\Inlämningar\Inlämning 2 - Webshop\Views\User\Orders.cshtml"
     foreach (var order in Model.OrderData)
    {

#line default
#line hidden
            BeginContext(190, 42, true);
            WriteLiteral("        <tr>\r\n            <td>Order date: ");
            EndContext();
            BeginContext(233, 22, false);
#line 13 "H:\Robert\Nackademin\ASPNET MVC1\Inlämningar\Inlämning 2 - Webshop\Views\User\Orders.cshtml"
                       Write(order.BestallningDatum);

#line default
#line hidden
            EndContext();
            BeginContext(255, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(279, 17, false);
#line 14 "H:\Robert\Nackademin\ASPNET MVC1\Inlämningar\Inlämning 2 - Webshop\Views\User\Orders.cshtml"
           Write(order.Totalbelopp);

#line default
#line hidden
            EndContext();
            BeginContext(296, 41, true);
            WriteLiteral("</td>\r\n            <td>Delivery status:\r\n");
            EndContext();
#line 16 "H:\Robert\Nackademin\ASPNET MVC1\Inlämningar\Inlämning 2 - Webshop\Views\User\Orders.cshtml"
             if (order.Levererad.Equals(false))
            {

#line default
#line hidden
            BeginContext(401, 41, true);
            WriteLiteral("                <span>On the way</span>\r\n");
            EndContext();
#line 19 "H:\Robert\Nackademin\ASPNET MVC1\Inlämningar\Inlämning 2 - Webshop\Views\User\Orders.cshtml"
            } else
            {

#line default
#line hidden
            BeginContext(477, 49, true);
            WriteLiteral("                <span>Delivery completed</span>\r\n");
            EndContext();
#line 22 "H:\Robert\Nackademin\ASPNET MVC1\Inlämningar\Inlämning 2 - Webshop\Views\User\Orders.cshtml"
            }

#line default
#line hidden
            BeginContext(541, 35, true);
            WriteLiteral("            </td>\r\n            <td>");
            EndContext();
            BeginContext(576, 137, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9ef3e4069acdc68db2837d35eab8147005ce5f966619", async() => {
                BeginContext(697, 12, true);
                WriteLiteral("Remove Order");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-orderid", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 24 "H:\Robert\Nackademin\ASPNET MVC1\Inlämningar\Inlämning 2 - Webshop\Views\User\Orders.cshtml"
                                                                         WriteLiteral(order.BestallningId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["orderid"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-orderid", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["orderid"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(713, 22, true);
            WriteLiteral("</td>\r\n        </tr>\r\n");
            EndContext();
#line 26 "H:\Robert\Nackademin\ASPNET MVC1\Inlämningar\Inlämning 2 - Webshop\Views\User\Orders.cshtml"
    }

#line default
#line hidden
            BeginContext(742, 8, true);
            WriteLiteral("</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Inlämning_2___Webshop.ViewModels.OrdersMatrattViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
