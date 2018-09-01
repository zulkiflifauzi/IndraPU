using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndraPU.Models
{
    public class MapViewModel
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int InstructorCount { get; set; }
    }
}