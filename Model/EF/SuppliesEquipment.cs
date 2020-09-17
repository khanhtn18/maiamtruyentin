namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SuppliesEquipment")]
    public partial class SuppliesEquipment
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public int? Number { get; set; }

        public int? BrokenNumber { get; set; }

        [StringLength(50)]
        public string Manager { get; set; }

        public string UsageHistory { get; set; }

        public string Description { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(500)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(500)]
        public string ModifiedBy { get; set; }

        public bool Status { get; set; }
    }
}
