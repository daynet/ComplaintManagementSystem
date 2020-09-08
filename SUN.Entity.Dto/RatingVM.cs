using System;

namespace SUN.Entity.Dto
{

    public class RatingVM
    {
        public int RatingId { get; set; }

        public int? ComplaintId { get; set; }

        public string Ratings { get; set; }
    }
}      
