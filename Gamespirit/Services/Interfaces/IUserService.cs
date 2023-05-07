using Gamespirit.Areas.Identity.Data;

namespace Gamespirit.Services.Interfaces
{
	public interface IUserService
	{
		List<GamespiritUser> GetAllUsers();
		GamespiritUser GetUser(Guid id);
	}
}
