using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PortfolioService.Model;
using PortfolioService.Repository;
using PortfolioService.Services;

namespace PortfolioService
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
            
            services.Configure<PortfolioManagerConnection>(Configuration.GetSection(nameof(PortfolioManagerConnection)));
            services.AddSingleton<IPortfolioManagerConnection>(sp => sp.GetRequiredService<IOptions<PortfolioManagerConnection>>().Value);            
            services.AddSingleton<IModelPortfolioRepository>(sp => {
                var portfolioManagerConnection = sp.GetRequiredService<IPortfolioManagerConnection>();
                return new MongoModelPortfolioRepository(portfolioManagerConnection);
                });

            services.AddSingleton<IModelPortfolioService>(sp => {
                var logger = sp.GetRequiredService<ILogger<ModelPortfolioService>>();
                var modelRepository = sp.GetRequiredService<IModelPortfolioRepository>();
                return new ModelPortfolioService(logger, modelRepository);
            });
            services.AddSingleton<ISearchRepository>(sp => {
                var portfolioManagerConnection = sp.GetRequiredService<IPortfolioManagerConnection>();
                return new SearchRepository(portfolioManagerConnection);
            });

            services.AddSingleton<ISearchService>(sp => {
                ISearchRepository searchRepository = sp.GetRequiredService<ISearchRepository>();
                return new SearchService(searchRepository);
            });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            services.AddSwaggerGen();
        }

        private int IOptions(PortfolioManagerConnection portfolioManagerConnection)
        {
            throw new NotImplementedException();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "service/{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
