namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChildrenCategory")]
    public partial class ChildrenCategory
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã hoàn cảnh trẻ")]
        public int ID { get; set; }

        [StringLength(250)]
        [DisplayName("Tên hoàn cảnh")]
        public string Name { get; set; }

        [StringLength(250)]
        [DisplayName("Tiêu đề")]
        public string MetaTitle { get; set; }

        [StringLength(250)]
        [DisplayName("Tiều đề trình duyệt")]
        public string SeoTitle { get; set; }

        [StringLength(250)]
        [DisplayName("Mô tả ngắn")]
        public string MetaDescriptions { get; set; }

        [DisplayName("Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(500)]
        [DisplayName("Người tạo")]
        public string CreatedBy { get; set; }

        [DisplayName("Ngày cập nhật")]
        public DateTime? ModifiedDate { get; set; }

        [StringLength(500)]
        [DisplayName("Người cập nhật")]
        public string ModifiedBy { get; set; }

        [DisplayName("Trạng thái")]
        public bool Status { get; set; }
    }
}
