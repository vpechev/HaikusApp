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
        public string Username { get; set; }
        public string PublishCode { get; set; }
        //public IList<long> BlockedUserIds { get; set; }
        public IList<Haiku> Haikus { get; set; }
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
        public bool IsVip { get; set; }


        private double computeActualRating()
        {
            return (double)RatingValue / RatersCount;
        }
    }
}
