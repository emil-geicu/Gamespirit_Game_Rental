using Gamespirit.Data.DbModels;
using Gamespirit.Repositories.Interfaces;
using Gamespirit.Services.Interfaces;

namespace Gamespirit.Services
{
    public class GameService : IGameService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public GameService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

    }
}
