using Server.Data.Models.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Models
{
    public class Rating : Identifiable
    {
        public int Value { get; set; }
    }
}
