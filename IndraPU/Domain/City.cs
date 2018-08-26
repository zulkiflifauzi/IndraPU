using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IndraPU.Domain
{
    [Table("Cities")]
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AreaCode { get; set; }

        [Required]
        public string Title { get; set; }

        public long? Latitude { get; set; }

        public long? Longitude { get; set; }

        [Required]
        public int StateId { get; set; }

        [ForeignKey("StateId")]
        public virtual State State { get; set; }
    }
}