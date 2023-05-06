using Gamespirit.Data.DbModels;

namespace Gamespirit.Repositories.Interfaces
{
    public interface IGameRepository : IRepositoryBase<Game>
    {
        Game FindByTitle(string title);
    }
}
