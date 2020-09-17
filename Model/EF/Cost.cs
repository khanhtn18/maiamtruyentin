namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cost")]
    public partial class Cost
    {
        [StringLength(50)]
        public string ID { get; set; }

        [StringLength(50)]
        public string CategoryID { get; set; }

        public decimal? UnitCost { get; set; }

        public int? Number { get; set; }

        public decimal? TotalAmount { get; set; }

        public string Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(500)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(500)]
        public string ModifiedBy { get; set; }

        public bool? Status { get; set; }
    }
}
