using Gamespirit.Data.DbModels;

namespace Gamespirit.Repositories.Interfaces
{
	public interface IRentHistoryRepository : IRepositoryBase<RentHistory>
	{
		RentHistory GetRentHistory(Guid gameId, Guid userId);
		List<RentHistory> GetRentHistoryWithDetails();
	}
}
