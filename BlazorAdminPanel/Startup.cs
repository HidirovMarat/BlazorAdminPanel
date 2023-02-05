using BlazorAdminPanel.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlazorAdminPanel
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            // Служба одного экземпляра класса на приложение
            services.AddSingleton<EarningsTable>();
            services.AddSingleton<RegionsTable>();
            services.AddSingleton<DBMSTable>();
            services.AddSingleton<WebProgTable>();

            //services.AddScoped<EarningsTable>();
            //services.AddScoped<RegionsTable>();
            //services.AddScoped<DBMSTable>();
            //services.AddScoped<WebProgTable>();

            //services.AddTransient<EarningsTable>();
            //services.AddTransient<RegionsTable>();
            //services.AddTransient<DBMSTable>();
            //services.AddTransient<WebProgTable>();
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
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
