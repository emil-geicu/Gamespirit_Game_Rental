using Azure.Core;
using Gamespirit.Areas.Identity.Data;
using Gamespirit.Data;
using Gamespirit.Services;
using Gamespirit.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Gamespirit.Controllers
{
	public class RequestsController : Controller
	{
		private readonly ApplicationDbContext _context;
		private IRequestService _requestService;
		private IRentHistoryService _rentHistoryService;
		private UserManager<GamespiritUser> _userManager;

		public RequestsController(ApplicationDbContext context, IRequestService requestService, IRentHistoryService rentHistoryService, UserManager<GamespiritUser> userManager)
		{
			_context = context;
			_requestService = requestService;
			_userManager = userManager;
			_rentHistoryService = rentHistoryService;
		}

		// GET: Requests
		public async Task<IActionResult> Index()
		{
			var user = _userManager.GetUserAsync(User).Result;
			return View(_requestService.GetAllRequests(user));
		}

		// GET: Requests/Edit/5
		public async Task<IActionResult> Aprove(Guid gameId, Guid userId)
		{
			_rentHistoryService.AssignGameToUser(gameId, userId);
			return RedirectToAction(nameof(Index));
		}
		private bool RequestExists(Guid id)
		{
			return (_context.Requests?.Any(e => e.GamespiritUserId == id)).GetValueOrDefault();
		}

		public IActionResult Delete(Guid id)
		{
			var user = _userManager.GetUserAsync(User).Result;
			_requestService.DeleteRequest(id,user.Id);
			return RedirectToAction(nameof(Index));
		}
	}
}
