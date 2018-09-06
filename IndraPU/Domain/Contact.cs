using IndraPU.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IndraPU.Domain
{
    [Table("Contacts")]
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
        
        public DateTime? RepliedDate { get; set; }

        public string Reply { get; set; }
        
        public int? ReplyUserId { get; set; }

        [ForeignKey("ReplyUserId")]
        public virtual ApplicationUser ReplyUser { get; set; }

    }
}