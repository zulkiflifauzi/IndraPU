using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IndraPU.Models
{
    public class ProgramViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Nama")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Jabatan Kerja")]
        public string EmploymentDept { get; set; }

        [Required]
        [DisplayName("Jenis Kegiatan")]
        public string Type { get; set; }

        [Required]
        [DisplayName("Metode Pelaksana")]
        public string Method { get; set; }

        [Required]
        [DisplayName("Sumber Dana")]
        public string SourceOfFunds { get; set; }

        [Required]
        [DisplayName("Pagu")]
        public int Budget { get; set; }

        [Required]
        public int StateId { get; set; }

        [Display(Name = "Provinsi")]
        public string StateName { get; set; }

        [Required]
        public int CityId { get; set; }

        [Display(Name = "Kabupaten/Kota")]
        public string CityName { get; set; }

        [Required]
        [DisplayName("Tempat")]
        public string Address { get; set; }

        [Required]
        [DisplayName("Jadwal Pelaksanaan")]
        public string Date { get; set; }

        [Required]
        [DisplayName("Jumlah Peserta")]
        public int Participants { get; set; }
    }
}