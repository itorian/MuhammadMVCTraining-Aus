using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVCApplication1.Models.ViewModels
{
    public class RegistrationVM
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string Address { get; set; }
    }
}