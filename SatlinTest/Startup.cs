using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SatlinTest.Back.Data;
using SatlinTest.Back.Repositories;
using System;

namespace SatlinTest
{
    public class Startup
    {
        IConfiguration configuration;

        public Startup(IConfiguration Configuration)
        {
            configuration = Configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            String urlApi = this.configuration["Api"];

            services.AddTransient(x => new ServiceApi(urlApi));

            services.AddSingleton<IConfiguration>(this.configuration);

            services.AddControllersWithViews(option => option.EnableEndpointRouting = false);

            String cadena = this.configuration.GetConnectionString("SatlinDB");
            services.AddTransient<UserRepo>();
            services.AddTransient<AddressRepo>();
            services.AddTransient<GeoRepo>();
            services.AddTransient<CompanyRepo>();
            services.AddDbContext<BackContext>(options => options.UseSqlServer(cadena));
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

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
