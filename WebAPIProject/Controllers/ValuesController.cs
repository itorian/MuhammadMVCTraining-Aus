using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIProject.Models;

namespace WebAPIProject.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        // Data source
        public List<Student> db = new List<Student>();
        public ValuesController()
        {
            db = new List<Student>
            {
                new Student { Id = 1, Name = "Abhimanyu K Vatsa", City = "Bokaro" },
                new Student { Id = 2, Name = "Deepak Kumar Gupta", City = "Bokaro" },
                new Student { Id = 3, Name = "Manish Kumar", City = "Muzaffarpur" },
                new Student { Id = 4, Name = "Rohit Ranjan", City = "Patna" },
                new Student { Id = 5, Name = "Shiv", City = "Motihari" },
                new Student { Id = 6, Name = "Rajesh Singh", City = "Dhanbad" },
                new Student { Id = 7, Name = "Staya", City = "Bokaro" },
                new Student { Id = 8, Name = "Samiran", City = "Chas" },
                new Student { Id = 9, Name = "Rajnish", City = "Bokaro" },
                new Student { Id = 10, Name = "Mahtab", City = "Dhanbad" }
            };
        }


        // GET api/values
        public IEnumerable<Student> Get()
        {
            //call database

            return db;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromUri]string value)
        {
            //save in database
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
