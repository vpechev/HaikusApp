using Server.Data.Models.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Models
{
    public class Haiku : Identifiable
    {
        public string Text { get; set; }
        public long UserId { get; set; }
        public IList<Rating> Ratings { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
