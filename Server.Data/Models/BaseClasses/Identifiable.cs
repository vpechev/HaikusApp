using Server.Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Models.BaseClasses
{
    public class Identifiable : IIdentifiable
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
