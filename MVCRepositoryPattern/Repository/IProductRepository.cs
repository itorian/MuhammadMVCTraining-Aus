using MVCRepositoryPattern.Models;
using System.Collections.Generic;

namespace MVCRepositoryPattern.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product Get(int id);
        Product Add(Product item);
        void Remove(int id);
        bool Update(Product item);
    }
}
