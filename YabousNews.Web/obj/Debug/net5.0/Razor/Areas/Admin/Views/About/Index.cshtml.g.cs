#pragma checksum "C:\Users\hp\Desktop\مكتبة العمل\YabousNews\YabousNews.Web\YabousNews.Web\Areas\Admin\Views\About\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "79e88c0d32705af9fe64ca40b1137ec3ce338901"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_About_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/About/Index.cshtml")]
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
#line 1 "C:\Users\hp\Desktop\مكتبة العمل\YabousNews\YabousNews.Web\YabousNews.Web\Areas\Admin\Views\_ViewImports.cshtml"
using YabousNews.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\hp\Desktop\مكتبة العمل\YabousNews\YabousNews.Web\YabousNews.Web\Areas\Admin\Views\_ViewImports.cshtml"
using YabousNews.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79e88c0d32705af9fe64ca40b1137ec3ce338901", @"/Areas/Admin/Views/About/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"571ff0655f523e777802f494b5889ccf015cd0fc", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_About_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<YabousNews.Data.Models.About>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\hp\Desktop\مكتبة العمل\YabousNews\YabousNews.Web\YabousNews.Web\Areas\Admin\Views\About\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<br />
<br />

<div class=""row"">
    <div class=""col-md-3"">
        <p>
            <a href=""Admin/About/Create"" class=""btn btn-light-primary font-weight-bolder btn-sm"">
                <i class=""fa fa-plus-square""></i>
                <span>إضافة صفحة تعريفية جديد</span>
            </a>
        </p>
    </div>
    <div class=""col-md-3"">

        <p>
            <a href=""Admin/TitleSubs/index"" class=""btn btn-light-primary font-weight-bolder btn-sm"">
                <i class=""fa fa-plus-square""></i>
                <span> القوائم  الفرعية </span>
            </a>
        </p>
    </div>
</div>
<table table class=""table m-table m-table--head-separator-primary content"">
    <thead>
        <tr>
            <th>
                العنوان
            </th>
            <th>
                عنوان القائمة الفرعية
            </th>

            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 43 "C:\Users\hp\Desktop\مكتبة العمل\YabousNews\YabousNews.Web\YabousNews.Web\Areas\Admin\Views\About\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 47 "C:\Users\hp\Desktop\مكتبة العمل\YabousNews\YabousNews.Web\YabousNews.Web\Areas\Admin\Views\About\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 50 "C:\Users\hp\Desktop\مكتبة العمل\YabousNews\YabousNews.Web\YabousNews.Web\Areas\Admin\Views\About\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.TitleSub.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 1383, "\"", 1416, 2);
            WriteAttributeValue("", 1390, "/Admin/About/Edit/", 1390, 18, true);
#nullable restore
#line 53 "C:\Users\hp\Desktop\مكتبة العمل\YabousNews\YabousNews.Web\YabousNews.Web\Areas\Admin\Views\About\Index.cshtml"
WriteAttributeValue("", 1408, item.Id, 1408, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">تعديل</a> |\r\n\r\n\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 1453, "\"", 1488, 2);
            WriteAttributeValue("", 1460, "/Admin/About/Delete/", 1460, 20, true);
#nullable restore
#line 56 "C:\Users\hp\Desktop\مكتبة العمل\YabousNews\YabousNews.Web\YabousNews.Web\Areas\Admin\Views\About\Index.cshtml"
WriteAttributeValue("", 1480, item.Id, 1480, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">حذف</a>\r\n            </td>\r\n\r\n        </tr>\r\n");
#nullable restore
#line 60 "C:\Users\hp\Desktop\مكتبة العمل\YabousNews\YabousNews.Web\YabousNews.Web\Areas\Admin\Views\About\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<YabousNews.Data.Models.About>> Html { get; private set; }
    }
}
#pragma warning restore 1591
