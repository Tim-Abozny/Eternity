using Eternity.DTO.DTOs;
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
        public async Task<ActionResult> Index()
        {
            _logger.LogInformation("PricesController called Index method");
            var myPrices = await _service.GetPrices();
            return View(myPrices);
        }
        public IActionResult Creating()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPrice(PriceDTO price)
        {
            _logger.LogInformation("PricesController called AddPrice method");
            if (ModelState.IsValid)
            {
                await _service.CreatePrice(price);
                _logger.LogInformation("Redirecting to Index method...");
            }
            return await Task.Run<IActionResult>(() => RedirectToAction("Index", "Prices"));
        }
        public async Task<IActionResult> EditPrice(PriceDTO price, int id)
        {
            _logger.LogInformation("PricesController called EditPrice method");
            await _service.EditPrice(price, id);
            return await Task.Run<IActionResult>(() => RedirectToAction("Index", "Prices"));    //it must return to adminPanel
        }
    }
}
