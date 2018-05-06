using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspNetCore.Models;
using Microsoft.Extensions.Logging;

namespace AspNetCore.Controllers
{
    public class HomeController : Controller
    {
        ILogger _logger;
        // Coonstrutor da HomeController injetando o ILogger
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            // Registrando um log
            _logger.LogInformation("Home/Index Executing..");

             return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
