using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVCApplication1.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Address> Address { get; set; }
    }

    public class Address
    {
        public int Id { get; set; }
        public int FriendId { get; set; }
        public string FullAddress { get; set; }
    }
}