namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XFamilyBook")]
    public partial class XFamilyBook
    {
        [StringLength(50)]
        public string ID { get; set; }

        [StringLength(50)]
        public string ChildrenID { get; set; }

        [StringLength(50)]
        public string BaptismalName { get; set; }

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
