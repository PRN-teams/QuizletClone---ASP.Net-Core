#pragma checksum "C:\Users\Macbook Pro\source\repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Room.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b480d075bc8d829961490e79b1cfee015b817999"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Flashcard_Room), @"mvc.1.0.view", @"/Views/Flashcard/Room.cshtml")]
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
#line 1 "C:\Users\Macbook Pro\source\repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Macbook Pro\source\repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b480d075bc8d829961490e79b1cfee015b817999", @"/Views/Flashcard/Room.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"729efaa87342638aecfe1a972ce9f9f8dff55b4c", @"/Views/_ViewImports.cshtml")]
    public class Views_Flashcard_Room : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("h5 font-weight-bold text-light text-decoration-none"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Flashcard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/credit-card.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:40px;height:40px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("mx-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Macbook Pro\source\repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Room.cshtml"
   ViewData["Title"] = $"Flashcard: {@ViewBag.Title}";

#line default
#line hidden
#nullable disable
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $(""#myCarousel"").carousel(""pause"");
            // Enable Carousel Controls
            $("".left"").click(function () {
                $(""#myCarousel"").carousel(""prev"");
            });
            $("".right"").click(function () {
                $(""#myCarousel"").carousel(""next"");
            });
            $("".start"").click(function () {
                $(""#myCarousel"").carousel(""next"");
                $(""#i"").addClass(""fa-pause"");
                a = true;
            });
            $(""#i"").removeClass(""fa-play"");
                 $(""#myCarousel"").on('slide.bs.carousel', function (event) {
                     console.log(event.from);
                $("".progress-bar"").css({ ""width"": ((event.from+1) * 100) / (100 *");
#nullable restore
#line 22 "C:\Users\Macbook Pro\source\repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Room.cshtml"
                                                                            Write(ViewBag.getQuiz.Count);

#line default
#line hidden
#nullable disable
                WriteLiteral(") * 100 +\"%\"});\r\n                $(\".totalquiz\").text((event.from + 1) + \"/\" +");
#nullable restore
#line 23 "C:\Users\Macbook Pro\source\repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Room.cshtml"
                                                        Write(ViewBag.getQuiz.Count);

#line default
#line hidden
#nullable disable
                WriteLiteral(");\r\n                if (event.from>= ");
#nullable restore
#line 24 "C:\Users\Macbook Pro\source\repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Room.cshtml"
                            Write(ViewBag.getQuiz.Count);

#line default
#line hidden
#nullable disable
                WriteLiteral(") {\r\n                     window.location.href = \'");
#nullable restore
#line 25 "C:\Users\Macbook Pro\source\repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Room.cshtml"
                                        Write(Url.Action("Congrats"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\'\r\n                }\r\n            });\r\n\r\n        });\r\n\r\n    </script>\r\n");
            }
            );
            WriteLiteral(@"    <style>
        * {
            color: white;
        }

        .card-container:hover .card-front {
            transform: rotateX(180deg);
        }

        .card-container:hover .card-back {
            transform: rotateX(0deg);
        }

        .card-back {
            transform: rotateX(-180deg);
        }

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

        .card-back .card-body {
            position: relative;
        }

        .card-front {
            text-align: center;
            align-content: center;
        }
    </style>
    <div class=""container"">
        <div class=""row"" style=""height:100vh;"">
            <div class=""col-md-3 pt-5 px-5 text-light d-flex flex-column bg-dark"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b480d075bc8d829961490e79b1cfee015b8179999092", async() => {
                WriteLiteral("<i class=\"fas fa-chevron-left\"></i> Return");
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
#line 75 "C:\Users\Macbook Pro\source\repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Room.cshtml"
                                                                                                                               WriteLiteral(TempData.Peek("getID"));

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
            WriteLiteral("\r\n                <h5 class=\"my-5 font-weight-bold\"> ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b480d075bc8d829961490e79b1cfee015b81799911750", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"Flashcard</h5>
                <div class=""progress"">
                    <div class=""progress-bar bg-info "" role=""progressbar"" aria-valuenow=""1"" aria-valuemin=""0"" aria-valuemax=""100""></div>
                </div>
                <div style=""display: flex; justify-content: space-between;"">
                    <h5 class=""my-2"">Progress</h5>
                    <h5 class=""my-2 totalquiz""> 0/");
#nullable restore
#line 82 "C:\Users\Macbook Pro\source\repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Room.cshtml"
                                             Write(ViewBag.getQuiz.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                </div>
                <a role=""button"" class=""btn btn-warning start"" style=""margin-top:80%"" data-slide=""next"" href=""#myCarousel""><i id=""i""class=""fas fa-play mr-3"" style=""color:white""></i>Start</a>
            </div>

            <div class=""col-md-9"">
                <div id=""myCarousel"" class=""carousel slide"">
                    <!-- Wrapper for slides -->
                    <div class=""carousel-inner"">

                        <div class=""carousel-item active pt-5"" style=""justify-content:center"">
                            <div class=""card-container"">
                                <div class=""card text-white bg-secondary mx-3 card-front mycard"" style=""width:54rem;height:35rem"">
                                    <div class=""card-body"" style=""display: flex; justify-content: center; align-items: center; "">
                                        <h3 class=""card-text "">");
#nullable restore
#line 96 "C:\Users\Macbook Pro\source\repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Room.cshtml"
                                                          Write(ViewBag.getFirst.Term);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                                    </div>
                                </div>
                                <div class=""card text-white bg-secondary mx-3 card-back mycard "" style=""width:54rem;height:35rem"">
                                    <div class=""card-body d-flex align-items-center justify-content-center"">
                                        <p class=""card-text h3 text-justify"" style=""width:43rem"">");
#nullable restore
#line 101 "C:\Users\Macbook Pro\source\repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Room.cshtml"
                                                                                            Write(ViewBag.getFirst.Definition);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n\r\n");
#nullable restore
#line 107 "C:\Users\Macbook Pro\source\repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Room.cshtml"
                         foreach (var item in ViewBag.getQuiz)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <div class=""carousel-item pt-5"" style=""justify-content:center"">
                                <div class=""card-container"">
                                    <div class=""card text-white bg-secondary mx-3 card-front mycard"" style=""width:54rem;height:35rem"">
                                        <div class=""card-body"" style=""display: flex; justify-content: center; align-items: center; "">
                                            <h3 class=""card-text"">");
#nullable restore
#line 113 "C:\Users\Macbook Pro\source\repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Room.cshtml"
                                                             Write(item.Term);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                                        </div>
                                    </div>
                                    <div class=""card text-white bg-secondary mx-3 card-back mycard"" style=""width:54rem;height:35rem"">
                                        <div class=""card-body d-flex align-items-center"">
                                            <p class=""card-text h3 text-justify"" style=""width:43rem"">");
#nullable restore
#line 118 "C:\Users\Macbook Pro\source\repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Room.cshtml"
                                                                                                Write(item.Definition);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 123 "C:\Users\Macbook Pro\source\repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Flashcard\Room.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </div>
                </div>
                <!-- Left and right controls -->
                <div class=""pt-4"" style=""margin-left:47%"">
                    <a role=""button"" class=""btn btn-info mr-3 left"" data-slide=""prev"" href=""#myCarousel""><i class=""fas fa-chevron-left""></i></a>
                    <a role=""button"" class=""btn btn-info right"" data-slide=""next"" href=""#myCarousel""><i class=""fas fa-chevron-right""></i></a>
                </div>

            </div>

        </div>
    </div>
");
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
