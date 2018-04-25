using AspNetCore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace AspNetCore
{
    //Ponto incial
    public class Startup
    {
        // private const string Template = "{controller=Home}/{action=Index}/{id?}";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMvc().AddViewLocalization().AddDataAnnotationsLocalization().AddRazorOptions(options =>
            {
                options.ViewLocationExpanders.Remove(options.ViewLocationExpanders.First(f => f is Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.PageViewLocationExpander));
            });
            // Adciona singleton do UsuarioService no Startup.cs
            services.AddSingleton<IUsuarioService, UsuarioService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
