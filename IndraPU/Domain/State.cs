using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IndraPU.Domain
{
    [Table("States")]
    public class State
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AreaCode { get; set; }

        [Required]
        public string Title { get; set; }
        
        public double? Latitude { get; set; } 

        public double? Longitude { get; set; }

        private ICollection<int> _cityIds;
        [NotMapped]
        public ICollection<int> CityIds
        {
            get { return _cityIds ?? (_cityIds = Cities.Select(s => s.Id).ToList()); }
            set { _cityIds = value; }
        }

        private ICollection<City> _cities;
        public virtual ICollection<City> Cities
        {
            get { return _cities ?? (_cities = new Collection<City>()); }
            set { _cities = value; }
        }

        private ICollection<int> _instructorIds;
        [NotMapped]
        public ICollection<int> InstructorIds
        {
            get { return _instructorIds ?? (_instructorIds = Instructors.Select(s => s.Id).ToList()); }
            set { _instructorIds = value; }
        }

        private ICollection<Instructor> _instructors;
        public virtual ICollection<Instructor> Instructors
        {
            get { return _instructors ?? (_instructors = new Collection<Instructor>()); }
            set { _instructors = value; }
        }

        private ICollection<int> _programIds;
        [NotMapped]
        public ICollection<int> ProgramIds
        {
            get { return _programIds ?? (_programIds = Programs.Select(s => s.Id).ToList()); }
            set { _programIds = value; }
        }

        private ICollection<Program> _programs;
        public virtual ICollection<Program> Programs
        {
            get { return _programs ?? (_programs = new Collection<Program>()); }
            set { _programs = value; }
        }
    }
}