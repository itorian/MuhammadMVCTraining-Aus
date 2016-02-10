using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmptyWebAPI.Controllers
{
    public class HomeController : ApiController
    {
        List<Student> student = new List<Student>();
        
        public HomeController()
        {
            student.Add(new Student { Id = 1, Name = "Abhimanyu", Address = "New Delhi" });
            student.Add(new Student { Id = 2, Name = "Rohan", Address = "Bokaro" });
            student.Add(new Student { Id = 3, Name = "Santosh", Address = "Jamshedpur" });
            student.Add(new Student { Id = 4, Name = "Aslam", Address = "Australia" });
            student.Add(new Student { Id = 5, Name = "Ramesh", Address = "Gurgaon" });
        }

        // GET: api/Home
        public IEnumerable<Student> Get()
        {
            return student;
        }

        // GET: api/Home/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Home
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Home/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Home/5
        public void Delete(int id)
        {

        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
