using Gamespirit.Data.DbModels;

namespace Gamespirit.Repositories.Interfaces
{
	public interface IRequestRepository : IRepositoryBase<PlayerGameRequest>
	{
        PlayerGameRequest GetRequest(Guid gameId, Guid userId);
        List<PlayerGameRequest> GetRequestsWithDetails();
	}
}
