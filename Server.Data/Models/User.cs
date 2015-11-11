using Server.Data.Models.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Models
{
    public class User : Identifiable
    {
        private long _actualRating;

        public string Username { get; set; }
        public string PublishCode { get; set; }
        //public IList<long> BlockedUserIds { get; set; }
        public IList<Haiku> Haikus { get; set; }
        public long RatingValue { get; set; }
        public long RatersCount { get; set; }
        public long ActualRating
        {
            get
            {
                if (RatersCount != 0)
                {
                    return RatingValue / RatersCount;
                }
                return 0;
            }
            set { this._actualRating = value; }             
        }
    }
}
