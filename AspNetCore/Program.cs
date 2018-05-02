using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace AspNetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // ASP.NET Core 2.0 usa assim o padrão
            BuildWebHost(args).Run();

            // ASP.NET Core 1.0 usa assim o padrão
            //var host = new WebHostBuilder()
            //    .UseKestrel()
            //    .UseContentRoot(Directory.GetCurrentDirectory())
            //    .UseWebRoot("wwwroot") // use "." to completely remove the wwwroot
            //    .UseIISIntegration()
            //    .UseStartup<Startup>()
            //    .Build();

            //host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                 // .UseStartup<MyStartup>() posso dar o nome por aqui <MyStartup> do meu arquivo startup
                .UseStartup<Startup>()
                .Build();
    }
}
