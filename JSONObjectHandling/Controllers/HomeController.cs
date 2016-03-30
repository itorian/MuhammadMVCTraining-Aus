using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace JSONObjectHandling.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string test)
        {

            // todo: insert in database

            return View();
        }

        public string SomeOtherMethod(string json)
        {
            List<Admission> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Admission>>(json); // JSON.parse
            Debug.WriteLine(list);
            string reJson = Newtonsoft.Json.JsonConvert.SerializeObject(list); // JSON.stringify
            Debug.WriteLine(reJson);
            return "true";
        }
    }

    public class Admission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }
}