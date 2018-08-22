using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace IndraPU.Models
{
    public class AddressViewModel
    {
        public int Id { get; set; }

        [DisplayName("Jalan")]
        public string Street { get; set; }

        [DisplayName("Nomor")]
        public int Number { get; set; }

        [DisplayName("Penghuni")]
        public int? OwnerId { get; set; }

        [DisplayName("Penghuni")]
        public string OwnerName { get; set; }
    }
}