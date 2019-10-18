using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PokeApp.BusinessLogic;
using PokeApp.Data;

namespace PokeApp.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // in ASP.NET 

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // we get the connection string from runtime configuration
            string connectionString = Configuration.GetConnectionString("PokeDb");

            // among the services you register for DI (dependency injection)
            // should be your DbContext.
            services.AddDbContext<PokemonDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            // this registers the Repository class under the "name" of IRepository.
            // aka: "if anyone needs an IRepository, make a Repository."
            services.AddScoped<IRepository, Repository>();

            // if class A needs class B to do its job, two options:
            // 1. somewhere in class A, we say "var b = new B()" and proceed
            // 2. A's constructor accepts an instance of B.
            // even better: have interface IB, accept in ctor any instance under IB

            // dependency inversion principle: classes shouldn't depend on each other,
            // instead should depend on interfaces

            // "new is glue": if a class "news" another class, they are pretty inextricable,
            //     too tightly coupled

            // we have this thing called "dependency injection container" that makes dealing with
            // option #2 easier.

            // there are three "lifetimes" for a service that you register here
            // singleton means: the whole lifetime of the app, there is only one instance of that service.
            // scoped means: one instance per "scope" - each HTTP request lifecycle is one scope
            // transient means: every time service is requested, you get a new instance

            // by default, DbContexts are scoped. (therefore, anything that depends on them
            // must be either scoped or transient)

            services.AddSingleton<SingletonGuidService>();
            services.AddScoped<ScopedGuidService>();
            services.AddTransient<TransientGuidService>();

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
            });
        }
    }
}
