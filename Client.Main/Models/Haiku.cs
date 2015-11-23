using System;

namespace Client.Main.Models
{
    public class Haiku
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Text { get; set; }
        public long UserId { get; set; }
        //public IList<Rating> Ratings { get; set; }
        public long RatingValue { get; set; }
        public long RatersCount { get; set; }
        public double ActualRating { get; set; }
        
        public DateTime Date { get; set; }

        public int Rating { get; set; }

        public string PublishCode { get; set; }
    }
}
