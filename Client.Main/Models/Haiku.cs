using System;

namespace Client.Main.Models
{
    public class Haiku
    {
        private long _actualRating;

        public long Id { get; set; }
        public bool IsDeleted { get; set; }

        public string Text { get; set; }
        public long UserId { get; set; }
        //public IList<Rating> Ratings { get; set; }
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
        public DateTime Date { get; set; }

        public int Rating { get; set; }
    }
}
