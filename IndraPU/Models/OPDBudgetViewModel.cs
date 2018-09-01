using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IndraPU.Models
{
    public class OPDBudgetViewModel
    {
        public int Id { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public Decimal Budget { get; set; }
        
        public int OPDId { get; set; }
    }
}