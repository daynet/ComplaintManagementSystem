namespace SUN.Business.Entity.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ComplaintResponse")]
    public partial class ComplaintResponse
    {
        public int ComplaintResponseId { get; set; }

        public int? ComplaintId { get; set; }

        public string Response { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? DateCreated { get; set; }
    }
}
