using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client.Main.Models
{
    public class Complaint
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public long HaikuId { get; set; }
        public DateTime Date { get; set; }
    }
}