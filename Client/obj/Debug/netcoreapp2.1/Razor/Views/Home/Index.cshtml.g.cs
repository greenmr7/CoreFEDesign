#pragma checksum "D:\MII\MCCOC\#7-Templating\tugas\CoreFEDesign\Client\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a52cd5a2484b8a7048a03cbc9b6b8f6f51e8a6ab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "D:\MII\MCCOC\#7-Templating\tugas\CoreFEDesign\Client\Views\_ViewImports.cshtml"
using Client;

#line default
#line hidden
#line 2 "D:\MII\MCCOC\#7-Templating\tugas\CoreFEDesign\Client\Views\_ViewImports.cshtml"
using Client.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a52cd5a2484b8a7048a03cbc9b6b8f6f51e8a6ab", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3332004e6f18ccbec22253d7e177fe1fd5f40969", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/site.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\MII\MCCOC\#7-Templating\tugas\CoreFEDesign\Client\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Dashboard";
    Layout = "~/Views/Layout/_Layout.cshtml";

#line default
#line hidden
            BeginContext(94, 56, true);
            WriteLiteral("\r\n<div class=\"page-header\">\r\n    <h4 class=\"page-title\">");
            EndContext();
            BeginContext(151, 17, false);
#line 8 "D:\MII\MCCOC\#7-Templating\tugas\CoreFEDesign\Client\Views\Home\Index.cshtml"
                      Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(168, 6486, true);
            WriteLiteral(@"</h4>
</div>
<div class=""row"">
    <div class=""col-sm-6 col-md-3"">
        <div class=""card card-stats card-round"">
            <div class=""card-body "">
                <div class=""row align-items-center"">
                    <div class=""col-icon"">
                        <div class=""icon-big text-center icon-primary bubble-shadow-small"">
                            <i class=""fas fa-users""></i>
                        </div>
                    </div>
                    <div class=""col col-stats ml-3 ml-sm-0"">
                        <div class=""numbers"">
                            <p class=""card-category"">Visitors</p>
                            <h4 class=""card-title"">1,294</h4>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""col-sm-6 col-md-3"">
        <div class=""card card-stats card-round"">
            <div class=""card-body"">
                <div class=""row align-items-center"">
       ");
            WriteLiteral(@"             <div class=""col-icon"">
                        <div class=""icon-big text-center icon-info bubble-shadow-small"">
                            <i class=""far fa-newspaper""></i>
                        </div>
                    </div>
                    <div class=""col col-stats ml-3 ml-sm-0"">
                        <div class=""numbers"">
                            <p class=""card-category"">Subscribers</p>
                            <h4 class=""card-title"">1303</h4>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""col-sm-6 col-md-3"">
        <div class=""card card-stats card-round"">
            <div class=""card-body"">
                <div class=""row align-items-center"">
                    <div class=""col-icon"">
                        <div class=""icon-big text-center icon-success bubble-shadow-small"">
                            <i class=""far fa-chart-bar""></i>
                        <");
            WriteLiteral(@"/div>
                    </div>
                    <div class=""col col-stats ml-3 ml-sm-0"">
                        <div class=""numbers"">
                            <p class=""card-category"">Sales</p>
                            <h4 class=""card-title"">$ 1,345</h4>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""col-sm-6 col-md-3"">
        <div class=""card card-stats card-round"">
            <div class=""card-body"">
                <div class=""row align-items-center"">
                    <div class=""col-icon"">
                        <div class=""icon-big text-center icon-secondary bubble-shadow-small"">
                            <i class=""far fa-check-circle""></i>
                        </div>
                    </div>
                    <div class=""col col-stats ml-3 ml-sm-0"">
                        <div class=""numbers"">
                            <p class=""card-category"">Order</p>
    ");
            WriteLiteral(@"                        <h4 class=""card-title"">576</h4>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<div class=""row"">
    <div class=""col-md-4"">
        <div class=""card"">
            <div class=""card-header"">
                <div class=""card-title"">Feed Activity</div>
            </div>
            <div class=""card-body"">
                <ol class=""activity-feed"">
                    <li class=""feed-item feed-item-secondary"">
                        <time class=""date"" datetime=""9-25"">Sep 25</time>
                        <span class=""text"">Responded to need <a href=""#"">""Volunteer opportunity""</a></span>
                    </li>
                    <li class=""feed-item feed-item-success"">
                        <time class=""date"" datetime=""9-24"">Sep 24</time>
                        <span class=""text"">Added an interest <a href=""#"">""Volunteer Activities""</a></span>
                    </li>
    ");
            WriteLiteral(@"                <li class=""feed-item feed-item-info"">
                        <time class=""date"" datetime=""9-23"">Sep 23</time>
                        <span class=""text"">Joined the group <a href=""single-group.php"">""Boardsmanship Forum""</a></span>
                    </li>
                    <li class=""feed-item feed-item-warning"">
                        <time class=""date"" datetime=""9-21"">Sep 21</time>
                        <span class=""text"">Responded to need <a href=""#"">""In-Kind Opportunity""</a></span>
                    </li>
                    <li class=""feed-item feed-item-danger"">
                        <time class=""date"" datetime=""9-18"">Sep 18</time>
                        <span class=""text"">Created need <a href=""#"">""Volunteer Opportunity""</a></span>
                    </li>
                    <li class=""feed-item"">
                        <time class=""date"" datetime=""9-17"">Sep 17</time>
                        <span class=""text"">Attending the event <a href=""single-event.php"">""So");
            WriteLiteral(@"me New Event""</a></span>
                    </li>
                </ol>
            </div>
        </div>
    </div>
    <div class=""col-md-8"">
        <div class=""card"">
            <div class=""card-header"">
                <div class=""card-head-row"">
                    <div class=""card-title"">User Statistics</div>
                    <div class=""card-tools"">
                        <a href=""#"" class=""btn btn-info btn-border btn-round btn-sm mr-2"">
                            <span class=""btn-label"">
                                <i class=""fa fa-pencil""></i>
                            </span>
                            Export
                        </a>
                        <a href=""#"" class=""btn btn-info btn-border btn-round btn-sm"">
                            <span class=""btn-label"">
                                <i class=""fa fa-print""></i>
                            </span>
                            Print
                        </a>
                    </div>
    ");
            WriteLiteral(@"            </div>
            </div>
            <div class=""card-body"">
                <div class=""chart-container"" style=""min-height: 375px"">
                    <canvas id=""statisticsChart""></canvas>
                </div>
                <div id=""myChartLegend""></div>
            </div>
        </div>
    </div>

</div>

");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(6671, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(6677, 36, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4089b48d5952449cba7768fa0b6b42cf", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(6713, 2, true);
                WriteLiteral("\r\n");
                EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
