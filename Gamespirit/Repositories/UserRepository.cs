using Gamespirit.Areas.Identity.Data;
using Gamespirit.Data;
using Gamespirit.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gamespirit.Repositories
{
	public class UserRepository : RepositoryBase<GamespiritUser>, IUserRepository
	{
		public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}

        public GamespiritUser GetUserWithDetails(Guid id)
        {
            return _dbContext.Users.Where(x => x.Id.Equals(id)).Include(x => x.RentHistory).ThenInclude(x => x.Game).FirstOrDefault();
        }
    }
}
