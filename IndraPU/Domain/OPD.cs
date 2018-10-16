using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IndraPU.Domain
{
    [Table("OPD")]
    public class OPD
    {
        [Key]
        public int Id { get; set; }

        public int? ParentId { get; set; }

        [Required]
        public string PIC { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Form { get; set; }

        public string Structure { get; set; }
        
        private ICollection<int> _activityIds;
        [NotMapped]
        public ICollection<int> ActivityIds
        {
            get { return _activityIds ?? (_activityIds = Activities.Select(s => s.Id).ToList()); }
            set { _activityIds = value; }
        }

        private ICollection<Activity> _activities;
        public virtual ICollection<Activity> Activities
        {
            get { return _activities ?? (_activities = new Collection<Activity>()); }
            set { _activities = value; }
        }

        private ICollection<int> _opdBudgetIds;
        [NotMapped]
        public ICollection<int> OPDBudgetIds
        {
            get { return _opdBudgetIds ?? (_opdBudgetIds = OPDBudgets.Select(s => s.Id).ToList()); }
            set { _opdBudgetIds = value; }
        }

        private ICollection<OPDBudget> _opdBudgets;
        public virtual ICollection<OPDBudget> OPDBudgets
        {
            get { return _opdBudgets ?? (_opdBudgets = new Collection<OPDBudget>()); }
            set { _opdBudgets = value; }
        }

    }
}