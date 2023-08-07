using Eternity.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Eternity.Website.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ILogger<ServicesController> _logger;
        private readonly IServiceService _service;
        public ServicesController(ILogger<ServicesController> logger, IServiceService service)
        {
            _logger = logger;
            _service = service;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}
