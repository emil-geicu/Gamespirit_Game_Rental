using Microsoft.AspNetCore.Mvc;

namespace Gamespirit.Controllers
{
    public class PlayersController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public PlayersController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}