using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAUlan.Models
{
    public partial class Pizza
    {
        public string name { get; set; }
        public string note { get; set; }
        public bool paid { get; set; }
    }
}