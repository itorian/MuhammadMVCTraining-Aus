using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVCApplication1.Models;
using WebMVCApplication1.Models.ViewModels;

namespace WebMVCApplication1.Controllers
{
    public class RegisterController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Register
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RegistrationVM model)
        {
            // validate model here

            var dbModel = new Registration{
                Address = model.Address,
                Username = model.Username,
                Password = model.Password
            };

            db.Registration.Add(dbModel);
            db.SaveChanges();

            return View(model);
        }
    }
}