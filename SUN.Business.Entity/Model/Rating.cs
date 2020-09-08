namespace SUN.Business.Entity.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rating")]
    public partial class Rating
    {
        public int RatingId { get; set; }

        [Column("Rating")]
        [StringLength(50)]
        public string Rating1 { get; set; }
    }
}
