using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndraPU.Models
{
    public class DikbudViewModel
    {
        public List<DikbudChildViewModel> data { get; set; }

    }

    public class DikbudChildViewModel
    {
        public string kode_wilayah { get; set; }

        public string nama { get; set; }

        public string mst_kode_wilayah { get; set; }
    }
}