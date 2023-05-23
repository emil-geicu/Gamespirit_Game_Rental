using Gamespirit.Data;
using Gamespirit.Data.DbModels;
using Gamespirit.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gamespirit.Repositories
{
    public class RentHistoryRepository : RepositoryBase<RentHistory>, IRentHistoryRepository
    {
        public RentHistoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
		public RentHistory GetRentHistory(Guid gameId, Guid userId)
		{
			return _dbContext.RentHistory.FirstOrDefault(x => x.GamespiritUserId.Equals(userId) && x.GameId.Equals(gameId));
		}

		public List<RentHistory> GetRentHistoryWithDetails()
		{
			return _dbContext.RentHistory.Include(x => x.GamespiritUser).Include(x => x.Game).ToList();
		}
	}
}
