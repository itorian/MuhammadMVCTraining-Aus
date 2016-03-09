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
    }
}