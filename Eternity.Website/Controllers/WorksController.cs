using Eternity.DTO.DTOs;
using Eternity.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Eternity.Website.Controllers
{
    public class WorksController : Controller
    {
        private readonly ILogger<WorksController> _logger;
        private readonly IWorkService _workService;
        public WorksController(ILogger<WorksController> logger, IWorkService workService)
        {
            _logger = logger;
            _workService= workService;
        }
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("WorksController called Index method");
            var myWorks = await _workService.ShowWorks();
            return View(myWorks);
        }
    }
}
