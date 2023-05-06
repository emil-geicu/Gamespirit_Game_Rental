namespace Gamespirit.Repositories.Interfaces
{
    public interface IRepositoryBase<T>
    {
        T Get(Guid id);
        IEnumerable<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
