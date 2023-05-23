
using Gamespirit.Data;
using Gamespirit.Data.DbModels;
using Gamespirit.Repositories;
using Gamespirit.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DigitalSchoolWorkspace.Repositories
{
    public class RequestRepository : RepositoryBase<PlayerGameRequest>, IRequestRepository
    {
        public RequestRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public PlayerGameRequest GetRequest(Guid gameId, Guid userId)
        {
            return _dbContext.Requests.FirstOrDefault(x => x.GamespiritUserId.Equals(userId) && x.GameId.Equals(gameId));
        }

        public List<PlayerGameRequest> GetRequestsWithDetails()
        {
            return _dbContext.Requests.Include(x => x.GamespiritUser).Include(x => x.Game).ToList();
        }
    }
}
