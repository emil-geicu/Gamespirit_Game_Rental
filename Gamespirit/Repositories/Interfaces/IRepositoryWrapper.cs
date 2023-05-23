namespace Gamespirit.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IGameRepository GameRepository { get; }
        IUserRepository UserRepository { get; }
        IRequestRepository RequestRepository { get; }
        IRentHistoryRepository RentHistoryRepository { get; }
        void Save();
    }
}
