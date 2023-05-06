using Gamespirit.Models;
using Gamespirit.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gamespirit.Controllers
{
    public class GamesController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IGameService _gameService;

        public GamesController(ILogger<HomeController> logger, IGameService gameService)
        {
            _logger = logger;
            _gameService = gameService;
        }

        public IActionResult Index()
        {
            return View(_gameService.GetAllGames());
        }

        public IActionResult GameDetails(Guid id)
        {
            if(id == Guid.Empty)
                return View();
            var game = _gameService.GetGame(id);

            if (game == null)
            {
                return RedirectToAction("Index");
            }

            return View(game);
        }

        public IActionResult AddGame()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewGame(GameViewModel game)
        {
            game.Id = Guid.NewGuid();

            if (!ModelState.IsValid)
            {
                return View("AddGame");
            }

            if (_gameService.GameExistsWithTitle(game.Title))
            {
                ModelState.AddModelError("Title", "There is alrready a game with this title!");
                return View("AddGame");
            }

            _gameService.CreateGame(game);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditGame(Guid id)
        {
            var game = _gameService.GetGame(id);

            if (game == null)
            {
                return RedirectToAction("Index");
            }

            return View(game);
        }
        [HttpPost]
        public IActionResult EditExistingGame(GameViewModel gameViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("EditGame");
            }

            _gameService.EditGame(gameViewModel);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteGame(Guid id)
        {
            _gameService.DeleteGame(id);
            return RedirectToAction(nameof(Index));
        }
    }
}