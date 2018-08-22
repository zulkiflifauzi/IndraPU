using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace IndraPU.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Current Address")]
        public string CurrentAddress { get; set; }

        [DisplayName("Role")]
        public string Role { get; set; }
    }
}