namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        public int ID { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(250)]
        public string Morning { get; set; }

        [StringLength(250)]
        public string BeforeNoon { get; set; }

        [StringLength(250)]
        public string Noon { get; set; }

        [StringLength(250)]
        public string LateAfterNoon { get; set; }

        [StringLength(250)]
        public string Evening { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

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
