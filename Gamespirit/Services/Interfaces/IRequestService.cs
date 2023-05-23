using Gamespirit.Areas.Identity.Data;
using Gamespirit.Data.DbModels;

namespace Gamespirit.Services.Interfaces
{
	public interface IRequestService
	{
		void AddUserRequest(Guid userId, Guid projectId);
		void DeleteRequest(Guid id, Guid id1);
		List<PlayerGameRequest> GetAllRequests(GamespiritUser user);
	}
}
