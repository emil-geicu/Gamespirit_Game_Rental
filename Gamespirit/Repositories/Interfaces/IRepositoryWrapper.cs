namespace Gamespirit.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IGameRepository GameRepository { get; }
        IUserRepository UserRepository { get; }
        void Save();
    }
}
