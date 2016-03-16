using System.Web.Mvc;
using MVCRepositoryPattern.Models;
using MVCRepositoryPattern.GenericRepository;
using System.Data.Entity;
using System.Collections.Generic;
using MVCRepositoryPattern.Repository;

namespace MVCRepositoryPattern.Controllers
{
    public class ProductController : Controller
    {
        //private ProductRepository repository = new ProductRepository();
        private ProductRepository<Product> repository = new ProductRepository<Product>();

        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        public ActionResult Details(int id)
        {
            Product product = repository.Get(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                repository.Add(product);
                
                return RedirectToAction("Index");
            }

            return View(product);
        }

        public ActionResult Edit(int id)
        {
            Product product = repository.Get(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                repository.Update(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Delete(int id)
        {
            Product product = repository.Get(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repository.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
