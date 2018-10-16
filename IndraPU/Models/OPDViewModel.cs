using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IndraPU.Models
{
    public class OPDViewModel
    {
        public int Id { get; set; }

        [DisplayName("Induk")]
        public int? ParentId { get; set; }

        [Required]
        [DisplayName("Nama")]
        public string Title { get; set; }

        public decimal ThisYearBudget { get; set; }

        [Required]
        [DisplayName("PIC")]
        public string PIC { get; set; }

        [Required]
        [DisplayName("Nomor Telepon")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [DisplayName("Bentuk")]
        public string Form { get; set; }

        [DisplayName("Struktur")]
        [AllowHtml]
        public string Structure { get; set; }

        [Required]
        [DisplayName("Anggaran (Rp.)")]
        public decimal Budget { get; set; }

        public List<ActivityViewModel> Activities { get; set; }

        public List<OPDBudgetViewModel> OPDBudgets { get; set; }
    }
}