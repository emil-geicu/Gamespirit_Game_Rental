using Gamespirit.Data;
using Gamespirit.Data.DbModels;
using Gamespirit.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gamespirit.Controllers
{
    public class GamesController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public GamesController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var games = await _dbContext.Games.Select(g => new GameViewModel()
            {
                Id = g.Id,
                Title = g.Title,
                Description = g.Description,
                Genre = g.Genre,
                ReleaseDate = g.ReleaseDate,
                CoverImageUrl = g.CoverImageUrl,
                TrailerUrl = g.TrailerUrl,
            }).ToListAsync();

            return View(games);
        }

        public async Task<IActionResult> GameDetails(Guid id)
        {
            var game = await _dbContext.Games.FirstOrDefaultAsync(g => g.Id.Equals(id));

            if (game == null)
            {
                return RedirectToAction("Index");
            }

            var gameViewModel = new GameViewModel()
            {
                Id = game.Id,
                Title = game.Title,
                Description = game.Description,
                Genre = game.Genre,
                ReleaseDate = game.ReleaseDate,
                CoverImageUrl = game.CoverImageUrl,
                TrailerUrl = game.TrailerUrl,
            };

            return View(gameViewModel);
        }

        public IActionResult AddGame()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewGame(GameViewModel game)
        {
            game.Id = Guid.NewGuid();

            if (!ModelState.IsValid)
            {
                return View("AddGame");
            }

            var existingGame = await _dbContext.Games.FirstOrDefaultAsync(g => g.Title == game.Title);
            if (existingGame != null)
            {
                ModelState.AddModelError("Title", "There is alrready a game with this title!");
                return View("AddGame");
            }

            _dbContext.Games.Add(new Game
            {
                Id = game.Id,
                Title = game.Title,
                Description = game.Description,
                Genre = game.Genre,
                ReleaseDate = game.ReleaseDate,
                CoverImageUrl = game.CoverImageUrl,
                TrailerUrl = game.TrailerUrl,
            });

            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditGame(Guid id)
        {
            var game = await _dbContext.Games.FirstOrDefaultAsync(g => g.Id.Equals(id));

            if (game == null)
            {
                return RedirectToAction("Index");
            }

            var gameViewModel = new GameViewModel()
            {
                Id = game.Id,
                Title = game.Title,
                Description = game.Description,
                Genre = game.Genre,
                ReleaseDate = game.ReleaseDate,
                CoverImageUrl = game.CoverImageUrl,
                TrailerUrl = game.TrailerUrl,
            };

            return View(gameViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditExistingGame(GameViewModel gameViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("EditGame");
            }

            var existingGame = await _dbContext.Games.FirstOrDefaultAsync(g => g.Id == gameViewModel.Id);

            existingGame.Title = gameViewModel.Title;
            existingGame.Description = gameViewModel.Description;
            existingGame.Genre = gameViewModel.Genre;
            existingGame.ReleaseDate = gameViewModel.ReleaseDate;
            existingGame.CoverImageUrl = gameViewModel.CoverImageUrl;
            existingGame.TrailerUrl = gameViewModel.TrailerUrl;

            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteGame(Guid id)
        {
            var existingGame = await _dbContext.Games.FirstOrDefaultAsync(g => g.Id == id);

            if (existingGame != null)
            {
                _dbContext.Games.Remove(existingGame);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}