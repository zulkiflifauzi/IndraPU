using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IndraPU.Models
{
    public class CityViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nama")]
        public string Title { get; set; }

        public int StateId { get; set; }
    }
}