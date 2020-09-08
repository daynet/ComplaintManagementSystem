using System;

namespace SUN.Entity.Dto
{

    public class ComplaintVM
    {
        public int complaintId { get; set; }

        public string logedBy { get; set; }

        public int? complaintTypeId { get; set; }

        public int? departmentId { get; set; }

        public string complaintDetail { get; set; }

        public string priority { get; set; }

        public string status { get; set; }

        public DateTime? dateCreated { get; set; }

        public int? statusId { get; set; }

        public int? priorityId { get; set; }
        public string departmentName { get; set; }
        public string complaintType { get; set; }
        public string title { get; set; }
        public string rating { get; set; }
        public int? ratingId { get; set; }

        public string ComplaintResponse { get; set; }
    }
}      
