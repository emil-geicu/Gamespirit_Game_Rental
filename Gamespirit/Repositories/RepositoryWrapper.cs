using DigitalSchoolWorkspace.Repositories;
using Gamespirit.Data;
using Gamespirit.Repositories.Interfaces;

namespace Gamespirit.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext _dbContext;
        private IGameRepository? _gameRepository;
        private IUserRepository? _userRepository;
        private IRequestRepository? _requestRepository;
        private IRentHistoryRepository? _rentHistoryRepository;


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
        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_dbContext);
                }

                return _userRepository;
            }
        }

        public IRentHistoryRepository RentHistoryRepository
        {
            get
            {
                if (_rentHistoryRepository == null)
                {
                    _rentHistoryRepository = new RentHistoryRepository(_dbContext);
                }

                return _rentHistoryRepository;
            }
        }

        public IRequestRepository RequestRepository
        {
            get
            {
                if (_requestRepository == null)
                {
                    _requestRepository = new RequestRepository(_dbContext);
                }

                return _requestRepository;

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
