using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCAsync.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // 1. Use CPU at the max - run many method same time without waiting for completion. Use only in long running method calls or maybe that method make use of third party libs
        // 2. Run background task - run task in background and alert on completion

        public async Task<ActionResult> SaveApplication()
        {
            // long running method call 1 - async work
            // long running method call 2 - async work
            // long running method call 3 - async work
            // process returned result
            // return response

            await GetTemprature();
            await GetPolutionLevel();
            await GetUserInfor(12342);

            string result = await GetUserProfilePic(342434);

            return View();
        }

        private Task<string> GetUserProfilePic(int v)
        {
            throw new NotImplementedException();
        }

        private Task GetUserInfor(int v)
        {
            throw new NotImplementedException();
        }

        private Task GetPolutionLevel()
        {
            throw new NotImplementedException();
        }

        private Task GetTemprature()
        {
            throw new NotImplementedException();
        }
    }
}