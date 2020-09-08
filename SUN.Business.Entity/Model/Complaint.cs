namespace SUN.Business.Entity.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Complaint")]
    public partial class Complaint
    {
        public int ComplaintId { get; set; }

        public string LogedBy { get; set; }

        public int? ComplaintTypeId { get; set; }

        public int? DepartmentId { get; set; }

        [StringLength(500)]
        public string Title { get; set; }

        public string ComplaintDetail { get; set; }

        public DateTime? DateCreated { get; set; }

        public int? StatusId { get; set; }

        public int? PriorityId { get; set; }

        public int? RatingId { get; set; }

        public string ComplaintResponse { get; set; }
    }
}
