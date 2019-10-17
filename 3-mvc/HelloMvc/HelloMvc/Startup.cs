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

namespace HelloMvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // this Configuration object is for reading in runtime configuration
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // in here, we register services for dependency injection
            // we set up middleware in here

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // in here we "plug in" middleware to the request lifecycle
            // and at the bottom, configure our routes.

            if (env.IsDevelopment())
            {
                // if Dev environment, plug in that nice exception page we saw
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
                // in this lambda expression here,
                // we can map as many routes as we want
                // right now one route is mapped

                // the routes are matched against each incoming URL,
                // the first one here that matches it will be followed
                endpoints.MapControllerRoute(
                    name: "privacy",
                    pattern: "Privacy", // the pattern is matched against the URL.
                    defaults: new { Controller = "Home", Action = "Privacy" });
                // that is "anonymous type" - an object without a class.
                // "web developer" way of thinking, just stuff the data in there
                // with no compile-time type checking

                // this is "endpoint routing"
                // the alternative is "attribute routing"
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
