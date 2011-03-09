using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AAUlan.Models
{
    public partial class Mad
    {
        public string x {get; set;}

        [Range(1, 90)]
        public int NUM { get; set; }
    }
}