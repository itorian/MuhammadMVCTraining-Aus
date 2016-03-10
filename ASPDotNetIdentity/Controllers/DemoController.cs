using ASPDotNetIdentity.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPDotNetIdentity.Controllers
{
    public class DemoController : Controller
    {
        public ActionResult Index()
        {
            throw new Exception();
            return View();
        }

        public ActionResult Test()
        {
            var addresses = new List<Address>() {
                new Address { Id = 1, FirstLine = "Palam Vihar", City = "Gurgaon", State = "Haryana", Country = "India" },
                new Address { Id = 2, FirstLine = "Palam Vihar Ext", City = "Gurgoan", State = "Haryana", Country = "India" },
            };

            var item = new CheckBoxModel() {
                Id = 1,
                Email = 
                "abhimanyu@knorish.com",
                Subscribe = true,
                Address = addresses
            };

            return View(item);
        }

        [HttpPost]
        public ActionResult Test(CheckBoxModel model)
        {
            

            return View();
        }

    }

    public class CheckBoxModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool Subscribe { get; set; }
        public List<Address> Address { get; set; }
    }

    public class Address
    {
        public int Id { get; set; }
        public string FirstLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}