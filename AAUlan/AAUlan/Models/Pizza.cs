using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAUlan.Models
{
    public partial class Pizza
    {
        public string Name { get; set; }
        public string Note { get; set; }
        public bool Paid 
        { 
            get
        {
        } set; }
    }
}