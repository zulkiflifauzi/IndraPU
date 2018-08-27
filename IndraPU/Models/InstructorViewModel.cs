using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IndraPU.Models
{
    public class InstructorViewModel
    {
        public int Id { get; set; }

        [Required]
        public int StateId { get; set; }

        [Display(Name = "Provinsi")]
        public string StateName { get; set; }

        [Required]
        public int CityId { get; set; }

        [Display(Name = "Kabupaten/Kota")]
        public string CityName { get; set; }

        [Required]
        [Display(Name = "Nama")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Bidang")]
        public string Area { get; set; }

        [Required]
        [Display(Name = "Nomor Telepon")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Tempat Lahir")]
        public string PlaceOfBirth { get; set; }

        [Required]
        [Display(Name = "Tanggal Lahir")]
        public string DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Alamat")]
        public string Address { get; set; }
    }
}