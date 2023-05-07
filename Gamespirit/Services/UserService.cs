using Gamespirit.Areas.Identity.Data;
using Gamespirit.Models;
using Gamespirit.Repositories.Interfaces;
using Gamespirit.Services.Interfaces;

namespace Gamespirit.Services
{
	public class UserService : IUserService
	{
		private IRepositoryWrapper _repositoryWrapper;

		public UserService(IRepositoryWrapper repositoryWrapper)
		{
			_repositoryWrapper = repositoryWrapper;
		}
		public List<GamespiritUser> GetAllUsers()
		{
			var users= _repositoryWrapper.UserRepository.GetAll().ToList();
			foreach(var user in users)
			{
				user.JoinDate= DateTime.Now;
			}
			return users;
		}

        public GamespiritUser GetUser(Guid id)
        {
			return _repositoryWrapper.UserRepository.GetUserWithDetails(id);
        }
    }
}
