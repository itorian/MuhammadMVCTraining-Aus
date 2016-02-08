using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVCApplication1.Models;

namespace WebMVCApplication1.Controllers
{
    public class FriendController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Friend - Address
        public ActionResult Index()
        {
            var friend = db.Friends.Include("Address");
            return View(friend);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Friend friend)
        {
            friend.Address = null;
            db.Friends.Add(friend);
            db.SaveChanges();
            return RedirectToAction("CreateAddress", new { id = friend.Id });
        }

        public ActionResult CreateAddress(int Id)
        {
            var friend = db.Friends.Find(Id);
            ViewBag.Friend = friend;

            var addreses = db.Addresses.Where(i => i.FriendId == Id).ToList();
            ViewBag.Addresses = addreses;

            Address address = new Address();
            address.FriendId = Id;

            return View(address);
        }

        [HttpPost]
        public ActionResult CreateAddress(Address address)
        {
            db.Addresses.Add(address);
            db.SaveChanges();
            return View("Index");
        }
    }
}