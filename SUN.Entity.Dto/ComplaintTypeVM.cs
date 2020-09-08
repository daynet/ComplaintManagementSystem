using System;

namespace SUN.Entity.Dto
{

    public class ComplaintTypeVM
    {
        public int complaintTypeId { get; set; }

        public int? departmentId { get; set; }

        public string complaintName { get; set; }

        public string departmentName { get; set; }
    }
}      
