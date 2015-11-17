using Server.Data.Models.BaseClasses;
using Server.Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Models
{
    public class Complaint : Identifiable
    {
        public long HaikuId { get; set; }
        public DateTime Date { get; set; }

    }
}
