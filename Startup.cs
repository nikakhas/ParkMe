using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//using Geocoding;
//using Geocoding.Google;

namespace ParkMe
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
            services.AddControllersWithViews();
            //services.AddGeoCoding();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "homepage",
                    pattern: "homepage",
                    defaults: new { controller = "Home", action = "Homepage" });

                endpoints.MapControllerRoute(
                    name: "login",
                    pattern: "login",
                    defaults: new { controller = "Home", action = "Login" });

                endpoints.MapControllerRoute(
                    name: "mapviews",
                    pattern: "mapviews",
                    defaults: new { controller = "Home", action = "MapViews" });

                endpoints.MapControllerRoute(
                    name: "parkinglistviews",
                    pattern: "parkinglistviews",
                    defaults: new { controller = "Home", action = "ParkingListViews" });

                endpoints.MapControllerRoute(
                    name: "parkingspotlog",
                    pattern: "parkingspotlog",
                    defaults: new { controller = "Home", action = "ParkingSpotLog" });
            });
        }
    }
}
