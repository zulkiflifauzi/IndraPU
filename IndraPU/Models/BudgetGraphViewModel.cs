using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndraPU.Models
{
    public class BudgetGraphViewModel
    {
        public string StateId { get; set; }

        public string StateName { get; set; }

        public int TotalParticipants { get; set; }

        public int TotalActivities { get; set;}
    }
}