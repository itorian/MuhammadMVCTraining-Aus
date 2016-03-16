using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MVCRepositoryPattern.GenericRepository
{
    public interface IProductRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Add(T item);
        void Remove(int id);
        bool Update(T item);
    }
}
