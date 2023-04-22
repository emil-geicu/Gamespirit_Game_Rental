﻿namespace Gamespirit.Repositories.Interfaces
{
    public interface IRepositoryBase<T>
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
