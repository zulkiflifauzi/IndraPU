using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IndraPU.Models
{
    public class ActivityViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Nama")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Tanggal")]
        public string Date { get; set; }

        [Required]
        [DisplayName("Deskripsi")]
        [AllowHtml]
        public string Description { get; set; }

        [Required]
        [DisplayName("Anggaran")]
        public decimal Budget { get; set; }

        public int OPDId { get; set; }
    }
}