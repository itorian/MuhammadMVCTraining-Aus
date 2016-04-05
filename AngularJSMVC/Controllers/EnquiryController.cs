using AngularJSMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularJSMVC.Controllers
{
    public class EnquiryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateEnquiry(Enquiry enquiry)
        {
            db.Enquiry.Add(enquiry);
            db.SaveChanges();

            return Json(true);
        }

        [HttpGet]
        public JsonResult GetEnquiries()
        {
            var enquiries = db.Enquiry.ToList();
            return Json(enquiries, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetEnquiry(int id)
        {
            var enquiry = db.Enquiry.Find(id);

            return Json(enquiry, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateEnquiry(Enquiry _enquiry)
        {
            Enquiry enquiry = db.Enquiry.Find(_enquiry.Id);
            enquiry.Name = _enquiry.Name;
            enquiry.Email = _enquiry.Email;
            enquiry.Contact = _enquiry.Contact;
            enquiry.Details = _enquiry.Details;
            db.Entry(enquiry).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return Json(true);
        }

        [HttpPost]
        public JsonResult DeleteEnquiry(int Id)
        {
            try
            {
                Enquiry ItemToDelete = db.Enquiry.Find(Id);
                db.Entry(ItemToDelete).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }


    }
}