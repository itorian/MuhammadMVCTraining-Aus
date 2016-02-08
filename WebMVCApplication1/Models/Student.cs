using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVCApplication1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Marks> Marks { get; set; }
    }

    public class Marks
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Subject { get; set; }
        public int Mark { get; set; }
    }
}