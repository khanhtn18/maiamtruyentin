namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SchoolReport")]
    public partial class SchoolReport
    {
        [Key]
        [StringLength(50)]
        public string ChildrenID { get; set; }

        [StringLength(500)]
        public string SchoolYear { get; set; }

        [StringLength(250)]
        public string SchoolName { get; set; }

        [StringLength(500)]
        public string TeacherName { get; set; }

        [StringLength(50)]
        public string Semester1 { get; set; }

        [StringLength(50)]
        public string Semester2 { get; set; }

        [StringLength(50)]
        public string FullYear { get; set; }

        [StringLength(250)]
        public string Rating { get; set; }

        [StringLength(250)]
        public string TeacherEvaluation { get; set; }

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
