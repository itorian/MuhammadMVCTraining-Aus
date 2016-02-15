using jQueryMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jQueryMVC.Controllers
{
    public class HomeController : Controller
    {
        List<Student> student = new List<Student>();

        public HomeController()
        {
            student.Add(new Student { Id = 1, Name = "Abhimanyu", Address = "New Delhi", Role = "Admin" });
            student.Add(new Student { Id = 2, Name = "Rohan", Address = "Bokaro", Role = "Admin" });
            student.Add(new Student { Id = 3, Name = "Santosh", Address = "Bokaro", Role = "Editor" });
            student.Add(new Student { Id = 4, Name = "Aslam", Address = "New Delhi" });
            student.Add(new Student { Id = 5, Name = "Ramesh", Address = "Gurgaon" });
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Welcome(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                return Json("null", JsonRequestBehavior.AllowGet);
            }

            //var data = student.Where(i => i.Address == input || i.Name == input);
            var data = student.Where(i => i.Address.ToLower().Contains(input) || i.Name.ToLower().Contains(input));

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}