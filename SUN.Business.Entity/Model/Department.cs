namespace SUN.Business.Entity.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Department")]
    public partial class Department
    {
        public int DepartmentId { get; set; }

        [StringLength(200)]
        public string DepartmentName { get; set; }

        public string Email { get; set; }
    }
}
