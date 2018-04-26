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
            
            // Adciona singleton do UsuarioService no Startup.cs
            services.AddSingleton<IUsuarioService, UsuarioService>();

            //Adcionar a connectionstring como um serviço ao projeto e referenciar o LibraryContext
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

            //Aqui faz a View do Controle Usuarios ser carregada primeira, pois as rotas definidas vão na ordem abaixo
            app.UseMvc(routes =>
            {
                // New route Usuarios ATENCAO: Se colocar o nome do template em letra MAIUSCULA o sistema fica instável (bug)
                routes.MapRoute(
                   name: "usuario",
                   template: "{controller=Usuarios}/{action=Index}/{id?}");
                // Default Route
                routes.MapRoute(
                   name: "default",
                   template: "{controller=Home}/{action=Index}/{id?}");
            });

            /// Aqui faz a página Home ser a primeira a carregar. 
            //app.UseMvc(routes =>
            //{
            //    // New route Usuarios ATENCAO: Se colocar o nome do template em letra MAIUSCULA o sistema fica instável (bug)
            //    routes.MapRoute(
            //      name: "usuario-route",
            //      template: "usuario",
            //      defaults: new { controller = "Usuarios", action = "Index" });
            //    // New Route About
            //    routes.MapRoute(
            //       name: "about-route",
            //       template: "about",
            //       defaults: new { controller = "Home", action = "About" });
            //    // Default Route
            //    routes.MapRoute(
            //       name: "default",
            //       template: "{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }
}
