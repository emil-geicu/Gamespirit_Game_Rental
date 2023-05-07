using Gamespirit.Areas.Identity.Data;

namespace Gamespirit.Repositories.Interfaces
{
	public interface IUserRepository : IRepositoryBase<GamespiritUser>
	{
        GamespiritUser GetUserWithDetails(Guid id);

    }
}
