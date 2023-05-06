using Gamespirit.Data.DbModels;
using Gamespirit.Models;

namespace Gamespirit.Services.Interfaces
{
    public interface IGameService
    {
        List<GameViewModel> GetAllGames();
        GameViewModel GetGame(Guid id);
        void CreateGame(GameViewModel game);
        GameViewModel FindGame(Guid id);
        bool GameExistsWithTitle(string title);
        void DeleteGame(Guid id);
        void EditGame(GameViewModel game);
    }
}
