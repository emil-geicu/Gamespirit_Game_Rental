using Gamespirit.Data;
using Gamespirit.Data.DbModels;
using Gamespirit.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gamespirit.Repositories
{
    public class GameRepository : RepositoryBase<Game>, IGameRepository
    {
        public GameRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public Game FindByTitle(string title)
        {
           return _dbContext.Games.FirstOrDefault(g => g.Title == title);
        }
    }
}
