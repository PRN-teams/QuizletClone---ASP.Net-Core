#pragma checksum "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Home\ForgotPassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "43de21217b4365fe51522c45ae42abe99eebc008"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ForgotPassword), @"mvc.1.0.view", @"/Views/Home/ForgotPassword.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"43de21217b4365fe51522c45ae42abe99eebc008", @"/Views/Home/ForgotPassword.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"729efaa87342638aecfe1a972ce9f9f8dff55b4c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ForgotPassword : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Home\ForgotPassword.cshtml"
   ViewData["Title"] = "Forgot Pasword";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    .login-container {
        margin-top: 8%;
        border: 0px solid #CCD1D1;
        border-radius: 12px;
        box-shadow: 0 0px 28px 0 rgb(0 0 0 / 8%);
        max-width: 50%;
        background: #FFF;
        z-index: 1;
        position: relative;
    }

    img.triangleA {
        position: absolute;
        margin-left: -16px;
        width: 60px;
        border-radius: 12px 0px 0px 0px;
    }

    img.triangleB {
        position: absolute;
        right: 0px;
        bottom: 0px;
        width: 360px;
        z-index: 0;
    }

    .welcome_auth {
        align-items: center;
        display: flex;
        justify-content: center;
        background: url('https://i.pinimg.com/564x/5b/ac/39/5bac39c17b49a67757a7f005591f4c62.jpg');
        background-repeat: no-repeat;
        background-size: cover;
    }


    .auth_welcome {
        font-weight: 100;
        font-size: 1.5em;
        background: -webkit-linear-gradient( 45deg, #07dd97, #beffe7);
");
            WriteLiteral(@"        background-size: 100%;
        -webkit-background-clip: text;
        -webkit-text-fill-color: transparent;
    }

    a.auth_branding_in img {
        width: 60px;
        height: 60px;
        border-radius: 1000px;
    }

    .login-form {
        background: #fbfbfb;
        border-radius: 0px 12px 12px 0px;
        align-items: center;
        display: flex;
        justify-content: center;
    }

    .login_form_in {
        padding: 4em 1em;
    }

    .login-form h1 {
        font-size: 1.2em;
        max-width: 600px;
        margin: 0 auto;
        color: #969696;
        line-height: 1.5em;
        padding: 1.2em 0px .8em;
    }

    .lni {
        display: inline-block;
        font: normal normal normal 1em/1 'LineIcons';
        speak: none;
        text-transform: none;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
    }

    .google_signup {
        margin-top: .8em;
    }

        .google_signup a ");
            WriteLiteral(@"{
            background: #DB4437;
            color: #FFF;
            display: block;
            text-align: center;
            padding: 12px 4px;
            border-radius: 5px;
        }

    .btn-primary {
        color: #fff;
        background-color: #5d00ff;
        border-color: #5d00ff;
    }

        .btn-primary:hover {
            color: #fff;
            background-color: #2900b7;
            border-color: #2900b7;
        }

    .google_signup a {
        background: #DB4437;
        color: #FFF;
        display: block;
        text-align: center;
        padding: 12px 4px;
        border-radius: 5px;
    }

        .google_signup a:hover {
            background: #d81505;
            color: #FFF;
        }

    .other_auth_links a:nth-child(2) {
        float: right;
    }

    a {
        text-decoration: none;
        color: #afafaf;
    }

        a:hover {
            text-decoration: none;
            color: #616161;
        }

    .alert");
            WriteLiteral(@"-success {
        background-color: rgb(190 255 231 / 33%);
        color: #07dd97;
        font-size: .9em;
    }   
</style>


    <div class=""container login-container"">
        <div class=""row"">
            <div class=""col-md-6 welcome_auth"">
                <div class=""auth_welcome"">
                   <h3>Personalize your study track </h3>
                </div>
            </div>
            <div class=""col-md-6 login-form"">
                <div class=""login_form_in"">
                    <div class=""auth_branding"">
                        <a class=""auth_branding_in"" href=""https://procraft.studio""><img src=""https://res.cloudinary.com/procraftstudio/image/upload/v1613964589/Procraft-Studio-Logo-1_tnfxuj.jpg"" alt='Procraft Studio'></a>
                    </div>
                    <h1 class=""auth_title text-left"">Password Reset</h1>
");
#nullable restore
#line 158 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Home\ForgotPassword.cshtml"
                     using (Html.BeginForm("ForgotPassword", "Home", FormMethod.Post))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "43de21217b4365fe51522c45ae42abe99eebc0089027", async() => {
                WriteLiteral(@"
                            <div class=""alert alert-primary bg-soft-primary border-0"" role=""alert"">
                                Enter your email address and we'll send you an email with instructions to reset your password.
                            </div>
                            <div class=""form-group"">
                                ");
#nullable restore
#line 165 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Home\ForgotPassword.cshtml"
                           Write(Html.TextBox("email", null, new { @class = "form-control", @type = "email", @placeholder = "Email Address" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                            </div>
                            <div class=""form-group"">
                                <button type=""submit"" class=""btn btn-primary btn-lg btn-block"">Reset Password</button>
                            </div>
                            <div class=""form-group other_auth_links"">
                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "43de21217b4365fe51522c45ae42abe99eebc00810375", async() => {
                    WriteLiteral(" Login");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "43de21217b4365fe51522c45ae42abe99eebc00811841", async() => {
                    WriteLiteral("Register");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            </div>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 175 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Home\ForgotPassword.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 176 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Home\ForgotPassword.cshtml"
                     if (ViewBag.EmailSendMessage != null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"alert alert-success\" role=\"alert\">\r\n                            ");
#nullable restore
#line 179 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Home\ForgotPassword.cshtml"
                       Write(ViewBag.EmailSendMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n");
#nullable restore
#line 181 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Home\ForgotPassword.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 182 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Home\ForgotPassword.cshtml"
                     if (@ViewBag.Err!=null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"alert alert-warning\" role=\"alert\">\r\n                            ");
#nullable restore
#line 185 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Home\ForgotPassword.cshtml"
                       Write(ViewBag.Err);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n");
#nullable restore
#line 187 "C:\Users\Macbook Pro\Source\Repos\QuizletClone---ASP.Net-Core\WebApplication1\Views\Home\ForgotPassword.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                </div>
            </div>
        </div>
    </div>


  <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css""
          integrity=""sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm"" crossorigin=""anonymous"">
    <link href=""https://cdn.lineicons.com/2.0/LineIcons.css"" rel=""stylesheet"">

    <script src=""https://code.jquery.com/jquery-3.2.1.slim.min.js""
            integrity=""sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN"" crossorigin=""anonymous"">
    </script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js""
            integrity=""sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q"" crossorigin=""anonymous"">
    </script>");
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
