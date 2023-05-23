using Gamespirit.Data.DbModels;
using Gamespirit.Repositories.Interfaces;
using Gamespirit.Services.Interfaces;

namespace DigitalSchoolWorkspace.Services
{
    public class RentHistoryService : IRentHistoryService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public RentHistoryService(IRepositoryWrapper repositoryWrapper, IUserService userService)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public void AssignGameToUser(Guid gameId, Guid userId)
        {
            _repositoryWrapper.RentHistoryRepository.Create(new RentHistory() { GameId = gameId, GamespiritUserId = userId });
            var requestToDelete = _repositoryWrapper.RequestRepository.GetRequest(gameId, userId);
            _repositoryWrapper.RequestRepository.Delete(requestToDelete);
            _repositoryWrapper.Save();
        }
		public void DeleteRent(Guid gameId, Guid userId)
		{
			var rent = _repositoryWrapper.RentHistoryRepository.GetRentHistory(gameId, userId);
			if (rent != null)
			{
				_repositoryWrapper.RentHistoryRepository.Delete(rent);
			}
			_repositoryWrapper.Save();

		}
	}
}
