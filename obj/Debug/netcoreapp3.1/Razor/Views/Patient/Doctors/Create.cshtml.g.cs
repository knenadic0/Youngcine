#pragma checksum "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Doctors\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7ba95b435befb8be99d445ce831cb586b44e15db"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Patient_Doctors_Create), @"mvc.1.0.view", @"/Views/Patient/Doctors/Create.cshtml")]
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
#line 1 "C:\Users\Kacko\source\repos\Mladacina\Views\_ViewImports.cshtml"
using Mladacina;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Kacko\source\repos\Mladacina\Views\_ViewImports.cshtml"
using Mladacina.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ba95b435befb8be99d445ce831cb586b44e15db", @"/Views/Patient/Doctors/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f39990cbfc43f8ca1f84b98495dbb7ebe0e527b", @"/Views/_ViewImports.cshtml")]
    public class Views_Patient_Doctors_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Mladacina.Models.PatientDoctor>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Doctors", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Doctors\Create.cshtml"
  
    ViewData["Title"] = "Doctor";
    ViewData["Role"] = "Patient";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    <div class=\"w-100 mt-lg-5 container-fluid\">\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-10\">\r\n                <h3 class=\"role\">My doctors</h3>\r\n            </div>\r\n            <div class=\"col-lg-2 text-right\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7ba95b435befb8be99d445ce831cb586b44e15db4253", async() => {
                WriteLiteral("\r\n                    <i class=\"fa fa-chevron-left\" aria-hidden=\"true\"></i>&nbsp;&nbsp;Back\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"mt-lg-4\">\r\n");
#nullable restore
#line 21 "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Doctors\Create.cshtml"
         using (Html.BeginForm())
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Doctors\Create.cshtml"
       Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"form-horizontal\">\r\n                <hr />\r\n                ");
#nullable restore
#line 27 "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Doctors\Create.cshtml"
           Write(Html.ValidationSummary(false, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 30 "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Doctors\Create.cshtml"
               Write(Html.LabelFor(model => model.DoctorId, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"col-md-12\">\r\n                        ");
#nullable restore
#line 32 "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Doctors\Create.cshtml"
                   Write(Html.DropDownListFor(model => model.DoctorId, (IEnumerable<SelectListItem>)ViewData["Doctors"], "Select Doctor", new { @class = "form-control", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 33 "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Doctors\Create.cshtml"
                   Write(Html.ValidationMessageFor(model => model.DoctorId, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </div>
                </div>

                <div class=""form-group"">
                    <div class=""col-md-2"">
                        <input type=""submit"" value=""Save"" class=""btn btn-info"" />
                    </div>
                </div>
            </div>
");
#nullable restore
#line 43 "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Doctors\Create.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Mladacina.Models.PatientDoctor> Html { get; private set; }
    }
}
#pragma warning restore 1591