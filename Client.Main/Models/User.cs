using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client.Main.Models
{
    public class User
    {
        private double _actualRating;

        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Username { get; set; }
        public string PublishCode { get; set; }
        //public IList<long> BlockedUserIds { get; set; }
        public IList<Haiku> Haikus { get; set; }
        public long RatingValue { get; set; }
        public long RatersCount { get; set; }
        public double ActualRating { get; set; }
        public bool IsVip { get; set; }
    }
}