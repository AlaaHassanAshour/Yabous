#pragma checksum "C:\Users\LTC2021\Downloads\Yabous Project\Yabous Project\YabousNews.Web\YabousNews.Web\Views\News\GetAll.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d29017e809efac7650f678cdbb0c40121b0189ec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_News_GetAll), @"mvc.1.0.view", @"/Views/News/GetAll.cshtml")]
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
#line 1 "C:\Users\LTC2021\Downloads\Yabous Project\Yabous Project\YabousNews.Web\YabousNews.Web\Views\_ViewImports.cshtml"
using YabousNews.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\LTC2021\Downloads\Yabous Project\Yabous Project\YabousNews.Web\YabousNews.Web\Views\_ViewImports.cshtml"
using YabousNews.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d29017e809efac7650f678cdbb0c40121b0189ec", @"/Views/News/GetAll.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"571ff0655f523e777802f494b5889ccf015cd0fc", @"/Views/_ViewImports.cshtml")]
    public class Views_News_GetAll : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<YabousNews.Data.Models.News>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-responsive"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\LTC2021\Downloads\Yabous Project\Yabous Project\YabousNews.Web\YabousNews.Web\Views\News\GetAll.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<br />
<br />
<br />
<<section class=""content_inner_page"">
    <div class=""container"">
        <div class=""row"">

            <div class=""col-md-12"">
                <div class=""primary_right"">


                        <div class=""row"">


");
#nullable restore
#line 20 "C:\Users\LTC2021\Downloads\Yabous Project\Yabous Project\YabousNews.Web\YabousNews.Web\Views\News\GetAll.cshtml"
                             foreach (var item in Model.Take(20))
                            {




#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <div class=""col-md-4 col-sm-4 col-xs-6"">
                                    <div class=""mNews_item"">
                                        <div class=""thumb height-img-overlay"">
                                            <a");
            BeginWriteAttribute("href", " href=\"", 703, "\"", 732, 2);
            WriteAttributeValue("", 710, "/News/Details/", 710, 14, true);
#nullable restore
#line 28 "C:\Users\LTC2021\Downloads\Yabous Project\Yabous Project\YabousNews.Web\YabousNews.Web\Views\News\GetAll.cshtml"
WriteAttributeValue("", 724, item.Id, 724, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"height-img-overlay\">\r\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d29017e809efac7650f678cdbb0c40121b0189ec5213", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 821, "~/images/", 821, 9, true);
#nullable restore
#line 29 "C:\Users\LTC2021\Downloads\Yabous Project\Yabous Project\YabousNews.Web\YabousNews.Web\Views\News\GetAll.cshtml"
AddHtmlAttributeValue("", 830, item.Image, 830, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                            </a>\r\n                                            <div class=\"img-overlay\">\r\n                                                <a");
            BeginWriteAttribute("href", " href=\"", 1039, "\"", 1068, 2);
            WriteAttributeValue("", 1046, "/News/Details/", 1046, 14, true);
#nullable restore
#line 32 "C:\Users\LTC2021\Downloads\Yabous Project\Yabous Project\YabousNews.Web\YabousNews.Web\Views\News\GetAll.cshtml"
WriteAttributeValue("", 1060, item.Id, 1060, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""Photo-overlay"">
                                                </a>
                                               
                                            </div>
                                        </div>
                                        <div class=""detail"">

                                            <h2 class=""title"">
                                                <a");
            BeginWriteAttribute("href", " href=\"", 1475, "\"", 1504, 2);
            WriteAttributeValue("", 1482, "/News/Details/", 1482, 14, true);
#nullable restore
#line 40 "C:\Users\LTC2021\Downloads\Yabous Project\Yabous Project\YabousNews.Web\YabousNews.Web\Views\News\GetAll.cshtml"
WriteAttributeValue("", 1496, item.Id, 1496, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"text-img-overlay\">  ");
#nullable restore
#line 40 "C:\Users\LTC2021\Downloads\Yabous Project\Yabous Project\YabousNews.Web\YabousNews.Web\Views\News\GetAll.cshtml"
                                                                                                       Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </a>\r\n\r\n                                            </h2>\r\n                                            <span class=\"span-date\"> ");
#nullable restore
#line 43 "C:\Users\LTC2021\Downloads\Yabous Project\Yabous Project\YabousNews.Web\YabousNews.Web\Views\News\GetAll.cshtml"
                                                                Write(item.CreatedAt);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\r\n\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n");
#nullable restore
#line 48 "C:\Users\LTC2021\Downloads\Yabous Project\Yabous Project\YabousNews.Web\YabousNews.Web\Views\News\GetAll.cshtml"

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<YabousNews.Data.Models.News>> Html { get; private set; }
    }
}
#pragma warning restore 1591
