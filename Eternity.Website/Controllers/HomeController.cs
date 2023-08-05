using Eternity.Website.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Eternity.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult f0c4d58042f6706fb41f416c9127141a9848f61b84fb699b02eb60862c5e21b9()//myadminpanel
        {
            _logger.LogInformation("!\n!!\n!!!\tAdminPanel opened");
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}