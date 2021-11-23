#pragma checksum "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Home\Register.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3fed8ad0e7ce276ff846f93f901e77b5fe7d503f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Register), @"mvc.1.0.view", @"/Views/Home/Register.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3fed8ad0e7ce276ff846f93f901e77b5fe7d503f", @"/Views/Home/Register.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"729efaa87342638aecfe1a972ce9f9f8dff55b4c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Register : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApplication1.Models.User>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("mx-1 mx-md-4"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Home\Register.cshtml"
  
    ViewData["Title"] = "Register";

#line default
#line hidden
#nullable disable
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        //Preview Avatar goes here
        imgInp.onchange = evt => {
            const [file] = imgInp.files
            if (file) {
                blah.src = URL.createObjectURL(file)
            }
        }

        //Avatar file goes here
        const url = ""https://api.cloudinary.com/v1_1/djhjuqgne/image/upload/?upload_preset=yfm96suk"";
        const form = document.querySelector(""#form"");

        form.addEventListener(""submit"", (e) => {
            e.preventDefault();

            const files = document.querySelector(""[type=file]"").files;
            const formData = new FormData();

            for (let i = 0; i < files.length; i++) {
                let file = files[i];
                formData.append(""file"", file);
                formData.append(""upload_preset"", ""docs_upload_example_us_preset"");

                fetch(url, {
                    method: ""POST"",
                    body: formData
                })
                    .then((response) => {");
                WriteLiteral(@"
                        return response.text();
                    })

                    .then((data) => {
                        console.log(data)
                        const object = JSON.parse(data)
                        document.getElementById(""data"").value = object.url;
                    });
            }
        });

        //Datetime picker goes here
        $(function () {
            $(""#datepicker"").datepicker();
        });

        //Password validation
        var password = $('.password');
            var confirm = $('.confirmpw');
            var btn = $('.register');
        btn.click(function (e) {
                if (password.val().localeCompare(confirm.val()) !== 0) {
                    $("".alert-danger"").css(""display"", ""inline-block"");
                    e.preventDefault();
                } 
                else {
                    $("".alert-danger"").css(""display"", ""none"");
                    $("".validate_year"").css(""display"", ""none"");
       ");
                WriteLiteral("         };\r\n            });\r\n\r\n    </script>\r\n");
            }
            );
            WriteLiteral(@"<section class=""vh-100 mt-2"">
    <div class=""container h-100"">
        <div class=""row d-flex justify-content-center align-items-center h-100"">
            <div class=""col-lg-12 col-xl-11"">
                <div class=""card text-black"" style=""border-radius: 25px;"">
                    <div class=""card-body p-md-5"">
                        <div class=""row justify-content-center"">
                            <div class=""col-md-10 col-lg-6 col-xl-5 order-2 order-lg-1"">

                                <p class=""text-center h1 fw-bold mb-5 mx-1 mx-md-4 mt-4"">Sign up</p>
");
#nullable restore
#line 78 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Home\Register.cshtml"
                                 using (Html.BeginForm("Register", "Home", FormMethod.Post))
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3fed8ad0e7ce276ff846f93f901e77b5fe7d503f8215", async() => {
                WriteLiteral(@"
                                        <div class=""d-flex flex-row align-items-center mb-4"">
                                            <i class=""fas fa-user fa-lg me-3 fa-fw""></i>
                                            <div class=""form-outline flex-fill mb-0"">
                                                ");
#nullable restore
#line 84 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Home\Register.cshtml"
                                           Write(Html.TextBoxFor(model => model.Username, new { @required = "required", @type = "text", @id = "form3Example4cd", @class = "form-control", @placeholder = "Your Name" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                            </div>
                                        </div>

                                        <div class=""d-flex flex-row align-items-center mb-4"">
                                            <i class=""fas fa-envelope fa-lg me-3 fa-fw""></i>
                                            <div class=""form-outline flex-fill mb-0"">
                                                ");
#nullable restore
#line 91 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Home\Register.cshtml"
                                           Write(Html.TextBoxFor(model => model.Email, new { @required = "required", @type = "email", @id = "form3Example4cd", @class = "form-control", @placeholder = "Your Email" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                            </div>
                                        </div>

                                        <div class=""d-flex flex-row align-items-center mb-4"">
                                            <i class=""fas fa-lock fa-lg me-3 fa-fw""></i>
                                            <div class=""form-outline flex-fill mb-0"">
                                                ");
#nullable restore
#line 98 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Home\Register.cshtml"
                                           Write(Html.TextBox("password", null, new { @required = "required", @class = "form-control password", @type = "password", @placeholder = "Password", @id = "form3Example4c" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                            </div>
                                        </div>

                                        <div class=""d-flex flex-row align-items-center mb-4"">
                                            <i class=""fas fa-key fa-lg me-3 fa-fw""></i>
                                            <div class=""form-outline flex-fill mb-0"">
                                                ");
#nullable restore
#line 105 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Home\Register.cshtml"
                                           Write(Html.TextBoxFor(model => model.Password, new { @required = "required", @type = "password", @id = "form3Example4cd", @class = "form-control confirmpw", @placeholder = "Repeat your password" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                            </div>
                                        </div>

                                        <div class=""d-flex flex-row align-items-center mb-4"">
                                            <i class=""fas fa-user-astronaut fa-lg me-3 fa-fw""></i>
                                            <div class=""form-outline flex-fill mb-0"">
                                                ");
#nullable restore
#line 112 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Home\Register.cshtml"
                                           Write(Html.TextBoxFor(model => model.AvatarUrl, new { @required = "required", @readonly = "readonly", @type = "text", @id = "data", @class = "form-control text-success", @placeholder = "Avatar Url goes here" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                            </div>
                                        </div>


                                        <div class=""d-flex flex-row align-items-center mb-4"">
                                            <i class=""fas fa-birthday-cake fa-lg me-3 fa-fw""></i>
                                            <div class='input-group date' id='datetimepicker1'>
                                                ");
#nullable restore
#line 120 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Home\Register.cshtml"
                                           Write(Html.TextBoxFor(model => model.Dob, new { @required = "required", @type = "date", @name = "DueDate", @class = "form-control", @id = "datepicker" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                                <span class=""input-group-addon"">
                                                    <span class=""glyphicon glyphicon-calendar""></span>
                                                </span>
                                            </div>
                                        </div>
                                        <div class=""d-flex justify-content-center mx-4 mb-3 mb-lg-4"">
                                            <button type=""submit"" class=""btn btn-primary btn-lg register"">Register</button>
                                        </div>

                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 131 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Home\Register.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <div class=""alert alert-danger"" role=""alert"" style=""display:none"">
                                    Your password and confirm password are not match!
                                    Please enter again!!
                                </div>
");
#nullable restore
#line 136 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Home\Register.cshtml"
                                 if (ViewBag.ValidYear != null)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div class=\"alert alert-warning\" role=\"alert\">\r\n                                        ");
#nullable restore
#line 139 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Home\Register.cshtml"
                                   Write(ViewBag.ValidYear);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </div>\r\n");
#nullable restore
#line 141 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Home\Register.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 142 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Home\Register.cshtml"
                                     if (ViewBag.Err != null)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <div class=\"alert alert-warning\" role=\"alert\">\r\n                                            ");
#nullable restore
#line 145 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Home\Register.cshtml"
                                       Write(ViewBag.Err);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </div>\r\n");
#nullable restore
#line 147 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Home\Register.cshtml"
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 148 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Home\Register.cshtml"
                                     if (ViewBag.Success != null)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <div class=\"alert alert-success\" role=\"alert\">\r\n                                            ");
#nullable restore
#line 151 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Home\Register.cshtml"
                                       Write(ViewBag.Success);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 151 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Home\Register.cshtml"
                                                        Write(Html.ActionLink("here", "Login", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" to join us!!\r\n                                        </div>\r\n");
#nullable restore
#line 153 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Home\Register.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                </div>

                            <div class=""align-content-center justify-content-center col-md-10 col-lg-6 col-xl-7 d-flex align-items-center order-1 order-lg-2 d-flex flex-column"">
                                <h4>Avatar Preview</h4>
                                <!--Preview img goes here!-->
                                <img id=""blah"" class=""img-fluid"" src=""https://avatars.dicebear.com/api/open-peeps/your-custom-seed.svg"" alt=""Default avatar"" style=""width:80%;height:70%; border-radius:50%;border:1px solid black"" />
                                <!--End preview-->
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3fed8ad0e7ce276ff846f93f901e77b5fe7d503f20026", async() => {
                WriteLiteral("\r\n                                    <input accept=\"image/*\" type=\'file\' id=\"imgInp\" placeholder=\"Avatar Upload\" />\r\n                                    <input type=\"submit\" value=\"Upload Files\" name=\"submit\">\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<script src=""https://ajax.googleapis.com/ajax/libs/jquery/1.12.3/jquery.min.js""></script>
<script src=""http://code.jquery.com/ui/1.11.1/jquery-ui.min.js""></script>
<link href=""https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.11.4/jquery-ui.css"" rel=""stylesheet"">
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApplication1.Models.User> Html { get; private set; }
    }
}
#pragma warning restore 1591
