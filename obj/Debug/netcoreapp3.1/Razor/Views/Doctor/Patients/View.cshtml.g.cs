#pragma checksum "C:\Users\Kacko\source\repos\Mladacina\Views\Doctor\Patients\View.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c3bf48ca5d1ed2ffcc189fd34fb5d4d956773c96"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Doctor_Patients_View), @"mvc.1.0.view", @"/Views/Doctor/Patients/View.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c3bf48ca5d1ed2ffcc189fd34fb5d4d956773c96", @"/Views/Doctor/Patients/View.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f39990cbfc43f8ca1f84b98495dbb7ebe0e527b", @"/Views/_ViewImports.cshtml")]
    public class Views_Doctor_Patients_View : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Mladacina.Models.Visit>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Patients", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "VisitCreate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "FinishDiagnose", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-toggle", new global::Microsoft.AspNetCore.Html.HtmlString("tooltip"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-placement", new global::Microsoft.AspNetCore.Html.HtmlString("top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Mark as healed"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Kacko\source\repos\Mladacina\Views\Doctor\Patients\View.cshtml"
  
    ViewData["Title"] = "Patients";
    ViewData["Role"] = "Doctor";
    var patient = (Patient)ViewData["Patient"];

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    <div class=\"w-100 mt-lg-5 container-fluid\">\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-9\">\r\n                <h3 class=\"role\">");
#nullable restore
#line 12 "C:\Users\Kacko\source\repos\Mladacina\Views\Doctor\Patients\View.cshtml"
                            Write(patient.User.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 12 "C:\Users\Kacko\source\repos\Mladacina\Views\Doctor\Patients\View.cshtml"
                                                    Write(patient.User.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\'s visits</h3>\r\n            </div>\r\n            <div class=\"col-lg-3 text-right\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c3bf48ca5d1ed2ffcc189fd34fb5d4d956773c966475", async() => {
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
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c3bf48ca5d1ed2ffcc189fd34fb5d4d956773c967840", async() => {
                WriteLiteral("\r\n                    <i class=\"fa fa-plus\" aria-hidden=\"true\"></i>&nbsp;&nbsp;New\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"container-fluid mt-lg-5\">\r\n");
#nullable restore
#line 25 "C:\Users\Kacko\source\repos\Mladacina\Views\Doctor\Patients\View.cshtml"
         if (Model != null && Model.Count > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <table class=""table table-hover mt-4"" id=""visitsTable"">
                <thead>
                    <tr>
                        <th class=""w-10"">Doctor</th>
                        <th class=""w-30"">Sympthoms</th>
                        <th class=""w-15"">Diagnosis</th>
                        <th class=""w-10"">Date</th>
                        <th class=""w-10 text-center"">Healed</th>
                        <th class=""w-15"">Prescriptions</th>
                        <th class=""w-10"">Finish</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 40 "C:\Users\Kacko\source\repos\Mladacina\Views\Doctor\Patients\View.cshtml"
                     foreach (Visit item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td class=\"align-middle\">");
#nullable restore
#line 43 "C:\Users\Kacko\source\repos\Mladacina\Views\Doctor\Patients\View.cshtml"
                                                Write(item.PatientDoctor.Doctor.User.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 43 "C:\Users\Kacko\source\repos\Mladacina\Views\Doctor\Patients\View.cshtml"
                                                                                          Write(item.PatientDoctor.Doctor.User.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"align-middle\">");
#nullable restore
#line 44 "C:\Users\Kacko\source\repos\Mladacina\Views\Doctor\Patients\View.cshtml"
                                                Write(item.Sympthoms);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"align-middle\">");
#nullable restore
#line 45 "C:\Users\Kacko\source\repos\Mladacina\Views\Doctor\Patients\View.cshtml"
                                                Write(item.Diagnosis);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"align-middle\">");
#nullable restore
#line 46 "C:\Users\Kacko\source\repos\Mladacina\Views\Doctor\Patients\View.cshtml"
                                                Write(item.DateFrom.ToNormalDate());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"align-middle text-center\">\r\n");
#nullable restore
#line 48 "C:\Users\Kacko\source\repos\Mladacina\Views\Doctor\Patients\View.cshtml"
                                 if (item.DateTo.HasValue)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span>");
#nullable restore
#line 50 "C:\Users\Kacko\source\repos\Mladacina\Views\Doctor\Patients\View.cshtml"
                                     Write(item.DateTo.Value.ToNormalDate());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 51 "C:\Users\Kacko\source\repos\Mladacina\Views\Doctor\Patients\View.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span>&infin;</span>\r\n");
