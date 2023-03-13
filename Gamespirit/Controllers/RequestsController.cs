using Microsoft.AspNetCore.Mvc;

namespace Gamespirit.Controllers
{
    public class RequestsController:Controller
    {

        private readonly ILogger<HomeController> _logger;

        public RequestsController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
