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
        private long _actualRating;

        public string Text { get; set; }
        public long UserId { get; set; }
        public IList<Rating> Ratings { get; set; }
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
            set { this._actualRating = value;  }
        }
        public DateTime PublishDate { get; set; }
    }
}
