using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndraPU.Models
{
    public class NodeViewModel
    {
        public string text { get; set; }

        public string href { get; set; }

        public List<NodeViewModel> nodes { get; set; }
    }
}