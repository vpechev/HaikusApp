using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client.Main.Models
{
    public class Rating
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public int Value { get; set; }
    }
}