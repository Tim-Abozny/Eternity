using Eternity.DTO.DTOs;
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
        public async Task<ActionResult> Index()
        {
            _logger.LogInformation("ServicesController CALLED Index method");
            var myServices = await _service.ShowServices();
            return View(myServices);
        }
        public IActionResult Editing()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddService(ServiceDTO service)
        {
            _logger.LogInformation("ServicesController CALLED AddService method");
            if (ModelState.IsValid)
            {
                await _service.AddService(service);
                _logger.LogInformation("Redirecting to Index method...");
            }
            return await Task.Run<IActionResult>(() => RedirectToAction("Index", "Services"));
        }
    }
}
