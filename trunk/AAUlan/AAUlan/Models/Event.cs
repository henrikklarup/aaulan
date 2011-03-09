using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAUlan.Models
{
    public partial class Event
    {

        public int timeTillNextPizza()
        {
            return (int)(this.EndTime - DateTime.Now).TotalSeconds;
        }

    }

}