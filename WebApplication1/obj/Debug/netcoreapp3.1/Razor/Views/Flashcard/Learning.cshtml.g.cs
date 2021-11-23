#pragma checksum "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Learning.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e197c1c6f3ab72c33b42f92335f790b889537613"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Flashcard_Learning), @"mvc.1.0.view", @"/Views/Flashcard/Learning.cshtml")]
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
#line 1 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e197c1c6f3ab72c33b42f92335f790b889537613", @"/Views/Flashcard/Learning.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"729efaa87342638aecfe1a972ce9f9f8dff55b4c", @"/Views/_ViewImports.cshtml")]
    public class Views_Flashcard_Learning : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-decoration-none"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Flashcard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Learning.cshtml"
  ViewData["Title"] = $"Learning: {@ViewBag.Title}"; 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    .card-container {
        position: relative;
        perspective: 200rem;
        height: 35rem;
        width: 54rem;
    }

    .mycard {
        position: absolute;
        transition: all 0.9s;
        backface-visibility: hidden;
    }

    .btn-outline-primary:hover {
        background: #38528c;
    }
</style>
");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        function change(o) {
            o.style.backgroundColor = ""green"";
        };
        function changes(o) {
            o.style.backgroundColor = ""red"";
        };

        const OnEvent = (doc) => {
            return {
                on: (event, selector, callback) => {
                    doc.addEventListener('click', (event) => {
                        if (!event.target.matches(selector)) return;
                        callback.call(event.target, event);
                    }, false);
                }
            }
        };

        OnEvent(document).on('click', '.btn', function (e) {
            if (e.target.id == ""true"") {
                $(""#myCarousel"").carousel(""next"");
                $("".alert"").css(""visibility"", ""hidden"");
            } else {
                $("".alert"").css(""visibility"", ""visible"");
            }
        });

         $(""#myCarousel"").on('slide.bs.carousel', function (event) {
             $("".progress-bar"").css({ ""width""");
                WriteLiteral(": ((event.from + 1) * 100) / (100 *");
#nullable restore
#line 50 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Learning.cshtml"
                                                                           Write(ViewBag.getQuiz.Count);

#line default
#line hidden
#nullable disable
                WriteLiteral(") * 100 + \"%\" });\r\n             console.log(event.from +\" \"+");
#nullable restore
#line 51 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Learning.cshtml"
                                    Write(ViewBag.getQuiz.Count);

#line default
#line hidden
#nullable disable
                WriteLiteral(" );\r\n\r\n                if (event.from>= ");
#nullable restore
#line 53 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Learning.cshtml"
                            Write(ViewBag.getQuiz.Count);

#line default
#line hidden
#nullable disable
                WriteLiteral("-1) {\r\n                     window.location.href = \'");
#nullable restore
#line 54 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Learning.cshtml"
                                        Write(Url.Action("Congrats"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\'\r\n                }\r\n         });\r\n        $(document).ready(function () {\r\n            $(\"#myCarousel\").carousel(\"pause\");\r\n        })\r\n    </script>\r\n    ");
            }
            );
            WriteLiteral(@"    <div class=""container"">
        <div class=""progress mt-4"" style=""background-color:black"">
            <div class=""progress-bar bg-primary"" style=""height:50%"" role=""progressbar"" aria-valuenow=""75"" aria-valuemin=""0"" aria-valuemax=""100""></div>
        </div>
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e197c1c6f3ab72c33b42f92335f790b8895376137855", async() => {
                WriteLiteral("<i class=\"fas fa-times fa-2x\" style=\"color:white\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 66 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Learning.cshtml"
                                                                                        WriteLiteral(ViewBag.getID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    </div>

    <div class=""container my-2 d-flex justify-content-center"">
        <div id=""myCarousel"" class=""carousel slide"">
            <!-- Wrapper for slides -->
            <div class=""carousel-inner"">

                <div class=""carousel-item active"" style=""justify-content:center"">
                    <div class=""card-container"">
                        <div class=""card text-white bg-secondary mx-3 card-front mycard"" style=""width:54rem;height:35rem"">
                            <div class=""card-header mt-5 mx-4 bg-secondary"" style="" border:none"">
                                <h3 class=""card-title""> ");
#nullable restore
#line 78 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Learning.cshtml"
                                                   Write(ViewBag.getFirst.Definition);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                            </div>
                            <div class=""mt-5 pt-5"">
                                <h4 class=""text-warning font-weight-bold ml-5"">Choose the correct answer:</h4>
                                <div style=""display: grid; grid-template-columns: auto auto;"" class=""mt-3"">
");
#nullable restore
#line 83 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Learning.cshtml"
                                     foreach (var item in @ViewBag.MultipleChoiceSet[0])
                                    {
                                        if (item.Term.Equals(ViewBag.getFirst.Term))
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <button type=\"button\" id=\"true\" onclick=\"change(this)\"  class=\"h3 btn btn-outline-light text-light mx-5 my-2 py-3 px-3\">");
#nullable restore
#line 87 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Learning.cshtml"
                                                                                                                                                               Write(item.Term);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n");
#nullable restore
#line 88 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Learning.cshtml"

                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <button type=\"button\" id=\"false\" onclick=\"changes(this)\" class=\"h3 btn btn-outline-light text-light mx-5 my-2 py-3 px-3\">");
#nullable restore
#line 92 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Learning.cshtml"
                                                                                                                                                                Write(item.Term);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n");
#nullable restore
#line 93 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Learning.cshtml"
                                        }

                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </div>
                            </div>
                            <div class=""alert alert-light bg-info text-light""role=""alert"" style=""visibility:hidden"">
                                Wrong answer, chosing again please :((!
                            </div>
                        </div>
                    </div>
                </div>
");
#nullable restore
#line 104 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Learning.cshtml"
                 for (int i = 1; i < @ViewBag.MultipleChoiceSet.Count; i++)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""carousel-item"" style=""justify-content:center"">
                        <div class=""card-container"">
                            <div class=""card text-white bg-secondary mx-3 card-front mycard"" style=""width:54rem;height:35rem"">
                                <div class=""card-header mt-5 mx-4 bg-secondary"" style="" border:none"">
                                    <h3 class=""card-title"">");
#nullable restore
#line 110 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Learning.cshtml"
                                                      Write(ViewBag.getQuiz[i].Definition);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                                </div>
                                <div class=""mt-5 pt-5"">
                                    <h4 class=""text-warning"">Choose the correct answer:</h4>
                                    <div style=""display: grid; grid-template-columns: auto auto;"" class=""mt-3"">
");
#nullable restore
#line 115 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Learning.cshtml"
                                         foreach (var item in @ViewBag.MultipleChoiceSet[i])
                                        {
                                            if (item.Term.Equals(ViewBag.getQuiz[i].Term))
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <button type=\"button\" id=\"true\" onclick=\"change(this)\" class=\"h3 btn btn-outline-light text-light mx-5 my-2 py-3 px-3\">");
#nullable restore
#line 119 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Learning.cshtml"
                                                                                                                                                                  Write(item.Term);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n");
#nullable restore
#line 120 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Learning.cshtml"

                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <button type=\"button\" id=\"false\" onclick=\"changes(this)\" class=\"h3 btn btn-outline-light text-light mx-5 my-2 py-3 px-3\">");
#nullable restore
#line 124 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Learning.cshtml"
                                                                                                                                                                    Write(item.Term);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n");
#nullable restore
#line 125 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Learning.cshtml"
                                            }
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    </div>
                                </div>
                                <div class=""alert alert-light bg-info text-light"" role=""alert"" style=""visibility:hidden"">
                                    Wrong answer, chosing again please :((!
                                </div>
                            </div>
                        </div>
                    </div>
");
#nullable restore
#line 135 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Learning.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n\r\n    </div>\r\n");
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
