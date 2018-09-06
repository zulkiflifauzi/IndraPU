using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IndraPU.Models
{
    public class ContactViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Nama")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Alamat")]
        public string Address { get; set; }

        [Required]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DisplayName("Judul")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Isi")]
        public string Content { get; set; }

        [DisplayName("Tanggal")]
        public string CreatedDate { get; set; }

        [DisplayName("Status")]
        public string Status { get; set; }
    }
}