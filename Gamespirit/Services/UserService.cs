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
        public void DeleteUser(Guid id)
        {
            var user = _repositoryWrapper.UserRepository.Get(id);
            if (user != null)
            {
                _repositoryWrapper.UserRepository.Delete(user);
            }
            _repositoryWrapper.Save();

        }

        public void EditUser(GamespiritUser user)
        {
            var currentUser = _repositoryWrapper.UserRepository.Get(user.Id);

            currentUser.UserName=user.UserName;
            currentUser.Email = user.Email;
            currentUser.JoinDate = user.JoinDate;
            currentUser.StatusDescription=user.StatusDescription;
            _repositoryWrapper.UserRepository.Update(user);
            _repositoryWrapper.Save();
        }
    }
}
