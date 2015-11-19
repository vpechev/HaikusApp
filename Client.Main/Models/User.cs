using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client.Main.Models
{
    public class User
    {
        private long _actualRating;

        public long Id { get; set; }
        public bool IsDeleted { get; set; }
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
        public bool IsVip { get; set; }
    }
}