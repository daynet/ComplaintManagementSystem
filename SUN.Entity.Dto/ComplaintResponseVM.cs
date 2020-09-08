using System;

namespace SUN.Entity.Dto
{

    public class ComplaintResponseVM
    {
        public int ComplaintResponseId { get; set; }

        public int? ComplaintId { get; set; }

        public string Response { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? DateCreated { get; set; }
    }
}      
