using Gamespirit.Data.DbModels;
using Gamespirit.Models;
using Gamespirit.Repositories.Interfaces;
using Gamespirit.Services.Interfaces;
using System.Security.Claims;
namespace Gamespirit.Services
{
    public class GameService : IGameService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public GameService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateGame(GameViewModel game)
        {
            _repositoryWrapper.GameRepository.Create(new Game
            {
                Id = game.Id,
                Title = game.Title,
                Description = game.Description,
                Genre = game.Genre,
                ReleaseDate = game.ReleaseDate,
                CoverImageUrl = game.CoverImageUrl,
                TrailerUrl = game.TrailerUrl,
            });
            _repositoryWrapper.Save();
        }

        public void DeleteGame(Guid id)
        {
            var game = _repositoryWrapper.GameRepository.Get(id);
            if (game != null)
            {
                _repositoryWrapper.GameRepository.Delete(game);
            }
            _repositoryWrapper.Save();

        }

        public void EditGame(GameViewModel game)
        {
            var existingGame = _repositoryWrapper.GameRepository.Get(game.Id);

            existingGame.Title = game.Title;
            existingGame.Description = game.Description;
            existingGame.Genre = game.Genre;
            existingGame.ReleaseDate = game.ReleaseDate;
            existingGame.CoverImageUrl = game.CoverImageUrl;
            existingGame.TrailerUrl = game.TrailerUrl;
            _repositoryWrapper.GameRepository.Update(existingGame);
            _repositoryWrapper.Save();
        }

        public GameViewModel FindGame(Guid id)
        {
            var game = _repositoryWrapper.GameRepository.Get(id);
            return new GameViewModel()
            {
                Id = game.Id,
                Title = game.Title,
                Description = game.Description,
                Genre = game.Genre,
                ReleaseDate = game.ReleaseDate,
                CoverImageUrl = game.CoverImageUrl,
                TrailerUrl = game.TrailerUrl,
            };
        }

        public bool GameExistsWithTitle(string title)
        {
            if (_repositoryWrapper.GameRepository.FindByTitle(title) != null)
                return true;

            return false;
        }

        public List<GameViewModel> GetAllGames()
        {
            return _repositoryWrapper.GameRepository.GetAll().Select(g => new GameViewModel()
            {
                Id = g.Id,
                Title = g.Title,
                Description = g.Description,
                Genre = g.Genre,
                ReleaseDate = g.ReleaseDate,
                CoverImageUrl = g.CoverImageUrl,
                TrailerUrl = g.TrailerUrl,
            }).ToList();
        }

        public GameViewModel GetGame(Guid id)
        {
            var game = _repositoryWrapper.GameRepository.Get(id);
            return new GameViewModel()
            {
                Id = game.Id,
                Title = game.Title,
                Description = game.Description,
                Genre = game.Genre,
                ReleaseDate = game.ReleaseDate,
                CoverImageUrl = game.CoverImageUrl,
                TrailerUrl = game.TrailerUrl,
            };
        }
    }
}
