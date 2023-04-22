using Gamespirit.Data;
using Gamespirit.Data.DbModels;
using Gamespirit.Repositories.Interfaces;

namespace Gamespirit.Repositories
{
    public class GameRepository : RepositoryBase<Game>, IGameRepository
    {
        public GameRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
