using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IndraPU.Models
{
    public class ReplyViewModel : ContactViewModel
    {
        [Required]
        [DisplayName("Jawab")]
        public string Reply { get; set; }

        [DisplayName("Tanggal Jawab")]
        public string ReplyDate { get; set; }

        [DisplayName("Penjawab")]
        public string ReplyUser { get; set; }
    }
}