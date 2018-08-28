using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IndraPU.Domain
{
    [Table("Programs")]
    public class Program
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string EmploymentDept { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Method { get; set; }

        [Required]
        public string SourceOfFunds { get; set; }

        [Required]
        public int Budget { get; set; }

        [Required]
        public int StateId { get; set; }

        [ForeignKey("StateId")]
        public virtual State State { get; set; }

        [Required]
        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Participants { get; set; }
    }
}