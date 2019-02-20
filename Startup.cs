using Inlämning_2___Webshop.IdentityData;
using Inlämning_2___Webshop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inlämning_2___Webshop
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var conn = Configuration.GetConnectionString("conn");

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(conn));
            services.AddDbContext<TomasosContext>(options => options.UseSqlServer(conn));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDBContext>()
                .AddEntityFrameworkStores<TomasosContext>()
                .AddDefaultTokenProviders();

            services.Configure<RouteOptions>(options => options.AppendTrailingSlash = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "AuthRoute",
                    template: "{action}",
                    defaults: new { controller = "Auth" });

                routes.MapRoute(
                    name: "UserRoute",
                    template: "{action}",
                    defaults: new { controller = "User" });

                routes.MapRoute(
                    name: "AdminPanel",
                    template: "Admin",
                    defaults: new { controller = "Admin", action = "AdminPanel" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
