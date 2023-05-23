using DigitalSchoolWorkspace.Services;
using Gamespirit.Areas.Identity.Data;
using Gamespirit.Models;
using Gamespirit.Services;
using Gamespirit.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Gamespirit.Controllers
{
    public class GamespiritUsersController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private IUserService _userService;
		private IRentHistoryService _rentHistoryService;
		private UserManager<GamespiritUser> _userManager;

		public GamespiritUsersController(ILogger<HomeController> logger,IUserService userService, IRentHistoryService rentHistoryService, UserManager<GamespiritUser> userManager)
        {
            _logger = logger;
            _userService = userService;
            _rentHistoryService = rentHistoryService;
            _userManager = userManager;
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
        public IActionResult EditGamespiritUser(Guid id)
        {
            var user = _userService.GetUser(id);

            if (user == null)
            {
                return RedirectToAction("Index");
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult EditExistinguserr(GamespiritUser user)
        {
            if (!ModelState.IsValid)
            {
                return View("EditGame");
            }

            _userService.EditUser(user);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteUser(Guid id)
        {
            _userService.DeleteUser(id);
            return RedirectToAction(nameof(Index));
        }


		public IActionResult DeleteRentHistory(Guid id)
        {
			var user = _userManager.GetUserAsync(User).Result;
			_rentHistoryService.DeleteRent(id, user.Id);
			return RedirectToAction(nameof(Index));
		}
	}
}