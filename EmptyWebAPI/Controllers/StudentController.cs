using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using EmptyWebAPI.Models;
using System.Web.Http.Routing;
using System.Web;
using EmptyWebAPI.Extension;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;

namespace EmptyWebAPI.Controllers
{
    public class StudentController : ApiController
    {
        private StudentContext db = new StudentContext();

        /// <summary>
        /// Paging, filtering and field level selection
        /// </summary>
        /// <param name="sort"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        // GET: api/Student
        [Route("api/student", Name = "StudentList")]
        public IHttpActionResult GetStudents(string sort = "name", int page = 1, int pageSize = 4, string fields = "id,name,address")
        {
            var data = db.Students.AsQueryable();

            // apply sorting on data
            //data = data.ApplySort(sort);  // do it later

            // alternative way to sort data, try to fix above method to get things done generic
            if (sort == "id")
            {
                data = data.OrderBy(i => i.Id);
            }

            if (sort == "-id")
            {
                data = data.OrderByDescending(i => i.Id);
            }

            if (sort == "name")
            {
                data = data.OrderBy(i => i.Name);
            }

            if (sort == "-name")
            {
                data = data.OrderByDescending(i => i.Name);
            }

            // Limit max page size in response to 3
            if (pageSize > 3)
            {
                pageSize = 3;
            }

            // Calculate totalCount and totalPage may have in database
            var totalCount = data.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            // Generate previous page and next page Urls
            var urlHelper = new UrlHelper(Request);
            var previousPageLink = page > 1 ? urlHelper.Link("StudentList",
                new
                {
                    page = page - 1,
                    pageSize = pageSize,
                    sort = sort
                    // pass other query string vriables if any
                }) : "";
            var nextPageLink = page < totalPages ? urlHelper.Link("StudentList",
                new
                {
                    page = page + 1,
                    pageSize = pageSize,
                    sort = sort
                    // pass other query string vriables if any
                }) : "";

            // Create response header
            var pagingResponseHeader = new
            {
                currentPage = page,
                pageSize = pageSize,
                totalCount = totalCount,
                totalPages = totalPages,
                previousPageLink = previousPageLink,
                nextPageLink = nextPageLink
            };

            // Add paging stuff in HTTP response header
            HttpContext.Current.Response.Headers.Add("Paging", Newtonsoft.Json.JsonConvert.SerializeObject(pagingResponseHeader));

            List<string> lstFields = new List<string>();
            if (fields != null)
            {
                lstFields = fields.ToLower().Split(',').ToList();
            }

            return Ok(data.OrderBy(i=>i.Id).ToList().Select(i => new CreateShappedObjectExtension().CreateShappedObject(i, lstFields)).Skip(pageSize * (page - 1)).Take(pageSize));
        }




        /// <summary>
        /// Get method without field level selection
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        //public IHttpActionResult Get(string sort = "id", int page = 1, int pageSize = 5)
        //{
        //    // Get data
        //    var data = db.AsQueryable();

        //    // Apply sorting
        //    data = data.ApplySort(sort);

        //    // Limit max page size in response to 4
        //    if (pageSize > 4)
        //    {
        //        pageSize = 4;
        //    }

        //    // Calculate totalCount and totalPage may have in database
        //    var totalCount = data.Count();
        //    var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

        //    // Generate previous page and next page Urls
        //    var urlHelper = new UrlHelper(Request);
        //    var previousPageLink = page > 1 ? urlHelper.Link("StudentList",
        //        new
        //        {
        //            page = page - 1,
        //            pageSize = pageSize,
        //            sort = sort
        //            // pass other query string vriables if any
        //        }) : "";
        //    var nextPageLink = page < totalPages ? urlHelper.Link("StudentList",
        //        new
        //        {
        //            page = page + 1,
        //            pageSize = pageSize,
        //            sort = sort
        //            // pass other query string vriables if any
        //        }) : "";

        //    // Create response header
        //    var pagingResponseHeader = new
        //    {
        //        currentPage = page,
        //        pageSize = pageSize,
        //        totalCount = totalCount,
        //        totalPages = totalPages,
        //        previousPageLink = previousPageLink,
        //        nextPageLink = nextPageLink
        //    };

        //    // Add paging stuff in HTTP response header
        //    HttpContext.Current.Response.Headers.Add("Paging", Newtonsoft.Json.JsonConvert.SerializeObject(pagingResponseHeader));

        //    return Ok(data.Skip(pageSize * (page - 1)).Take(pageSize));
        //}

        // GET: api/Student/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult GetStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);  //restful type
        }

        // PUT: api/Student/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.Id)
            {
                return BadRequest();
            }

            db.Entry(student).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Student
        [ResponseType(typeof(Student))]
        public IHttpActionResult PostStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Students.Add(student);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = student.Id }, student);
        }

        // DELETE: api/Student/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            db.Students.Remove(student);
            db.SaveChanges();

            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(int id)
        {
            return db.Students.Count(e => e.Id == id) > 0;
        }
    }
}