using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizletClone.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace QuizletClone
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
            services.AddDbContext<DBQuizSharpContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DBQuizSharp")));
            services.AddScoped(typeof(DBQuizSharpContext));
            services.AddDistributedMemoryCache();

            services.AddSession((option) =>
            {
                option.Cookie.Name = "MyQuizletClone";
                option.IdleTimeout = new TimeSpan(2, 30, 0); //2 tieng ruoi
            });

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
                .AddCookie(options =>
                {
                    options.LoginPath = "/Login/google-login"; // Must be lowercase
                })
             .AddGoogle(googleOptions =>
             {
                 // ?oc thong tin Authentication:Google tu appsettings.json
                 IConfigurationSection googleAuthNSection = Configuration.GetSection("Authentication:Google");

                 // Thiet lap ClientID va ClientSecret de truy cap API google
                 googleOptions.ClientId = googleAuthNSection["ClientId"];
                 googleOptions.ClientSecret = googleAuthNSection["ClientSecret"];
                 // Cau hinh Url callbacklai tu google (ko thiet lap thi mac dinh la /signin-google)
                 googleOptions.CallbackPath = "/Google-login";

             })
             .AddFacebook(option =>
             {
                 IConfigurationSection facebookAuthNSection = Configuration.GetSection("Authentication:Facebook");
                 option.AppId = facebookAuthNSection["ClientId"];
                 option.ClientSecret = facebookAuthNSection["ClientSecret"];
             });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
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
            });
        }
    }
}
