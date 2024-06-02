using System;
using System.Web.Security;
using System.Web;

namespace ECommerceSystem.Models
{
    public class User
    {
        public int User_ID { get; set; }

        public string Fullname { get; set; }

        public string User_Type { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int Contact_No { get; set; }

        public string Gender { get; set; }

        public string Home_No { get; set; }

        public string Street { get; set; }

        public string Barangay { get; set; }

        public string City { get; set; }

        public string Municipality { get; set; }

        public string Region { get; set; }

        public string Country { get; set; }

        public int Zipcode { get; set; }

    }
}