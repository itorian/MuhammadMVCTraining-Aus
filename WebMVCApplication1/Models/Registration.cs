using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVCApplication1.Models
{
    // database model
    public class Registration
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
    }
}