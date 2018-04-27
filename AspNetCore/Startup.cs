using AspNetCore.DBCoontext;
using AspNetCore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCore
{
    //Ponto incial
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
            services.AddMvc();

            // Para especificar a quantidade de erros de validação permitida. 

            services.AddMvc(options => options.MaxModelValidationErrors = 50);

            // Adciona singleton do UsuarioService no Startup.cs se o EF não for utilizado
            services.AddSingleton(Configuration);

            // Adcionar o Singleton no UsuarioService se  o EF core for utlizado. 
            services.AddScoped<IUsuarioService, UsuarioService>();

            // Adcionar a connectionstring do BD como um serviço ao projeto e referenciar o LibraryContext
            services.AddDbContext<LibraryContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LibraryConnection")));
            
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
                // New route Usuarios
                routes.MapRoute(
                   name: "usuario",
                   template: "usuario/",
                defaults: new { controller = "Usuarios", action = "index" });
                // Default Route
                routes.MapRoute(
                   name: "default",
                   template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
