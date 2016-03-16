using MVCRepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MVCRepositoryPattern.GenericRepository
{
    //public class ProductRepository : IProductRepository
    public class ProductRepository<T> : IProductRepository<T> where T : class
    {
        private DatabaseContext db = new DatabaseContext();

        public IEnumerable<T> GetAll()
        {
            return db.Set<T>();
        }

        public T Get(int id)
        {
            return db.Set<T>().Find(id);
        }        

        public T Add(T item)
        {
            db.Set<T>().Add(item);
            db.SaveChanges();
            return item;
        }

        public void Remove(int id)
        {
            var record = db.Set<T>().Find(id);
            T item = db.Set<T>().Remove(record);
            db.SaveChanges();
        }

        public bool Update(T item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
    }
}
