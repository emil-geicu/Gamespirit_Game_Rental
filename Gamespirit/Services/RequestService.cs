using Gamespirit.Areas.Identity.Data;
using Gamespirit.Data.DbModels;
using Gamespirit.Repositories.Interfaces;
using Gamespirit.Services.Interfaces;

namespace DigitalSchoolWorkspace.Services
{
	public class RequestService : IRequestService
	{
		private IRepositoryWrapper _repositoryWrapper;
		private IUserService _userService;

		public RequestService(IRepositoryWrapper repositoryWrapper, IUserService userService)
		{
			_repositoryWrapper = repositoryWrapper;
			_userService = userService;
		}

		public void AddUserRequest(Guid userId, Guid gameId)
		{
			var request = _repositoryWrapper.RequestRepository.GetRequest(gameId, userId);

			if (request == null)
			{
				_repositoryWrapper.RequestRepository.Create(new PlayerGameRequest() { GamespiritUserId = userId, GameId = gameId });
				_repositoryWrapper.Save();
			}
		}
		public void DeleteRequest(Guid gameId,Guid userId)
		{
			var request = _repositoryWrapper.RequestRepository.GetRequest(gameId,userId);
			if (request != null)
			{
				_repositoryWrapper.RequestRepository.Delete(request);
			}
			_repositoryWrapper.Save();

		}

		public List<PlayerGameRequest> GetAllRequests(GamespiritUser user)
		{
			var requests = _repositoryWrapper.RequestRepository.GetRequestsWithDetails();
			return requests;
		}
	}
}
