using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebMVCApplication1.CustomAttributes;

namespace WebMVCApplication1.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [ExcludeCharsVal("@.#$%&^")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        public List<Marks> Marks { get; set; }
    }

    public class Marks
    {
        public int Id { get; set; }
        public int StudentId { get; set; }

        [ExcludeCharsVal("!.")]
        public string Subject { get; set; }
        public int Mark { get; set; }
    }
}