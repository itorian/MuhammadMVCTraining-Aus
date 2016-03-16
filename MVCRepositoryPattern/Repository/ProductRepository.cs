using MVCRepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MVCRepositoryPattern.Repository
{
    public class ProductRepository : IProductRepository
    {
        private DatabaseContext db = new DatabaseContext();

        public IEnumerable<Product> GetAll()
        {
            return db.Products;
        }

        public Product Get(int id)
        {
            return db.Products.FirstOrDefault((p) => p.Id == id);
        }        

        public Product Add(Product item)
        {
            db.Products.Add(item);
            db.SaveChanges();
            return item;
        }

        public void Remove(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public bool Update(Product item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
    }
}