#nullable restore
#line 55 "C:\Users\Kacko\source\repos\Mladacina\Views\Doctor\Patients\View.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </td>\r\n");
#nullable restore
#line 57 "C:\Users\Kacko\source\repos\Mladacina\Views\Doctor\Patients\View.cshtml"
                             if (item.Prescriptions.Count > 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td class=\"align-middle\">\r\n");
#nullable restore
#line 60 "C:\Users\Kacko\source\repos\Mladacina\Views\Doctor\Patients\View.cshtml"
                                     foreach (Prescription prescription in item.Prescriptions)
                                    {
                                        string measureUnit = prescription.Medicine.Type == MedicineType.Syrup ? "ml" : "pcs";

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span class=\"d-block\">\r\n                                            ");
#nullable restore
#line 64 "C:\Users\Kacko\source\repos\Mladacina\Views\Doctor\Patients\View.cshtml"
                                       Write(prescription.Medicine.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (");
#nullable restore
#line 64 "C:\Users\Kacko\source\repos\Mladacina\Views\Doctor\Patients\View.cshtml"
                                                                    Write(prescription.Medicine.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 64 "C:\Users\Kacko\source\repos\Mladacina\Views\Doctor\Patients\View.cshtml"
                                                                                                    Write(measureUnit);

#line default
#line hidden
#nullable disable
            WriteLiteral(")\r\n                                        </span>\r\n");
#nullable restore
#line 66 "C:\Users\Kacko\source\repos\Mladacina\Views\Doctor\Patients\View.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </td>\r\n");
#nullable restore
#line 68 "C:\Users\Kacko\source\repos\Mladacina\Views\Doctor\Patients\View.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td class=\"align-middle text-center\">/</td>\r\n");
#nullable restore
#line 72 "C:\Users\Kacko\source\repos\Mladacina\Views\Doctor\Patients\View.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td class=\"align-middle text-center\">\r\n");
#nullable restore
#line 74 "C:\Users\Kacko\source\repos\Mladacina\Views\Doctor\Patients\View.cshtml"
                                 if (!item.DateTo.HasValue)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c3bf48ca5d1ed2ffcc189fd34fb5d4d956773c9616393", async() => {
                WriteLiteral("\r\n                                        <i class=\"fa fa-check\" aria-hidden=\"true\"></i>\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 76 "C:\Users\Kacko\source\repos\Mladacina\Views\Doctor\Patients\View.cshtml"
                                                                     WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 79 "C:\Users\Kacko\source\repos\Mladacina\Views\Doctor\Patients\View.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 82 "C:\Users\Kacko\source\repos\Mladacina\Views\Doctor\Patients\View.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n");
#nullable restore
#line 85 "C:\Users\Kacko\source\repos\Mladacina\Views\Doctor\Patients\View.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"card-body m-5\">\r\n                <h5 class=\"text-center m-5\">Patient hasn\'t visited any doctor yet.</h5>\r\n            </div>\r\n");
#nullable restore
#line 91 "C:\Users\Kacko\source\repos\Mladacina\Views\Doctor\Patients\View.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script src=""http://cdn.datatables.net/1.10.23/js/jquery.dataTables.min.js""></script>
    <script>
        $(document).ready(function () {
            $('#visitsTable').DataTable();
            $('[data-toggle=""tooltip""]').tooltip();
        });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Mladacina.Models.Visit>> Html { get; private set; }
    }
}
#pragma warning restore 1591
