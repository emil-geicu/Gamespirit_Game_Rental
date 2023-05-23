namespace Gamespirit.Services.Interfaces
{
	public interface IRentHistoryService
	{
		void AssignGameToUser(Guid projectId, Guid userId);
		void DeleteRent(Guid gameId, Guid userId);

	}
}
