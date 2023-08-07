using Eternity.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Eternity.Website.Controllers
{
    public class PricesController : Controller
    {
        private readonly ILogger<PricesController> _logger;
        private readonly IPriceService _service;
        public PricesController(ILogger<PricesController> logger, IPriceService service)
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
