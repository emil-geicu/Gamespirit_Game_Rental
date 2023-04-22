using Gamespirit.Data;
using Gamespirit.Repositories.Interfaces;

namespace Gamespirit.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext _dbContext;
        private IGameRepository? _gameRepository;

        public IGameRepository GameRepository
        {
            get
            {
                if (_gameRepository == null)
                {
                    _gameRepository = new GameRepository(_dbContext);
                }

                return _gameRepository;
            }
        }

        public RepositoryWrapper(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
