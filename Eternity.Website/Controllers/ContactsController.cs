using Eternity.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Eternity.Website.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ILogger<ContactsController> _logger;
        public ContactsController(ILogger<ContactsController> logger)
        {
            _logger = logger;
        }
        public ActionResult Index() 
        {
            return View();
        }
    }
}
