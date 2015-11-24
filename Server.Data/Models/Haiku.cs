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
        public long RatingValue { get; set; }
        public long RatersCount { get; set; }
        public double ActualRating 
        {
            get
            {
                if (RatersCount != 0)
                {
                    return computeActualRating();
                }
                return 0;
            }
        }
        public DateTime Date { get; set; }

        public string Username { get; set; }

        private double computeActualRating()
        {
            return (double)RatingValue / RatersCount;
        }
    }
}
