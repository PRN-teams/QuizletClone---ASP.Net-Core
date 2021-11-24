using Google.Apis.Auth.AspNetCore3;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DBQuizSharpContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DBQuizSharp")));
            services.AddScoped(typeof(DBQuizSharpContext));
            services.AddDistributedMemoryCache();

            // This configures Google.Apis.Auth.AspNetCore3 for use in this app.
            services
                .AddAuthentication(o =>
                {
         // This forces challenge results to be handled by Google OpenID Handler, so there's no
         // need to add an AccountController that emits challenges for Login.
         o.DefaultChallengeScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
         // This forces forbid results to be handled by Google OpenID Handler, which checks if
         // extra scopes are required and does automatic incremental auth.
         o.DefaultForbidScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
         // Default scheme that will handle everything else.
         // Once a user is authenticated, the OAuth2 token info is stored in cookies.
         o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                  .AddCookie()
                  .AddGoogleOpenIdConnect(options =>
                  {
                      IConfigurationSection googleAuthNSection =
                      Configuration.GetSection("Authentication:Google");

                      options.ClientId = googleAuthNSection["ClientId"];
                      options.ClientSecret = googleAuthNSection["ClientSecret"];
                  });
            //End Google Config

            //Session Config
            services.AddSession((option) =>
            {
                option.Cookie.Name = "MyQuizletClone";
                option.IdleTimeout = new TimeSpan(2, 30, 0); //2 tieng ruoi
            });

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<DBQuizSharpContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
