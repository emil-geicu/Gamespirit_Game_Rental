namespace Gamespirit.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IGameRepository GameRepository { get; }

        void Save();
    }
}
