#pragma checksum "C:\Users\LTC2021\Downloads\Yabous Project\Yabous Project\YabousNews.Web\YabousNews.Web\Views\Attachments\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe8dc0c82109a3ef5992ca7b89df223cb386a739"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Attachments_Details), @"mvc.1.0.view", @"/Views/Attachments/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe8dc0c82109a3ef5992ca7b89df223cb386a739", @"/Views/Attachments/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"571ff0655f523e777802f494b5889ccf015cd0fc", @"/Views/_ViewImports.cshtml")]
    public class Views_Attachments_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<YabousNews.Data.Models.Attachment>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Images/pdflog.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-responsive"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\LTC2021\Downloads\Yabous Project\Yabous Project\YabousNews.Web\YabousNews.Web\Views\Attachments\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "_Layout";


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""content_inner_page"">
    <div class=""container"">
        <div class=""row"">

            <div class=""col-md-9"">
                <div class=""primary_right"">

                    <ol class=""breadcrumb"">
                        <li><a href=""../index.html""><i class=""fa fa-home"" aria-hidden=""true""></i></a></li>
                        <li><a href=""../category/4.html"">اسم الاصدار</a></li>
                    </ol>
                        <div class=""post_content"" style=""padding: 25px;"">
                            <a");
            BeginWriteAttribute("href", " href=\"", 659, "\"", 677, 1);
#nullable restore
#line 21 "C:\Users\LTC2021\Downloads\Yabous Project\Yabous Project\YabousNews.Web\YabousNews.Web\Views\Attachments\Details.cshtml"
WriteAttributeValue("", 666, Model.File, 666, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" >");
#nullable restore
#line 21 "C:\Users\LTC2021\Downloads\Yabous Project\Yabous Project\YabousNews.Web\YabousNews.Web\Views\Attachments\Details.cshtml"
                                              Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                            <div class=\"post-thumb\">\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 786, "\"", 804, 1);
#nullable restore
#line 23 "C:\Users\LTC2021\Downloads\Yabous Project\Yabous Project\YabousNews.Web\YabousNews.Web\Views\Attachments\Details.cshtml"
WriteAttributeValue("", 793, Model.File, 793, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" >\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "fe8dc0c82109a3ef5992ca7b89df223cb386a7396421", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                </a>
                                    </div>

                        </div>

                    



                </div><!--primary_right-->
            </div>



        </div>
    </div>
</section>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<YabousNews.Data.Models.Attachment> Html { get; private set; }
    }
}
#pragma warning restore 1591
