#pragma checksum "C:\Users\Kacko\source\repos\Mladacina\Views\Pharmacist\Medicine\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5c1c48813c7f8914a038e37bd9abc3d3331ac3b6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pharmacist_Medicine_Create), @"mvc.1.0.view", @"/Views/Pharmacist/Medicine/Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c1c48813c7f8914a038e37bd9abc3d3331ac3b6", @"/Views/Pharmacist/Medicine/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f39990cbfc43f8ca1f84b98495dbb7ebe0e527b", @"/Views/_ViewImports.cshtml")]
    public class Views_Pharmacist_Medicine_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Mladacina.Models.Medicine>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Medicine", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Kacko\source\repos\Mladacina\Views\Pharmacist\Medicine\Create.cshtml"
  
    ViewData["Title"] = "Medicine";
    ViewData["Role"] = "Pharmacist";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    <div class=\"w-100 mt-lg-5 container-fluid\">\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-10\">\r\n                <h3 class=\"role\">Medicine</h3>\r\n            </div>\r\n            <div class=\"col-lg-2 text-right\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5c1c48813c7f8914a038e37bd9abc3d3331ac3b64276", async() => {
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
#line 21 "C:\Users\Kacko\source\repos\Mladacina\Views\Pharmacist\Medicine\Create.cshtml"
         using (Html.BeginForm())
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\Kacko\source\repos\Mladacina\Views\Pharmacist\Medicine\Create.cshtml"
       Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"form-horizontal\">\r\n            <hr />\r\n            ");
#nullable restore
#line 27 "C:\Users\Kacko\source\repos\Mladacina\Views\Pharmacist\Medicine\Create.cshtml"
       Write(Html.ValidationSummary(false, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 30 "C:\Users\Kacko\source\repos\Mladacina\Views\Pharmacist\Medicine\Create.cshtml"
           Write(Html.LabelFor(model => model.Name, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-12\">\r\n                    ");
#nullable restore
#line 32 "C:\Users\Kacko\source\repos\Mladacina\Views\Pharmacist\Medicine\Create.cshtml"
               Write(Html.EditorFor(model => model.Name, new { htmlAttributes = new { @class = "form-control", @required = "required" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 33 "C:\Users\Kacko\source\repos\Mladacina\Views\Pharmacist\Medicine\Create.cshtml"
               Write(Html.ValidationMessageFor(model => model.Name, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 38 "C:\Users\Kacko\source\repos\Mladacina\Views\Pharmacist\Medicine\Create.cshtml"
           Write(Html.LabelFor(model => model.Type, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-12\">\r\n                    ");
#nullable restore
#line 40 "C:\Users\Kacko\source\repos\Mladacina\Views\Pharmacist\Medicine\Create.cshtml"
               Write(Html.DropDownListFor(model => model.Type, new SelectList(Enum.GetValues(typeof(MedicineType))), new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 41 "C:\Users\Kacko\source\repos\Mladacina\Views\Pharmacist\Medicine\Create.cshtml"
               Write(Html.ValidationMessageFor(model => model.Type, "", new { htmlAttributes = new { @class = "text-danger", @required = "required" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 46 "C:\Users\Kacko\source\repos\Mladacina\Views\Pharmacist\Medicine\Create.cshtml"
           Write(Html.Label("Price", "Price (HRK)", htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-12\">\r\n                    ");
#nullable restore
#line 48 "C:\Users\Kacko\source\repos\Mladacina\Views\Pharmacist\Medicine\Create.cshtml"
               Write(Html.EditorFor(model => model.Price, new { htmlAttributes = new { @class = "form-control", @required = "required", @type = "number", @step = ".01" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 49 "C:\Users\Kacko\source\repos\Mladacina\Views\Pharmacist\Medicine\Create.cshtml"
               Write(Html.ValidationMessageFor(model => model.Price, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 54 "C:\Users\Kacko\source\repos\Mladacina\Views\Pharmacist\Medicine\Create.cshtml"
           Write(Html.Label("Quantity", "Quantity (pcs)", htmlAttributes: new { @class = "control-label col-md-2", @id = "quantityLabel" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-12\">\r\n                    ");
#nullable restore
#line 56 "C:\Users\Kacko\source\repos\Mladacina\Views\Pharmacist\Medicine\Create.cshtml"
               Write(Html.EditorFor(model => model.Quantity, new { htmlAttributes = new { @class = "form-control", @required = "required" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 57 "C:\Users\Kacko\source\repos\Mladacina\Views\Pharmacist\Medicine\Create.cshtml"
               Write(Html.ValidationMessageFor(model => model.Quantity, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 62 "C:\Users\Kacko\source\repos\Mladacina\Views\Pharmacist\Medicine\Create.cshtml"
           Write(Html.Label("WithoutPrescription", "Without Prescription", htmlAttributes: new { @class = "control-label col-md-12" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-12\">\r\n                    ");
#nullable restore
#line 64 "C:\Users\Kacko\source\repos\Mladacina\Views\Pharmacist\Medicine\Create.cshtml"
               Write(Html.EditorFor(model => model.WithoutPrescription, new { htmlAttributes = new { @class = "form-control checkbox" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 65 "C:\Users\Kacko\source\repos\Mladacina\Views\Pharmacist\Medicine\Create.cshtml"
               Write(Html.ValidationMessageFor(model => model.WithoutPrescription, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 70 "C:\Users\Kacko\source\repos\Mladacina\Views\Pharmacist\Medicine\Create.cshtml"
           Write(Html.LabelFor(model => model.Description, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-md-12\">\r\n                    ");
#nullable restore
#line 72 "C:\Users\Kacko\source\repos\Mladacina\Views\Pharmacist\Medicine\Create.cshtml"
               Write(Html.EditorFor(model => model.Description, new { htmlAttributes = new { @class = "form-control", @required = "required" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 73 "C:\Users\Kacko\source\repos\Mladacina\Views\Pharmacist\Medicine\Create.cshtml"
               Write(Html.ValidationMessageFor(model => model.Description, "", new { @class = "text-danger" }));

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
#line 83 "C:\Users\Kacko\source\repos\Mladacina\Views\Pharmacist\Medicine\Create.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
<script>
    $(document).ready(function () {
        $(""#Type"").change(function () {
            var type = $(this).val();
            switch (type) {
                case ""Syrup"":
                    $(""#quantityLabel"").text('Quantity (ml)');
                    break;
                default:
                    $(""#quantityLabel"").text('Quantity (pcs)');
                    break;
            }
        })
        $(""#Type"").change();
    })
</script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Mladacina.Models.Medicine> Html { get; private set; }
    }
}
#pragma warning restore 1591