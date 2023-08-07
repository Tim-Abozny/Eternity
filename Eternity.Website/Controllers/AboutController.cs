using Eternity.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Eternity.Website.Controllers
{
    public class AboutController : Controller
    {
        private readonly ILogger<AboutController> _logger;
        private readonly IAboutService _aboutService;
        public AboutController(ILogger<AboutController> logger, IAboutService aboutService)
        {
            _logger = logger;
            _aboutService = aboutService;
        }
        public ActionResult Index() 
        {
            return View();
        }
    }
}
