using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Interfaces
{
    public interface IRepository<T>
    {
        string Path { get; }
        IList<T> GetAll();
        void Add(T entity);
        void Update(Guid id, T entity);
        void Delete(T entity);
    }
}
