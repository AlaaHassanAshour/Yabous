#pragma checksum "C:\Users\hp\Desktop\مكتبة العمل\YabousNews\YabousNews.Web\YabousNews.Web\Areas\Admin\Views\CategoryAttatcmants\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2b1034ea11c7c3739ffeeb346484502735780e29"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_CategoryAttatcmants_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/CategoryAttatcmants/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b1034ea11c7c3739ffeeb346484502735780e29", @"/Areas/Admin/Views/CategoryAttatcmants/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"571ff0655f523e777802f494b5889ccf015cd0fc", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_CategoryAttatcmants_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<YabousNews.Data.Models.CategoryAttatcmant>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\hp\Desktop\مكتبة العمل\YabousNews\YabousNews.Web\YabousNews.Web\Areas\Admin\Views\CategoryAttatcmants\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<br />
<br />
<br />
<br />
<p>
    <a href=""Admin/CategoryAttatcmants/Create"" class=""btn btn-light-primary font-weight-bolder btn-sm"">
        <i class=""fa fa-plus-square""></i>
        <span>إضافة تصنيف جديد</span>
    </a>
</p>
<table class=""table content"">
    <thead>
        <tr>
            <th>
              اسم التصنيف
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 28 "C:\Users\hp\Desktop\مكتبة العمل\YabousNews\YabousNews.Web\YabousNews.Web\Areas\Admin\Views\CategoryAttatcmants\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 32 "C:\Users\hp\Desktop\مكتبة العمل\YabousNews\YabousNews.Web\YabousNews.Web\Areas\Admin\Views\CategoryAttatcmants\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 812, "\"", 858, 2);
            WriteAttributeValue("", 819, "Admin/CategoryAttatcmants/Edit/", 819, 31, true);
#nullable restore
#line 35 "C:\Users\hp\Desktop\مكتبة العمل\YabousNews\YabousNews.Web\YabousNews.Web\Areas\Admin\Views\CategoryAttatcmants\Index.cshtml"
WriteAttributeValue("", 850, item.Id, 850, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> |\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 894, "\"", 943, 2);
            WriteAttributeValue(" ", 901, "Admin/CategoryAttatcmants/Delete/", 902, 34, true);
#nullable restore
#line 36 "C:\Users\hp\Desktop\مكتبة العمل\YabousNews\YabousNews.Web\YabousNews.Web\Areas\Admin\Views\CategoryAttatcmants\Index.cshtml"
WriteAttributeValue("", 935, item.Id, 935, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 39 "C:\Users\hp\Desktop\مكتبة العمل\YabousNews\YabousNews.Web\YabousNews.Web\Areas\Admin\Views\CategoryAttatcmants\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<YabousNews.Data.Models.CategoryAttatcmant>> Html { get; private set; }
    }
}
#pragma warning restore 1591