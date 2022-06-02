using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ContosoCrafts.WebSite
{
    public class Startup
    {
        // This method is to initiate the configuration method
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        // This method is to call configuration object
        public IConfiguration Configuration { get; }

        /// This method gets called by the runtime. Use this method to add
        /// services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Adding all the services we need
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddHttpClient();
            services.AddControllers();
            services.AddTransient<JsonFileProductService>();
        }

        /// This method gets called by the runtime. Use this method to
        /// configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.Use(async (context, next) =>
                {
                    await next();
                    if (context.Response.StatusCode == 400)
                    {
                        Pages.ErrorModel.func_error("Error 400");
                        context.Request.Path = "/Error";
                        await next();
                    }
                    if (context.Response.StatusCode == 404)
                    {
                        Pages.ErrorModel.func_error("Error 404");
                        context.Request.Path = "/Error";
                        await next();
                    }
                });

                app.UseExceptionHandler("/Error");
            }
            else
            {
                app.Use(async (context, next) =>
                {
                    await next();
                    if (context.Response.StatusCode == 400)
                    {
                        Pages.ErrorModel.func_error("Error 400");
                        context.Request.Path = "/Error";
                        await next();
                    }
                    if (context.Response.StatusCode == 404)
                    {
                        Pages.ErrorModel.func_error("Error 404");
                        context.Request.Path = "/Error";
                        await next();
                    }
                });

                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change
                // this for production scenarios,
                // see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Following serveice is to configuate the network and
            // make sure the end points are reachable
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapBlazorHub();

                // Might be using for later
                // endpoints.MapGet("/products", (context) => 
                // {
                //     var products = app.ApplicationServices.GetService
                //     <JsonFileProductService>().GetProducts();
                //     var json = JsonSerializer.Serialize
                //     <IEnumerable<Product>>(products);
                //     return context.Response.WriteAsync(json);
                // });
            });
        }
    }
}
