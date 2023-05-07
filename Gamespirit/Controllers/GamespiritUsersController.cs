using Gamespirit.Services;
using Gamespirit.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gamespirit.Controllers
{
    public class GamespiritUsersController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private IUserService _userService;

		public GamespiritUsersController(ILogger<HomeController> logger,IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View(_userService.GetAllUsers());
        }
        public IActionResult GamespiritUserDetails(Guid id)
        {
            if (id == Guid.Empty)
                return View();
            var user = _userService.GetUser(id);

            if (user == null)
            {
                return RedirectToAction("Index");
            }

            return View(user);
        }
        public IActionResult EditGamespiritUser()
        {
            return View();
        }
    }
}