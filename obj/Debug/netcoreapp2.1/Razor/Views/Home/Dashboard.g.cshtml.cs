#pragma checksum "C:\Users\little silver\Desktop\C#-stack\Asp.net\Wedding_Planner\Views\Home\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2ab9937258574f1d1b354d8ae9332421b447425f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Dashboard), @"mvc.1.0.view", @"/Views/Home/Dashboard.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Dashboard.cshtml", typeof(AspNetCore.Views_Home_Dashboard))]
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
#line 1 "C:\Users\little silver\Desktop\C#-stack\Asp.net\Wedding_Planner\Views\_ViewImports.cshtml"
using Wedding_Planner;

#line default
#line hidden
#line 2 "C:\Users\little silver\Desktop\C#-stack\Asp.net\Wedding_Planner\Views\_ViewImports.cshtml"
using Wedding_Planner.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ab9937258574f1d1b354d8ae9332421b447425f", @"/Views/Home/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84b0732bfebbac067a62d1314c0d18406fc96ec4", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<WeddingPlan>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(26, 599, true);
            WriteLiteral(@"
<h1>Welcome to the Wedding Planner</h1>
<a href=""/logout"">Log out!</a>

 <center>
        <table class=""table table-striped col-sm-10 border"">

            <thead>
                <tr>
                    <th class='border-left border-right' scope=""col-2"">Wedding</th>
                    <th class='border-left border-right' scope=""col-1"">Date</th>
                    <th class='border-left border-right' scope=""col-1"">Guest</th>
                    <th class='border-left border-right' scope=""col-1"">Action</th>
                </tr>
            </thead>

            <tbody>

");
            EndContext();
#line 20 "C:\Users\little silver\Desktop\C#-stack\Asp.net\Wedding_Planner\Views\Home\Dashboard.cshtml"
               foreach(var x in Model){


#line default
#line hidden
            BeginContext(668, 122, true);
            WriteLiteral("                    <tr>   \r\n                        <td class=\'border-left border-right\'>\r\n                            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 790, "\"", 821, 2);
            WriteAttributeValue("", 797, "/detail/", 797, 8, true);
#line 24 "C:\Users\little silver\Desktop\C#-stack\Asp.net\Wedding_Planner\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 805, x.WeddingPlanId, 805, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(822, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(824, 11, false);
#line 24 "C:\Users\little silver\Desktop\C#-stack\Asp.net\Wedding_Planner\Views\Home\Dashboard.cshtml"
                                                          Write(x.WedderOne);

#line default
#line hidden
            EndContext();
            BeginContext(835, 3, true);
            WriteLiteral(" & ");
            EndContext();
            BeginContext(839, 11, false);
#line 24 "C:\Users\little silver\Desktop\C#-stack\Asp.net\Wedding_Planner\Views\Home\Dashboard.cshtml"
                                                                         Write(x.WedderTwo);

#line default
#line hidden
            EndContext();
            BeginContext(850, 98, true);
            WriteLiteral("</a>\r\n                        </td>\r\n                        <td class=\'border-left border-right\'>");
            EndContext();
            BeginContext(949, 6, false);
#line 26 "C:\Users\little silver\Desktop\C#-stack\Asp.net\Wedding_Planner\Views\Home\Dashboard.cshtml"
                                                        Write(x.Date);

#line default
#line hidden
            EndContext();
            BeginContext(955, 68, true);
            WriteLiteral("</td>\r\n                        <td class=\'border-left border-right\'>");
            EndContext();
            BeginContext(1024, 14, false);
#line 27 "C:\Users\little silver\Desktop\C#-stack\Asp.net\Wedding_Planner\Views\Home\Dashboard.cshtml"
                                                        Write(x.Guests.Count);

#line default
#line hidden
            EndContext();
            BeginContext(1038, 89, true);
            WriteLiteral("</td> \r\n                \r\n                        <td class=\'border-left border-right\'>\r\n");
            EndContext();
#line 30 "C:\Users\little silver\Desktop\C#-stack\Asp.net\Wedding_Planner\Views\Home\Dashboard.cshtml"
                         if(x.UserId==@ViewBag.userid){

#line default
#line hidden
            BeginContext(1184, 34, true);
            WriteLiteral("                                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1218, "\"", 1249, 2);
            WriteAttributeValue("", 1225, "/delete/", 1225, 8, true);
#line 31 "C:\Users\little silver\Desktop\C#-stack\Asp.net\Wedding_Planner\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 1233, x.WeddingPlanId, 1233, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1250, 13, true);
            WriteLiteral(">Delete</a>\r\n");
            EndContext();
#line 32 "C:\Users\little silver\Desktop\C#-stack\Asp.net\Wedding_Planner\Views\Home\Dashboard.cshtml"
                        }else{
                            

#line default
#line hidden
#line 33 "C:\Users\little silver\Desktop\C#-stack\Asp.net\Wedding_Planner\Views\Home\Dashboard.cshtml"
                             if(x.Guests.Any(r=>r.UserId==@ViewBag.userid)){

#line default
#line hidden
            BeginContext(1373, 38, true);
            WriteLiteral("                                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1411, "\"", 1443, 2);
            WriteAttributeValue("", 1418, "/un-rsvp/", 1418, 9, true);
#line 34 "C:\Users\little silver\Desktop\C#-stack\Asp.net\Wedding_Planner\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 1427, x.WeddingPlanId, 1427, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1444, 14, true);
            WriteLiteral(">Un-RSVP</a>\r\n");
            EndContext();
#line 35 "C:\Users\little silver\Desktop\C#-stack\Asp.net\Wedding_Planner\Views\Home\Dashboard.cshtml"
                            }else{

#line default
#line hidden
            BeginContext(1494, 38, true);
            WriteLiteral("                                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1532, "\"", 1561, 2);
            WriteAttributeValue("", 1539, "/rsvp/", 1539, 6, true);
#line 36 "C:\Users\little silver\Desktop\C#-stack\Asp.net\Wedding_Planner\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 1545, x.WeddingPlanId, 1545, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1562, 11, true);
            WriteLiteral(">RSVP</a>\r\n");
            EndContext();
#line 37 "C:\Users\little silver\Desktop\C#-stack\Asp.net\Wedding_Planner\Views\Home\Dashboard.cshtml"
                            }

#line default
#line hidden
#line 37 "C:\Users\little silver\Desktop\C#-stack\Asp.net\Wedding_Planner\Views\Home\Dashboard.cshtml"
                             
                        }

#line default
#line hidden
            BeginContext(1631, 59, true);
            WriteLiteral("                        </td> \r\n                    </tr>\r\n");
            EndContext();
#line 41 "C:\Users\little silver\Desktop\C#-stack\Asp.net\Wedding_Planner\Views\Home\Dashboard.cshtml"
                }

#line default
#line hidden
            BeginContext(1709, 108, true);
            WriteLiteral("            </tbody>\r\n\r\n        </table>\r\n    </center>\r\n    <button><a href=\"/new\">New Wedding</a></button>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<WeddingPlan>> Html { get; private set; }
    }
}
#pragma warning restore 1591
