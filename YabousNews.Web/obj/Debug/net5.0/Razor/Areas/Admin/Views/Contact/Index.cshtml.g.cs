#pragma checksum "C:\Users\hp\Desktop\مكتبة العمل\YabousNews\YabousNews.Web\YabousNews.Web\Areas\Admin\Views\Contact\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "32cf01ca6e13632feae24ae86c42358fdb66c395"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Contact_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Contact/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32cf01ca6e13632feae24ae86c42358fdb66c395", @"/Areas/Admin/Views/Contact/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"571ff0655f523e777802f494b5889ccf015cd0fc", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Contact_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<YabousNews.Data.Models.Contact>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\hp\Desktop\مكتبة العمل\YabousNews\YabousNews.Web\YabousNews.Web\Areas\Admin\Views\Contact\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            DefineSection("Css", async() => {
                WriteLiteral(@"
    <style>
        td {
            padding: 4px 1px 0px 1px !important;
            font-size: 11px !important
        }

            td a {
                margin-left: 5px !important;
            }

        .m-portlet__body {
            padding-top: 0px !important;
        }
    </style>
");
            }
            );
            WriteLiteral(@"
<div class="" container  d-flex align-items-center justify-content-between flex-wrap flex-sm-nowrap p-10"" style=""background-color: white;"">
    <!--begin::Info-->
    <div class=""d-flex align-items-center flex-wrap mr-1"">
        <!--begin::Mobile Toggle-->
        <button class=""burger-icon burger-icon-left mr-4 d-inline-block d-lg-none"" id=""kt_subheader_mobile_toggle"">
            <span></span>
        </button>
        <!--end::Mobile Toggle-->
        <!--begin::Page Heading-->
        <div class=""d-flex align-items-baseline flex-wrap mr-5"">
            <!--begin::Page Title-->
            <h5 class=""text-dark font-weight-bold my-1 mr-5"">
                <b> فهرس بيانات التواصل في النظام </b>- عرض وتعديل بيانات التواصل
            </h5>
            <!--end::Page Title-->
            <!--begin::Breadcrumb-->
            <!--ul li-->
            <!--end::Breadcrumb-->
        </div>
        <!--end::Page Heading-->
    </div>
    <!--end::Info-->
    <!--begin::Toolbar-->
    <div cl");
            WriteLiteral(@"ass=""d-flex align-items-center"">
        <!--begin::Actions-->
        <a href=""/Admin/Contact/Create"" title=""إضافة جديد"" class=""form-modal btn btn-light-primary font-weight-bolder btn-sm"">
            <i class=""fa fa-plus-square""></i>
            <span>إضافة</span>
        </a>
        <!--end::Actions-->
    </div>
    <!--end::Toolbar-->
</div>


<div class=""content flex-column-fluid"" id=""kt_content"">


    <div class=""m-form m-form--label-align-right m--margin-top-10 m--margin-bottom-0"">
        <div class=""row align-items-center"">
            <div class=""col-xl-8 order-2 order-xl-1"">
                <div class=""form-group m-form__group row align-items-center"">
                    <div class=""col-md-6"">
                        <div class=""m-input-icon m-input-icon--left"">
                            <input type=""text"" id=""SearchKey"" name=""SearchKey"" class=""form-control m-input m-input--air"" placeholder=""وسيلة التواصل.. "">
                        </div>
                    </div>
  ");
            WriteLiteral(@"                  <div class=""col-md-2"">
                        <a id=""btnSearch"" class=""SearchBtn btn btn-primary m-btn m-btn--icon btn-sm m-btn--icon-only m-btn--custom m-btn--outline-1x m-btn--pill m-btn--air"">
                            <i class=""fa fa-search""></i>
                        </a>
                    </div>

                </div>
            </div>

        </div>
    </div>
    <table class=""table m-table m-table--head-separator-primary"" id=""ContactTable"">
        <thead>
            <tr>
                <th>وسيلة التواصل</th>
                <th>الرابط</th>
                <th>تاريخ الانشاء</th>
                <th width=""20%"">العمليات</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>

</div>
 

");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script>
            var Otables = """";
            var Otable = {
                init: function () {
                    var table = $('#ContactTable');
                    Otables = table.DataTable({
                ""processing"": true,
                        ""serverSide"": true,
                        ""filter"": false,
                        ""ordering"": false,
                        ""ajax"": {
                ""url"": '/Admin/Contact/IndexAjax',
                            ""type"": ""POST"",
                            ""datatype"": ""json"",
                            ""data"": function (data) {
                // Append to data
                                data.SearchKey = $('#SearchKey').val();
                            }
                        },
                        ""columnDefs"": [{
                /*  ""targets"": [0],*/
                ""visible"": false,
                            ""searchable"": false,
                            ""orderable"": false,
                      ");
                WriteLiteral(@"  }],
                        ""columns"": [
                            { ""data"": ""socialMedia"", ""name"": ""socialMedia"", ""autoWidth"": true },
                            { ""data"": ""link"", ""name"": ""link"", ""autoWidth"": true },
                             {
                ""data"": ""createdAt"", ""name"": ""createdAt"", ""autoWidth"": true,
                                ""render"": function (data, type, row) {
                                    var date1 = formatDate(row[""createdAt""]);
                                    return date1;
                                }
                            },
                            {
                name: 'buttons', ""render"": function (data, type, row) {
                                     var jsdel = 'jQueryModalConfirm(""/Admin/Contact/Delete?id=' + row.id +'"",""هل أنت متأكد من حذف هذا العنصر ؟"")';
                                    return (
                                         ""  <a href='/Admin/Contact/Edit/"" + row.id+""' class='form-modal btn btn-sm btn");
                WriteLiteral(@"-clean btn-icon mr-2' title='تعديل وسيلة التواصل'>""
                                        + ""    <span class='svg-icon svg-icon-md'>""
                                        + ""     <svg xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' width='24px' height='24px' viewBox='0 0 24 24' version='1.1'>""
                                        + ""       <g stroke='none' stroke-width='1' fill='none' fill-rule='evenodd'>""
                                        + ""        <rect x='0' y='0' width='24' height='24'></rect>""
                                        + ""     <path d='M8,17.9148182 L8,5.96685884 C8,5.56391781 8.16211443,5.17792052 8.44982609,4.89581508 L10.965708,2.42895648 C11.5426798,1.86322723 12.4640974,1.85620921 13.0496196,2.41308426 L15.5337377,4.77566479 C15.8314604,5.0588212 16,5.45170806 16,5.86258077 L16,17.9148182 C16,18.7432453 15.3284271,19.4148182 14.5,19.4148182 L9.5,19.4148182 C8.67157288,19.4148182 8,18.7432453 8,17.9148182 Z'""
                           ");
                WriteLiteral(@"             + ""          fill='#000000'""
                                        + ""             fill-rule='nonzero'""
                                        + ""            transform='translate(12.000000, 10.707409) rotate(-135.000000) translate(-12.000000, -10.707409) '></path>""
                                        + ""      <rect fill='#000000' opacity='0.3' x='5' y='20' width='15' height='2' rx='1'></rect>""
                                        + ""   </g>""
                                        + ""  </svg>""
                                        + ""  </span>""
                                        + ""  </a>""
                                        + ""  <a  onclick='"" + jsdel + ""' class='btn btn-sm btn-clean btn-icon' title='Delete'>""
                                        + ""      <span class='svg-icon svg-icon-md'>""
                                        + ""       <svg xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' width='24px' height='24px' viewBox='0 0 ");
                WriteLiteral(@"24 24' version='1.1'>""
                                        + ""          <g stroke='none' stroke-width='1' fill='none' fill-rule='evenodd'>""
                                        + ""             <rect x='0' y='0' width='24' height='24'></rect>""
                                        + ""            <path d='M6,8 L6,20.5 C6,21.3284271 6.67157288,22 7.5,22 L16.5,22 C17.3284271,22 18,21.3284271 18,20.5 L18,8 L6,8 Z' fill='#000000' fill-rule='nonzero'></path>""
                                        + ""          <path d='M14,4.5 L14,4 C14,3.44771525 13.5522847,3 13,3 L11,3 C10.4477153,3 10,3.44771525 10,4 L10,4.5 L5.5,4.5 C5.22385763,4.5 5,4.72385763 5,5 L5,5.5 C5,5.77614237 5.22385763,6 5.5,6 L18.5,6 C18.7761424,6 19,5.77614237 19,5.5 L19,5 C19,4.72385763 18.7761424,4.5 18.5,4.5 L14,4.5 Z'""
                                        + ""          fill='#000000'""
                                        + ""            opacity='0.3'></path>""
                                        + ""    </g>""
            ");
                WriteLiteral(@"                            + ""  </svg>""
                                        + "" </span>""
                                        + ""  </a>""
                                    );
                                }
                            },
                        ],
        ""fnServerParams"": function (aoData) {
            //aoData.push(

            //    { ""name"": ""Username"", ""value"": $('#Username').val() },

            //);

        }
                    });
                }
            }
            $(document).on(""click"", ""#btnSearch"", function () {
            Otables.draw();
        });
        $(document).ready(function () {
            Otable.init();
        });
    </script>

");
            }
            );
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<YabousNews.Data.Models.Contact>> Html { get; private set; }
    }
}
#pragma warning restore 1591