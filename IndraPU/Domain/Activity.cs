using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IndraPU.Domain
{

    [Table("Activities")]
    public class Activity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Budget { get; set; }

        [Required]
        public int OPDId { get; set; }

        [ForeignKey("OPDId")]
        public virtual OPD OPD { get; set; }
    }
}