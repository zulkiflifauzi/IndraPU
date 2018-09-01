using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IndraPU.Domain
{
    [Table("OPDBudget")]
    public class OPDBudget
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public Decimal Budget { get; set; }

        [Required]
        public int OPDId { get; set; }

        [ForeignKey("OPDId")]
        public virtual OPD OPD { get; set; }
    }
}