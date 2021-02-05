#pragma checksum "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Visits\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a3a7deff716631859bb8ff2104613a6e79ce6d74"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Patient_Visits_Index), @"mvc.1.0.view", @"/Views/Patient/Visits/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3a7deff716631859bb8ff2104613a6e79ce6d74", @"/Views/Patient/Visits/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f39990cbfc43f8ca1f84b98495dbb7ebe0e527b", @"/Views/_ViewImports.cshtml")]
    public class Views_Patient_Visits_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Mladacina.Models.Visit>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Visits\Index.cshtml"
  
    ViewData["Title"] = "Visits";
    ViewData["Role"] = "Patient";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div>
    <div class=""w-100 mt-lg-5 container-fluid"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <h3 class=""role"">My visits</h3>
            </div>
        </div>
    </div>
    <div class=""container-fluid mt-lg-5"">
");
#nullable restore
#line 16 "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Visits\Index.cshtml"
         if (Model != null && Model.Count > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <table class=""table table-hover mt-4"" id=""visitsTable"">
                <thead>
                    <tr>
                        <th class=""w-10"">Doctor</th>
                        <th class=""w-35"">Sympthoms</th>
                        <th class=""w-20"">Diagnosis</th>
                        <th class=""w-10"">Date</th>
                        <th class=""w-10 text-center"">Healed</th>
                        <th class=""w-15"">Prescriptions</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 30 "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Visits\Index.cshtml"
                     foreach (Visit item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td class=\"align-middle\">");
#nullable restore
#line 33 "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Visits\Index.cshtml"
                                                Write(item.PatientDoctor.Doctor.User.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 33 "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Visits\Index.cshtml"
                                                                                          Write(item.PatientDoctor.Doctor.User.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"align-middle\">");
#nullable restore
#line 34 "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Visits\Index.cshtml"
                                                Write(item.Sympthoms);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"align-middle\">");
#nullable restore
#line 35 "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Visits\Index.cshtml"
                                                Write(item.Diagnosis);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"align-middle\">");
#nullable restore
#line 36 "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Visits\Index.cshtml"
                                                Write(item.DateFrom.ToNormalDate());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"align-middle text-center\">\r\n");
#nullable restore
#line 38 "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Visits\Index.cshtml"
                                 if (item.DateTo.HasValue)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span>");
#nullable restore
#line 40 "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Visits\Index.cshtml"
                                     Write(item.DateTo.Value.ToNormalDate());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 41 "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Visits\Index.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span>&infin;</span>\r\n");
#nullable restore
#line 45 "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Visits\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </td>\r\n");
#nullable restore
#line 47 "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Visits\Index.cshtml"
                             if (item.Prescriptions.Count > 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td class=\"align-middle\">\r\n");
#nullable restore
#line 50 "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Visits\Index.cshtml"
                                     foreach (Prescription prescription in item.Prescriptions)
                                    {
                                        string measureUnit = prescription.Medicine.Type == MedicineType.Syrup ? "ml" : "pcs";

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span class=\"d-block\">\r\n                                            ");
#nullable restore
#line 54 "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Visits\Index.cshtml"
                                       Write(prescription.Medicine.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (");
#nullable restore
#line 54 "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Visits\Index.cshtml"
                                                                    Write(prescription.Medicine.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 54 "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Visits\Index.cshtml"
                                                                                                    Write(measureUnit);

#line default
#line hidden
#nullable disable
            WriteLiteral(")\r\n                                        </span>\r\n");
#nullable restore
#line 56 "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Visits\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </td>\r\n");
#nullable restore
#line 58 "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Visits\Index.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td class=\"align-middle text-center\">/</td>\r\n");
#nullable restore
#line 62 "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Visits\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tr>\r\n");
#nullable restore
#line 64 "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Visits\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n");
#nullable restore
#line 67 "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Visits\Index.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"card-body m-5\">\r\n                <h5 class=\"text-center m-5\">No visits yet.</h5>\r\n            </div>\r\n");
#nullable restore
#line 73 "C:\Users\Kacko\source\repos\Mladacina\Views\Patient\Visits\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script src=\"http://cdn.datatables.net/1.10.23/js/jquery.dataTables.min.js\"></script>\r\n    <script>\r\n        $(document).ready(function () {\r\n            $(\'#visitsTable\').DataTable();\r\n        });\r\n    </script>\r\n");
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