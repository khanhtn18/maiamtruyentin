namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Visitor")]
    public partial class Visitor
    {
        public int ID { get; set; }

        [StringLength(11)]
        public string IdentityCard { get; set; }

        [StringLength(250)]
        public string VisitReason { get; set; }

        [StringLength(11)]
        public string Phone { get; set; }

        [StringLength(25)]
        public string Email { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(500)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(500)]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        public string Status { get; set; }
    }
}
