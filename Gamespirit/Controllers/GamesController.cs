using Microsoft.AspNetCore.Mvc;

namespace Gamespirit.Controllers
{
    public class GamesController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public GamesController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}