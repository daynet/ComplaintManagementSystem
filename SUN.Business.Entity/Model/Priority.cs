namespace SUN.Business.Entity.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Priority")]
    public partial class Priority
    {
        public int PriorityId { get; set; }

        [StringLength(50)]
        public string PriorityName { get; set; }
    }
}
