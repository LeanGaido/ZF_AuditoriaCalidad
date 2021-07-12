using AutoMapper;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using ZF_AuditoriaCalidad.Server.Data;
using ZF_AuditoriaCalidad.Server.Helpers;
using ZF_AuditoriaCalidad.Server.Models;

namespace ZF_AuditoriaCalidad.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            
        }

        public IConfiguration Configuration { get; }
       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

           //services.AddTransient<ProfileService>();

            services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<IdentityOptions>(options =>
                options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier);


            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(option => {
                    option.IdentityResources["openid"].UserClaims.Add("name");
                    option.ApiResources.Single().UserClaims.Add("name");
                    option.IdentityResources["openid"].UserClaims.Add("role");
                    option.ApiResources.Single().UserClaims.Add("role");
                })
                 .AddProfileService<ProfileService>();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("role");
            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");

                endpoints.MapControllerRoute(
                    name: "ContentAdmin",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
