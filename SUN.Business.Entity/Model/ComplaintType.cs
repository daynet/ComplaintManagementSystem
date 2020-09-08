namespace SUN.Business.Entity.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ComplaintType")]
    public partial class ComplaintType
    {
        public int ComplaintTypeId { get; set; }

        public int? DepartmentId { get; set; }

        [StringLength(200)]
        public string ComplaintName { get; set; }
    }
}
